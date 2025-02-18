#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>


 struct Student{
    char name[50];
    char group[10];
    float averageScore;
    float incomePerFamilyMember;
} ;
struct Student students[10];
void sortByIncome(struct Student* students, int count) {
    for (int i = 0; i < count - 1; i++) {
       for (int j = 0; j < count - i - 1; j++) {
           if (students[j].incomePerFamilyMember < students[j + 1].incomePerFamilyMember) {
               struct Student temp = students[j];
               students[j] = students[j + 1];
                students[j + 1] = temp;
            }
        }
    }
}

void printStudents(struct Student* students, int count) {
    printf("List of the students:\n");
    for (int i = 0; i < count; i++) {
        printf("Student %d:\n", i + 1);
        printf("Initials: %s\n", students[i].name);
        printf("Group number: %s\n", students[i].group);
        printf("Calculated score: %.2f\n", students[i].averageScore);
        printf("Income of one family member: %.2f\n", students[i].incomePerFamilyMember);
        printf("\n");
    }
}

int main() {
    int count;
    printf("Write a number of students: ");
    scanf_s("%d", &count);

   

    for (int i = 0; i < count; i++) {
        printf("Student %d:\n", i + 1);
        printf("Write his initials: ");
        scanf("%s", students[i].name);
        printf("Write the number of the group: ");
        scanf("%s", students[i].group);
        printf("Write his calculated score: ");
        scanf("%f", &students[i].averageScore);
        printf("Write an income of one family member: ");
        scanf("%f", &students[i].incomePerFamilyMember);
        printf("\n");
    }

    sortByIncome(students, count);
    printStudents(students, count);

    return 0;
}