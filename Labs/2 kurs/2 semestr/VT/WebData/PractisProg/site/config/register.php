<?php
global $conn;
//global $logname;
require_once ('db.php');
$login = $_POST['login'];
$pass = $_POST['pass'];
$repeatpass = $_POST['repeatpass'];
$email = $_POST['email'];


session_start();

unset($_SESSION['page_visits']);
unset($_SESSION['link_clicks']);


$_SESSION['page_visits'] = array();


//if (session_status() == !PHP_SESSION_NONE) {session_destroy();}
if (empty($login) || empty($pass) || empty($repeatpass) || empty($email)) {
    header("Location: index.php?error=Заполните все поля");
} else {
    if ($pass != $repeatpass) {
        header("Location: index.php?error=Пароли не совпадают");
    } else {
        $sql = "SELECT * FROM users WHERE login = '$login'";
        $result = $conn->query($sql);
        if ($result->num_rows > 0) {
            // Пользователь с таким же логином уже существует
            header("Location: index.php?error=Пользователь с таким логином уже существует");
        } else {
            $sql = "INSERT INTO users (login, pass, email) VALUES ('$login', '$pass', '$email')";
            if ($conn->query($sql) === TRUE) {
                $user_id = $conn->insert_id;

                // Выполните запрос, чтобы получить логин пользователя по его идентификатору
                $sql = "SELECT login FROM users WHERE id = $user_id";
                $result = $conn->query($sql);
                // Получите логин пользователя из результата запроса
                $login = $result->fetch_assoc()['login'];

                // Установите логин пользователя в сессию
                $_SESSION['login'] = $login;

                //$_SESSION['login'] = $logname;
                header("Location: http://192.168.175.1:90/site/Main.php");
                //echo "Успешная регистрация";
            } else {
                echo "Error: " . $sql . "<br>" . $conn->error;
            }
        }
    }
}
