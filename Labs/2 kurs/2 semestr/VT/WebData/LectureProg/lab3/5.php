<?php

// Произвольный многомерный массив
$initialArray = [
    "value1" => 12,
    "value2" => 5.678,
    "value3" => "Hello, World!"
];

// Функция для обработки элементов многомерного массива
function processArray($input) {
    if (is_array($input)) {
        $output = [];
        foreach ($input as $key => $value) {
            $output[$key] = processArray($value);
        }
        return $output;
    } else {
        if (is_int($input)) {
            return $input * 2; // Умножаем целые числа на два
        } elseif (is_float($input)) {
            return round($input, 2); // Округляем дроби до сотых
        } elseif (is_string($input)) {
            return strtoupper($input); // Переводим строки в верхний регистр
        } else {
            return $input;
        }
    }
}

// Обрабатываем исходный массив
$processedArray = processArray($initialArray);

print_r($processedArray);

?>
