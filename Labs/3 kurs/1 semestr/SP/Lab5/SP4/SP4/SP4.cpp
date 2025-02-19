#include "framework.h"
#include "SP4.h"
#include <vector>
#include <string>
#include <algorithm>
#include <memory>
#include "Form.h"

#define MAX_LOADSTRING 100

HINSTANCE hInst;
WCHAR szTitle[MAX_LOADSTRING];
WCHAR szWindowClass[MAX_LOADSTRING];
HFONT hFont;

using std::vector, std::exception, 
std::to_wstring, std::wstring, std::unique_ptr;

ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
    _In_opt_ HINSTANCE hPrevInstance,
    _In_ LPWSTR    lpCmdLine,
    _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_SP4, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    hFont = CreateFont(
        20,
        0,
        0,
        0,
        FW_NORMAL,
        FALSE,
        FALSE,
        FALSE,
        DEFAULT_CHARSET,
        OUT_DEFAULT_PRECIS,
        CLIP_DEFAULT_PRECIS,
        DEFAULT_QUALITY,
        DEFAULT_PITCH | FF_SWISS,
        L"Arial");

    if (!InitInstance(hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_SP4));

    MSG msg;

    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int)msg.wParam;
}

ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc = WndProc;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    //wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_SP4));
    wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground = CreateSolidBrush(RGB(0, 0, 255));
    //wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
    wcex.lpszMenuName = nullptr;
    wcex.lpszClassName = szWindowClass;
    wcex.hIcon = LoadIcon(nullptr, IDI_APPLICATION);
    //wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));
    if (wcex.hIcon == NULL) {
        MessageBox(NULL, L"Failed to load standard icon!", L"Error", MB_OK | MB_ICONERROR);
        return 0;
    }
    wcex.hIconSm = LoadIcon(nullptr, IDI_APPLICATION); // Use the standard app icon for small icon, too
    return RegisterClassExW(&wcex);
}

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
    hInst = hInstance;

    const int WINDOW_WIDTH = 600;
    const int WINDOW_HEIGHT = 600;

    HWND hWnd = CreateWindowW(
        szWindowClass,
        szTitle,
        WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU,
        CW_USEDEFAULT,
        CW_USEDEFAULT,
        WINDOW_WIDTH,
        WINDOW_HEIGHT,
        nullptr,
        nullptr,
        hInstance,
        nullptr
    );

    if (!hWnd) return FALSE;

    ShowWindow(hWnd, nCmdShow);
    UpdateWindow(hWnd);

    return TRUE;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {

    static unique_ptr<Form> form{nullptr};

    switch (message)
    {
    case WM_CREATE:
    {
        form.reset(new Form(lParam, hWnd));
        break;
    }
    case WM_COMMAND:
    {
        int wmId = LOWORD(wParam);
        switch (wmId)
        {
        case IDM_EXIT:
            DestroyWindow(hWnd);
            break;
        case BTN_FIND:
        {
            form->onBtnFind();
            break;
        }
        case BTN_REPEAT:
        {
            form->onBtnRepeat();
            break;
        }
        case BTN_SET:
        {
            form->onBtnSet();
            break;
        }
        case BTN_INJECT:
            form->onInject();
            break;
        case CHECKBOX1:
            form->onCheckboxPress(1);
            break;
        case CHECKBOX2:
            form->onCheckboxPress(2);
            break;
        default:
            return DefWindowProc(hWnd, message, wParam, lParam);
        }
        break;
    }
    case WM_PAINT:
    {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);
        EndPaint(hWnd, &ps);
        break;
    }
    case WM_DESTROY:
        //DeleteObject(wcex.hbrBackground); //Add this line
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}