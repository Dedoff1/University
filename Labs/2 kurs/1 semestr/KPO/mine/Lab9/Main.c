#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

struct Student {
    char name[10];
    unsigned int score;
};

int main() {
    FILE* inputFile, * outputFile;
    struct Student student;
    int i = 0;

    
    inputFile = fopen("exam_results.txt", "r");
    if (inputFile == NULL) {
        perror("Error opening file");
        return -1;
    }

    
    outputFile = fopen("failing_students.txt", "w");
    if (outputFile == NULL) {
        perror("Error creating file");
        fclose(inputFile); 
        return -1;
    }

    while (fscanf(inputFile, "%s %u", student.name, &student.score) != EOF) {
        if (student.score < 5) {
            fprintf(outputFile, "%s %u\n", student.name, student.score);
        }
    }

    
    fclose(inputFile);
    fclose(outputFile);

    return 0;
}

