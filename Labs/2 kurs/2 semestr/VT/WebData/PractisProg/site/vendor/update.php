<?php



global $connects3;
require_once '../config/connect.php';



$id = $_POST['id'];
$result = $_POST['результат'];
$time = $_POST['время'];
$type = $_POST['режим'];


mysqli_query($connects3, "UPDATE `gameresults` SET 'Номер' = NULL, `Результат` = $result, `Время` = '$time', `Режим` = '$type' WHERE `gameresults`.`Номер` = $id");



header('Location:  http://192.168.175.1:90/site/ResultsOfGames.php');
