#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#define MAX_LENGTH 50
 struct Translation {
	char eng[MAX_LENGTH];
	char rus[MAX_LENGTH];
};
int main() {
	char sentence[MAX_LENGTH];
	char word[MAX_LENGTH];
	char res[MAX_LENGTH];
	struct Translation word1 = { "THIS", "ETO"};
	struct Translation word2 = { "IS", "" };
	struct Translation word3 = { "A", "" };
	struct Translation word4 = { "TABLE", "STOL" };
	printf("Write a sentence: ");
	fgets(sentence, sizeof(sentence), stdin);
	sentence[strcspn(sentence, "\n")] = '\0';
	*res = "";
	for (int i = 0; i <= strlen(sentence); i++) {
		int j = 0;
		*word = "";
		while (isalpha(sentence[i])) {
			word[j] = sentence[i];
		}
		switch (*word) {
		case word1.eng:
			strcat(res, word1.rus);
		case word2.eng:
			strcat(res, word2.rus);
		case word3.eng:
			strcat(res, word3.rus);
		case word4.eng:
			strcat(res, word4.rus);
		}
	}
	res[strcspn(res, "\n")] = '\0';
	for (int i = 0; i <= strlen(res); i++) {
		printf(" %c", res[i]);
	}
	return 0;
}