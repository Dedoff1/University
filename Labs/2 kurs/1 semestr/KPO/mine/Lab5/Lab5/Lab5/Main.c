#include <stdio.h>
#include <ctype.h>
#include <string.h>

#define MAX_LENGTH 100

void sortLetters(char* sentence, char* result) {
    int count = 0;
    int length = strlen(sentence);

    for (int i = 0; i < length; i++) {
        char c = toupper(sentence[i]); // Переводим символ в прописную форму

        if (isalpha(c) && (c >= 'Q' && c <= 'Z')) {
            result[count++] = c;
        }
    }

    // Сортировка букв в алфавитном порядке
    for (int i = 0; i < count - 1; i++) {
        for (int j = i + 1; j < count; j++) {
            if (result[j] < result[i]) {
                char temp = result[i];
                result[i] = result[j];
                result[j] = temp;
            }
        }
    }

    result[count] = '\0';
}

int main() {
    char sentence[MAX_LENGTH];
    char result[MAX_LENGTH];

    printf("Write a sentence: ");
    fgets(sentence, sizeof(sentence), stdin);
    sentence[strcspn(sentence, "\n")] = '\0';

    sortLetters(sentence, result);

    printf("Result: %s\n", result);

    return 0;
}