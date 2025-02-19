<?php
if($_SERVER['REQUEST_METHOD'] === 'POST' || $_SERVER['REQUEST_METHOD'] === 'GET'){
    // Проверяем, была ли передана строка через POST- или GET-запрос
    if(isset($_REQUEST['input_string'])){
        $input_string = $_REQUEST['input_string'];

        // Разбиваем строку на слова
        $words = explode(" ", $input_string);

        // Переворачиваем порядок слов
        $reversed_words = array_reverse($words);

        // Соединяем слова обратно в строку
        $output_string = implode(" ", $reversed_words);

        // Выводим строку с переставленными словами
        echo $output_string;
    } else {
        echo "Пожалуйста, введите строку через POST- или GET-запрос.";
    }
} else {
    echo "Данный скрипт поддерживает только POST- или GET-запросы.";
}
?>