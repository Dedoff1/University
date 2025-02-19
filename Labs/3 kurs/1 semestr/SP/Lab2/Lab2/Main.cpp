#include <windows.h>
#include <string> 

struct TableRow {
    std::wstring text; 
    int height; 
};

struct Table {
    int columns; 
    int rows; 
    TableRow* rowsData; 
    int cellWidth; 
};

Table table;

int GetRowHeight(HDC hdc, const wchar_t* text) {
    SIZE textSize = { 0 };
    GetTextExtentPoint32(hdc, text, wcslen(text), &textSize);
    return textSize.cy; 
}


LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam) {
    switch (message) {
    case WM_CREATE:
    {
       
        table.columns = 5; 
        table.rows = 3; 
        table.rowsData = new TableRow[table.rows * table.columns];

       
        for (int row = 0; row < table.rows; ++row) {
            for (int col = 0; col < table.columns; ++col) {
                table.rowsData[row * table.columns + col].text = L"Ячейка " + std::to_wstring(row + 1) + L"," + std::to_wstring(col + 1);
            }
        }

        HDC hdc = GetDC(hWnd);
        for (int i = 0; i < table.rows; i++) {
            for (int j = 0; j < table.columns; j++) {
                int index = i * table.columns + j;
                table.rowsData[index].height = GetRowHeight(hdc, table.rowsData[index].text.c_str());
            }
        }
        ReleaseDC(hWnd, hdc);

        RECT clientRect;
        GetClientRect(hWnd, &clientRect);
        table.cellWidth = clientRect.right / table.columns;

        break;
    }
    case WM_SIZE:
    {
       
        RECT clientRect;
        GetClientRect(hWnd, &clientRect);
        table.cellWidth = clientRect.right / table.columns;
        InvalidateRect(hWnd, NULL, TRUE); 
        break;
    }
    case WM_PAINT:
    {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);

        
        int x = 0;
        int y = 0;
        for (int row = 0; row < table.rows; row++) {
            for (int col = 0; col < table.columns; col++) {
                
                Rectangle(hdc, x, y, x + table.cellWidth, y + table.rowsData[row * table.columns + col].height);

               
                TextOut(hdc, x + 5, y + 5, table.rowsData[row * table.columns + col].text.c_str(), (int)table.rowsData[row * table.columns + col].text.length());

                x += table.cellWidth;
            }
            x = 0;
            y += table.rowsData[row * table.columns].height;
        }

        EndPaint(hWnd, &ps);
        break;
    }
    case WM_DESTROY:
    {
       
        delete[] table.rowsData;
        PostQuitMessage(0);
        break;
    }
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow) {

    WNDCLASS wc = {};
    wc.lpfnWndProc = WndProc;
    wc.hInstance = hInstance;
    wc.lpszClassName = L"SampleWindowClass";

    RegisterClass(&wc);

    HWND hWnd = CreateWindowEx(
        0,
        L"SampleWindowClass",
        L"Таблица",
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT,
        NULL,
        NULL,
        hInstance,
        NULL
    );

    ShowWindow(hWnd, nCmdShow);

    
    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return 0;
}
