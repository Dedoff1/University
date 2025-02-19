<?php
if($_SERVER['REQUEST_METHOD'] === 'POST'){
    // Проверяем, были ли переданы два набора чисел через POST-запрос
    if(isset($_POST['numbers1']) && isset($_POST['numbers2'])){
        $numbers1 = explode(" ", $_POST['numbers1']);
        $numbers2 = explode(" ", $_POST['numbers2']);

        $result = $numbers1;

        // Обрабатываем второй набор чисел
        foreach($numbers2 as $number){
            if(!in_array($number, $result)){
                $result[] = $number;
            }
        }

        // Выводим результирующий набор чисел
        echo implode(" ", $result);
    } else {
        echo "Пожалуйста, передайте два набора чисел через POST-запрос.";
    }
} else {
    echo "Данный скрипт поддерживает только POST-запросы.";
}
?>
