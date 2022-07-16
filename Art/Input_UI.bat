@echo off
set packPath=%~f1
set packName=%~n1%~x1
set dir=%cd%
cd /d ..
cd /d ..
set outDir=E:\A_trunk\GearFactory\project_code\GearFactory\Assets\LocalResources\Atlas
cd /d E:\CodeSoft\TexturePacker\TexturePacker\bin
TexturePacker %packPath% --max-size 2048 --force-squared --multipack --format unity-texture2d --size-constraints POT --shape-padding 2 --border-padding 2 --disable-rotation --algorithm MaxRects --opt RGBA8888 --dither-fs-alpha --scale 1 --sheet %outDir%/%packName%.png --data %outDir%/%packName%.tpsheet
@echo .
@echo .
@echo %outDir% -- %packName%
pause
