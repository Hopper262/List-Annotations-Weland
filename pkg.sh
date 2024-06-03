#!/bin/sh
if [ -d List_Annotations ]; then rm -r List_Annotations; fi
if [ -f List_Annotations.zip ]; then rm List_Annotations.zip; fi
mkdir List_Annotations
cp List_Annotations.dll List_Annotations/
cp pkg-readme.txt List_Annotations/"Read Me.txt"
zip -r -X List_Annotations.zip List_Annotations
rm -r List_Annotations
