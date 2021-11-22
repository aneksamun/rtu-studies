unit ellipsis;

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
    Button1: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
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
procedure Zimet(x,y,xc,yc:Integer);
begin
    Form1.Canvas.Pixels[x+xc,y+yc]:=$000000;
    Form1.Canvas.Pixels[-x+xc,y+yc]:=$000000;
    Form1.Canvas.Pixels[x+xc,-y+yc]:=$000000;
    Form1.Canvas.Pixels[-x+xc,-y+yc]:=$000000;
end;

procedure Ellipse(xc,yc,rx,ry:Integer);
var x,y:Integer;
    Rx2y,Ry2x,Rx2,Ry2,p:Real;
begin
    x:=-1;
    y:=Ry;
    Rx2:=sqr(Rx);
    Ry2:=sqr(Ry);
    Rx2y:=2*Rx2*y;
    Ry2x:=2*Ry2*x;
    p:=Ry2-Rx2+0.25*Rx2;
    
    while Ry2x<=Rx2y do
        begin
            if p<0 then
                begin
                    x:=x+1;
                    Ry2x:=2*Ry2*x;
                    p:=p+Ry2x+Ry2;
                end
            else
                begin
                    x:=x+1;
                    y:=y-1;
                    Rx2y:=2*Rx2*y;
                    Ry2x:=2*Ry2*x;
                    p:=p+Ry2x-Rx2y+Ry2;
                end;
            Zimet(x,y,xc,yc);
        end;
     
    p:=Ry2*sqr(x+0.5)+Rx2*sqr(y-1)-Rx2*Ry2;

    while y>=0 do
        begin
            if p>0 then
                begin
                    y:=y-1;
                    Rx2y:=2*Rx2*y;
                    p:=p-Rx2y+Rx2;
                end
            else
                begin
                    x:=x+1;
                    y:=y-1;
                    rx2y:=2*Rx2*y;
                    ry2x:=2*Ry2*x;
                    p:=p+Ry2x-Rx2y+Rx2;
                end;
            Zimet(x,y,xc,yc);
       end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var xc,yx,rx,ry:integer;
begin
    xc:=StrToInt(Edit1.Text);
    yc:=StrToInt(Edit2.Text);
    rx:=StrToInt(Edit3.Text);
    ry:=StrToInt(Edit4.Text);
    Elipse_calc(xc,yc,rx,ry);
end;

end.
