#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>




struct priority {
    int level;
    int  value[8];
};

int main() {
   
    struct priority s[6];
    s[0].level = 0;
    s[0].value[0] = 9;
    s[0].value[1] = 6;
    s[0].value[2] = 3;
    s[0].value[3] = 2;
    s[0].value[4] = 8;
    s[0].value[5] = 7;
    s[0].value[6] = 4;
    s[1].level = 1;
    s[1].value[0] = 3;
    s[1].value[1] = 7;
    s[1].value[2] = 2;
    s[1].value[3] = 4;
    s[1].value[4] = 7;
    s[1].value[5] = 3;
    s[1].value[6] = 1;
    s[2].level = 1;
    s[2].value[0] = 4;
    s[2].value[1] = 5;
    s[2].value[2] = 6;
    s[2].value[3] = 4;
    s[2].value[4] = 2;
    s[2].value[5] = 3;
    s[2].value[6] = 4;
    s[2].value[7] = 5;
    s[3].level = 1;
    s[3].value[0] = 3;
    s[3].value[1] = 5;
    s[3].value[2] = 4;
    s[3].value[3] = 2;
    s[3].value[4] = 1;
    s[3].value[5] = 6;
    s[3].value[6] = 8;
    s[3].value[7] = 3;
    s[4].level = 2;
    s[4].value[0] = 2;
    s[4].value[1] = 3;
    s[4].value[2] = 2;
    s[4].value[3] = 1;
    s[4].value[4] = 4;
    s[4].value[5] = 2;
    s[4].value[6] = 3;
    s[4].value[7] = 4;
    s[5].level = 2;
    s[5].value[0] = 3;
    s[5].value[1] = 2;
    s[5].value[2] = 1;
    s[5].value[3] = 2;
    s[5].value[4] = 3;
    s[5].value[5] = 4;
    s[5].value[6] = 3;
    s[5].value[7] = 4;
    int periodtime = 0, entertime = 0, theorytime = 0, practicetime = 0;
    float efficiency = 0;
    bool done;
    printf("Enter a period time\n");
    scanf("%d", &periodtime);
    printf("Enter an enter time\n");
    scanf("%d", &entertime);
    for (int i = 0; i < 6; i++) {
        if (i <= 1) {
            for (int j = 0; j < 7; j++) {
                theorytime += s[i].value[j];
            }
        }
        else {
            for (int j = 0; j < 8; j++) {
                theorytime += s[i].value[j];
            }
        }
    }
    printf("Theory Time: %d\n", theorytime);
    int i = 0;
    int j = 0;
    while (done = false) {
        while (j <= s[i].value[i])
        for (int j = 0;j <= periodtime;j++)
        s[i].value[i]
    }
    return 0;
}