<?php
if ($argc < 2 || !is_numeric($argv[1])) {
    echo "Пожалуйста, введите число через командную строку.\n";
    exit();
}

$numberString = $argv[1];
$sum = array_sum(str_split($numberString));

echo "Сумма цифр в числе $numberString: $sum\n";
?>
