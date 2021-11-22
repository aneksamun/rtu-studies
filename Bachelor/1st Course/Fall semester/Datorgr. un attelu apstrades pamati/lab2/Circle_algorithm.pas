unit krugis;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
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
procedure Pix(a,b,da,db:integer);
begin
    Form1.Canvas.Pixels[a+da,b+db]:=$000000;
    Form1.Canvas.Pixels[-a+da,-b+db]:=$000000;
    Form1.Canvas.Pixels[a+da,-b+db]:=$000000;
    Form1.Canvas.Pixels[-a+da,b+db]:=$000000;
    Form1.Canvas.Pixels[a+da,b-db]:=$000000;
    Form1.Canvas.Pixels[-a+da,-b-db]:=$000000;
    Form1.Canvas.Pixels[a+da,-b-db]:=$000000;
    Form1.Canvas.Pixels[-a+da,b-db]:=$000000;
end;

procedure Circle(xc,yc,r:integer);
    var x,y,p:integer;
begin
    x:=0;
    y:=r;
    p:=1-r;
    
    Pix(x,y,xc,yc);
    Pix(y,x,xc,yc);
    
    while x <= y do
    begin
        if p < 0 then
            begin
                x:=x+1;
                y:=y;
                p:=p+1+2*x;
            end 
        else 
            begin
                x:=x+1;
                y:=y-1;
                p:=p+1+2*x-2*y;
            end;
            
        Pix(x,y,xc,yc);
        Pix(y,x,xc,yc);
    end;
end;





procedure TForm1.Button1Click(Sender: TObject);

var x1,y1,r1:integer;
begin
x1:=strtoint(Edit1.text);
y1:=strtoint(Edit2.text);
r1:=strtoint(Edit3.text);

Circle(x1,y1,r1);

end;

end.
