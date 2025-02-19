<?php
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
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <style type="text/css">

        .block-on-center {
            position: absolute;
            top: 30%;
            left: 30%;
            margin-top: -100px;
            margin-left: -100px;
        }

        .cal{
            border: 1px solid #ccc;
            color: #333;
            background: #F6F6F6;
            font-family: Arial, serif;
            font-size: 14px;
            text-align: center;}

        .caltoday{
            font-family: Arial, serif;
            font-size: 14px;
            text-align: center;
            font-weight: bold;
            background: aqua;
        }

        .navi{
            font-family: Arial, serif;
            font-size: 16px;
            font-weight: bold;
            color: #F6F6F6;
        }

        .datehead{
            font-family: Arial, serif;
            font-size: 16px;
            font-weight: bold;
            padding: 5px; /* Добавляет внутренний отступ вокруг текста */
            text-align: center; /* Выравнивание текста по центру */
            margin-left: 10px;
        }
        .datehead2{
            font-family: Arial, serif;
            font-size: 16px;
            font-weight: bold;
            padding: 5px; /* Добавляет внутренний отступ вокруг текста */
            text-align: center; /* Выравнивание текста по центру */
            margin-left: 10px;
            color: red;
        }
        body {
            background: burlywood;
        }


    </style>
    <title>Календарь</title>
</head>
<body>
<?php

$self = $_SERVER['PHP_SELF'];

if(isset($_GET['month']))
    $month = $_GET['month'];
elseif(isset($_GET['viewmonth']))
    $month = $_GET['viewmonth'];
else
    $month = date('m');

if(isset($_GET['year']))
    $year = $_GET['year'];
elseif(isset($_GET['viewyear']))
    $year = $_GET['viewyear'];
else
    $year = date('Y');

if($month == '12')
    $next_year = $year + 1;
else
    $next_year = $year;


$Month_r = array(
    "1" => "январь",
    "2" => "февраль",
    "3" => "март",
    "4" => "апрель",
    "5" => "май",
    "6" => "июнь",
    "7" => "июль",
    "8" => "август",
    "9" => "сентябрь",
    "10" => "октябрь",
    "11" => "ноябрь",
    "12" => "декабрь");

$first_of_month = mktime(0, 0, 0, $month, 1, $year);

$day_headings = array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');

$maxdays = date('t', $first_of_month);
$date_info = getdate($first_of_month);
$month = $date_info['mon'];
$year = $date_info['year'];

if($month == '1')
    $last_year = $year-1;
else
    $last_year = $year;

$timestamp_last_month = $first_of_month - (24*60*60);
$last_month = date("m", $timestamp_last_month);

if($month == '12')
    $next_month = '1';
else
    $next_month = $month+1;

$calendar = "
<div class=\"block-on-center\">
<table width='700px' height='500px' style='border: 1px solid #cccccc';>
    <tr style='background: #008000;'>
        <td colspan='7' class='navi'>
            <a style='margin-left: 10px; margin-right: 10px; color: #ffffff;' href='$self?month=".$last_month."&year=".$last_year."'>&lt;=</a>
           ".$Month_r[$month]." ".$year."
            <a style='margin-left: 10px; color: #ffffff;' href='$self?month=".$next_month."&year=".$next_year."'>=&gt;</a>
        </td>
    </tr>
    <tr>
        <td class='datehead'>Пн</td>
        <td class='datehead'>Вт</td>
        <td class='datehead'>Ср</td>
        <td class='datehead'>Чт</td>
        <td class='datehead'>Пт</td>
        <td class='datehead2'>Сб</td>
		<td class='datehead2'>Вс</td>
    </tr>
    <tr>";

$class = "";

$weekday = $date_info['wday'];

$weekday = $weekday-1;
if($weekday == -1) $weekday=6;

$day = 1;

if($weekday > 0)
    $calendar .= "<td colspan='$weekday'> </td>";

while($day <= $maxdays)
{
    if($weekday == 7) {
        $calendar .= "</tr><tr>";
        $weekday = 0;
    }

    $linkDate = mktime(0, 0, 0, $month, $day, $year);

    if((($day < 10 and "0$day" == date('d')) or ($day >= 10 and "$day" == date('d'))) and (($month < 10 and "0$month" == date('m')) or ($month >= 10 and "$month" == date('m'))) and $year == date('Y'))
        $class = "caltoday";

    else {
        $d = date('m/d/Y', $linkDate);

        $class = "cal";
    }

    if($weekday == 5 || $weekday == 6) $red='style="color: red" ';
    else $red='';

    $calendar .= "
        <td class='{$class}'><span ".$red.">{$day}</span>
        </td>";
    $day++;
    $weekday++;
}

if($weekday != 7)
    $calendar .= "<td colspan='" . (7 - $weekday) . "'> </td>";

echo $calendar . "</tr></table>";

$months = array('Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь');

echo "<form style='float: right; margin-right: 10px;' action='$self' method='get'><select name='month'>";

for($i=0; $i<=11; $i++) {
    echo "<option value='".($i+1)."'";
    if($month == $i+1)
        echo "selected = 'selected'";
    echo ">".$months[$i]."</option>";
}

echo "</select>";
echo "<select name='year'>";

for ($i = date('Y') - 40; $i <= (date('Y') + 40); $i++) {
    $selected = ($year == $i) ? "selected='selected'" : '';
    echo "<option value='$i' $selected>$i</option>";
}


echo "</select><input type='submit' value='смотреть' /></form>";

if($month != date('m') || $year != date('Y'))
    echo "<a style='float: left; margin-left: 10px; font-size: 12px; padding-top: 5px;' href='".$self."?month=".date('m')."&year=".date('Y')."'>&lt;&lt; Вернуться к текущей дате</a>";
echo "</div>";

?>

<a href="/site/Main.php">На главную</a>
</body>
</html>
