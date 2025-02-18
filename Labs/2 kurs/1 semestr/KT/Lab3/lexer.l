%{
#include "y.tab.h"
%}

%%
[:] {printf("COLON "); return COLON;} 
[=] {printf("EQUAL "); return EQUAL;}
[.] {printf("DOT "); return DOT;}
"div" {printf("DIV "); return DIV;}
[(] {printf("OP "); return OP;}
[)] {printf("CP "); return CP;}
[-] {printf("MINUS "); return MINUS;}
[+] {printf("PLUS "); return PLUS;}
[>] {printf("MORE "); return MORE;}
"<" {printf("LESS "); return LESS;}
[;] {printf("SEMICOLON "); return SEMICOLON;}
[,] {printf("COMA "); return COMA;}
"\\"   {printf("BACKSLAH "); return BACKSLAH;}
"case" {printf("CASE "); return CASE;}
"end"  {printf("END "); return END;}
"when" {printf("WHEN "); return WHEN;}
"of"  {printf("OF "); return OF;}
"rem" {printf("REM "); return REM;}
" "+   { }
"	"+ { }
\n { }

[a-zA-Z0-9]+ {printf("ID ");  return ID; }

%%

int yywrap()
{
return 1;
}