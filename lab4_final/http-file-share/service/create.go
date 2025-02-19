package service

import (
	"fmt"
	"io"
	"log"
	"net/http"
	"os"
	//"http-file-share/client/main"
)

// var UserDir = "/http-file-share/client"
// var Clientpath = "/h"
func createFileHandler(w http.ResponseWriter, r *http.Request) {
	//clientpath := "/http-file-share/client";
	file, handler, err := r.FormFile("file")
	if err != nil {
		log.Println(err)
		http.Error(w, "Create file error", http.StatusBadRequest)
		return
	}

	defer file.Close()

	fmt.Println(CurGlobalPath + handler.Filename)

	f, err := os.Create(CurGlobalPath + handler.Filename)
	if err != nil {
		log.Println(err)
		http.Error(w, "Error creating file on server", http.StatusInternalServerError)
		return
	}
	defer f.Close()

	_, err = io.Copy(f, file)
	if err != nil {
		log.Println(err)
		http.Error(w, "Error saving file to server", http.StatusInternalServerError)
		return
	}

	fmt.Fprintf(w, "File %s uploaded successfully", handler.Filename)
}
