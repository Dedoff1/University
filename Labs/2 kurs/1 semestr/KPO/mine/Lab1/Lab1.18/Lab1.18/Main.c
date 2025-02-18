#define _CRT_SECURE_NO_WARNINGS
#include "math.h"
#include "stdio.h"
int main() {
	printf("Number 18\n");
	printf("Write a number\n");
	double res18 = 0, part18 = 0;
	int n18 = 0;
	scanf("%d", &n18);
	printf("Result of expression Sum 1/k from 1 to %d equals\n", n18);
	for (int k18 = 1; k18 <= n18; k18++) {
		part18 = 1.0 / k18;
		res18 += part18;
	}
	printf("%lf\n", res18);

	printf("Result of expression Sum 1/(2k+1)^2 from 1 to %d equals\n", n18);
	for (int k18 = 1; k18 <= n18; k18++) {
		part18 = 1.0 / (pow(2*k18 + 1, 2));
		res18 += part18;
	}
	printf("%lf", res18);
}