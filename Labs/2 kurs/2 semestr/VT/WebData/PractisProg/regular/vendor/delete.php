<?php
global $connect;
require_once '../config/connect.php';



$id = $_GET['id'];



mysqli_query($connect,  "DELETE FROM regularvariables WHERE `regularvariables`.`Номер` =$id");

header('Location:  http://192.168.175.1:90/regular/Main.php');