#include <GuiMenu.au3>

Run("C:\Program Files\Notepad++\notepad++.exe")
WinWaitActive("[CLASS:Notepad++]")
$hWnd = WinGetHandle("[CLASS:Notepad++]")
Sleep(2000)

While 1
   ControlSend($hWnd, "", "", "^n")
   WinWaitActive("new 1 - Notepad++")
   Local $fileName = "thornedthymus" & Random(1,100,1) & ".txt"
   Send($fileName & @CRLF)
   Send("--------------------------------------------------------------------------------" & @CRLF)
   Send("This is a test of new file creation" & @CRLF)
   Send("If it works then we should have a nice test case for the ThornedThymus Project" & @CRLF)
   Send("ThornedThymus is a project at LLNL")
   Sleep(15000)
   ControlSend($hWnd, "", "", "^s")
   WinWaitActive("Save As")
   ControlFocus("Save As", "Tree View", "SysTreeView321")
   ControlSend("Save As", "Tree View", "SysTreeView321", "Documents" & @CRLF)
   WinWaitActive("Save As")
   ControlFocus("Save As", "", "Edit1")
   ControlSend("Save As", "", "Edit1", $fileName)
   WinWaitActive("Save As")
   ControlClick("Save As", "&Save", "Button3")
   Sleep(10000)
WEnd
--------------------