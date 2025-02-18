#pragma warning(disable : 4996)
#pragma warning(disable : 4244)
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

// Function to generate a random matrix
void generateRandomMatrix(int a[][100], int n) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            a[i][j] = rand() % 100; // Generate random integers between 0 and 99
        }
    }
}

// Function to print a matrix with aligned columns
void printMatrix(int a[][100], int n) {
    int maxDigits = 0;

    // Find the maximum number of digits in the matrix
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            int num = a[i][j];
            int digits = 0;
            while (num != 0) {
                num /= 10;
                digits++;
            }
            if (digits > maxDigits) {
                maxDigits = digits;
            }
        }
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            printf("%*d ", maxDigits, a[i][j]);
        }
        printf("\n");
    }
}

int main() {
    srand(time(NULL));

    int n = 0;

    printf("Enter N - the size of the matrix: ");
    scanf("%d", &n);

    printf("You have entered %d\n", n);

    int a[100][100];

    // Generate a random matrix
    generateRandomMatrix(a, n);

    printf("Randomly generated matrix:\n");
    printMatrix(a, n);
    int mindiag= a[0][1];
    int mini, minj;
    for (int i = 0; i < n/ 2; i++) {
        for (int j = i + 1; j < n - i - 1; j++) {
            if (a[i][j] < mindiag) {
                mindiag = a[i][j];
            }
            if (a[n - i - 1][n - j - 1] < mindiag) {
                mindiag = a[n - i - 1][n - j - 1];
                mini = n - i - 1;
                minj = n - j - 1;
            }
        }
    }
    printf("The min from left and right sedes of X - type field: %d with coordinates %d %d\n", mindiag, mini, minj);
    
    
    
    int min_x_upper = a[0][1]; // Минимальное значение в верхней части символа "X"

    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n - i - 1; j++) {
            if (a[i][j] < min_x_upper) {
                min_x_upper = a[i][j];
                mini = i;
                minj = j;
            }
        }
    }


    printf("The min from upper sedes of X - type field: %d with coordinates %d %d\n", min_x_upper, mini+1, minj+1);



    return 0;
}