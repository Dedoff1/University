<?php
global $conn;
global $logname;
require_once ("db.php");

$login = $_POST['login'];
$pass = $_POST['pass'];

// Начните сессию
session_start();


unset($_SESSION['page_visits']);
unset($_SESSION['link_clicks']);

$_SESSION['page_visits'] = array();


//if (session_status() == !PHP_SESSION_NONE) {session_destroy();}
if(empty($login) || empty($pass)){
    header("Location: index.php?error=Заполните все поля");
} else {
    $sql = "SELECT * FROM users WHERE login='$login' AND pass='$pass'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        while($row = $result->fetch_assoc()) {
            $_SESSION['login'] = $login;
            header("Location: http://192.168.175.1:90/site/Main.php");
            //echo "Добро пожаловать ".$row["login"]."<br>";
        }
    } else {
        header("Location: index.php?error=Неверный логин или пароль");
    }
}
