#pragma once
#include <Windows.h>
#include <vector>
#include <string>
#include <memory>

#define BTN_FIND 1
#define BTN_REPEAT 2
#define BTN_SET 3
#define CHECKBOX1 4
#define CHECKBOX2 5
#define BTN_INJECT 6

//#define STATIC

using std::vector, std::wstring;

class Form {
public:
    Form(LPARAM lParam, HWND _hWnd);
    HWND hLabelPID;
    HWND hLabelValue;
    ~Form();

    void onBtnFind();

    void onBtnRepeat();

    void onBtnSet();

    BOOL onInject();

    void onCheckboxPress(int number) const;

private:
#ifndef STATIC
    HMODULE dll4;
    typedef vector<void*>(WINAPI* TRepeat)(HANDLE, const vector<void*>&, const char*, size_t);
    typedef vector<void*>(WINAPI* TSearch)(HANDLE, const char*, size_t);
    typedef SIZE_T(WINAPI* TSet)(HANDLE, const vector<void*>&, const char*, size_t);

    TRepeat repeat{ nullptr };
    TSet setvalues{ nullptr };
    TSearch search{ nullptr };
#endif

    HWND hWnd;
    HWND btnFind, btnRepeat, btnSet, btnInject;
    HWND hEdit, hPID;
    HWND hLabel, hCheckbox, hCheckbox2;
    bool visible{ false };
    vector<void*> vec;
    enum Mode {
        FIND,
        REPEAT,
        SET,
    };

    BOOL onBtnPress(Mode m);

    DWORD getDword(HWND entry);

    wstring getWstr(HWND entry);
};