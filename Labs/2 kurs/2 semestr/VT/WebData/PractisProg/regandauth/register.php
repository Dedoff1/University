<?php
global $conn;
require_once ('db.php');
$login = $_POST['login'];
$pass = $_POST['pass'];
$repeatpass = $_POST['repeatpass'];
$email = $_POST['email'];
if (empty($login) || empty($pass) || empty($repeatpass) || empty($email)) {
    header("Location: index.php?error=Заполните все поля");
} else {
    if ($pass != $repeatpass) {
        header("Location: index.php?error=Пароли не совпадают");
    } else {
        $sql = "INSERT INTO users (login, pass, email) VALUES ('$login', '$pass', '$email')";
        if ($conn->query($sql) === TRUE) {
            echo "Успешная регистрация";
        }
        else {
            echo "Error: " . $sql . "<br>" . $conn->error;
        }
    }
}

