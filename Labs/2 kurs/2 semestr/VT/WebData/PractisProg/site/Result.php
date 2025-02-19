<?php



global $connects3;
require_once 'config/connect.php';



$result_id = $_GET['id'];



$result = mysqli_query($connects3, "SELECT * FROM `gameresults` WHERE `id` = '$result_id'");



$result = mysqli_fetch_assoc($result);



$comments = mysqli_query($connects3, "SELECT * FROM `comments` WHERE `result_id` = '$result_id'");



$comments = mysqli_fetch_all($comments);
?>

<!doctype html>
<html lang="en">
<head>
    <title>Product</title>
</head>
<body>
<h2>Результат: <?= $result['result'] ?></h2>
<h4>Price: <?= $result['time'] ?></h4>
<h4>Type: <?= $result['type'] ?></h4>
<p>Description: <?= $result['description'] ?></p>

<hr>

<h3>Add comment</h3>
<form action="vendor/create_comment.php" method="post">
    <input type="hidden" name="номер" value="<?= $result['номер'] ?>">
    <textarea name="body"></textarea> <br><br>
    <button type="submit">Add comment</button>
</form>

<hr>

<h3>Comments</h3>
<ul>
    <?php



    foreach ($comments as $comment) {
        ?>
        <li><?= $comment[2] ?></li>
        <?php
    }
    ?>
</ul>
</body>
</html>
