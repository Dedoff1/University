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

// var userDir = "/http-file-share/client"
type PathData struct {
	NewPath string `json:"new_path"`
}

var baseUrl = "http://localhost:8080"
var Clientpath = "/http-file-share/client"
var UserDir = "/http-file-share/client"

func main() {
	reader := bufio.NewReader(os.Stdin)
	//clientpath := "/http-file-share/client";
	//clientpath := "/http-file-share/storage/users";
	//fmt.Println("Введите URL сервера:")
	//baseUrl, _ = reader.ReadString('\n')
	//baseUrl = baseUrl[:len(baseUrl)-1]

	for {
		// Get user input for action (authorization or registration)
		fmt.Println("Do you want to register or authorize? (r/a)")
		action, err := reader.ReadString('\n')
		if err != nil {
			fmt.Println("Ошибка ввода")
			continue
		}
		action = strings.TrimSpace(action)

		// Handle user action
		switch action {
		case "r":
			// Registration
			fmt.Println("Enter a username:")
			username, err := reader.ReadString('\n')
			if err != nil {
				fmt.Println("Ошибка ввода")
				continue
			}
			username = strings.TrimSpace(username)

			// Check if user already exists
			UserDir := filepath.Join("../storage/users", username)
			if _, err := os.Stat(UserDir); err == nil {
				fmt.Println("User already exists")
				continue
			}

			// Create user directory
			err = os.MkdirAll(UserDir, 0755)
			if err != nil {
				fmt.Println("Ошибка установки новой директории")
				continue
			}

			// Set default working directory to user directory
			err = os.Chdir(UserDir)
			if err != nil {
				fmt.Println("Ошибка установки новой директории")
				continue
			}

			// Создание файла password.txt
			//passwordFile := filepath.Join(userDir, "password.txt")
			f, err := os.Create("password.txt") //passwordFile)
			if err != nil {
				fmt.Println("Ошибка создания файла с паролем")
				continue
			}
			defer f.Close()

			fmt.Println("Enter a password:")
			password, err := reader.ReadString('\n')
			if err != nil {
				fmt.Println("Ошибка ввода")
				continue
			}
			password = strings.TrimSpace(password)

			// Сохранение пароля в виде обычного текста
			_, err = f.WriteString(password)
			if err != nil {
				fmt.Println("Ошибка сохранения пароля")
				continue
			}

		case "a":
			// Authorization
			fmt.Println("Enter your username:")
			username, err := reader.ReadString('\n')
			if err != nil {
				fmt.Println("Ошибка ввода")
				continue
			}
			username = strings.TrimSpace(username)

			// Check if user exists
			UserDir := filepath.Join("../storage/users", username)
			if _, err := os.Stat(UserDir); err != nil {
				fmt.Println("User does not exist")
				continue
			}

			// Read password from file
			passwordFile := filepath.Join(UserDir, "password.txt")
			f, err := os.Open(passwordFile)
			if err != nil {
				fmt.Println("Ошибка чтения пароля")
				continue
			}
			defer f.Close()

			var storedPassword string
			_, err = fmt.Fscanf(f, "%s", &storedPassword)
			if err != nil {
				fmt.Println("Ошибка чтения пароля")
				continue
			}

			fmt.Println("Enter your password:")
			password, err := reader.ReadString('\n')
			if err != nil {
				fmt.Println("Ошибка ввода")
				continue
			}
			password = strings.TrimSpace(password)

			// Check if password matches
			if password != storedPassword {
				fmt.Println("Invalid login or password")
				continue
			}

			// Set default working directory to user directory
			err = os.Chdir(UserDir)
			if err != nil {
				fmt.Println("Ошибка установки новой директории")
				continue
			}

		default:
			fmt.Println("Invalid action")
			continue
		}

		fmt.Println("Success!")
		break
	}

	for {
		fmt.Printf(
			`
		1 - Сreate file
		2 - Append file
		3 - Get file
		4 - Delete file
		5 - Copy file
		6 - Move file
`,
		)
		fmt.Println("Введите число от 1 до 6 для вызова соответствующей функции или 7 для выхода:")

		input, _ := reader.ReadString('\n')
		input = input[:len(input)-2]

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
	filePath = filePath[:len(filePath)-2]

	file, err := os.Open(Clientpath + filePath)
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

	req, err := http.NewRequest("PUT", UserDir, body)
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
	filePath = filePath[:len(filePath)-2]

	fmt.Println("Введите путь к файлу на сервере:")
	filePathServer, _ := reader.ReadString('\n')
	filePathServer = filePathServer[:len(filePathServer)-2]

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
	filePath = filePath[:len(filePath)-2]

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
	sourceFile = sourceFile[:len(sourceFile)-2]

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
	sourceFile = sourceFile[:len(sourceFile)-2]

	fmt.Println("Введите путь, куда нужно переместить файл:")
	destinationFile, _ := reader.ReadString('\n')
	destinationFile = destinationFile[:len(destinationFile)-2]

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
	sourceFile = sourceFile[:len(sourceFile)-2]

	fmt.Println("Введите путь, куда нужно переместить файл:")
	destinationFile, _ := reader.ReadString('\n')
	destinationFile = destinationFile[:len(destinationFile)-2]

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
