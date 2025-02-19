package main

import (
	"bufio"
	"bytes"
	"encoding/json"
	"fmt"
	"io"
	"io/ioutil"
	"mime/multipart"
	"net/http"
	"os"
	"path/filepath"
	"strconv"
	"strings"
)

type PathData struct {
	NewPath string `json:"new_path"`
}

var baseUrl = "http://localhost:8080"

func main() {
	reader := bufio.NewReader(os.Stdin)

	//fmt.Println("Введите URL сервера:")
	//baseUrl, _ = reader.ReadString('\n')
	//baseUrl = baseUrl[:len(baseUrl)-1]

	for {
		fmt.Printf(
			`
		1 - Create file
		2 - Append file
		3 - Get file
		4 - Delete file
		5 - Copy file
		6 - Move file
`,
		)
		fmt.Println("Введите число от 1 до 6 для вызова соответствующей функции или 7 для выхода:")

		input, _ := reader.ReadString('\n')
		input = input[:len(input)-1]

		choice, err := strconv.Atoi(input)
		if err != nil {
			fmt.Println("Неверный ввод. Пожалуйста, введите число от 1 до 7.")
			continue
		}

		switch choice {
		case 1:
			Create()
		case 2:
			Append()
		case 3:
			Get()
		case 4:
			Delete()
		case 5:
			Copy()
		case 6:
			Move()
		case 7:
			fmt.Println("Программа завершена.")
			return
		default:
			fmt.Println("Неверный ввод. Пожалуйста, введите число от 1 до 7.")
		}
	}
}

func Create() {
	reader := bufio.NewReader(os.Stdin)

	fmt.Println("Введите путь к файлу у вас:")
	filePath, _ := reader.ReadString('\n')
	filePath = filePath[:len(filePath)-1]

	file, err := os.Open(filePath)
	if err != nil {
		fmt.Println("Ошибка открытия файла:", err)
		return
	}
	defer file.Close()

	body := &bytes.Buffer{}
	writer := multipart.NewWriter(body)
	part, err := writer.CreateFormFile("file", filepath.Base(filePath))
	if err != nil {
		fmt.Println("Ошибка создания формы файла:", err)
		return
	}

	_, err = io.Copy(part, file)
	if err != nil {
		fmt.Println("Ошибка копирования файла в форму:", err)
		return
	}

	writer.Close()

	req, err := http.NewRequest("PUT", baseUrl+"/file", body)
	if err != nil {
		fmt.Println("Ошибка создания HTTP-запроса:", err)
		return
	}

	req.Header.Set("Content-Type", writer.FormDataContentType())

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		fmt.Println("Ошибка отправки HTTP-запроса:", err)
		return
	}
	defer resp.Body.Close()

	fmt.Println("Файл успешно отправлен.")
}

func Append() {
	reader := bufio.NewReader(os.Stdin)

	fmt.Println("Введите путь к файлу у вас:")
	filePath, _ := reader.ReadString('\n')
	filePath = filePath[:len(filePath)-1]

	fmt.Println("Введите путь к файлу на сервере:")
	filePathServer, _ := reader.ReadString('\n')
	filePathServer = filePathServer[:len(filePathServer)-1]

	file, err := os.Open(filePath)
	if err != nil {
		fmt.Println("Ошибка открытия файла:", err)
		return
	}
	defer file.Close()

	body := &bytes.Buffer{}
	writer := multipart.NewWriter(body)
	part, err := writer.CreateFormFile("file", filepath.Base(filePath))
	if err != nil {
		fmt.Println("Ошибка создания формы файла:", err)
		return
	}

	_, err = io.Copy(part, file)
	if err != nil {
		fmt.Println("Ошибка копирования файла в форму:", err)
		return
	}

	writer.Close()

	req, err := http.NewRequest("POST", baseUrl+"/file/"+filePathServer, body)
	if err != nil {
		fmt.Println("Ошибка создания HTTP-запроса:", err)
		return
	}

	req.Header.Set("Content-Type", writer.FormDataContentType())

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		fmt.Println("Ошибка отправки HTTP-запроса:", err)
		return
	}
	defer resp.Body.Close()

	fmt.Println("Файл успешно отправлен.")
}

func Get() {
	reader := bufio.NewReader(os.Stdin)

	fmt.Println("Введите путь к файлу на сервере:")
	filePath, _ := reader.ReadString('\n')
	filePath = filePath[:len(filePath)-1]

	resp, err := http.Get(baseUrl + "/file/" + filePath)
	if err != nil {
		fmt.Println("Ошибка при выполнении GET-запроса:", err)
		return
	}
	defer resp.Body.Close()

	if resp.StatusCode != http.StatusOK {
		fmt.Println("Ошибка: неверный статус ответа", resp.Status)
		return
	}

	response, _ := ioutil.ReadAll(resp.Body)
	parts := strings.Split(string(response), "\n")
	var fileName string

	// Поиск строки с именем файла
	for _, part := range parts {
		if strings.Contains(part, "filename=") {
			fileName = strings.Trim(strings.Split(part, "filename=")[1], `"`)

			break
		}
	}

	file, err := os.Create(fileName[:len(fileName)-2])
	if err != nil {
		fmt.Println("Ошибка создания файла для записи:", err)
		return
	}
	defer file.Close()

	substring := "Content-Type: application/octet-stream"
	indexStart := strings.Index(string(response), substring)
	var indexEnd, indexEndEnd int

	if indexStart != -1 {
		indexEnd = indexStart + len(substring)
		fmt.Println("Индекс конца подстроки:", indexEnd)
	} else {
		fmt.Println("Подстрока не найдена в строке")
	}

	isFind := false
	for i := indexEnd; !isFind; i++ {
		if response[i] == '-' {
			indexEndEnd = i
			isFind = true
		}
	}

	_, err = io.Copy(file, bytes.NewBuffer(response[indexEnd+4:indexEndEnd]))
	if err != nil {
		fmt.Println("Ошибка при сохранении файла:", err)
		return
	}

	fmt.Println("Файл успешно сохранен")
}

func Delete() {
	reader := bufio.NewReader(os.Stdin)

	fmt.Println("Введите путь к файлу, который нужно удалить:")
	sourceFile, _ := reader.ReadString('\n')
	sourceFile = sourceFile[:len(sourceFile)-1]

	req, err := http.NewRequest("DELETE", baseUrl+"/file/"+sourceFile, nil)
	if err != nil {
		fmt.Println(err)
		return
	}

	req.Header.Set("Content-Type", "application/json")

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		fmt.Println(err)
		return
	}
	defer resp.Body.Close()

	if resp.StatusCode != http.StatusOK {
		fmt.Println(fmt.Errorf("не удалось выполнить PUT-запрос. Код ответа: %d", resp.StatusCode))
		return
	}

	fmt.Println("запрос выполнен успешно.")
}

// tmp/new.txt -> ..
func Copy() {
	reader := bufio.NewReader(os.Stdin)

	fmt.Println("Введите путь к файлу на сервере, который нужно скопировать:")
	sourceFile, _ := reader.ReadString('\n')
	sourceFile = sourceFile[:len(sourceFile)-1]

	fmt.Println("Введите путь, куда нужно переместить файл:")
	destinationFile, _ := reader.ReadString('\n')
	destinationFile = destinationFile[:len(destinationFile)-1]

	data, err := json.Marshal(PathData{NewPath: destinationFile})
	if err != nil {
		fmt.Println(err)
		return
	}

	req, err := http.NewRequest("POST", baseUrl+"/file/copy/"+sourceFile, bytes.NewBuffer(data))
	if err != nil {
		fmt.Println(err)
		return
	}

	req.Header.Set("Content-Type", "application/json")

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		fmt.Println(err)
		return
	}
	defer resp.Body.Close()

	if resp.StatusCode != http.StatusOK {
		fmt.Println(fmt.Errorf("не удалось выполнить запрос. Код ответа: %d", resp.StatusCode))
		return
	}

	fmt.Println("запрос выполнен успешно.")
}

// tmp/new.txt -> ..
func Move() {
	reader := bufio.NewReader(os.Stdin)

	fmt.Println("Введите путь к файлу, который нужно переместить:")
	sourceFile, _ := reader.ReadString('\n')
	sourceFile = sourceFile[:len(sourceFile)-1]

	fmt.Println("Введите путь, куда нужно переместить файл:")
	destinationFile, _ := reader.ReadString('\n')
	destinationFile = destinationFile[:len(destinationFile)-1]

	data, err := json.Marshal(PathData{NewPath: destinationFile})
	if err != nil {
		fmt.Println(err)
		return
	}

	req, err := http.NewRequest("PUT", baseUrl+"/file/move/"+sourceFile, bytes.NewBuffer(data))
	if err != nil {
		fmt.Println(err)
		return
	}

	req.Header.Set("Content-Type", "application/json")

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		fmt.Println(err)
		return
	}
	defer resp.Body.Close()

	if resp.StatusCode != http.StatusOK {
		fmt.Println(fmt.Errorf("не удалось выполнить PUT-запрос. Код ответа: %d", resp.StatusCode))
		return
	}

	fmt.Println("PUT-запрос выполнен успешно.")
}
