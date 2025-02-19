#include <windows.h>
#include <stdio.h>

#define BUTTON_WIDTH 100 
#define BUTTON_HEIGHT 30 

#define MAX_KEYS 256
#define MAX_VALUES 256
#define MAX_KEY_LENGTH 255
#define MAX_VALUE_NAME 255

#define ID_OPEN_KEY 1
#define ID_READ_VALUE 2
#define ID_SET_VALUE 3
#define ID_CREATE_KEY 4
#define ID_DELETE_KEY 5
#define ID_SET_DATA 6
#define ID_BACK 7
#define ID_CREATE_VALUE 8
#define ID_DELETE_VALUE 9
#define ID_READ_TYPE 10

#define IDC_LISTBOX_KEYS 11
#define IDC_LISTBOX_VALUES 12
#define IDC_MY_COMBOBOX 13
#define ID_EDIT 14
#define ID_LABEL_KEY 15
#define ID_LABEL_VALUE 16

#define ACTION_CREATE_KEY 17
#define ACTION_SET_VALUE 18
#define ACTION_CREATE_VALUE 19


typedef struct{
    char* btnName;
    int btnId;
} buts;

buts btnInfo[] = {
    {"Open Key", ID_OPEN_KEY},
    {"Back", ID_BACK},
    {"Create Key", ID_CREATE_KEY},
    {"Delete Key", ID_DELETE_KEY},
    {"Create Value", ID_CREATE_VALUE},
    {"Read Value", ID_READ_VALUE},
    {"Set Value", ID_SET_VALUE},
    {"Delete Value", ID_DELETE_VALUE},
    {"Read Type", ID_READ_TYPE},
    {NULL, 0}
};

typedef struct {
    char name[MAX_KEY_LENGTH];
} KeyInfo;

typedef struct {
    char name[MAX_VALUE_NAME];
    BYTE data[MAX_VALUE_NAME];
    DWORD dataType;
} ValueInfo;

const char* subKey = "";
char valueName[MAX_KEY_LENGTH] = { "\0" };
char newValue[MAX_KEY_LENGTH] = { "\0" };
char chosenFile[MAX_KEYS][MAX_KEY_LENGTH] = {'\0'};
HKEY hKeys[MAX_KEYS] = { HKEY_CURRENT_USER };
int pointer = 0;

DWORD subKeyCount, valueCount;
KeyInfo keys[MAX_KEYS];
ValueInfo values[256];

int action = 0;

static HWND hListBoxKeys, hListBoxValues;
static HWND hEdit, hBtnOk, hComboBox;

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
int OpenRegistryKeyForFirst(HWND hwnd);
int OpenRegistryKey(HWND hwnd, const char* keyName, int i);
void ReadRegistryValue(HWND hwnd, const char* valueName);
void SetRegistryValue(HWND hwnd, const char* valueName, const char* newValue, DWORD type);
void DeleteRegistryValue(HWND hwnd, const char* valueName);
void CreateRegistryKey(HWND hwnd, const char* valueName);
void DeleteRegistryKey(HWND hwnd, const char* valueName);
void ShowRegistryKeysAndValues(HWND hwnd);
void FillDataAboutKey(int i);
void ReadRegistryType(HWND hwnd, const char* valueName);
const char* GetRegTypeName(DWORD dataType);
DWORD GetRegType(const char* type);
int GetIdOfType(DWORD type);
DWORD GetType(HWND hwnd, const char* valueName);
char* GetData(HWND hwnd, const char* valueName);

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
    wcex.lpszClassName = "Lab3";
    wcex.hIconSm = wcex.hIcon;
    RegisterClassEx(&wcex);
    hWnd = CreateWindow("Lab3", L"Third lab",
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
    switch (uMsg) {
    case WM_ERASEBKGND: {
        HDC hdc = (HDC)wParam;
        RECT rect;
        GetClientRect(hwnd, &rect);
        HBRUSH hBrush = CreateSolidBrush(RGB(0, 0, 255));
        FillRect(hdc, &rect, hBrush);
        DeleteObject(hBrush);
        return 1; 
    }
    case WM_CTLCOLORSTATIC: { 
        HDC hdcStatic = (HDC)wParam;
        HWND hWndStatic = (HWND)lParam;
        SetBkMode(hdcStatic, TRANSPARENT); 
        SetTextColor(hdcStatic, RGB(255, 255, 0)); 
        return (LRESULT)GetStockObject(NULL_BRUSH); 
    }
  
    case WM_CREATE: {
        int i = 0;
        for (i = 0; btnInfo[i].btnName != NULL; i++) {
            CreateWindowA("BUTTON", btnInfo[i].btnName,
                WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
                10 * (i + 1) + BUTTON_WIDTH * i, 10, BUTTON_WIDTH, BUTTON_HEIGHT,
                hwnd, (HMENU)btnInfo[i].btnId, NULL, NULL);
        }

        hEdit = CreateWindowA("EDIT", "",
            WS_CHILD | WS_VISIBLE | WS_BORDER,
            50 + 10 * (i + 1) + BUTTON_WIDTH * i, 10, BUTTON_WIDTH, 30,
            hwnd, (HMENU)ID_EDIT, NULL, NULL);
        ShowWindow(hEdit, SW_HIDE);

        hComboBox = CreateWindowA("COMBOBOX", "", WS_CHILD | WS_VISIBLE | CBS_DROPDOWNLIST,
            50 + 10 * (i + 1) + BUTTON_WIDTH * i, 50, 200, 150 / 9 * 7,
            hwnd, (HMENU)IDC_MY_COMBOBOX, NULL, NULL);
        ShowWindow(hComboBox, SW_HIDE);
        char* items[] = { "REG_SZ", "REG_DWORD", "REG_BINARY", "REG_EXPAND_SZ", "REG_MULTI_SZ", NULL };
        for (int j = 0; items[j] != NULL; ++j) {
            SendMessageA(hComboBox, CB_ADDSTRING, 0, (LPARAM)items[j]);
        }
        SendMessageA(hComboBox, CB_SETCURSEL, 0, 0);
        i++;

        hBtnOk = CreateWindowA("BUTTON", "OK",
            WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
            50 + 10 * (i + 1) + BUTTON_WIDTH * i, 10, BUTTON_WIDTH, BUTTON_HEIGHT,
            hwnd, (HMENU)ID_SET_DATA, NULL, NULL);
        ShowWindow(hBtnOk, SW_HIDE);
        i++;

        CreateWindowA("static", " Keys",
            WS_CHILD | WS_VISIBLE | WS_TABSTOP,
            10, 50, 300, 20,
            hwnd, (HMENU)ID_LABEL_KEY, (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);

        hListBoxKeys = CreateWindowA("LISTBOX", "Keys", WS_CHILD | WS_VISIBLE | LBS_NOTIFY,
            10, 90, 300, 150,
            hwnd, (HMENU)IDC_LISTBOX_KEYS,
            (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);

        CreateWindowA("static", " Values",
            WS_CHILD | WS_VISIBLE | WS_TABSTOP,
            320, 50, 300, 20,
            hwnd, (HMENU)ID_LABEL_VALUE, NULL, NULL);

        hListBoxValues = CreateWindowA("LISTBOX", "Values", WS_CHILD | WS_VISIBLE | LBS_NOTIFY,
            320, 90, 200, 150,
            hwnd, (HMENU)IDC_LISTBOX_VALUES,
            (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);

        OpenRegistryKeyForFirst(hwnd);

        break;
    }
    case WM_COMMAND: {
        switch (LOWORD(wParam)) {
        case ID_OPEN_KEY: {
            pointer -= OpenRegistryKey(hwnd, chosenFile[pointer], 1);
            pointer++;
            valueName[0] = '\0';
            break;
        }
        case ID_READ_VALUE: {
            ReadRegistryValue(hwnd, valueName);
            break;
        }
        case ID_SET_VALUE: {
            SendMessageA(hComboBox, CB_SETCURSEL, GetIdOfType(GetType(hwnd, valueName)), 0);
            SetWindowTextA(hEdit, GetData(hwnd, valueName));
            ShowWindow(hEdit, SW_SHOW);
            ShowWindow(hBtnOk, SW_SHOW);
            ShowWindow(hComboBox, SW_SHOW);
            action = ACTION_SET_VALUE;
            break;
        }
        case ID_DELETE_VALUE: {
            DeleteRegistryValue(hwnd, valueName);
            FillDataAboutKey(0);
            ShowRegistryKeysAndValues(hwnd);
            break;
        }
        case ID_CREATE_KEY: {
            ShowWindow(hEdit, SW_SHOW);
            ShowWindow(hBtnOk, SW_SHOW);
            action = ACTION_CREATE_KEY;
            break;
        }
        case ID_DELETE_KEY: {
            DeleteRegistryKey(hwnd, chosenFile[pointer]);
            break;
        }
        case ID_SET_DATA: {
            switch (action) {
            case ACTION_CREATE_KEY: {
                int length = GetWindowTextA(hEdit, valueName, sizeof(valueName));
                action = 0;
                ShowWindow(hEdit, SW_HIDE);
                ShowWindow(hBtnOk, SW_HIDE);
                SetWindowTextA(hEdit, "");
                CreateRegistryKey(hwnd, valueName);
                break;
            }
            case ACTION_SET_VALUE: {
                int length = GetWindowTextA(hEdit, newValue, sizeof(newValue));
                char tmp[MAX_KEY_LENGTH] = { '\0' };
                GetWindowTextA(hComboBox, tmp, sizeof(tmp));
                action = 0;
                ShowWindow(hEdit, SW_HIDE);
                SetWindowTextA(hEdit, "");
                ShowWindow(hBtnOk, SW_HIDE);
                ShowWindow(hComboBox, SW_HIDE);
                SetRegistryValue(hwnd, valueName, newValue, GetRegType(tmp));
                break;
            }
            case ACTION_CREATE_VALUE: {
                int length = GetWindowTextA(hEdit, valueName, sizeof(valueName));
                action = 0;
                ShowWindow(hEdit, SW_HIDE);
                ShowWindow(hBtnOk, SW_HIDE);
                SetWindowTextA(hEdit, "");
                SetRegistryValue(hwnd, valueName, "", REG_SZ);
                FillDataAboutKey(0);
                ShowRegistryKeysAndValues(hwnd);
                break;
            }
            }
            break;
        }
        case ID_BACK: {
            pointer--;
            if (pointer > 0) {
                OpenRegistryKey(hwnd, chosenFile[pointer], 0);
                chosenFile[pointer + 1][0] = '\0';
                RegCloseKey(hKeys[pointer + 1]);
                hKeys[pointer + 1] = NULL;
            }
            else if (pointer == 0)
                OpenRegistryKeyForFirst(hwnd);
            else pointer++;

            ShowRegistryKeysAndValues(hwnd);
            break;
        }
        case ID_CREATE_VALUE: {
            ShowWindow(hEdit, SW_SHOW);
            ShowWindow(hBtnOk, SW_SHOW);
            action = ACTION_CREATE_VALUE;
            break;
        }
        case ID_READ_TYPE: {
            ReadRegistryType(hwnd, valueName);
            break;
        }
        }

        if (HIWORD(wParam) == LBN_SELCHANGE) {
            if ((HWND)lParam == hListBoxKeys) {

                int index = (int)SendMessage(hListBoxKeys, LB_GETCURSEL, 0, 0);
                int length = (int)SendMessage(hListBoxKeys, LB_GETTEXTLEN, index, 0);
                length++;
                SendMessageA(hListBoxKeys, LB_GETTEXT, index, (LPARAM)chosenFile[pointer]);
            }
        }

        if (HIWORD(wParam) == LBN_SELCHANGE && (HWND)lParam == hListBoxValues) {
            int index = (int)SendMessage(hListBoxValues, LB_GETCURSEL, 0, 0);
            int length = (int)SendMessage(hListBoxValues, LB_GETTEXTLEN, index, 0);
            length++;
            SendMessageA(hListBoxValues, LB_GETTEXT, index, (LPARAM)valueName);
        }
        break;
    }
    case WM_DESTROY: {
        for (int i = 0; i <= pointer; i++)
            RegCloseKey(hKeys[i]);
        PostQuitMessage(0);
        break;
    }
    default:
        return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }
    return 0;
}

int OpenRegistryKey(HWND hwnd, const char* keyName, int i) {
    if (RegOpenKeyExA(hKeys[pointer], keyName, 0, KEY_ALL_ACCESS, &hKeys[pointer + 1]) == ERROR_SUCCESS && (keyName != NULL && keyName[0] != '\0')) {
        FillDataAboutKey(i);
        ShowRegistryKeysAndValues(hwnd);
        return 0;
    }
    else {
        MessageBoxA(hwnd, "Failed to open key.", "Error", MB_OK | MB_ICONERROR);
        return 1;
    }
}

void ReadRegistryValue(HWND hwnd, const char* valueName) {
    LPDWORD dataType = REG_SZ;
    LPBYTE data[256] = {'\0'};
    LPDWORD dataSize = sizeof(data);

    if (RegQueryValueExA(hKeys[pointer], valueName, NULL, &dataType, data, &dataSize) == ERROR_SUCCESS)
            MessageBoxA(hwnd, (unsigned short*)data, "Value", MB_OK);
    else
        MessageBoxA(hwnd, "Failed to read value.", "Error", MB_OK | MB_ICONERROR);
}

void SetRegistryValue(HWND hwnd, const char* valueName, const char* newValue, DWORD type){
    if (RegSetValueExA(hKeys[pointer], valueName, 0, type, (const BYTE*)newValue, strlen(newValue) + 1) != ERROR_SUCCESS)
        MessageBoxA(hwnd, "Failed to set value.", "Error", MB_OK | MB_ICONERROR);
    else
        MessageBoxA(hwnd, "Value set successfully.", "Info", MB_OK);
}

void DeleteRegistryValue(HWND hwnd, const char* valueName) {
    if (RegDeleteValueA(hKeys[pointer], valueName) != ERROR_SUCCESS)
        MessageBoxA(hwnd, "Failed to delete value.", "Error", MB_OK | MB_ICONERROR);
    else
        MessageBoxA(hwnd, "Value deleted successfully.", "Info", MB_OK);
}

void CreateRegistryKey(HWND hwnd, const char* valueName) {
    HKEY hk;
    DWORD disposition;
    if (RegCreateKeyExA(hKeys[pointer], valueName, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hk, &disposition) == ERROR_SUCCESS) {
        FillDataAboutKey(0);
        ShowRegistryKeysAndValues(hwnd);
    }
    else {
        MessageBoxA(hwnd, "Failed to create key.", "Error", MB_OK | MB_ICONERROR);
    }
}

void DeleteRegistryKey(HWND hwnd, const char* valueName) {
    if (RegDeleteKeyExA(hKeys[pointer], valueName, KEY_WOW64_64KEY, 0) == ERROR_SUCCESS) {
        FillDataAboutKey(0);
        ShowRegistryKeysAndValues(hwnd);
    }
    else {
        MessageBoxA(hwnd, "Failed to delete key.", "Error", MB_OK | MB_ICONERROR);
    }
}

void ShowRegistryKeysAndValues(HWND hwnd) {
    int heigt = 150 / 9 * subKeyCount;

    SendMessageA(hListBoxKeys, LB_RESETCONTENT, 0, 0);
    SetWindowPos(hListBoxKeys, NULL, 10, 70, 300, heigt, SWP_NOZORDER);

    for (int i = 0; i < subKeyCount; i++) {
        SendMessageA(hListBoxKeys, LB_ADDSTRING, 0, (LPARAM)keys[i].name);
    }

    heigt = 150 / 9 * valueCount;

    SendMessageA(hListBoxValues, LB_RESETCONTENT, 0, 0);
    SetWindowPos(hListBoxValues, NULL, 320, 70, 200, heigt, SWP_NOZORDER);

    for (int i = 0; i < valueCount; i++) {
        SendMessageA(hListBoxValues, LB_ADDSTRING, 0, (LPARAM)values[i].name);
    }
}

void FillDataAboutKey(int i) {
    DWORD valueNameSize, valueDataSize;
    RegQueryInfoKey(hKeys[pointer + i], NULL, NULL, NULL, &subKeyCount, NULL, NULL, &valueCount, NULL, NULL, NULL, NULL);

    for (DWORD index = 0; index < subKeyCount && index < MAX_KEYS; ++index) {
        DWORD keyNameSize = MAX_KEY_LENGTH;
        RegEnumKeyExA(hKeys[pointer + i], index, keys[index].name, &keyNameSize, NULL, NULL, NULL, NULL);
    }

    for (DWORD index = 0; index < valueCount && index < MAX_VALUES; ++index) {
        valueNameSize = MAX_VALUE_NAME;
        valueDataSize = MAX_VALUE_NAME;
        values[index].dataType = 0;
        RegEnumValueA(hKeys[pointer + i], index, values[index].name, &valueNameSize, NULL, &values[index].dataType, values[index].data, &valueDataSize) == ERROR_SUCCESS;
    }
}

int OpenRegistryKeyForFirst(HWND hwnd) {
    if (RegOpenKeyExA(HKEY_CURRENT_USER, NULL, 0, KEY_ALL_ACCESS, &hKeys[pointer]) == ERROR_SUCCESS) {
        FillDataAboutKey(0);
        ShowRegistryKeysAndValues(hwnd);
        return 0;
    }
    else {
        MessageBoxA(hwnd, "Failed to open key.", "Error", MB_OK | MB_ICONERROR);
        return 1;
    }
}

void ReadRegistryType(HWND hwnd, const char* valueName) {
    LPDWORD dataType = REG_SZ;
    LPBYTE data[256] = { '\0' };
    LPDWORD dataSize = sizeof(data);

    if (RegQueryValueExA(hKeys[pointer], valueName, NULL, &dataType, data, &dataSize) == ERROR_SUCCESS)
        MessageBoxA(hwnd, (unsigned short*)GetRegTypeName(dataType), "Value", MB_OK);
    else
        MessageBoxA(hwnd, "Failed to read value.", "Error", MB_OK | MB_ICONERROR);
};

const char* GetRegTypeName(DWORD dataType) {
    switch (dataType) {
    case REG_SZ:
        return "REG_SZ";
    case REG_DWORD:
        return "REG_DWORD";
    case REG_BINARY:
        return "REG_BINARY";
    case REG_EXPAND_SZ:
        return "REG_EXPAND_SZ";
    case REG_MULTI_SZ:
        return "REG_MULTI_SZ";
    default:
        return "Unknown Type";
    }
}

DWORD GetRegType(const char* type) {
    if (strcmp(type, "REG_SZ") == 0)
        return REG_SZ;
    else if (strcmp(type, "REG_DWORD") == 0)
        return REG_DWORD;
    else if (strcmp(type, "REG_BINARY") == 0)
        return REG_BINARY;
    else if (strcmp(type, "REG_EXPAND_SZ") == 0)
        return REG_EXPAND_SZ;
    else if (strcmp(type, "REG_MULTI_SZ") == 0)
        return REG_MULTI_SZ;
}

int GetIdOfType(DWORD type) {
    char* items[] = { "REG_SZ", "REG_DWORD", "REG_BINARY", "REG_EXPAND_SZ", "REG_MULTI_SZ", NULL };
    for (int i = 0; items[i] != NULL; i++) {
        if (strcmp(items[i], GetRegTypeName(type)) == 0)
            return i;
    }
    return -1;
}

DWORD GetType(HWND hwnd, const char* valueName) {
    LPDWORD dataType = REG_SZ;
    LPBYTE data[256] = { '\0' };
    LPDWORD dataSize = sizeof(data);

    if (RegQueryValueExA(hKeys[pointer], valueName, NULL, &dataType, data, &dataSize) == ERROR_SUCCESS)
        return dataType;
    return REG_SZ;
}

char* GetData(HWND hwnd, const char* valueName) {
    LPDWORD dataType = REG_SZ;
    LPBYTE data[256] = { '\0' };
    LPDWORD dataSize = sizeof(data);

    if (RegQueryValueExA(hKeys[pointer], valueName, NULL, &dataType, data, &dataSize) == ERROR_SUCCESS)
        return data;
    return '\0';
}