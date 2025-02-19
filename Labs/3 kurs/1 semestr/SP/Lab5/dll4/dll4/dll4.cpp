#pragma once
#include "pch.h"
#define _EXPORTING
#include "dll4.h"

#include <algorithm>
#include <ranges>

using std::ranges::for_each;

vector<void*> Search(HANDLE hProcess, const char* target, size_t size) {
    vector<void*> result;

    SYSTEM_INFO sysInfo;
    GetSystemInfo(&sysInfo);

    LPVOID start = sysInfo.lpMinimumApplicationAddress;
    LPVOID end = sysInfo.lpMaximumApplicationAddress;

    SIZE_T bytesRead;
    MEMORY_BASIC_INFORMATION mbi;

    BYTE buffer[4096];
    constexpr SIZE_T bsize = sizeof(buffer);

    while (start < end) {
        if (VirtualQueryEx(hProcess, start, &mbi, sizeof(mbi)) == 0)
            break;

        if (mbi.State == MEM_COMMIT && (mbi.Protect & PAGE_READWRITE)) {
            SIZE_T regionSize = mbi.RegionSize;
            LPBYTE regionBase = static_cast<LPBYTE>(mbi.BaseAddress);

            for (SIZE_T i = 0; i < regionSize; i += bsize) {
                SIZE_T chunkSize = min(bsize, regionSize - i);

                if (ReadProcessMemory(hProcess, regionBase + i, buffer, chunkSize, &bytesRead)) {
                    for (SIZE_T j = 0; j <= bytesRead - size; ++j) {
                        if (memcmp(buffer + j, target, size) == 0) {
                            result.push_back(regionBase + i + j);
                        }
                    }
                }
            }
        }
        start = static_cast<LPBYTE>(start) + mbi.RegionSize;
    }

    return result;
}

vector<void*> Repeat(HANDLE hProcess, const vector<void*>& vec, const char* target, size_t size) {
    vector<void*> result;
    char buffer[4096];
    SIZE_T bytesRead;

    for_each(vec, [&](const auto& ptr) {
        if (ReadProcessMemory(hProcess, ptr, buffer, size, &bytesRead) && bytesRead == size) {
            if (memcmp(buffer, target, size) == 0) {
                result.push_back(ptr);
            }
        }
        });
    return result;
}

SIZE_T setValues(HANDLE hProcess, const vector<void*>& dest, const char* source, size_t size) {
    SIZE_T bytes{ 0 };
    SIZE_T result{ 0 };
    for_each(dest, [&](const auto& ptr) {
        if (WriteProcessMemory(hProcess, ptr, source, size, &bytes)
            && bytes == size) {
            result++;
        }
        });
    return result;
}