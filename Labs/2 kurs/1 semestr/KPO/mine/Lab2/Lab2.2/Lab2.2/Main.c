#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

#include <conio.h>

#include <stdlib.h>

main()

{

    int a[5][5]; 

    int i, j, range, min, mini, diag, temp; 


    printf("Write a possible range\n");

    scanf("%d", &range);

    

    for (i = 0; i < 5; i++)

    {

       

        for (j = 0; j < 5; j++)

        {

            a[i][j] = rand() % range + 1; 

        }

    }

  

    printf("Array\n");

    

    for (i = 0; i < 5; i++)

    {

        

        for (j = 0; j < 5; j++)

        {

            printf("%d ", a[i][j]);

        }

      

        printf("\n");

    }
    diag = 4;
    for (j = 0; j < 5; j++)
    {
        min = a[0][j];
        mini = 0;
        
        for (i = 0; i < 5; i++)
        {
            if (a[i][j] < min)
            {
                min = a[i][j];
                mini = i;
            }
        }
        temp = a[diag][j];
        a[diag][j] = a[mini][j];
        a[mini][j] = temp;
        diag = diag - 1;
    }
    

    printf("Array\n");

   

    for (i = 0; i < 5; i++)

    {

        

        for (j = 0; j < 5; j++)

        {

            printf("%d ", a[i][j]);

        }

        

        printf("\n");

    }

    scanf("%d", range);

}