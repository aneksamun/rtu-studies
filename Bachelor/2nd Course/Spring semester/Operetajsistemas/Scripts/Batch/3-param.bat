@echo off
cls
cd\
mkdir work     
cd WORK
copy c:\NC\ARCVIEW.EXE
copy c:\NC\NCEDIT.EXE
mkdir K1 K2

:start
@echo Izveleties kadus failus parvietot:
echo.
echo [1] ARCVIEW.EXE
echo [2] NCEDIT.EXE
set choice=
set /p choice=
if not '%choice%'=='' set choice=%choice:~0,1%
if '%choice%'=='1' goto AV
if '%choice%'=='2' goto NE
echo "%choice%" vertiba ir neparieza, meginiet velreiz.
echo.
goto start

:AV
@echo Izvelets ARCVIEW.EXE fails.
@echo Kada katologa parvietot:
echo.
echo [1] K1
echo [2] K2
set choice=
set /p choice=
if not '%choice%'=='' set choice=%choice:~0,1%
if '%choice%'=='1' goto MOTION1
if '%choice%'=='2' goto MOTION2
echo "%choice%" vertiba ir neparieza, meginiet velreiz.
echo.
goto AV

:NE
@echo Izvelets NCEDIT.EXE fails.
@echo Kada katologa parvietot:
echo.
echo [1] K1
echo [2] K2
set choice=
set /p choice=
if not '%choice%'=='' set choice=%choice:~0,1%
if '%choice%'=='1' goto MOTION2
if '%choice%'=='2' goto MOTION1
echo "%choice%" vertiba ir neparieza, meginiet velreiz.
echo.
goto NE

:MOTION1
@echo ARCVIEW.EXE parvietots uz K1 katologu
@echo NCEDIT.EXE parvietots uz K2 katologu
move ARCVIEW.EXE C:\work\K1
move NCEDIT.EXE C:\work\K2
goto continue

:MOTION2
@echo ARCVIEW.EXE parvietots uz K2 katologu
@echo NCEDIT.EXE parvietots uz K1 katologu
move ARCVIEW.EXE C:\work\K2
move NCEDIT.EXE C:\work\K1
goto continue

:continue 
set path="C:\Program Files\WinRaR\";%path%
cd K1
if exist ARCVIEW.EXE rar.exe a c:\K1 ARCVIEW.EXE
if exist NCEDIT.EXE rar.exe a c:\K1 NCEDIT.EXE
del *.* /Q
cd..
cd K2
if exist ARCVIEW.EXE rar.exe a c:\K2 ARCVIEW.EXE
if exist NCEDIT.EXE rar.exe a c:\K2 NCEDIT.EXE
del *.* /Q
cd..
rmdir K1 K2
unrar.exe e c:\k1.rar
unrar.exe e c:\k2.rar
pause
dir > f1.txt
more /c f1.txt
echo.
find /n "DIR" f1.txt
goto end

:end
del *.* /Q
cd\
rmdir c:\work
del K1.rar
del K2.rar
echo.
@echo "OK"
pause