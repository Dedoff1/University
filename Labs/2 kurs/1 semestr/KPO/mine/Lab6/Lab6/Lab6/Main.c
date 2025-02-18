#include <stdio.h>
#include <ctype.h>
#include <string.h>

#define MAX_LENGTH 100

void reverseWord(char* word) {
    int length = strlen(word);

    for (int i = 0; i < length / 2; i++) {
        char temp = word[i];
        word[i] = word[length - i - 1];
        word[length - i - 1] = temp;
    }
}

void printDigitsAndLetters(char* sentence) {
    int length = strlen(sentence);
    char digits[MAX_LENGTH];
    char letters[MAX_LENGTH + 1]; 

    int digitCount = 0;
    int letterCount = 0;

    for (int i = 0; i < length; i++) {
        char c = sentence[i];

        if (isdigit(c)) {
            digits[digitCount++] = c;
        }
        else if (isalpha(c)) {
            letters[letterCount++] = c;
        }
    }

    
    letters[letterCount] = '\0';

    printf("RES: ");
    for (int i = 0; i < digitCount; i++) {
        printf("%c", digits[i]);
    }
    
    reverseWord(letters);
    for (int i = 0; i < letterCount; i++) {
        printf("%c", letters[i]);
    }
    printf("\n");
}

int main() {
    char sentence[MAX_LENGTH];

    printf("Enter a sentence: ");
    fgets(sentence, sizeof(sentence), stdin);
    sentence[strcspn(sentence, "\n")] = '\0';

    printDigitsAndLetters(sentence);

    return 0;
}