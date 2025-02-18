#define _CRT_SECURE_NO_WARNINGS
#include "math.h"
#include "stdio.h"
int main() {
    int n10, res10;
	printf("Number 10\n");
	printf("Write a number\n");
	scanf("%d", &n10);
	printf("2 in power %d equals\n",n10);
	res10 = pow(2, n10);
	printf("%d\n", res10);

	int n11, res11, a11, i11;
	printf("Number 11\n");
	printf("Write a number\n");
	scanf("%d", &a11);
	printf("Write the power of this number\n");
	scanf("%d", &n11);
	printf("%d in power %d equals\n", a11, n11);
	res11 = pow(a11, n11);
	printf("%d\n", res11);
	res11 = 1;
	i11 = 0;
	while (i11 < n11) {
		res11 = res11 * (a11 + i11);
		i11++;
	}
	printf("Result of expression: a(a+1)...(a+n-1) equals\n");
	printf("%d\n", res11);

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