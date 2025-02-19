<?php

$connects = mysqli_connect('localhost', 'root', '4MyL1nux', 'chess');

if (!$connects) {
    die('Error connect to database!');
}
$connects2 = mysqli_connect('localhost', 'root', '4MyL1nux', 'chessvariants');
if (!$connects2) {
    die('Error connect to database!');
}
$connects3 = mysqli_connect('localhost', 'root', '4MyL1nux', 'gameresults');
if (!$connects3) {
    die('Error connect to database!');
}
