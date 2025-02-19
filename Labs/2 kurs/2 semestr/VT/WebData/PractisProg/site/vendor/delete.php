<?php





global $connects3;
require_once '../config/connect.php';



$id = $_GET['id'];



mysqli_query($connects3,  "DELETE FROM gameresults WHERE `gameresults`.`Номер` =$id");



header('Location:  http://192.168.175.1:90/site/ResultsOfGames.php');
