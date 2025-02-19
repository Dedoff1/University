package service

import (
	"fmt"
	"io"
	"log"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

func addFileHandler(w http.ResponseWriter, r *http.Request) {
	file, handler, err := r.FormFile("file")
	if err != nil {
		log.Println(err)
		http.Error(w, "Create file error", http.StatusBadRequest)
		return
	}
	defer file.Close()

	filename, ok := mux.Vars(r)["file"]
	if !ok {
		log.Println(err)
		http.Error(w, "Invalid file name", http.StatusBadRequest)
		return
	}

	resFilename := CurGlobalPath + filename

	addedFile, err := os.OpenFile(resFilename, os.O_APPEND|os.O_WRONLY, 0644)
	if err != nil {
		log.Println(err)
		http.Error(w, "Open file error", http.StatusBadRequest)
		return
	}
	defer addedFile.Close()

	_, err = io.Copy(addedFile, file)
	if err != nil {
		log.Println(err)
		http.Error(w, "Copy file error", http.StatusBadRequest)
		return
	}

	fmt.Fprintf(w, "File %s added successfully", handler.Filename)
}
