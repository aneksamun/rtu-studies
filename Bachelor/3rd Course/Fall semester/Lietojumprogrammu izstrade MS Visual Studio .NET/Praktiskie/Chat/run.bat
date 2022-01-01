set path="C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727";%path%
csc /t:library ChatCoordinator.cs
@echo.
csc /r:ChatCoordinator.dll server.cs
@echo.
csc /r:ChatCoordinator.dll Client.cs
pause