#include "Form.h"
#include "Creates.h"
#include "dll4.h"

#include <memory>
#include <iterator>
#include <algorithm>

#ifdef STATIC
#pragma comment(lib, "dll4.lib")
#endif

using std::exception, std::to_wstring, std::unique_ptr, std::string;

BOOL InjectDLL(DWORD processID, const wstring& dllPath) {
    auto procCloser = [](HANDLE proc) {
        if (proc) CloseHandle(proc);
    };
    unique_ptr<void, decltype(procCloser)> hProcess {
        OpenProcess(PROCESS_ALL_ACCESS, FALSE, processID),
        procCloser
    };

    LPVOID pRemotePath = VirtualAllocEx(hProcess.get(), NULL, (dllPath.size() + 1) * sizeof(wchar_t), MEM_COMMIT, PAGE_READWRITE);

    auto result = WriteProcessMemory(hProcess.get(), pRemotePath, 
        dllPath.c_str(), (dllPath.size() + 1) * sizeof(wchar_t), NULL);
    if (!result) return FALSE;

    HMODULE hKernel32 = GetModuleHandle(L"kernel32.dll");
    FARPROC pLoadLibraryW = GetProcAddress(hKernel32, "LoadLibraryW");

    unique_ptr<void, decltype(procCloser)> hThread{
        CreateRemoteThread(hProcess.get(), NULL, 0, (LPTHREAD_START_ROUTINE)pLoadLibraryW, pRemotePath, 0, NULL),
        procCloser };

    WaitForSingleObject(hThread.get(), INFINITE);
    VirtualFreeEx(hProcess.get(), pRemotePath, 0, MEM_RELEASE);
    return TRUE;
}

Form::Form(LPARAM lParam, HWND _hWnd) : hWnd(_hWnd) {
#ifndef STATIC
    dll4 = LoadLibrary(L"dll4.dll");
    if (dll4 != nullptr) {
        repeat = (TRepeat)GetProcAddress(dll4, "?Repeat@@YA?AV?$vector@PEAXV?$allocator@PEAX@std@@@std@@PEAXAEBV12@PEBD_K@Z");
        search = (TSearch)GetProcAddress(dll4, "?Search@@YA?AV?$vector@PEAXV?$allocator@PEAX@std@@@std@@PEAXPEBD_K@Z");
        setvalues = (TSet)GetProcAddress(dll4, "?setValues@@YA_KPEAXAEBV?$vector@PEAXV?$allocator@PEAX@std@@@std@@PEBD_K@Z");

    }
#endif
    hLabelPID = createLabel(50, 20, lParam, L"Enter the ID of process:", hWnd);
    hLabelValue = createLabel(50, 90, lParam, L"Enter value:", hWnd);
    btnFind = createButton(50, 225, 100, L"Search", BTN_FIND, hWnd);
    btnRepeat = createButton(175, 225, 100, L"Filter", BTN_REPEAT, hWnd);
    btnSet = createButton(300, 225, 200, L"Set", BTN_SET, hWnd);
    btnInject = createButton(175, 275, 100, L"Inject", BTN_INJECT, hWnd);

    hLabel = createLabel(50, 400, lParam, L"", hWnd);

    hCheckbox = createCheckbox(75, 180, lParam, L"Number", CHECKBOX1, hWnd);
    hCheckbox2 = createCheckbox(225, 180, lParam, L"String", CHECKBOX2, hWnd);

    hEdit = createEntry(50, 120, hWnd);
    hPID = createEntry(50, 50, hWnd);

    SendMessage(hEdit, EM_LIMITTEXT, (WPARAM)9, 0);
    SendMessage(hPID, EM_LIMITTEXT, (WPARAM)5, 0);
    SendMessage(hCheckbox, BM_SETCHECK, BST_CHECKED, 0);

    ShowWindow(hLabel, SW_HIDE);
}

Form::~Form() {
#ifndef STATIC
    if (dll4) {
        FreeLibrary(dll4);
    }
#endif
}

void Form::onBtnFind() {
    visible = false;
    ShowWindow(hLabel, visible ? SW_SHOW : SW_HIDE);
    vec.clear();

    if (BOOL result = onBtnPress(FIND); !result) return;

    visible = true;
    ShowWindow(hLabel, visible ? SW_SHOW : SW_HIDE);
    wstring caption = L"Elements: " + to_wstring(static_cast<int>(vec.size())) + L" found";
    SetWindowText(hLabel, caption.c_str());
}

void Form::onBtnRepeat() {
    visible = false;
    ShowWindow(hLabel, visible ? SW_SHOW : SW_HIDE);

    if (BOOL result = onBtnPress(REPEAT); !result) return;

    visible = true;
    ShowWindow(hLabel, visible ? SW_SHOW : SW_HIDE);
    wstring caption = L"Elements: " + to_wstring(static_cast<int>(vec.size())) + L" found";
    SetWindowText(hLabel, caption.c_str());
}

void Form::onBtnSet() {
    visible = false;
    ShowWindow(hLabel, visible ? SW_SHOW : SW_HIDE);

    if (BOOL result = onBtnPress(SET);
        !result) return;

    wstring caption = L"Elements: " + to_wstring(static_cast<int>(vec.size())) + L" changed";
    MessageBox(hWnd, caption.c_str(), L"Successful", MB_OK);
};

BOOL Form::onInject() {
    visible = false;
    ShowWindow(hLabel, visible ? SW_SHOW : SW_HIDE);
    vec.clear();
    DWORD PID{ 0 };
    try {
        PID = getDword(hPID);
    }
    catch (exception e) {
        MessageBox(hWnd, L"Warning: Enter value.", L"Warning", MB_OK | MB_ICONERROR);
        return FALSE;
    }
    return InjectDLL(PID, L"D:\\Projects\\Uni\\Labs\\3 kurs\\1 semestr\\SP\\Lab5\\Inject\\x64\\Debug\\Inject.dll");
}

void Form::onCheckboxPress(int number) const {
    SetWindowText(hEdit, L"");

    switch (number) {
    case 1:
        SendMessage(hEdit, EM_LIMITTEXT, (WPARAM)10, 0);
        SendMessage(hCheckbox, BM_SETCHECK, BST_CHECKED, 0);
        SendMessage(hCheckbox2, BM_SETCHECK, BST_UNCHECKED, 0);
        break;
    case 2:
        SendMessage(hEdit, EM_LIMITTEXT, (WPARAM)30, 0);
        SendMessage(hCheckbox, BM_SETCHECK, BST_UNCHECKED, 0);
        SendMessage(hCheckbox2, BM_SETCHECK, BST_CHECKED, 0);
        break;
    }
}

BOOL Form::onBtnPress(Mode m) {

    DWORD PID{ 0 };
    try {
        PID = getDword(hPID);
    }
    catch (exception e) {
        MessageBox(hWnd, L"Warning: Enter value.", L"Warning", MB_OK | MB_ICONERROR);
        return FALSE;
    }
    DWORD FLAG = (m == SET) ?
        (PROCESS_VM_WRITE | PROCESS_VM_OPERATION) :
        (PROCESS_VM_READ | PROCESS_QUERY_INFORMATION);

    HANDLE hProcess = OpenProcess(FLAG, FALSE, PID);

    if (hProcess == nullptr) {
        MessageBox(hWnd, L"Warning: Thread not found", L"Warning", MB_OK | MB_ICONERROR);
        return FALSE;
    }

    LRESULT state = SendMessage(hCheckbox, BM_GETCHECK, 0, 0);
    SIZE_T size{ 0 };
    char* cdata{ nullptr };

    try {
        if (state == BST_CHECKED) {
            DWORD toFind = getDword(hEdit);
            cdata = reinterpret_cast<char*>(&toFind);
            size = sizeof(DWORD);
        }
        else {
            wstring wstr = getWstr(hEdit);
            wchar_t* cwdata = const_cast<wchar_t*>(wstr.c_str());
            cdata = reinterpret_cast<char*>(cwdata);
            size = wstr.size() * 2;
        }
#ifdef STATIC
        switch (m) {
        case FIND:
            vec = Search(hProcess, cdata, size);
            break;
        case REPEAT:
            vec = Repeat(hProcess, vec, cdata, size);
            break;
        case SET:
            return !!setValues(hProcess, vec, cdata, size);
        }
#else
        switch (m) {
        case FIND:
            vec = search(hProcess, cdata, size);
            break;
        case REPEAT:
            vec = repeat(hProcess, vec, cdata, size);
            break;
        case SET:
            return !!setvalues(hProcess, vec, cdata, size);
        }
#endif
    }
    catch (exception e) {
        MessageBox(hWnd, L"Warning: Check your data.", L"Warning", MB_OK | MB_ICONERROR);
        return FALSE;
    }
    return TRUE;
};

DWORD Form::getDword(HWND entry) {
    wchar_t buffer[256];
    GetWindowText(entry, buffer, 256);
    wchar_t* endPtr;

    auto value = wcstoul(buffer, &endPtr, 10);

    if (*endPtr != L'\0' || buffer == endPtr) {
        throw exception();
    }
    return static_cast<DWORD>(value);
}

wstring Form::getWstr(HWND entry) {
    wchar_t buffer[256];
    GetWindowText(entry, buffer, 256);
    if (*buffer == L'\0') {
        throw exception();
    }
    return wstring{ buffer };
}