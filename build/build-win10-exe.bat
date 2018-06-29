@echo off
cd %~dp0
cd..
dotnet build /p:configuration=Release -r win10-x64