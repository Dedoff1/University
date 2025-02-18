%{ 
#include <stdio.h> 
%} 

%token COLON
%token EQUAL
%token DOT
%token DIV
%token OP
%token CP
%token MINUS
%token PLUS
%token MORE
%token LESS
%token SEMICOLON
%token COMA
%token CASE
%token END
%token WHEN
%token REM
%token ID
%token BACKSLAH
%token OF
%token EPSILON
  
%% 

program:
ID OP CP MINUS MORE statement{ printf ("\nCorrect String\n");  } ; 

statement: 
loop newstatement
| for newstatement
| case newstatement
| expression newstatement
| DOT
| epsilon
; 

newstatement:
COMA statement
| epsilon
| DOT 
;

loop:
ID OP ID CP COMA ID OP ID CP MINUS MORE statement ID OP expression CP 
| epsilon
;


for:
ID OP ID COMA ID CP COMA ID OP ID COMA ID CP WHEN condition MINUS MORE statement ID OP expression COMA ID CP
;


case:
CASE expression OF variant
;


variant:
ID MINUS MORE statement SEMICOLON variant 
| END
;


condition:
ID symbol ID
;


symbol:
| MORE
| LESS
| EQUAL EQUAL
| MORE EQUAL
| LESS EQUAL
| BACKSLAH EQUAL
;


expression:
ID EQUAL expression DOT
| ID EQUAL expression 
| ID operation ID
;


operation:
| PLUS
| MINUS
| DIV
| REM
;

epsilon:
;

%% 

int main() { 
yyparse(); 
return 0; 
} 

void yyerror(char *s) { 
fprintf (stderr, "%s\n", s); 
}