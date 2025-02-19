package service

import "github.com/gorilla/mux"

var CurGlobalPath = "./storage/users"

func AddHandlers(r *mux.Router) {
	r.HandleFunc("/file/{file}", getFileHandler).Methods("GET")
	r.HandleFunc("/file/{file}", deleteFileHandler).Methods("DELETE")
	r.HandleFunc("/file/{file}", addFileHandler).Methods("POST")
	r.HandleFunc("/file/{username}", createFileHandler).Methods("PUT")

	r.HandleFunc("/file/copy/{file_from}", copyFileHandler).Methods("POST")
	r.HandleFunc("/file/move/{file_from}", moveFileHandler).Methods("PUT")
}
