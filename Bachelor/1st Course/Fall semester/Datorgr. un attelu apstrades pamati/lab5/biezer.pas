unit likne;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Edit5: TEdit;
    Edit6: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var x,y,i:integer;
    t:real;
    m:array[1..6] of integer;
begin
    for i:=1 to 6 do
      begin
    m[i]:=StrToInt(TEdit(FindComponent ('Edit'+IntToStr(i) )).text);
    end;
    t:=0;
    while t<1 do
      begin
        t:=t+0.005;
        x:=0;
        y:=0;

        x:=round(m[5]*(t*t)+m[3]*2*t*(1-t)+m[1]*(1-t)*(1-t));
        y:=round(m[6]*(t*t)+m[4]*2*t*(1-t)+m[2]*(1-t)*(1-t));

        Form1.Canvas.Pixels[x,y]:=CLBLACK;
      end;
end;

end.
