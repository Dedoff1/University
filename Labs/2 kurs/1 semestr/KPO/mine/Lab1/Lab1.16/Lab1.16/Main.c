#define _CRT_SECURE_NO_WARNINGS
#include "math.h"
#include "stdio.h"
int main() {
	double res = 0, part = 0;
	for (int i = 1; i <= 100; i++) {
		part = 1.0 / (i * i);
		res += part;
	}
	printf("Result of expression equals\n");
	printf("%lf", res);

}