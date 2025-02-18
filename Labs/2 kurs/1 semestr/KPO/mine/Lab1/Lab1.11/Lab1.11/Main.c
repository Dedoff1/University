#define _CRT_SECURE_NO_WARNINGS
#include "math.h"
#include "stdio.h"
int main() {
	int n, res, a, i;

	printf("Write a number\n");
	scanf("%d", &a);
	printf("Write the power of this number\n");
	scanf("%d", &n);
	printf("%d in power %d equals\n", a, n);
	res = pow(a, n);
	printf("%d\n", res);
	res = 1;
	i = 0;
	while (i<n){
		res = res * (a + i);
		i++;
	}
	printf("Result of expression: a(a+1)...(a+n-1) equals\n");
	printf("%d", res);

}