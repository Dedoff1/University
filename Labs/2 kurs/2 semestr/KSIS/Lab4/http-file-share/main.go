package main

import (
	"http-file-share/service"
	"net/http"

	"github.com/gorilla/mux"
)

func main() {
	r := mux.NewRouter()
	service.AddHandlers(r)

	http.Handle("/", r)
	http.ListenAndServe(":8080", nil)
}

// Get {file}
// PUT {file} rewrite
// POST {file} add
// DELETE {file} delete
