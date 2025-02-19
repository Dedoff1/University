<?php
$longestWord = '';
$maxLength = 0;

for ($i = 1; $i < $argc; $i++) {
    $currentWord = $argv[$i];
    $currentLength = strlen($currentWord);

    if ($currentLength > $maxLength) {
        $longestWord = $currentWord;
        $maxLength = $currentLength;
    }
}

echo "Самое длинное слово: $longestWord\n";
?>

