<?php
global $Maincount;
global $conn;
global $logname;
global $login;

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

echo $translations['TOTAL']." "; echo array_sum($_SESSION['page_visits']) . "<br>";


foreach ($_SESSION['page_visits'] as $page => $visits) {
    echo $translations['PAGE'] . " " . $page . " " . $translations['VISITED'] . " " . $visits . " " . $translations['TIMES']."<br>";

}

if (!isset($_SESSION['link_clicks'])) {
    $_SESSION['link_clicks'] = 0;
}



$link = 'https://www.youtube.com/watch?v=dQw4w9WgXcQ';


echo "<a href='$link'>" . $translations['LINK'] . "</a><br>";
if (isset($_GET['href']) && $_GET['href'] == $link)
    {
        $_SESSION['link_clicks']++;
    }
echo  $translations['CLICK']." ". $_SESSION['link_clicks'];
function get_platform()
{
    $agent = $_SERVER['HTTP_USER_AGENT'];
    if (preg_match('/Windows/', $agent)) {
        return 'Windows';
    } elseif (preg_match('/Macintosh/', $agent)) {
        return 'macOS';
    } elseif (preg_match('/Linux/', $agent)) {
        return 'Linux';
    } else {
        return  $translations['UNKNOWN'];
    }
}


$platform = get_platform();
?>
<!doctype html>
<html lang="<?php echo $_SESSION['lang']; ?>">
<head>
    <meta charset="UTF-8">
    <title><?php echo $translations['CHESSSITE'] ?></title>
</head>
<style>
    body {
        background: burlywood;
    }
</style>
<body>
<form method="get" action="">
        <button type="submit" name="lang" value="en">English</button>
        <button type="submit" name="lang" value="ru">Русский</button>
    </form>
<h1> <?php  $login = $_SESSION['login']; echo $translations['WELCOME'].", ". $login?>!</h1>
<h1><?php   echo $translations['USING']." ". $platform?></h1>
<h1><?php   echo $translations['INTRODUCTION']?></h1>
<!--<br><p1>Шахматы являются одной из самых старых игр на земле. Если вы хотите научитьс играть в шахматы, то наш сайт поможет вам в этом.<br></p1>-->
<p2><?php   echo $translations['DESCRIPTION']?><br></p2>
<h2><?php   echo $translations['CONTENT']?></h2>
<ul>
    <li><a href="/site/ChessPieces.php"><?php   echo $translations['PIECES']?></a></li>
    <li><a href="/site/TypesOfPlay.php"><?php   echo $translations['TYPES']?></a></li>
    <li><a href="/site/ResultsOfGames.php"><?php   echo $translations['RESULTS']?></a></li>
    <li><a href="/site/Calendar.php"><?php   echo $translations['CALENDAR']?></a></li>
    <li><a href="/site/config"><?php   echo $translations['LOGOUT']?></a></li>
</ul>
</body>
</html>
