#define _CRT_SECURE_NO_WARNINGS
#include "math.h"
#include "stdio.h"
int main() {
	
	printf("Number 16\n");
	printf("Result of expression Sum 1/i^2 from 1 to 100 equals\n");
	double res16 = 0, part16 = 0;
	for (int i16 = 1; i16 <= 100; i16++) {
		part16 = 1.0 / (i16 * i16);
		res16 += part16;
	}
	printf("%lf\n", res16);

	printf("Number 17\n");
	printf("Result of expression Sum 1/i^3 from 1 to 50 equals\n");
	double res17 = 0, part17 = 0;
	for (int i17 = 1; i17 <= 50; i17++) {
		part17 = 1.0 / (i17 * i17 * i17);
		res17 += part17;
	}
	printf("%lf\n", res17);

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
		part18 = 1.0 / (pow(2 * k18 + 1, 2));
		res18 += part18;
	}
	printf("%lf", res18);
}