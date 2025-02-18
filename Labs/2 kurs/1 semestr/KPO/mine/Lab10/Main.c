#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

int main() {
    FILE* inputFile1, * inputFile2, * outputFile;
    int number;

   
    inputFile1 = fopen("F1.txt", "r");
    if (inputFile1 == NULL) {
        perror("Error opening file");
        return -1;
    }
    inputFile2 = fopen("F2.txt", "r");
    if (inputFile2 == NULL) {
        perror("Error opening file");
        fclose(inputFile1);  
        return -1;
    }

    
    outputFile = fopen("F3.txt", "w");
    if (outputFile == NULL) {
        perror("Error creating file");
        fclose(inputFile1);  
        fclose(inputFile2);
        return -1;
    }

    
    while (fscanf(inputFile1, "%d", &number) == 1) {
        fprintf(outputFile, "%d\n", number);
    }

    
    while (fscanf(inputFile2, "%ch", &number) == 1) {
        fprintf(outputFile, "%ch\n", number);
    }

    
    fclose(inputFile1);
    fclose(inputFile2);
    fclose(outputFile);

    return 0;
}
