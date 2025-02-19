<?php
// Проверяем, был ли передан параметр 'text' через GET-запрос
if(isset($_GET['text'])){
    $text = $_GET['text'];

    // Разбиваем текст на слова
    $words = explode(" ", $text);

    // Проходим по каждому слову и изменяем его в соответствии с условиями
    foreach($words as $key => $word){
        if(($key + 1) % 3 == 0){
            // Каждое третье слово делаем заглавными буквами
            $words[$key] = strtoupper($word);
        }
        if(strlen($word) >= 3){
            // Каждая третья буква слова становится фиолетовой
            $chars = str_split($word);
            foreach($chars as $charKey => $char){
                if(($charKey + 1) % 3 == 0){
                    $chars[$charKey] = '<span style="color: purple;">' . $char . '</span>';
                }
            }
            $words[$key] = implode("", $chars);
        }
    }

    // Выводим измененный текст
    echo implode(" ", $words);
} else {
    echo "Пожалуйста, передайте текст через GET-запрос.";
}
?>
