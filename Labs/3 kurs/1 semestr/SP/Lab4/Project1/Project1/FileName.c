#include <windows.h>
#include <time.h>
#include <stdio.h>

#define THREAD_START 6
#define THREAD_END 1
#define THREAD_STEP 1

#define MAX_STRING_LENGTH 256
#define MAX_STRINGS_COUNT 1000
#define MAX_NUMBERS_COUNT 180000

#define IDC_LISTBOX_STRINGS 1
#define IDC_LISTBOX_NUMBERS 2
#define ID_LABEL_STRINGS 11
#define ID_LABEL_NUMBERS 12

int THREAD_COUNT = 6;
char str[THREAD_START][MAX_STRINGS_COUNT][MAX_STRING_LENGTH];
int numbers[THREAD_START][MAX_NUMBERS_COUNT];
int threadNumbers[THREAD_START];
int countStrings = 0;

HANDLE threads[THREAD_START];
static HWND hListBoxStrings, hListBoxNumbers;

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
int CreateThreads();
int CreateThreadsForNumbers();
DWORD WINAPI ThreadFunction(LPVOID lpParameter);
DWORD WINAPI ThreadFunctionForNumbers(LPVOID lpParameter);
void GetStringsFromFile(const char* fileName); 
void GetStringsFromFileForNumbers(const char* fileName); 
void CreateExitThread(const char* fileName);
void CreateExitThreadForNumbers(const char* fileName);
int FindFirstString(char strings[THREAD_START][MAX_STRING_LENGTH]);
int FindFirstNumber(int nums[THREAD_START]);
void to_uppercase(char* str);


int APIENTRY WinMain(HINSTANCE hInstance,
    HINSTANCE hPrevInstance, LPTSTR lpCmdLine, int nCmdShow)
{
    WNDCLASSEX wcex; HWND hWnd; MSG msg;
    wcex.cbSize = sizeof(WNDCLASSEX);
    wcex.style = CS_DBLCLKS;
    wcex.lpfnWndProc = WindowProc;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    wcex.hIcon = LoadIcon(NULL, IDI_APPLICATION);
    wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
    wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
    wcex.lpszMenuName = NULL;
    wcex.lpszClassName = "Lab4";
    wcex.hIconSm = wcex.hIcon;
    RegisterClassEx(&wcex);
    hWnd = CreateWindow("Lab4", L"Forth lab",
        WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, 0,
        CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

    ShowWindow(hWnd, nCmdShow);
    UpdateWindow(hWnd);
    while (GetMessage(&msg, NULL, 0, 0))
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return (int)msg.wParam;
}

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    static HBRUSH hBlueBrush;
    SetClassLongPtr(hwnd, GCLP_HBRBACKGROUND, (LONG)hBlueBrush);
    switch (uMsg) {
    case WM_CREATE: {
        hBlueBrush = CreateSolidBrush(RGB(0, 0, 255));
        CreateWindowA("static", " Strings",
            WS_CHILD | WS_VISIBLE | WS_TABSTOP,
            10, 10, 290, 18,
            hwnd, (HMENU)ID_LABEL_STRINGS, (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);

        hListBoxStrings = CreateWindowA("LISTBOX", "Keys", WS_CHILD | WS_VISIBLE | LBS_NOTIFY,
            10, 30, 290, (150 / 9) * (THREAD_START / THREAD_STEP + 1),
            hwnd, (HMENU)IDC_LISTBOX_STRINGS,
            (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);

        CreateWindowA("static", " Numbers",
            WS_CHILD | WS_VISIBLE | WS_TABSTOP,
            310, 10, 290, 18,
            hwnd, (HMENU)ID_LABEL_NUMBERS, (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);

        hListBoxNumbers = CreateWindowA("LISTBOX", "Keys", WS_CHILD | WS_VISIBLE | LBS_NOTIFY,
            310, 30, 290, (150 / 9) * (THREAD_START / THREAD_STEP + 1),
            hwnd, (HMENU)IDC_LISTBOX_NUMBERS,
            (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);

        for (int i = 0; i < THREAD_START; i++)
            for (int j = 0; j < MAX_NUMBERS_COUNT; j++)
                numbers[i][j] = INT_MAX;

        for (THREAD_COUNT = THREAD_START; THREAD_COUNT >= THREAD_END; THREAD_COUNT -= THREAD_STEP) {
            // Со строками
            DWORD time = GetTickCount();

            GetStringsFromFile("strings\\input.txt");
            int res = CreateThreads();
            if (res == 0) {
                WaitForMultipleObjects(THREAD_COUNT, threads, TRUE, INFINITE);
                for (int i = 0; i < THREAD_COUNT; i++)
                    CloseHandle(threads[i]);

                char fileName[50];
                snprintf(fileName, sizeof(fileName), "strings\\output%d.txt", THREAD_COUNT);
                CreateExitThread(fileName);
            }

            time = GetTickCount() - time;
            char tmp[50];
            snprintf(tmp, sizeof(tmp), "%d threads: %lu millisec", THREAD_COUNT, time == 0 ? 14 : time);
            SendMessageA(hListBoxStrings, LB_ADDSTRING, 0, (LPARAM)(tmp)); 

            // С числами
            time = GetTickCount();

            GetStringsFromFileForNumbers("numbers\\input.txt");
            res = CreateThreadsForNumbers();
            if (res == 0) {
                WaitForMultipleObjects(THREAD_COUNT, threads, TRUE, INFINITE);
                for (int i = 0; i < THREAD_COUNT; i++)
                    CloseHandle(threads[i]);

                char fileName[50];
                snprintf(fileName, sizeof(fileName), "numbers\\output%d.txt", THREAD_COUNT);
                CreateExitThreadForNumbers(fileName);
            }

            time = GetTickCount() - time;
            snprintf(tmp, sizeof(tmp), "%d threads: %lu.%lu sec", THREAD_COUNT, (time == 0 ? 14 / 1000 : time / 1000), (time == 0 ? 14 % 1000 : time % 1000));
            SendMessageA(hListBoxNumbers, LB_ADDSTRING, 0, (LPARAM)(tmp));
        }
        break;
    }
    case WM_CTLCOLORSTATIC: 
    case WM_CTLCOLORLISTBOX: 
    {
        HDC hdc = (HDC)wParam;
        HWND hwndCtl = (HWND)lParam;
        SetBkMode(hdc, TRANSPARENT);

        if (hwndCtl == hListBoxStrings || hwndCtl == hListBoxNumbers) {
            SetTextColor(hdc, RGB(255, 255, 0)); 
            return (INT_PTR)hBlueBrush; 
        }
        else {
            SetTextColor(hdc, RGB(255, 255, 0)); 
            return (INT_PTR)hBlueBrush; 
        }
    }
    case WM_DESTROY: {
        
        DeleteObject(hBlueBrush);
        PostQuitMessage(0);
        break;
    }
    default:
        return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }
    return 0;
}

int CreateThreads() {

    for (int i = 0; i < THREAD_COUNT; i++) {
        threadNumbers[i] = i;
        threads[i] = CreateThread(NULL, 0, ThreadFunction, 
            &threadNumbers[i], 0, NULL);      
        if (threads[i] == NULL) {
            return i + 1; 
        }
    }
    return 0;
}

int CreateThreadsForNumbers() {

    for (int i = 0; i < THREAD_COUNT; i++) {
        threadNumbers[i] = i;
        threads[i] = CreateThread(NULL, 0, ThreadFunctionForNumbers,
            &threadNumbers[i], 0, NULL);
        if (threads[i] == NULL) {
            return i + 1;
        }
    }
    return 0;
}

DWORD WINAPI ThreadFunction(LPVOID lpParameter) {
    int threadNumber = *((int*)lpParameter);
    for (int i = 0; i < MAX_STRINGS_COUNT && str[threadNumber][i][0] != '\0'; i++) {
        int minPosition = i;
        for (int j = i + 1; j < MAX_STRINGS_COUNT && str[threadNumber][j][0] != '\0'; j++) {
            char str1[MAX_STRING_LENGTH], str2[MAX_STRING_LENGTH];
            strcpy_s(str1, MAX_STRING_LENGTH, str[threadNumber][j]);
            strcpy_s(str2, MAX_STRING_LENGTH, str[threadNumber][minPosition]);
            to_uppercase(str1);
            to_uppercase(str2);
            if (strcmp(str1, str2) < 0)
                minPosition = j;
        }

        char tmp[MAX_STRING_LENGTH] = "";
        strcpy_s(tmp, MAX_STRING_LENGTH, str[threadNumber][i]);
        strcpy_s(str[threadNumber][i], MAX_STRING_LENGTH, str[threadNumber][minPosition]);
        strcpy_s(str[threadNumber][minPosition], MAX_STRING_LENGTH, tmp);
    }
    return 0;
}

DWORD WINAPI ThreadFunctionForNumbers(LPVOID lpParameter) {
    int threadNumber = *((int*)lpParameter);
    for (int i = 0; i < MAX_NUMBERS_COUNT && numbers[threadNumber][i] != INT_MAX; i++) {
        int minPosition = i;
        for (int j = i + 1; j < MAX_NUMBERS_COUNT && numbers[threadNumber][j] != INT_MAX; j++)
            if (numbers[threadNumber][j] < numbers[threadNumber][minPosition])
                minPosition = j;

        int tmp = numbers[threadNumber][i];
        numbers[threadNumber][i] = numbers[threadNumber][minPosition];
        numbers[threadNumber][minPosition] = tmp;
    }
    return 0;
}

void GetStringsFromFile(const char* fileName) {
    FILE* file = fopen(fileName, "r");
    if (!file)
        return NULL;

    countStrings = 0;
    char val[MAX_STRING_LENGTH] = "";
    int iThread = 0;
    for (int i = 0; fgets(val, MAX_STRING_LENGTH, file); i++) {
        strcpy_s(str[iThread][i / THREAD_COUNT], MAX_STRING_LENGTH, val);
        iThread = (iThread + 1) % THREAD_COUNT;
        countStrings++;
    }
    fclose(file);
}

void GetStringsFromFileForNumbers(const char* fileName) {
    FILE* file = fopen(fileName, "r");
    if (!file)
        return NULL;

    countStrings = 0;
    char val[MAX_STRING_LENGTH] = "";
    int iThread = 0;
    char* context;
    for (int i = 0; fgets(val, sizeof(val), file) != NULL;) {
        char* token = strtok_s(val, " \n", &context);
        while (token != NULL) {
            numbers[iThread][i/ THREAD_COUNT] = atoi(token);
            iThread = (iThread + 1) % THREAD_COUNT;

            token = strtok_s(NULL, " \n", &context);
            countStrings++;
            i++;
        }
    }
    fclose(file);
}

void CreateExitThread(const char* fileName) {
    FILE* file = fopen(fileName, "w+");

    int p[THREAD_START] = { 0 };
    char strings[THREAD_START][MAX_STRING_LENGTH] = { '\0' };
    for (int i = 0; i < THREAD_COUNT; i++)
            strcpy_s(strings[i], MAX_STRING_LENGTH, str[i][0]);

    for (int i = 0; i < countStrings; i++) {
        int ind = FindFirstString(strings);
        fprintf(file, strings[ind]);
        p[ind]++;
        if (p[ind] >= MAX_STRINGS_COUNT)
            strings[p[ind]][0] = '\0';
        else
            strcpy_s(strings[ind], MAX_STRING_LENGTH, str[ind][p[ind]]);
    }
    fclose(file);
}

void CreateExitThreadForNumbers(const char* fileName) {
    FILE* file = fopen(fileName, "w+");

    int p[THREAD_START] = { 0 };
    int nums[THREAD_START] = { 0 };
    for (int i = 0; i < THREAD_COUNT; i++)
        nums[i] = numbers[i][0];

    for (int i = 0; i < countStrings; i++) {
        int ind = FindFirstNumber(nums);
        fprintf(file, "%d ", nums[ind]);
        if ((i + 1) % 20 == 0)
            fprintf(file, "\n");

        p[ind]++;
        if (p[ind] >= MAX_NUMBERS_COUNT) {
            p[ind]--;
            nums[p[ind]] = INT_MAX;
        }
        else
            nums[ind] = numbers[ind][p[ind]];
    }
    fclose(file);
}

int FindFirstString(char strings[THREAD_START][MAX_STRING_LENGTH]) {
    int iFirst = 0;
    for (iFirst = 0; iFirst < THREAD_COUNT && strings[iFirst][0] == '\0'; iFirst++);
    char result[MAX_STRING_LENGTH];
    strcpy_s(result, MAX_STRING_LENGTH, strings[iFirst]);
    for (int i = 1; i < THREAD_COUNT; i++) {
        char str1[MAX_STRING_LENGTH], str2[MAX_STRING_LENGTH];
        strcpy_s(str1, MAX_STRING_LENGTH, result);
        strcpy_s(str2, MAX_STRING_LENGTH, strings[i]);
        to_uppercase(str1);
        to_uppercase(str2);
        if (strings[i][0] != '\0' && strcmp(str2, str1) < 0) {
            strcpy_s(result, MAX_STRING_LENGTH, strings[i]);
            iFirst = i;
        }
    }
    return iFirst;
}

int FindFirstNumber(int nums[THREAD_START]) {
    int iFirst = 0;
    for (iFirst = 0; iFirst < THREAD_COUNT && nums[iFirst] == INT_MAX; iFirst++);
    int result = nums[iFirst];

    for (int i = 1; i < THREAD_COUNT; i++) {
        if (nums[i] != INT_MAX && nums[i] < nums[iFirst]) {
            result = nums[i];
            iFirst = i;
        }
    }
    return iFirst;
}

void to_uppercase(char* str) {
    for (int i = 0; str[i] != '\0'; i++) {
        str[i] = toupper((unsigned char)str[i]); 
    }
}