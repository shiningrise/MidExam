echo off
cd ..\
mkdir Release
cd tools
path %SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319\
msbuild.exe ..\src\MidExam.sln /t:Rebuild /p:Configuration=Release /l:FileLogger,Microsoft.Build.Engine;logfile=Build1.log
msbuild.exe ..\src\WebSetup1\WebSetup1.vdproj /t:Rebuild /p:Configuration=Release /l:FileLogger,Microsoft.Build.Engine;logfile=Build2.log

rem msbuild ..\src\SpNhi.Web\MidExam.Website_deploy.wdproj /t:ResolveReferences;Compile /t:_WPPCopyWebApplication /p:Configuration=Release /p:WebProjectOutputDir=..\..\Release /l:FileLogger,Microsoft.Build.Engine;logfile=Build2.log
echo on