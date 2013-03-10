echo on
cd ..\Release
set fileName=Release%date:~0,4%%date:~5,2%%date:~8,2%.zip
..\tools\zip -r %fileName% * -x ./%fileName%
move %fileName% ..\

::cd ..\Setup
::set fileName=Setup%date:~0,4%%date:~5,2%%date:~8,2%.zip
::..\tools\zip -r %fileName% Setup/* -x ./%fileName%
::move %fileName% ..\

::del /q/a/f/s Release*.zip

cd ..\tools
pause

