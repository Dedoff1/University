#include <stdio.h>

typedef enum {
    ctAcceptable,
    ctBigLetter,
    ctSmallLetter,
    ctForbidden
} TCharType;

typedef enum {
    ErrorState,
    WaitFirstChar,
    ReadChar
} TState;

const TState Transitions[3][4] = {
        {ErrorState, ErrorState, ErrorState, ErrorState},
        {ErrorState, ReadChar,   ErrorState, ReadChar},
        {ErrorState, ReadChar,   ReadChar,   ReadChar}
};

const int IsFinalState[3] = { 0, 0, 1 };
TCharType GetCharType(char c) {
    if  (c >= 'A' && c <= 'Z') {
        return ctBigLetter;
    }
    else if (c >= 'a' && c <= 'z') {
        return ctSmallLetter;
    }
    else if ((c == '_') || (c == '*') || (c == '|') || c == '\\'|| (c == ':') || (c == '"')|| (c == '<')|| (c == '>')|| (c == '?')|| (c == '/')) {
        return ctForbidden;
    }
    else {
        return ctAcceptable;
    }
}

int CheckString(const char* str) {
    TState state = WaitFirstChar;
    int i = 0;
    while (str[i] != '\0') {
        TCharType charType = GetCharType(str[i]);
        state = Transitions[state][charType];
        if (state == ErrorState) {
            return 0; // Не валидный идентификатор
        }
        i++;
    }
    return IsFinalState[state];
}

int main() {
    const char* input1 = "A:\\bCde";
    const char* input2 = "x0";
    const char* input3 = "Y";
    const char* input4 = "9_1";
    const char* input5 = "X:f";
    const char* input6 = "F:\\as1\\df";
    const char* input7 = "S:\\d<";
    const char* input8 = "A12";

    printf("%s\n", CheckString(input1) ? "Valid identifier" : "Invalid identifier");
    printf("%s\n", CheckString(input2) ? "Valid identifier" : "Invalid identifier");
    printf("%s\n", CheckString(input3) ? "Valid identifier" : "Invalid identifier");
    printf("%s\n", CheckString(input4) ? "Valid identifier" : "Invalid identifier");
    printf("%s\n", CheckString(input5) ? "Valid identifier" : "Invalid identifier");
    printf("%s\n", CheckString(input6) ? "Valid identifier" : "Invalid identifier");
    printf("%s\n", CheckString(input7) ? "Valid identifier" : "Invalid identifier");
    printf("%s\n", CheckString(input8) ? "Valid identifier" : "Invalid identifier");

    return 0;
}
