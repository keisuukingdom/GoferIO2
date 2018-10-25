rem @ECHO OFF

if %5 == "1" bcp %6 queryout %7 -c -t "," -r "\n" -U %1 -P %2 -S %3

osql -U %1 -P %2 -S %3 -Q %4

:END
rem @ECHO ON
