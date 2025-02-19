<?php

// Обработчик кнопки перевода
if (isset($_POST['translate'])) {
    $html = $_POST['html'];
    $language = $_POST['language'];

    // Создать файл переводов
    $translations = parse_ini_file('translations.ini', true);

    // Заменить текст на переведенный
    foreach ($translations[$language] as $key => $value) {
        $html = preg_replace('/(' . $key . '(\s+[^<>]*)?)/i', '$1" title="' . $value . '"', $html);
    }

    // Вывести переведенную страницу
    echo $html;
    exit;
}

?>
