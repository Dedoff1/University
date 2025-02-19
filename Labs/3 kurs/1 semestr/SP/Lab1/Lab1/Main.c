#include <windows.h>
#include <math.h>
#define M_PI 3.14159265358979323846

struct Square {
    int x;
    int y;
    int width;
    int height;
};


struct Square square = { 100, 100, 50, 50 };
float angle = 0.0f; 


POINT points[4];


void ChangePoints(int x, int y, int alpha) {
    float rad = alpha * M_PI / 180.0f;
    float rotMatrix[2][2] = { {cos(rad), -sin(rad)}, {sin(rad), cos(rad)} };

    for (int i = 0; i < 4; i++) {
        points[i].x += x;
        points[i].y += y;
    }

    float CenterX = (points[0].x + points[1].x + points[2].x + points[3].x) / 4;
    float CenterY = (points[0].y + points[1].y + points[2].y + points[3].y) / 4;

    for (int i = 0; i < 4; i++) {
        POINT p = { 0, 0 };
        points[i].x -= CenterX;
        points[i].y -= CenterY;

        
        p.x = points[i].x * rotMatrix[0][0] + points[i].y * rotMatrix[0][1];
        p.y = points[i].x * rotMatrix[1][0] + points[i].y * rotMatrix[1][1];

        points[i].x = p.x + CenterX;
        points[i].y = p.y + CenterY;
    }
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {
    switch (message) {
    case WM_PAINT: {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);

       
        HBRUSH brush = CreateSolidBrush(RGB(255, 0, 0));
        SelectObject(hdc, brush);

       
        points[0].x = square.x;
        points[0].y = square.y;
        points[1].x = square.x + square.width;
        points[1].y = square.y;
        points[2].x = square.x + square.width;
        points[2].y = square.y + square.height;
        points[3].x = square.x;
        points[3].y = square.y + square.height;


       
        ChangePoints(0, 0, angle);

       
        Polygon(hdc, points, 4);
        DeleteObject(brush);

        EndPaint(hWnd, &ps);
        return 0;
    }
    case WM_KEYDOWN: {
        switch (wParam) {
        case VK_LEFT:
        case 'A':
            if (square.x >= 10)
                square.x -= 10; break; 
        case VK_RIGHT:
        case 'D':
            if (square.x <= 420)
                square.x += 10; break;
        case VK_UP:
        case 'W':
            if (square.y >= 10)
                square.y -= 10; break; 
        case VK_DOWN:
        case 'S':
            if (square.y <= 400)
                square.y += 10; break;
        case 'Q':
            angle -= 10; break; 
        case 'E':
            angle += 10; break; 
        }
        InvalidateRect(hWnd, NULL, TRUE); 
        return 0;
    }
    case WM_MOUSEWHEEL: {
        int delta = GET_WHEEL_DELTA_WPARAM(wParam);
        if (delta > 0) {
            if (GetKeyState(VK_MENU) & 0x8000) 
            {
               
                if (square.x <= 420)
                    square.x += 10;
            }
            else
            {
                
                if (square.y >= 10)
                    square.y -= 10;
            }
        }
        else if (delta < 0) {
            if (GetKeyState(VK_MENU) & 0x8000) 
            {
                
                if (square.x >= 10)
                    square.x -= 10;
            }
            else
            {
                
                if (square.y <= 400)
                    square.y += 10;
            }
        }
        InvalidateRect(hWnd, NULL, TRUE);
        return 0;
    }
    case WM_SYSKEYDOWN:
        if (wParam == 'Q') {
            int result = MessageBox(hWnd, L"Are you sure you want to quit?", L"Quitting", MB_YESNO | MB_ICONQUESTION);
            if (result == IDYES) {
                PostQuitMessage(0);
            }
        }
        return 0;
    case WM_CLOSE: {
        int result = MessageBox(hWnd, L"Are you sure you want to quit?", L"Quitting", MB_YESNO | MB_ICONQUESTION);
        if (result == IDYES) {
            PostQuitMessage(0);
        }
        return 0;
    }
    case WM_DESTROY:
        PostQuitMessage(0);
        return 0;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
}

int APIENTRY WinMain(HINSTANCE hInstance,
    HINSTANCE hPrevInstance,
    LPTSTR lpCmdLine,
    int nCmdShow) {

   
    WNDCLASSEX wcex;
    wcex.cbSize = sizeof(WNDCLASSEX);
    wcex.style = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc = WndProc;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    wcex.hIcon = LoadIcon(NULL, IDI_APPLICATION);
    wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
    wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
    wcex.lpszMenuName = NULL;
    wcex.lpszClassName = L"MyWindowClass";
    wcex.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

    if (!RegisterClassEx(&wcex)) {
        MessageBox(NULL, L"Не удалось зарегистрировать класс окна", L"Ошибка", MB_OK | MB_ICONERROR);
        return 1;
    }

    
    HWND hWnd = CreateWindowEx(
        0,
        L"MyWindowClass",
        L"SP Lab1",
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, CW_USEDEFAULT,
        500, 500,
        NULL, NULL, hInstance, NULL
    );

    if (!hWnd) {
        MessageBox(NULL, L"Не удалось создать окно", L"Ошибка", MB_OK | MB_ICONERROR);
        return 1;
    }

    
    ShowWindow(hWnd, nCmdShow);
    UpdateWindow(hWnd);

   
    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return (int)msg.wParam;
}
