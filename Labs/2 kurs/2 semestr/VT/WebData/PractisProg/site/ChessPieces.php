<?php
global $connects;
global $Maincount;
global $Figurescount;
global $lang;

session_start();

if (isset($_GET['lang'])) {
    $_SESSION['lang'] = $_GET['lang'];
}
if (!isset($_SESSION['lang'])) {
    $_SESSION['lang'] = 'en'; 
}
if (!isset($_SESSION['page_visits'])) {
    $_SESSION['page_visits'] = array();
}
if ($_SESSION['lang'] == 'en') {
    $translations = parse_ini_file('translations_en.ini');
} elseif ($_SESSION['lang'] == 'ru') {
    $translations = parse_ini_file('translations_ru.ini');
}

$current_page = basename($_SERVER['PHP_SELF']);

if (isset($_SESSION['page_visits'][$current_page])) {
    $_SESSION['page_visits'][$current_page]++;
} else {
    $_SESSION['page_visits'][$current_page] = 1;
}


$total_visits = array_sum($_SESSION['page_visits']);


require_once 'config/connect.php';
?>

<!doctype html>
<html lang="<?php echo $_SESSION['lang']; ?>">
<head>
    <meta charset="UTF-8">
    <title><?php echo $translations['PIECES'] ?></title>
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
<form method="get" action="">
        <button type="submit" name="lang" value="en">English</button>
        <button type="submit" name="lang" value="ru">Русский</button>
    </form>
<table>
    <tr>
        <th><?php echo $translations['NAME'] ?></th>
        <th><?php echo $translations['MOVEMENT'] ?></th>
        <th><?php echo $translations['DESCRYPTION'] ?></th>
    </tr>

    <?php



    $pieces = mysqli_query($connects, "SELECT * FROM `chess`");



    $pieces = mysqli_fetch_all($pieces);



    foreach ($pieces as $piece) {
        ?>
        <tr>
            <td><?= $piece[0] ?></td>
            <td><?= $piece[1] ?></td>
            <td><?= $piece[2] ?></td>
        </tr>
        <?php
    }
    ?>
</table>
<a href="/site/Main.php"><?php echo $translations['MAIN'] ?></a>
</body>
</html>
