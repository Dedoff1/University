#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

#include <conio.h>

#include <stdlib.h>

main()

{
    int a[8][8]; 

    int i, j, range, min, minj, temp, mini,k; 

    printf("Part 1\n");
    printf("Write a possible range\n");
    scanf("%d", &range);
    for (i = 0; i < 8; i++)
    {
        for (j = 0; j < 8; j++)
        {
            a[i][j] = rand() % range + 1; 
        }
    }
    printf("Array\n");
    for (i = 0; i < 8; i++)
    {
        for (j = 0; j < 8; j++)
        {
            printf("%d ", a[i][j]);
        }
        printf("\n");
    }     
            k = 0;
            min = INT_MAX;
            minj = 0;
            mini = 0;
    for (i = 7; i >=  4; i--, k++)
    {       
        for (int j = k; j < 8 - k; j++) {
            if (a[i][j] < min) {
                min = a[i][j];
                mini = i;
                minj = j;
            }
        }
            
           
    }
    

    printf("Min in this range is %d with coordinates %d %d\n", min, mini,minj);

    

 

        

        

    
    int b[9][9];

    int diag;

    printf("Part 2\n");

    for (i = 0; i < 9; i++)

    {



        for (j = 0; j < 9; j++)

        {

            b[i][j] = rand() % range + 1;

        }

    }



    printf("Array\n");



    for (i = 0; i < 9; i++)

    {



        for (j = 0; j < 9; j++)

        {

            printf("%d ", b[i][j]);

        }



        printf("\n");

    }
    diag = 4;
    for (j = 0; j < 9; j++)
    {
        min = b[0][j];
        mini = 0;

        for (i = 0; i < 9; i++)
        {
            if (b[i][j] < min)
            {
                min = b[i][j];
                mini = i;
            }
        }
        temp = b[diag][j];
        b[diag][j] = b[mini][j];
        b[mini][j] = temp;
        diag = diag - 1;
    }


    printf("Modified Array\n");



    for (i = 0; i < 5; i++)

    {



        for (j = 0; j < 5; j++)

        {

            printf("%d ", b[i][j]);

        }



        printf("\n");

    }

}