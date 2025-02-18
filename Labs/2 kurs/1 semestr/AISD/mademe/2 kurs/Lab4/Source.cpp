#include<iostream>
#include<vector>
#include<algorithm>
using namespace std;

#define NUM_TABS 2

struct TreeNode {
    int value = INT_MIN;
    TreeNode* left = nullptr, * right = nullptr;
    TreeNode* next = nullptr;
};


TreeNode* createTree(vector<int>& values, int left, int right) {
    if (left > right) {
        return nullptr;
    }

    int mid = (left + right) / 2;
    TreeNode* root = new TreeNode;

    root->value = values[mid];
    root->left = createTree(values, left, mid - 1);
    root->right = createTree(values, mid + 1, right);
    return root;
}

void outputTree(TreeNode* root, int tabs = 0) {
    if (!root) {
        for (int i = 0; i < tabs; i++) {
            cout << " ";
        }
        cout << "null" << "\n";
        return;
    }

    for (int i = 0; i < tabs; i++) {
        cout << " ";
    }
    cout << root->value << "\n";

    outputTree(root->left, tabs + NUM_TABS);
    outputTree(root->right, tabs + NUM_TABS);
}

void inorder(TreeNode* root) {
    if (!root)
        return;
    inorder(root->left);
    cout << root->value << " ";
    inorder(root->right);
}

void preorder(TreeNode* root) {
    if (!root)
        return;
    cout << root->value << " ";
    preorder(root->left);
    preorder(root->right);
}

void postorder(TreeNode* root) {
    if (!root)
        return;
    postorder(root->left);
    postorder(root->right);
    cout << root->value << " ";
}

void reverseThread(TreeNode* root, TreeNode*& prev) {
    if (!root)
        return;

    reverseThread(root->left, prev);
    root->next = prev;
    prev = root;

    reverseThread(root->right, prev);
}

void inorderRight(TreeNode* root, bool flag, TreeNode* prevNode) {
    TreeNode* prev = nullptr;
    reverseThread(root, prev);

    if (!root)
        return;

    inorderRight(root->left, false, root);

    cout << root->value << "<-";

    if (root->next != nullptr) {
        cout << "(" << root->next->value << ") ";
    }
    else {
        cout << "(" << "null" << ") ";
    }

    inorderRight(root->right, false, root);
}

TreeNode* findMinNode(TreeNode* root) {
    while (root->left)
        root = root->left;
    return root;
}

TreeNode* erase(TreeNode* root, int val) {
    if (root == nullptr)
        return nullptr;

    if (val < root->value) {
        root->left = erase(root->left, val);
    }
    else if (val > root->value) {
        root->right = erase(root->right, val);
    }
    else {
        if (!root->left && !root->right) {
            delete root;
            root = nullptr;
        }
        else if (!root->left) {
            TreeNode* toDelete = root;
            root = root->right;
            delete toDelete;
        }
        else if (!root->right) {
            TreeNode* toDelete = root;
            root = root->left;
            delete toDelete;
        }
        else {
            TreeNode* toDelete = findMinNode(root->right);
            root->value = toDelete->value;
            root->right = erase(root->right, toDelete->value);
        }
    }

    return root;
}

int main() {
    srand(time(NULL));

    int n = 0;
    cout << "Enter the number of nodes: ";
    cin >> n;
    vector<int> values(n, 0);
    cout << "Enter values: \n";
    for (int i = 0; i < n; i++) {
        // cin >> values[i];
        values[i] = rand() % 100;
        cout << values[i] << " ";
    }

    sort(values.begin(), values.end());
    TreeNode* root = createTree(values, 0, values.size() - 1);

    cout << "\nTree: \n";
    outputTree(root, 0);

    cout << "Inorder: \n";
    inorder(root);

    cout << "\nPreorder: \n";
    preorder(root);

    cout << "\nPostorder: \n";
    postorder(root);

    cout << "\nInorder right: \n";
    inorderRight(root, false, nullptr);

    int val = 0;
    cout << "\n to delete: \n";
    cin >> val;
    root = erase(root, val);

    cout << "\nTree: \n";
    outputTree(root, 0);

    cout << "\nInorder right: \n";
    inorderRight(root, false, nullptr);
}
