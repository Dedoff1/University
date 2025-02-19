<?php



global $connects3;
require_once '../config/connect.php';

$right = True;

$result = $_POST['результат'];
$time = $_POST['время'];
$type = $_POST['режим'];


if ($type == 'Рапид') {
    if ($time >= 10)
        $right = False;
}
else
    if ($type == 'Блиц') {
        if ($time >= 70)
            $right = False;
    }
if ($right)
mysqli_query($connects3,"INSERT INTO `gameresults`(`Номер`, `Результат`, `Время`, `Режим`) VALUES (NULL, '$result', '$time', '$type')");



header('Location: http://192.168.175.1:90/site/ResultsOfGames.php');