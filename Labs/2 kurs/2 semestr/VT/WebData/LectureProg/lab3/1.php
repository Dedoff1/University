<?php
// Проверяем, был ли передан параметр 'cities' через GET-запрос
if(isset($_GET['cities'])){

    // Получаем список городов из GET-параметра и разделяем их по запятой
    $cities = explode(',', $_GET['cities']);

    // Устраняем дубликаты, сортируем по алфавиту и сохраняем в итоговый массив
    $uniqueCities = array_unique($cities);
    sort($uniqueCities);

    // Выводим отсортированный список городов
    foreach($uniqueCities as $city){
        echo $city . "<br>";
    }
} else {
    echo "Пожалуйста, передайте список городов через GET-запрос.";
}
?>