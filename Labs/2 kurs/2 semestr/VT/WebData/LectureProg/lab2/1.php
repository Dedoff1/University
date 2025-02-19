<?php
foreach (array_slice($argv, 1) as $param) {
    if (is_numeric($param)) {
        if (strpos($param, '.') !== false) {
            echo "$param: дробное число\n";
        } else {
            echo "$param: целое число\n";
        }
    } else {
        echo "$param: строка\n";
    }
}
?>


