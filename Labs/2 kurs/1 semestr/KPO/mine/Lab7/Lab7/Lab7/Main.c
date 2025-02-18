#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <locale.h> 
#define MAX_WORDS 100
#define MAX_LENGTH 50

struct Translation {
    char english[MAX_LENGTH];
    char russian[MAX_LENGTH];
};

struct Translation dictionary[] = {
    {"THIS", "ЭТО"},
    {"IS", "ЯВЛЯЕТСЯ"},
    {"A", "ОДИН"},
    {"TABLE", "СТОЛ"},
    // Добавьте сюда другие слова и их переводы
};

int main() {
    char sentence[MAX_LENGTH];
    char result[MAX_LENGTH] = ""; // Инициализация результата пустой строкой

    printf("ENGLISH: ");
    fgets(sentence, sizeof(sentence), stdin);
    sentence[strcspn(sentence, "\n")] = '\0';

    char* token = strtok(sentence, " "); // Исправлен разделитель - пробел
    int count = 0;

    while (token != NULL) {
        int foundTranslation = 0;

        for (int i = 0; i < sizeof(dictionary) / sizeof(dictionary[0]); i++) {
            if (strcmp(token, dictionary[i].english) == 0) {
                strcat(result, dictionary[i].russian);
                foundTranslation = 1;
                break;
            }
        }

        if (!foundTranslation) {
            strcat(result, token);
        }

        strcat(result, " ");
        token = strtok(NULL, " "); // Исправлен разделитель - пробел
        count++;
    }

    result[strlen(result) - 1] = '\0';

    // Установка кодировки UTF-8 для вывода на консоль
    setlocale(LC_ALL, "en_US.UTF-8");

    printf("RUSSIAN: %s\n", result);

    return 0;
}