#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <ctype.h>

#define MAX_LENGTH 50

struct Translation {
    char eng[MAX_LENGTH];
    char rus[MAX_LENGTH];
};

int main() {
    char sentence[MAX_LENGTH];
    char result[MAX_LENGTH];
    struct Translation dictionary[] = {
        { "THIS", "ETO" },
        { "IS", "" },
        { "A", "" },
        { "TABLE", "STOL" },
        {"PEN", "RUCHKA"},
        {"PENCIL","KARANDASH"},
        {"NOT","NE"},
        {"CAR","MASHINA"}
    };
    printf("Eng: ");
    fgets(sentence, sizeof(sentence), stdin);
    sentence[strcspn(sentence, "\n")] = '\0';

    char* token = strtok(sentence, " ");
    *result = '\0';

    while (token != NULL) {
        int foundTranslation = 0;

        for (int i = 0; i < sizeof(dictionary) / sizeof(dictionary[0]); i++) {
            if (strcmp(token, dictionary[i].eng) == 0) {
                strcat(result, dictionary[i].rus);
                foundTranslation = 1;
                break;
            }
        }

        if (!foundTranslation) {
            strcat(result, token);
        }

        strcat(result, " ");
        token = strtok(NULL, " ");
    }

    result[strlen(result) - 1] = '\0';

    printf("Res: %s\n", result);

    return 0;
}
