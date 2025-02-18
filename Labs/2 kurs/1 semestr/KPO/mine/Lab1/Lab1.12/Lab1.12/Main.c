#define _CRT_SECURE_NO_WARNINGS
#include "math.h"
#include "stdio.h"
int main() {
	int n, a, i;
	float res, prev;
	printf("Write a number\n");
	scanf("%d", &a);
	printf("Write a second number\n");
	scanf("%d", &n);
	res = 0;
	i = 0;
	prev = 1;
	while (i <= n) {
		res = res + 1/(prev * (a + i));
		prev = 1 / (a + i);
		i++;
	}
	printf("Result of the first expression equals\n");
	printf("%f", res);

}