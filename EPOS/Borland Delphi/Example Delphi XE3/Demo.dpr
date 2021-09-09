program Demo;

uses
  Forms,
  Demo_WinDLL in 'Demo_WinDLL.pas' {DemoDlg},
  Definitions in 'Definitions.pas';

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TDemoDlg, DemoDlg);
  Application.Run;
end.
