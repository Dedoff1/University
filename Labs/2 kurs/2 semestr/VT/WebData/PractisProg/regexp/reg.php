<?php
$text = '';
$resultText = '';

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $userInput = $_POST['userInput'];


    $integerRegex = '/(?<!\=)\b\d+\b(?!=[^=&]*\d)/';
    $emailRegex = '/[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}/';
    $urlRegex = '/(https?:\/\/)?([^\/\?]+)(\?[^ ]+)?/';

    $resultText = preg_replace($integerRegex, "<span style='color: blue;'>$0</span>", $userInput);
    $resultText = preg_replace($emailRegex, "<span style='color: red;'>$0</span>", $resultText);
    $resultText = preg_replace_callback($urlRegex, function ($matches) {
        $urlWithoutQuery = $matches[2];

        return $urlWithoutQuery;
    }, $resultText);

    $userInput = '';
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Регулярные выражения в PHP</title>
</head>
<body>
<h1>Обработка текста с использованием регулярных выражений</h1>
<form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
    <label for="userInput">Введите текст для обработки:</label><br>
    <textarea name="userInput" id="userInput" rows="4" cols="50"><?php echo $text; ?></textarea><br><br>
    <button type="submit">Выполнить</button>
</form>

<?php if ($_SERVER["REQUEST_METHOD"] == "POST"): ?>
    <div style="margin-top: 20px;">
        <h2>Результат обработки:</h2>
        <div><?php echo $resultText; ?></div>
    </div>
<?php endif; ?>
</body>
</html>
