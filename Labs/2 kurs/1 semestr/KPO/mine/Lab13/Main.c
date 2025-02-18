#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>


typedef struct Node {
    int data;
    struct Node* left;
    struct Node* right;
} Node;
int i;
Node* createNode(int data) {
    Node* newNode = (Node*)malloc(sizeof(Node));
    newNode->data = data;
    newNode->left = NULL;
    newNode->right = NULL;
    return newNode;
}

void insert(Node** root, int data) {
    if (*root == NULL) {
        *root = createNode(data);
    }
    else {
        if (data < (*root)->data) {
            insert(&(*root)->left, data);
        }
        else {
            insert(&(*root)->right, data);
        }
    }
}

void printInOrder(Node* root) {
    if (root != NULL) {
        printInOrder(root->left);
        if (i % 2 == 0)
            printf("%d \n", root->data);
        else
            printf("%d ", root->data);
        printInOrder(root->right);
        i++;
    }
}


int findPath(Node* node, int key) {
    
    if (node == NULL) {
        return 0;
    }
    
    if (node->data == key) {
        return 1;
    }
    
    int left = findPath(node->left, key);
    int right = findPath(node->right, key);
    
    return 1 + (left > right ? left : right);
}

int main() {
    Node* root = NULL;
    int numChildren;
    printf("Enter the number of children: ");
    scanf("%d", &numChildren);

    for (int i = 0; i < numChildren; i++) {
        int value;
        printf("Enter the value for child %d: ", i + 1);
        scanf("%d", &value);
        insert(&root, value);
    }

    printf("In order traversal of the tree: \n");
    i = 1;
    printInOrder(root);

    int key;
    
    printf("\nWhich element are we looking for? ");
    scanf("%d", &key);
    int pathLength = findPath(root, key);

    
    printf("Length for the element %d: %d", key, pathLength/2+1);

    return 0;
}
