#include <stdio.h>
#include "stdlib.h"
#include <time.h>
#include <limits.h>

void fillMatrixRandom(int N, int matrix[N][N]) {
    for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
            matrix[i][j] = rand() % 100;
}

void printMatrix(int N, int matrix[N][N]) {
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++)
            printf("%3d ", matrix[i][j]);

        printf("\n");
    }
    printf("\n");
}

int findMinBetweenDiagonals(int N, int matrix[N][N]) {
    int min = INT_MAX;

    for (int i = 0; i < N / 2; i++) {
        for (int j = i + 1; j < N - i - 1; j++) {
            if (matrix[i][j] < min) {
                min = matrix[i][j];
            }
            if (matrix[N - i - 1][N - j - 1] < min) {
                min = matrix[N - i - 1][N - j - 1];
            }
        }
    }
    return min;
}

int findMinLeft(int N, int matrix[N][N]) {
    int min = INT_MAX;

    for (int j = 0; j < N / 2; j++) {
        for (int i = j + 1; i < N - j - 1; i++) {
            if (matrix[i][j] < min)
                min = matrix[i][j];
        }
    }
    return min;
}

int main() {
    const int N = 7;

    int a[N][N];

    srand(time(NULL));

    fillMatrixRandom(N, a);
    printMatrix(N, a);

    int result = findMinBetweenDiagonals(N, a);
    printf("%3d ", result);

    printf("\n");

    result = findMinLeft(N, a);
    printf("%3d ", result);

    return 0;
}