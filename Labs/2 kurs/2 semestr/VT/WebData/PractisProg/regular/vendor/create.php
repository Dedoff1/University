<?php
global $connect;
require_once '../config/connect.php';

$result = $_POST['выражение'];
$tempstring = $result;
$result = '';
$temp = '';
$i = 0;

while ($i < strlen($tempstring)) {
    while ($tempstring[$i] !== ' ' && $i < strlen($tempstring)) {
        $temp .= $tempstring[$i];
        $i++;
    }

    if (is_numeric($temp[0])) {
        $result .= "<span style='color: red;'>$temp</span>"; // Обернули цифры в тег <span> с красным цветом
    } else {
        $result .= $temp;
    }

    $temp = '';
    $i++;
}

mysqli_query($connect, "INSERT INTO regularvariables(Номер, Выражение) VALUES (NULL, '$result')");

header('Location: http://192.168.175.1:90/regular/Main.php');
