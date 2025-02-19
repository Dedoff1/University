package service

import (
	"encoding/json"
	"fmt"
	"io"
	"log"
	"net/http"
	"os"
	"strings"

	"github.com/gorilla/mux"
)

func moveFileHandler(w http.ResponseWriter, r *http.Request) {
	filename_from, ok := mux.Vars(r)["file_from"]
	if !ok {
		http.Error(w, "Invalid file name", http.StatusBadRequest)
		return
	}

	path := &PathData{}
	if err := json.NewDecoder(r.Body).Decode(path); err != nil {
		log.Println(err)
		http.Error(w, "json decode err", http.StatusBadRequest)
		return
	}

	res_filename_from := CurGlobalPath + filename_from
	tmp := strings.Split(res_filename_from, "/")
	tmpPath := strings.Trim(path.NewPath, "/")

	res_filename_in := CurGlobalPath + tmpPath + "/" + tmp[len(tmp)-1]

	fmt.Println(res_filename_from, res_filename_in)
	// Открываем исходный файл для чтения
	fromFile, err := os.Open(res_filename_from)
	if err != nil {
		log.Println(err)
		http.Error(w, "Error opening source file", http.StatusBadRequest)
		return
	}
	defer fromFile.Close()

	// Создаем целевой файл для записи
	inFile, err := os.Create(res_filename_in)
	if err != nil {
		log.Println(err)
		http.Error(w, "Error creating target file", http.StatusBadRequest)
		return
	}
	defer inFile.Close()

	// Копируем содержимое исходного файла в целевой файл
	_, err = io.Copy(inFile, fromFile)
	if err != nil {
		log.Println(err)
		http.Error(w, "Error copying file", http.StatusBadRequest)
		return
	}

	if err := os.Remove(res_filename_from); err != nil {
		log.Println(err)
		http.Error(w, "Delete file error", http.StatusBadRequest)
		return
	}

	fmt.Fprintf(w, "File %s copied to %s successfully", filename_from, res_filename_in)
}
