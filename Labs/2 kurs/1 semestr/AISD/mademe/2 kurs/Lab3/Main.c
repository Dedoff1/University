#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct TreeNode {
    int data;
    struct TreeNode* left;
    struct TreeNode* right;
    struct TreeNode* wire;
};

struct Tree {
    int size;
    struct TreeNode* root;
};

struct Tree NewTree() {
    struct Tree* root = (struct Tree*)malloc(sizeof(struct Tree));
    root->size = 0;
    root->root = NULL;
    return *root;
}

struct TreeNode* NewNode(int data) {
    struct TreeNode* node = (struct TreeNode*)malloc(sizeof(struct TreeNode));
    node->data = data;
    node->left = NULL;
    node->right = NULL;
    return node;
}

short Tree_Add(struct Tree* tree, int data) {
    struct TreeNode* temp = tree->root;
    struct TreeNode* parent = NULL;
    while (temp != NULL) {
        parent = temp;
        if (temp->data < data) {
            temp = temp->right;
        }
        else if (temp->data > data) {
            temp = temp->left;
        }
        else {
            return 0;
        }
    }
    struct TreeNode* toInsert = NewNode(data);
    if (parent == NULL) {
        tree->root = toInsert;
    }
    else {
        if (parent->data < data) {
            parent->right = toInsert;
        }
        else {
            parent->left = toInsert;
        }
    }
    int newVal = 0;
    tree->size++;
    return 1;
}

short Tree_Delete(struct Tree* tree, int data) {
    struct TreeNode* temp = tree->root;
    struct TreeNode* parent = NULL;

    while (temp != NULL) {
        if (temp->data < data) {
            parent = temp;
            temp = temp->right;
        }
        else if (temp->data > data) {
            parent = temp;
            temp = temp->left;
        }
        else {
            if (temp->right == NULL && temp->left == NULL) {
                if (parent != NULL) {
                    if (parent->right == temp) {
                        parent->right = NULL;
                    }
                    else {
                        parent->left = NULL;
                    }
                }
                else {
                    tree->root = NULL;
                }
            }
            else if (temp->right == NULL && temp->left != NULL) {
                if (parent != NULL) {
                    if (parent->right == temp) {
                        parent->right = temp->left;
                    }
                    else {
                        parent->left = temp->left;
                    }
                }
                else {
                    tree->root = temp->left;
                }
            }
            else if (temp->right != NULL && temp->left == NULL) {
                if (parent != NULL) {
                    if (parent->right == temp) {
                        parent->right = temp->right;
                    }
                    else {
                        parent->left = temp->right;
                    }
                }
                else {
                    tree->root = temp->right;
                }
            }
            else {
                struct TreeNode* minRight = temp->right;
                struct TreeNode* minRightParent = temp;

                while (minRight->left != NULL) {
                    minRightParent = minRight;
                    minRight = minRight->left;
                }

                if (minRightParent->left == minRight) {
                    minRightParent->left = minRight->right;
                }
                else {
                    minRightParent->right = minRight->right;
                }

                minRight->left = temp->left;
                minRight->right = temp->right;

                if (parent != NULL) {
                    if (parent->right == temp) {
                        parent->right = minRight;
                    }
                    else {
                        parent->left = minRight;
                    }
                }
                else {
                    tree->root = minRight;
                }
            }

            free(temp);
            tree->size--;

            return 1;
        }
    }

    return 0;
}

void printSpaces(int amount) {
    for (int i = 0; i < amount; i++) {
        printf("    ");
    }
}

void printTree(struct TreeNode* root, int level, int isLeft) {
    if (root == NULL) {
        return;
    }

    printTree(root->right, level + 1, 0);

    if (level != 0) {
        if (isLeft) {
            printSpaces(level - 1);
            printf("   \\   \n");
            printSpaces(level);
            printf(" %d\n", root->data);
        }
        else {
            printSpaces(level);
            printf(" %d\n", root->data);
            printSpaces(level - 1);
            printf("   /   \n");
        }
    }
    else {
        printf(" %d\n", root->data);
    }

    printTree(root->left, level + 1, 1);
}

int FindDepth(struct TreeNode* root, int depth) {
    int a = 0, b = 0;
    if (root->left != NULL) {
        a = FindDepth(root->left, depth + 1);
    }
    if (root->right != NULL) {
        b = FindDepth(root->right, depth + 1);
    }
    if (a == 0 && b == 0) {
        return depth;
    }
    if (a > b) { return a; }
    else { return b; }
}

char* FindLongestPath(struct TreeNode* root, int depth, char* currentPath, size_t pathSize) {
    if (root == NULL) {
        return currentPath;
    }

    // Создание новой строки для текущего поддерева
    char* leftPath = malloc(pathSize);
    char* rightPath = malloc(pathSize);
    leftPath[0] = '\0';
    rightPath[0] = '\0';

    // Вызов рекурсивной функции для левого поддерева
    leftPath = FindLongestPath(root->left, depth + 1, leftPath, pathSize);

    // Вызов рекурсивной функции для правого поддерева
    rightPath = FindLongestPath(root->right, depth + 1, rightPath, pathSize);

    // Добавление текущего узла к текущему пути
    char* str = malloc(100);
    sprintf(str, "%d", root->data);
    strcat(currentPath, str);


    // Выбор самого длинного пути
    if (strlen(leftPath) > strlen(rightPath)) {
        strcat(currentPath, " -> ");
        strcat(currentPath, leftPath);
    }
    else {
        strcat(currentPath, " -> ");
        strcat(currentPath, rightPath);
    }

    // Освобождение памяти, выделенной для поддеревьев и текущего узла
    free(leftPath);
    free(rightPath);

    return currentPath;
}



int main() {
    struct Tree root = NewTree();
    char command = ' ';
    printf("Use a to add an element to a tree\n");
    printf("Use d to delete an element from a tree\n");
    printf("Use p to print a tree\n");
    printf("Use f to find a path to an element of the tree\n");
    printf("Use l to right a path\n");
    printf("Use e to exit a programm\n");
    
    // a - add
    // d - delete
    // p - print tree
    // f - find depth
    // e - end

    while (command != 'e') {
        scanf("%c", &command);
        if (command == 'a') {
            int temp;
            scanf("%d", &temp);
            if (!Tree_Add(&root, temp)) {
                printf("This value is in a tree already \n");
            };
        }

        if (command == 'p') {
            printTree(root.root, 0, 0);
        }

        if (command == 'f') {
            int temp = FindDepth(root.root, 1);
                printf("%d\n", temp);
        }

        if (command == 'd') {
            int temp;
            scanf("%d", &temp);
            if (!Tree_Delete(&root, temp)) {
                printf("No such element in a tree \n");
            };
        }

        if (command == 'l') {
            int depth = 1;
            char* path = malloc(500);
            path[0] = '\0';

            char* longestPath = FindLongestPath(root.root, depth, path, 500);
            longestPath[strlen(longestPath) - 4] = '\0';

            printf("Longest Path: %s\n", longestPath);
        }
    }

    return 0;
}