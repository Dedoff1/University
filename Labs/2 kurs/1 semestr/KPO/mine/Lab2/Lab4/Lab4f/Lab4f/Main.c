#include <stdio.h>
#include <string.h>
#include <ctype.h>

#define MAX_LENGTH 100

void countLetters(const char* sentence, char* result) {
    int letterCount[26] = { 0 }; 
    int sentenceLength = strlen(sentence);

    for (int i = 0; i < sentenceLength; i++) {
        if (isalpha(sentence[i])) { 
            letterCount[tolower(sentence[i]) - 'a']++; 
        }
    }

    for (int i = 0; i < 26; i++) {
        if (letterCount[i] > 0) {
            sprintf_s(result, MAX_LENGTH, "%s%c%d", result, 'A' + i, letterCount[i]); 
        }
    }
}

int main() {
    char sentence[MAX_LENGTH];
    char result[MAX_LENGTH] = "";

    printf("Write a sentence: ");
    fgets(sentence, MAX_LENGTH, stdin);
   

    countLetters(sentence, result);

    printf("Result: %s\n", result);

    return 0;
}