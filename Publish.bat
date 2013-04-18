cd Release
del web.config
cd Data
del Bmk.db
del Bmk.mdb
cd BmkHistory
del /q/a/f/s *.*
cd ..\Dbf
del /q/a/f/s *.*
cd ..\Logs
del /q/a/f/s *.*
cd ..\..\
cd tmp
del /q/a/f/s *.*
cd ..\..\
cd tools
publish.bat
cmd
