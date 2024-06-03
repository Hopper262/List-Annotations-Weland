#!/bin/sh
# WELAND="$HOME/Source/weland-svn/Weland.exe"
WELAND="/Applications/Games/Aleph One/Utilities/Weland.app/Contents/MacOS/Weland.exe"
PATH="/Library/Frameworks/Mono.framework/Commands:$PATH" \
PKG_CONFIG_PATH="/Library/Frameworks/Mono.framework/Libraries/pkgconfig" \
  mcs -debug -r:"$WELAND" \
  -pkg:gtk-sharp-2.0 \
  -target:library \
  -out:List_Annotations.dll \
  Plugin.cs \
  && \
  cp List_Annotations.dll "$HOME/.config/Weland/Plugins/List_Annotations.dll"
