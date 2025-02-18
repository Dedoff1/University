#include <stdio.h>
#include <ctype.h>
#include <string.h>

#define MAX_LENGTH 100
char VOKABULARY[] = "THIS", "ETO", "IS", "", "A", "","TABLE", "STOL";
char ENGLISH[MAX_LENGTH];
char RUSSIAN[MAX_LENGTH];
void TRANSLATION(char* sentence, char* result) {
    int count = 0;
    int length = strlen(sentence);
    int i = 0;
    char search[MAX_LENGTH];
    while (i <= length) {
        char c = sentence[i];
        int j = 0;
        search = "";
        while (isalpha(c)) {
            search[j] = c;
            j++;
            c = sentence[i++];
        }
        while (j <= strlen(VOKABULARY) {
            if (search == VOKABULARY[j]) {
                RUSSIAN += VOKABULARY[j + 1];
            }
            J += 2;
        }
        RUSSIAN += "_";
    }

   
    

    result = RUSSIAN;
}

int main() {
    

    printf("Write a sentence: ");
    fgets(ENGLISH, sizeof(ENGLISH), stdin);
    ENGLISH[strcspn(ENGLISH, "\n")] = '\0';

    TRANSLATION(ENGLISH, RUSSIAN);

    printf("Result: %s\n", RUSSIAN);

    return 0;
}