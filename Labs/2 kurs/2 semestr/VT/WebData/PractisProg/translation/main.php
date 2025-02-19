<?php
session_start();

if (isset($_GET['lang'])) {
    $_SESSION['lang'] = $_GET['lang'];
}

if (!isset($_SESSION['lang'])) {
    $_SESSION['lang'] = 'en'; // Устанавливаем английский язык по умолчанию
}

if ($_SESSION['lang'] == 'en') {
    $translations = parse_ini_file('translations_en.ini');
} elseif ($_SESSION['lang'] == 'ru') {
    $translations = parse_ini_file('translations_ru.ini');
}
?>

<!DOCTYPE html>
<html lang="<?php echo $_SESSION['lang']; ?>">
<head>
    <meta charset="UTF-8">
    <title>Пример перевода сайта</title>
</head>
<body>
    <h1><?php echo $translations['HELLO']; ?></h1>
    <p><?php echo $translations['WELCOME']; ?></p>

    <form method="get" action="">
        <button type="submit" name="lang" value="en">English</button>
        <button type="submit" name="lang" value="ru">Русский</button>
    </form>
</body>
</html>
