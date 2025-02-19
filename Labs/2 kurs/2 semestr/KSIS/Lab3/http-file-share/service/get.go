package service

import (
	"bytes"
	"io"
	"log"
	"mime/multipart"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

func getFileHandler(w http.ResponseWriter, r *http.Request) {
	filename, ok := mux.Vars(r)["file"]
	if !ok {
		http.Error(w, "Invalid file name", http.StatusBadRequest)
		return
	}

	resFilename := CurGlobalPath + filename

	file, err := os.Open(resFilename)
	if err != nil {
		log.Println(err)
		http.Error(w, "Open file error", http.StatusBadRequest)
		return
	}
	defer file.Close()

	body := &bytes.Buffer{}
	writer := multipart.NewWriter(body)

	part, err := writer.CreateFormFile("file", filename)
	if err != nil {
		panic(err)
	}
	io.Copy(part, file)
	writer.Close()

	w.Write(body.Bytes())
}
