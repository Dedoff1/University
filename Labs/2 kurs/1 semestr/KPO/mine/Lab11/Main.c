#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#define SIZE 5

void enQueue(int);
void deQueue();
void display();

int items[SIZE], front = -1, rear = -1;

int main() {
    
    int n;
    for (int i = 0; i <= 4; i++) {
        printf("Write %d element of the queue\n", i+1);
        scanf("%d", &n);
        enQueue(n);
    }
    display();
    printf("How many do you want to be deleted?\n");
    scanf("%d", &n);
    for (int i = 0; i < n; i++)
        deQueue();
   

    
    display();

    return 0;
}

void enQueue(int value) {
    if (rear == SIZE - 1)
        printf("\nQueue is full");
    else {
        if (front == -1)
            front = 0;
        rear++;
        items[rear] = value;
        printf("Added element -> %d\n", value);
    }
}

void deQueue() {
    if (front == -1)
        printf("\nQueue is empty");
    else {
        printf("Deleted element: %d\n", items[front]);
        front++;
        if (front > rear)
            front = rear = -1;
    }
}


void display() {
    if (rear == -1)
        printf("\nQueue is empty");
    else {
        int i;
        printf("\nElements of the queue:\n");
        for (i = front; i <= rear; i++)
            printf("%d  ", items[i]);
    }
    printf("\n");
}