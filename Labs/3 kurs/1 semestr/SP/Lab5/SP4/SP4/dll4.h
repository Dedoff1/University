#pragma once
#include <vector>
#include <Windows.h>

using std::vector;

#ifdef _EXPORTING
#define CLASS_DECLSPEC    __declspec(dllexport)
#else
#define CLASS_DECLSPEC    __declspec(dllimport)
#endif

extern "C" {
	CLASS_DECLSPEC vector<void*> WINAPI Repeat(HANDLE hProcess, const vector<void*>& vec, const char* target, size_t size);

	CLASS_DECLSPEC vector<void*> WINAPI Search(HANDLE hProcess, const char* target, size_t size);

	CLASS_DECLSPEC SIZE_T WINAPI setValues(HANDLE hProcess, const vector<void*>& dest, const char* source, size_t);
}