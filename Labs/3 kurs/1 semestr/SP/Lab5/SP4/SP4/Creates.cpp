#pragma once
#include "Creates.h"

extern HFONT hFont;

HWND createButton(int x, int y, int w, LPCWSTR text, int ID, HWND parent) {
    HWND button = CreateWindow(
        L"BUTTON",
        text,
        WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON,
        x,
        y,
        w,
        35,
        parent,
        (HMENU)ID,
        (HINSTANCE)GetWindowLongPtr(parent, GWLP_HINSTANCE),
        NULL);
    SendMessage(button, WM_SETFONT, (WPARAM)hFont, TRUE);
    return button;
}

HWND createEntry(int x, int y, HWND parent) {
    HWND entry = CreateWindow(
        L"EDIT",
        L"",
        WS_CHILD | WS_VISIBLE | WS_BORDER | ES_LEFT,
        x,
        y,
        300,
        30,
        parent,
        NULL,
        (HINSTANCE)GetWindowLongPtr(parent, GWLP_HINSTANCE),
        NULL);

    SendMessage(entry, WM_SETFONT, (WPARAM)hFont, TRUE);
    return entry;
}

HWND createLabel(int x, int y, LPARAM lParam, LPCWSTR caption, HWND parent) {
    HWND label = CreateWindow(
        L"STATIC",
        caption,
        WS_VISIBLE | WS_CHILD,
        x, y, 300, 20,
        parent,
        NULL,
        ((LPCREATESTRUCT)lParam)->hInstance,
        NULL
    );
    SendMessage(label, WM_SETFONT, (WPARAM)hFont, TRUE);
    return label;
}

HWND createCheckbox(int x, int y, LPARAM lParam, LPCWSTR caption, int ID, HWND parent) {
    HWND checkbox = CreateWindow(
        L"BUTTON",
        caption,
        WS_VISIBLE | WS_CHILD | BS_AUTOCHECKBOX,
        x, y, 100, 20,
        parent,
        (HMENU)ID,
        ((LPCREATESTRUCT)lParam)->hInstance,
        NULL
    );
    SendMessage(checkbox, WM_SETFONT, (WPARAM)hFont, TRUE);
    return checkbox;
}