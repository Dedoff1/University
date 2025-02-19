package service

import (
	"log"
	"net/http"
	"os"

	"github.com/gorilla/mux"
)

func deleteFileHandler(w http.ResponseWriter, r *http.Request) {
	filename, ok := mux.Vars(r)["file"]
	if !ok {
		http.Error(w, "Invalid file name", http.StatusBadRequest)
		return
	}

	resFilename := CurGlobalPath + filename

	if err := os.Remove(resFilename); err != nil {
		log.Println(err)
		http.Error(w, "Delete file error", http.StatusBadRequest)
		return
	}
}
