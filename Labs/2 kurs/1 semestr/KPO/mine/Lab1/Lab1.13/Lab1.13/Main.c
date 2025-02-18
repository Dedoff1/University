#define _CRT_SECURE_NO_WARNINGS
#include "math.h"
#include "stdio.h"
int main() {
	    double res = 1, part = 0;
		for (int i = 0.1; i <= 10; i=i+0.1) {
			part = sin(i);
			res *= part;
		}
	printf("Result of expression equals\n");
	printf("%lf", res);

}