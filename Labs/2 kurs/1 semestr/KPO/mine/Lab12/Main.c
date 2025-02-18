#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

#define MAX_SIZE 100

struct Stack {
    int items[MAX_SIZE];
    int top;
};

void push(struct Stack* stack, int item) {
    if (stack->top == MAX_SIZE - 1) {
        printf("Stack Overflow\n");
        return;
    }
    stack->items[++stack->top] = item;
}

int pop(struct Stack* stack) {
    if (stack->top == -1) {
        printf("Stack Underflow\n");
        exit(1);
    }
    return stack->items[stack->top--];
}

void mergeStacks(struct Stack* stack1, struct Stack* stack2, struct Stack* result) {
    while (stack1->top != -1 && stack2->top != -1) {
        if (stack1->items[stack1->top] < stack2->items[stack2->top]) {
            push(result, pop(stack1));
        }
        else {
            push(result, pop(stack2));
        }
    }
    while (stack1->top != -1) {
        push(result, pop(stack1));
    }
    while (stack2->top != -1) {
        push(result, pop(stack2));
    }
}

int main() {
    struct Stack stack1, stack2, result;
    stack1.top = -1;
    stack2.top = -1;
    result.top = -1;
    int size = 0;
    int n = 0;
    printf("How many variables will be in the first stack?:\n");
    scanf("%d", &size);
    printf("Add variables to the first stack:\n");
    for (int i = 0; i < size; i++) {
        scanf("%d", &n);
        push(&stack1, n);
    }
    printf("How many variables will be in the second stack?:\n");
    scanf("%d", &size);
    printf("Add variables to the second stack:\n");
    for (int i = 0; i < size; i++) {
        scanf("%d", &n);
        push(&stack2, n);
    }
    

    mergeStacks(&stack1, &stack2, &result);

    printf("Merged Stack in ascending order: ");
    while (result.top != -1) {
        printf("%d ", pop(&result));
    }
    printf("\n");

    return 0;
}

