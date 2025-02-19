#pragma once
#include <Windows.h>

HWND createButton(int x, int y, int w, LPCWSTR text, int ID, HWND parent);

HWND createEntry(int x, int y, HWND parent);

HWND createLabel(int x, int y, LPARAM lParam, LPCWSTR caption, HWND parent);

HWND createCheckbox(int x, int y, LPARAM lParam, LPCWSTR caption, int ID, HWND parent);