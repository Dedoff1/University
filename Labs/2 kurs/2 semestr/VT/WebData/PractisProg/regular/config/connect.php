<?php
$connect = mysqli_connect('localhost', 'root', '4MyL1nux', 'regular');

if (!$connect) {
    die('Error connect to database!');
}