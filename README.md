C# Windows Form Application : TEAMVIEWER Project Overview

/////////////////////////////////////////////////////////////////////////////
Use:

  The project is used to control another computer remotly or to trasfer files between two computers. 
  
  first of all you need to register so you can log in in first
 form chose regstir button then log in with you new account:
  
  * choose file trasfer button to trasfer files between two compuers
  * choose remote Desktop nutton to controll remotely anotyher computer or be controlled by another computer
  
  and the application also work with c++ server project that is responsible for the log in.


/////////////////////////////////////////////////////////////////////////////
Prerequisite:

Visual Studio 2008 installed or newer version. 

*Windows platform:
www.microsoft.com/en-us/software-download/


/////////////////////////////////////////////////////////////////////////////
Demo:
  
*open the project

* log in and if you dont have an account register and then log in
*choose what you want : trasfer file or control another computer
*copy the other computer ip make sure it is in the local network
*connect

*when you done close the option form or log out


/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step1. Create a Visual Studio 2008 windows form Application project

Step2. Clear unnecessary parts in the project

Step3: Add our project files you can get them from the gitlab website
https://gitlab.com/radwan1230/karmiel-206-teamviewer/tree/master/
        
Step4: change the log in server ip to the ip of the computer that is running the server

Step5: Build the project and run it


/////////////////////////////////////////////////////////////////////////////
References:

#C# Tutorials
http://www.tutorialspoint.com/csharp/


/////////////////////////////////////////////////////////////////////////////

The Project uses classic C# WinForms client + a small C/C++ login server—no obvious package manager files (no packages.config, no NuGet refs) and the README points to a plain Visual Studio setup, so it likely relies only on built-in .NET / Win32 libs rather than third-party packages.  ￼

Here’s the best-effort library/namespace inventory you’d expect in a project like this:

C# WinForms client (built-in .NET Framework)
	•	System
	•	System.Windows.Forms
	•	System.Drawing
	•	System.IO
	•	System.Net
	•	System.Net.Sockets
	•	System.Threading / System.Threading.Tasks
	•	System.ComponentModel
	•	System.Data (often present by template even if not used)

C/C++ “login server” (Win32 / Winsock)
	•	Headers: winsock2.h, windows.h, (possibly ws2tcpip.h)
	•	Linker import libs: Ws2_32.lib, Advapi32.lib (the latter only if doing any registry/crypto), sometimes Mswsock.lib for extras

Third-party / NuGet packages
	•	None apparent in the repo structure/README (looks like a straight Visual Studio solution without external deps). 
