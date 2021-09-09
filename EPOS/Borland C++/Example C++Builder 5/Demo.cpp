//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
USERES("Demo.res");
USEFORM("Demo_WinDLL.cpp", DemoDlg);
USELIB("EposCmd.lib");
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TDemoDlg), &DemoDlg);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        return 0;
}
//---------------------------------------------------------------------------
