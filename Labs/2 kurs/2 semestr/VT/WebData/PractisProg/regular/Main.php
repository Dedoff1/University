<?php
global $connect;
require_once 'config/connect.php';
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Регулярные выражения</title>
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
        <th>Выражение</th>
    </tr>

    <?php



    $results = mysqli_query($connect, "SELECT * FROM `regularvariables`");



    $results = mysqli_fetch_all($results);



    foreach ($results as $result) {
        ?>
        <tr>
            <td><?= $result[0] ?></td>
            <td><?= $result[1] ?></td>
            <td><a style="color: red;" href="vendor/delete.php?id=<?= $result[0] ?>">Удалить</a>
        </tr>
        <?php
    }
    ?>
</table>
<h1>Добавить выражение</h1>
<form action = "vendor/create.php" method = "post">
    <p>Выражение</p>
    <input type="text" name="выражение">
     <br> <br>
    <button type="submit">Добавить новое выражение</button>
</form>
</body>
</html>