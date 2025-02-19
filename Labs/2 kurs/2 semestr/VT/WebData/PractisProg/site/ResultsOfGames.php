<?php
global $connects3;
require_once 'config/connect.php';


session_start();


if (!isset($_SESSION['page_visits'])) {
    $_SESSION['page_visits'] = array();
}


$current_page = basename($_SERVER['PHP_SELF']);

if (isset($_SESSION['page_visits'][$current_page])) {
    $_SESSION['page_visits'][$current_page]++;
} else {
    $_SESSION['page_visits'][$current_page] = 1;
}


$total_visits = array_sum($_SESSION['page_visits']);


?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Результаты игр</title>
</head>
<style>
    th, td {
        padding: 10px;
    }

    th {
        background: #606060;
        color: #fff;
    }

    td {
        background: #b5b5b5;
    }
    body {
        background: burlywood;
    }
</style>
<body>
<table>
    <tr>
        <th>Номер</th>
        <th>Результат</th>
        <th>Время</th>
        <th>Режим</th>
    </tr>

    <?php



    $results = mysqli_query($connects3, "SELECT * FROM `gameresults`");



    $results = mysqli_fetch_all($results);



    foreach ($results as $result) {
        ?>
        <tr>
            <td><?= $result[0] ?></td>
            <td><?= $result[1] ?></td>
            <td><?= $result[2] ?></td>
            <td><?= $result[3] ?></td>
            <td><a href="vendor/update.php?id=<?= $result[0] ?>">Изменить</a></td>
            <td><a style="color: red;" href="vendor/delete.php?id=<?= $result[0] ?>">Удалить</a>
        </tr>
        <?php
    }
    ?>
</table>
<h1>Добавить партию</h1>
<form action = "vendor/create.php" method = "post">
    <p>Результат</p>
    <input type="text" name="результат">
    <p>Время</p>
    <input type="number" name="время">
    <p>Режим</p>
    <input type="text" name="режим"> <br> <br>
    <button type="submit">Добавить новую партию</button>
</form>
<a href="/site/Main.php">На главную</a>
</body>
</html>
