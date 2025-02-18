#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

#include <conio.h>

#include <stdlib.h>

main()

{

    int a[6][6]; 

    int i, j, range, min, max, minj, maxj, temp; 

    printf("Part 1\n");
    printf("Write a possible range\n");

    scanf("%d", &range);

   

    for (i = 0; i < 6; i++)

    {

       

        for (j = 0; j < 6; j++)

        {

            a[i][j] = rand() % range + 1; 

        }

    }


    printf("Array\n");

   

    for (i = 0; i < 6; i++)

    {

      

        for (j = 0; j < 6; j++)

        {

            printf("%d ", a[i][j]);

        }

      

        printf("\n");

    }
   
    for (i = 0; i < 6; i++)
    {       
            min = a[i][0];
            max = a[i][0];
            minj = 0;
            maxj = 0;
            for (j = 0; j < 6; j++)
            {
                if (a[i][j] < min)
                {
                    min = a[i][j];
                    minj = j;
                }
                

                    if (a[i][j] > max)
                    {
                        max = a[i][j];
                        maxj = j;
                    }
                
               
            } 
                temp = a[i][maxj];
                a[i][maxj] = a[i][minj];
                a[i][minj] = temp;
    }
    

    printf("Modified Array\n");

    

    for (i = 0; i < 6; i++)

    {

        

        for (j = 0; j < 6; j++)

        {

            printf("%d ", a[i][j]);

        }

        

        printf("\n");

    }
    int b[5][5];

    int  mini, diag;

    printf("Part 2\n");

    for (i = 0; i < 5; i++)

    {



        for (j = 0; j < 5; j++)

        {

            b[i][j] = rand() % range + 1;

        }

    }



    printf("Array\n");



    for (i = 0; i < 5; i++)

    {



        for (j = 0; j < 5; j++)

        {

            printf("%d ", b[i][j]);

        }



        printf("\n");

    }
    diag = 4;
    for (j = 0; j < 5; j++)
    {
        min = b[0][j];
        mini = 0;

        for (i = 0; i < 5; i++)
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