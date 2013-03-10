echo off
del /q/a/f/s Release\*
cd tools
build.bat
cd ../
cd Release
del /q web.config
cd \Data
del /q/a/f/s Data\*.*

