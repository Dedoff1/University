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
    n -= 1;
    int min = a[0][1];
    int left = 0;
    int right = 0;
    int buff = 0;
    int mini, minj;
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


    printf("The min from upper sedes of X - type field: %d with coordinates %d %d\n", min_x_upper, mini + 1, minj + 1);


   
    int minleft, minright;
    minleft = a[1][0];
    int center = 0;
    buff = 0;
    right = 0;
    center = n / 2;
    for (int i = 0; i <= n; i++) {
        right = i;
        if (i > center) {
            right = n - i;
        }

        for (int j = 0; j <= right; j++) {
            if (i != j && a[i][j] < min && j != n && i != n - j) {
                min = a[i][j];
            }
        }
    }
    printf("The min from the > - type field:\n");
    printf("%d\n", min);
    // Поиск минимального значения в правой части символа "X"

    int min_x_right = min;

    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n - i - 1; j++) {
            if (a[i][j] < min_x_right) {
                min_x_right = a[i][j];
            }
        }
    }
    printf("The min from the < - type field:\n");
    printf("%d\n", min_x_right);

    return 0;
}