<?php
$multiArray = [
    'красный' => [
        'синий' => [
            'зеленый' => [
                'фиолетовый' => [
                    'желтый' => [
                        'элемент'
                    ]
                ]
            ]
        ]
    ]
];

function displayNestedArray($array, $level = 1) {
    $colors = ['красный', 'синий', 'зеленый', 'фиолетовый', 'желтый'];
    echo "<ul style='color: {$colors[$level - 1]};'>";
    foreach ($array as $key => $value) {
        echo "<li>$key</li>";
        if (is_array($value)) {
            if (isset($colors[$level])) {
                displayNestedArray($value, $level + 1);
            } else {
                displayNestedArray($value, 1);
            }
        }
    }
    echo "</ul>";
}

displayNestedArray($multiArray);
?>
