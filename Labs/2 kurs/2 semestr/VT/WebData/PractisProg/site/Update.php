<?php



global $connects3;
require_once 'config/connect.php';



$result_id = $_GET['id'];



$result = mysqli_query($connects3, "SELECT * FROM gameresults WHERE Номер = '$result_id'");


$result = mysqli_fetch_assoc($result);
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Update Result</title>
</head>
<body>
<h3>Update Result</h3>
<form action="vendor/update.php" method="post">
    <input type="hidden" name="номер" value="<?= $result['номер'] ?>">
    <p>Result</p>
    <input type="text" name="результат" value="<?= $result['результат'] ?>">
    <p>Time</p>
    <input type="number" name="время" value="<?= $result['время'] ?>"> <br> <br>
    <p>Type</p>
    <input type="text" name="режим" value="<?= $result['режим'] ?>">

    <button type="submit">Изменить</button>
</form>
</body>
</html>

