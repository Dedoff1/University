unit Unit3;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm3 = class(TForm)
    Button1: TButton;
    Label1: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form3: TForm3;

implementation

{$R *.dfm}
uses Unit1,Unit2, Unit4;
procedure TForm3.Button1Click(Sender: TObject);
begin
  Form3.Hide;
  Form1.Show;
end;

procedure TForm3.FormCreate(Sender: TObject);
begin
  Form1.Visible:=False;
  
end;

end.
