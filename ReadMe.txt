Pro WF:  Windows Workflow in .NET 3.0 - by Bruce Bukovics - Apress

** EXAMPLE CODE BUILD INSTRUCTIONS **

Software Requirements:

The following build procedure assumes that you have the following
software already installed:
 - Visual Studio 2005
 - The .NET 3.0 runtime
 - The Designated version of the Windows SDK that supports
   the workflow designers
 - The Windows Workflow Visual Studio add-in

You should be able to find all of the necessary software 
components from the .NET Framework Developer Center which is
currently at this address:

http://msdn2.microsoft.com/en-us/netframework/default.aspx

Follow these steps to build all sample code for the book:

1)  If you haven't already done so, unzip all sample code
    to a work directory.  Use the option that preserves
    the directory structure contained within the zip file.
    The assumed name for the directory is \ProWF.  
    Once unzipped, you should see separate folders for 
    each chapter in the book.  Within each chapter, there 
    are individual folders for each project.  Each chapter
    also has a \bin directory where all assemblies are copied
    during post-build steps.
    
2)  Open a Visual Studio 2005 command prompt.  This sets all 
    of the necessary environment variables.

3)  While in the command prompt, change to the \ProWF directory.

4)  Execute the command BuildExampleCode.cmd.  This will build all
    of the solutions for all chapters of the book.  

