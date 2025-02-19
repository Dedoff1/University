package service

import (
	"fmt"
	"io"
	"log"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

// var UserDir = "/http-file-share/client"
// var Clientpath = "/h"
func createFileHandler(w http.ResponseWriter, r *http.Request) {
	username, ok := mux.Vars(r)["username"]
	if !ok {
		log.Println("username not found")
		http.Error(w, "Invalid username", http.StatusBadRequest)
		return
	}

	//clientpath := "/http-file-share/client";
	file, handler, err := r.FormFile("file")
	if err != nil {
		log.Println(err)
		http.Error(w, "Create file error", http.StatusBadRequest)
		return
	}

	defer file.Close()

	fmt.Println(CurGlobalPath + "/" + username + "/" + handler.Filename)

	f, err := os.Create(CurGlobalPath + "/" + username + "/" + handler.Filename)
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
