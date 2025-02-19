<?php
global $connects2;
require_once 'config/connect.php';


session_start();

if (isset($_GET['lang'])) {
    $_SESSION['lang'] = $_GET['lang'];
}
if (!isset($_SESSION['lang'])) {
    $_SESSION['lang'] = 'en'; 
}

if ($_SESSION['lang'] == 'en') {
    $translations = parse_ini_file('translations_en.ini');
} elseif ($_SESSION['lang'] == 'ru') {
    $translations = parse_ini_file('translations_ru.ini');
}
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
        <th><?php echo $translations['TYPE'] ?></th>
        <th><?php echo $translations['DESCRYPTION'] ?></th>
    </tr>

    <?php



if ($_SESSION['lang'] == 'en') {
    $types = mysqli_query($connects2, "SELECT * FROM `typeseng`");
} else {
    $types = mysqli_query($connects2, "SELECT * FROM `typesofplay`");
}

    
    

    $types = mysqli_fetch_all($types);



    foreach ($types as $type) {
        ?>
        <tr>
            <td><?= $type[0] ?></td>
            <td><?= $type[1] ?></td>
        </tr>
        <?php
    }
    ?>
</table>
<a href="/site/Main.php"><?php echo $translations['MAIN'] ?></a>
</body>
</html>
