echo off
set fileName=Release%date:~0,4%%date:~5,2%%date:~8,2%%time:~0,2%%time:~3,2%.zip
zip -r ../%fileName% ../Release/* -x ./%fileName%

set fileName=Setup%date:~0,4%%date:~5,2%%date:~8,2%%time:~0,2%%time:~3,2%.zip
zip -r ../%fileName% ../Setup/* -x ./%fileName%
pause

