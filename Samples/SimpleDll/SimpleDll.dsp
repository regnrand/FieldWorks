# Microsoft Developer Studio Project File - Name="SimpleDll" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) External Target" 0x0106

CFG=SimpleDll - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE
!MESSAGE NMAKE /f "SimpleDll.mak".
!MESSAGE
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE
!MESSAGE NMAKE /f "SimpleDll.mak" CFG="SimpleDll - Win32 Debug"
!MESSAGE
!MESSAGE Possible choices for configuration are:
!MESSAGE
!MESSAGE "SimpleDll - Win32 Release" (based on "Win32 (x86) External Target")
!MESSAGE "SimpleDll - Win32 Debug" (based on "Win32 (x86) External Target")
!MESSAGE

# Begin Project
# PROP AllowPerConfigDependencies 0
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""

!IF  "$(CFG)" == "SimpleDll - Win32 Release"

# PROP BASE Use_MFC
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Cmd_Line "NMAKE /f SimpleDll.mak"
# PROP BASE Rebuild_Opt "/a"
# PROP BASE Target_File "SimpleDll.exe"
# PROP BASE Bsc_Name "SimpleDll.bsc"
# PROP BASE Target_Dir ""
# PROP Use_MFC
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "Release"
# PROP Intermediate_Dir "Release"
# PROP Cmd_Line "mksd r"
# PROP Rebuild_Opt "cc"
# PROP Target_File "..\..\output\release\SimpleDll.dll"
# PROP Bsc_Name ""
# PROP Target_Dir ""

!ELSEIF  "$(CFG)" == "SimpleDll - Win32 Debug"

# PROP BASE Use_MFC
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "Debug"
# PROP BASE Intermediate_Dir "Debug"
# PROP BASE Cmd_Line "NMAKE /f SimpleDll.mak"
# PROP BASE Rebuild_Opt "/a"
# PROP BASE Target_File "SimpleDll.exe"
# PROP BASE Bsc_Name "SimpleDll.bsc"
# PROP BASE Target_Dir ""
# PROP Use_MFC
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "Debug"
# PROP Intermediate_Dir "Debug"
# PROP Cmd_Line "mksd.bat"
# PROP Rebuild_Opt "cc"
# PROP Target_File "..\..\output\debug\SimpleDll.dll"
# PROP Bsc_Name ""
# PROP Target_Dir ""

!ENDIF

# Begin Target

# Name "SimpleDll - Win32 Release"
# Name "SimpleDll - Win32 Debug"

!IF  "$(CFG)" == "SimpleDll - Win32 Release"

!ELSEIF  "$(CFG)" == "SimpleDll - Win32 Debug"

!ENDIF

# Begin Group "Source Files"

# PROP Default_Filter "cpp;c;cxx;rc;def;r;odl;idl;hpj;bat"
# Begin Source File

SOURCE=.\mksd.bat
# End Source File
# Begin Source File

SOURCE=.\SampleInterface.cpp
# End Source File
# Begin Source File

SOURCE=.\SimpleDll.def
# End Source File
# Begin Source File

SOURCE=.\SimpleDll.rc
# End Source File
# Begin Source File

SOURCE=.\SimpleDllPs.idl
# End Source File
# Begin Source File

SOURCE=.\SimpleDllTlb.idl
# End Source File
# End Group
# Begin Group "Header Files"

# PROP Default_Filter "h;hpp;hxx;hm;inl"
# Begin Source File

SOURCE=.\Main.h
# End Source File
# Begin Source File

SOURCE=.\SampleInterface.h
# End Source File
# End Group
# Begin Group "Resource Files"

# PROP Default_Filter "ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe"
# End Group
# Begin Source File

SOURCE=.\SimpleDll.idh
# End Source File
# Begin Source File

SOURCE=.\SimpleDll.mak
# End Source File
# End Target
# End Project
