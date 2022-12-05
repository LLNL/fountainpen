; Name of our application
Name "fountainpen plugin for Notepad++"

; The file to write
OutFile "setup_fountainpen.exe"

; Set the default Installation Directory
InstallDir "$PROGRAMFILES64\Notepad++\plugins\fountainpen"

; Set the text which prompts the user to enter the installation directory
DirText "Please choose a directory to which you'd like to install the fountainpen plugin."

; ----------------------------------------------------------------------------------
; *************************** SECTION FOR INSTALLING *******************************
; ----------------------------------------------------------------------------------

Section "" ; A "useful" name is not needed as we are not installing separate components

; Set output path to the installation directory. Also sets the working
; directory for shortcuts
SetOutPath $INSTDIR\

File fountainpen.dll
File fountainpen.ini

SectionEnd