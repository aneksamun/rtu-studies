@echo off
cls
:: Pareja uz C: diska sakuma katologu
cd\
:: Veidojam darba katologu ( 1. darb. nr. )
@echo Viedojam darba katologu %1...
echo.
mkdir %1 
:: Stradajam no darba katologa    
cd %1
:: Kopejam cikla ARCVIEW.EXE un NCEDIT.EXE failus no NC katologa  ( 2. darb. nr.)
@echo Kopejam cikla ARCVIEW.EXE un NCEDIT.EXE failus no NC katologa...
copy c:\NC\ARCVIEW.EXE
copy c:\NC\NCEDIT.EXE
:: Veidojam divus apakskatologus K1 un K2 ( 3. darb. nr)
echo.
@echo Veidojam divus apakskatologus %2 un %3...
mkdir %2 %3
:: /* Pec lietotaja izveles parvietojam izveleto failu uz izveleto katologu, citu failu uz citu 
:: katologu  (3. darb. nr) */
echo.

:: Vispirms piedavajam izveleties failus 
:start
@echo Izveleties kadus failus parvietot:
echo.
echo [1] ARCVIEW.EXE
echo [2] NCEDIT.EXE
:: ielasam vertibu kadu ievada lietotajs un ejam uz noteiktu sekciju
set choice=
set /p choice=
if not '%choice%'=='' set choice=%choice:~0,1%
if '%choice%'=='1' goto AV
if '%choice%'=='2' goto NE
:: vertiba ir neparieza, pazinojam  un atgriezamies pie izvelnes
echo "%choice%" vertiba ir neparieza, meginiet velreiz.
echo.
goto start

:: Sekcija AV, lietotajs ir izvelejies ARCVIEW.EXE failu, tagad jaizvelas katologs, kura
:: dotais fails tiks parvietots
:AV
cls
@echo Izvelets ARCVIEW.EXE fails...
@echo Izveleties katologu, kura parvietot:
echo.
echo [1] %2
echo [2] %3
set choice=
set /p choice=
if not '%choice%'=='' set choice=%choice:~0,1%
if '%choice%'=='1' goto MOTION1
if '%choice%'=='2' goto MOTION2
echo "%choice%" vertiba ir neparieza, meginiet velreiz.
echo.
pause
goto AV

:: Sekcija NE, lietotajs ir izvelejies NCEDIT.EXE failu, tagad jaizvelas katologs, kura
:: dotais fails tiks parvietots
:NE
cls
@echo Izvelets NCEDIT.EXE fails...
@echo Izveleties katologu, kura parvietot:
echo.
echo [1] %2
echo [2] %3
set choice=
set /p choice=
if not '%choice%'=='' set choice=%choice:~0,1%
if '%choice%'=='1' goto MOTION2
if '%choice%'=='2' goto MOTION1
echo "%choice%" vertiba ir neparieza, meginiet velreiz.
echo.
pause
goto NE

:: Lietotajs izvelejies parvietot failu ARCVIEW.EXE uz K1 katologu, vai ari
:: lietotajs izvelejies parvietot NCEDIT.EXE failu uz K2 katologu 
:MOTION1
@echo ARCVIEW.EXE parvietots uz %2 katologu,
@echo NCEDIT.EXE parvietots uz %3 katologu...
move ARCVIEW.EXE C:\%1\%2
move NCEDIT.EXE C:\%1\%3
echo.
pause
goto continue

:: Lietotajs izvelejies parvietot failu ARCVIEW.EXE uz K2 katologu, vai ari
:: lietotajs izvelejies parvietot NCEDIT.EXE failu uz K1 katologu 
:MOTION2
@echo ARCVIEW.EXE parvietots uz %3 katologu,
@echo NCEDIT.EXE parvietots uz %2 katologu...
move ARCVIEW.EXE C:\%1\%3
move NCEDIT.EXE C:\%1\%2
echo.
pause
goto continue

:continue 
:: Izmantojot arhivatoru WinRar veidojam divus arhivus uz a: diska, ievietojot katra arhiva vienu no failiem (4. darb. nr.)
cls
@echo Viedojam divus arhivus uz a: diska un dzesam apakskatologus...
@echo Ielieciet disketi diskdzini.
pause
:: Noradam vietu, kur meklet rar.exe un unrar.exe
set path="C:\Program Files\WinRaR\";%path%
:: Ienakam K1, K2 katologos un veicam faila arhivesanu
cd %2
if exist ARCVIEW.EXE rar.exe a a:\ARCVIEW.RAR ARCVIEW.EXE
if exist NCEDIT.EXE rar.exe a a:\NCEDIT.RAR NCEDIT.EXE
:: Dzesam failus no apakskatologiem ( 5. darb. nr. ) 
del *.* /Q
cd..
cd %3
if exist ARCVIEW.EXE rar.exe a a:\ARCVIEW.RAR ARCVIEW.EXE
if exist NCEDIT.EXE rar.exe a a:\NCEDIT.RAR NCEDIT.EXE
del *.* /Q
:: ienakam atkal sava darba katologa
cd..
:: Dzesam apakskatologus no darba direktorijas ( 5. darb. nr. ) 
rmdir %2 %3
pause
:: Atjaunojam failus no arhiviem uz darba katologu (6.darb. nr.)
cls
@echo Atjaunojam failus no arhiviem uz darba katologu...
unrar.exe e a:\ARCVIEW.rar
unrar.exe e a:\NCEDIT.rar
pause
:: Darba katologa saturu izvadam faila F1, kurs tiks izvietots darba katologa (7. darb. nr.)
dir > f1.txt
:: Paradam darba katologa saturu uz ekrana pa lappusem (8. darb. nr.)
more /c f1.txt
echo.
:: Faila F1 meklejam simbola virkni "DIR" un paradam kopa rindinas numuriem pa lapusem (9. darb. nr.)
@echo Faila F1 meklejam simbola virkni "DIR"...
find /n "DIR" f1.txt
goto end

:end
:: Dzesam darba katologu no c: diska un arhivus no a: diska ( 10. darb. nr. )
echo.
@echo Dzesam darba katologu no c: diska un arhivus no a: diska
echo.
del *.* /Q
cd\
rmdir c:\%1
del a:\ARCVIEW.RAR
del a:\NCEDIT.RAR
:: Izvadam komentaru "OK" uz ekrana ( 11. darb. nr.) 
@echo "OK"
pause