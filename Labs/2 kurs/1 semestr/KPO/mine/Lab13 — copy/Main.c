#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

#include <stdio.h>
#include <stdlib.h>

// Структура узла дерева
typedef struct Node {
    int data;
    struct Node* left;
    struct Node* right;
    struct Node* parent;
} Node;

// Структура для узла в очереди
typedef struct QueueNode {
    Node* node;
    struct QueueNode* next;
} QueueNode;

// Структура очереди
typedef struct {
    QueueNode* front;
    QueueNode* rear;
} Queue;

// Создание нового узла
Node* createNode(int data) {
    Node* newNode = (Node*)malloc(sizeof(Node));
    newNode->data = data;
    newNode->left = newNode->right = newNode->parent = NULL;
    return newNode;
}

// Вставка нового узла в дерево
Node* insertNode(Node* root, int data, Node* parent) {
    if (root == NULL) {
        Node* newNode = createNode(data);
        newNode->parent = parent;
        return newNode;
    }

    if (data < root->data)
        root->left = insertNode(root->left, data, root);
    else if (data > root->data)
        root->right = insertNode(root->right, data, root);

    return root;
}

// Создание новой пустой очереди
Queue* createQueue() {
    Queue* queue = (Queue*)malloc(sizeof(Queue));
    queue->front = queue->rear = NULL;
    return queue;
}

// Проверка на пустоту очереди
int isEmpty(Queue* queue) {
    return (queue->front == NULL);
}

// Добавление узла в очередь
void enqueue(Queue* queue, Node* node) {
    QueueNode* temp = (QueueNode*)malloc(sizeof(QueueNode));
    temp->node = node;
    temp->next = NULL;

    if (isEmpty(queue)) {
        queue->front = queue->rear = temp;
        return;
    }

    queue->rear->next = temp;
    queue->rear = temp;
}

Node* dequeue(Queue* queue) {
    if (isEmpty(queue))
        return NULL;

    QueueNode* temp = queue->front;
    Node* node = temp->node;
    queue->front = queue->front->next;

    if (queue->front == NULL)
        queue->rear = NULL;

    free(temp);
    return node;
}


void printLevelOrder(Node* root) {
    if (root == NULL)
        return;

    Queue* queue = createQueue();
    enqueue(queue, root);

    while (!isEmpty(queue)) {
        int levelSize = queue->rear - queue->front + 1;  

        for (int i = 0; i < levelSize; i++) {
            Node* current = dequeue(queue);
            printf("%d ", current->data);

            if (current->left)
                enqueue(queue, current->left);
            if (current->right)
                enqueue(queue, current->right);
        }

        printf("\n"); 
    }
}

int main() {
    Node* root = NULL;

    int elements[] = { 8, 3, 10, 1, 6, 14, 4, 7, 13 };
    int numElements = sizeof(elements) / sizeof(elements[0]);

    for (int i = 0; i < numElements; i++) {
        root = insertNode(root, elements[i], NULL);
    }

    printf("Tree with levels:\n");
    printLevelOrder(root);

    return 0;
}


