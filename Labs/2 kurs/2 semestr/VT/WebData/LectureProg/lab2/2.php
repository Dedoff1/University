<?php
if ($argc < 2 || !is_numeric($argv[1])) {
    echo "Пожалуйста, укажите количество строк в таблице через командную строку.\n";
    exit();
}

$rowCount = $argv[1];

echo "<table border='1'>";
for ($i = 1; $i <= $rowCount; $i++) {
    echo "<tr><td>Строка $i</td></tr>";
}
echo "</table>";
?>

