#include "pch.h"
#include <Windows.h>
#include <string>


using std::wstring, std::to_wstring;

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    {
        wstring msg = L"Сообщение из DLL-инъекции " + to_wstring(GetProcessId(GetCurrentProcess()));
        for (int i = 0; i < 10; ++i)
        {
            MessageBox(NULL,
                msg.c_str(),
                (L"MessageBox " + std::to_wstring(i)).c_str(),
                MB_OK | MB_ICONINFORMATION);
        }
        break;
    }
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
