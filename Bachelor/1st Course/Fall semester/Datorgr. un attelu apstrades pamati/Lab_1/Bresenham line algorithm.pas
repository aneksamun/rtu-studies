unit turn;

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
        Label1: TLabel;
        Label2: TLabel;
        Label3: TLabel;
        Label4: TLabel;
        Label5: TLabel;
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
    procedure Taisne(x0, y0, x1, y1 : Integer);
        var x, y, dx, dy, ix, iy, p, i : Integer;
    begin
        dx := abs(x1 - x0);
        dy := abs(y1 - y0);
        x := x0;
        y := y0;
        if (x1 - x0) < 0 then 
            ix:=-1
        else 
            ix:=1;
            
        if y1 - y0 < 0 then 
            iy:=-1
        else 
            iy:=1;
            
        if dx >= dy then //slipumam mazakam vai vien. ar 45 gr.
            begin
                p := 2 * dy - dx;
                
                for i := 1 To dx do
                    begin
                        if p > 0 then
                            begin
                                x := x + ix;
                                y := y + iy;
                                p := p + 2 * (dy - dx);
                                form1.Canvas.Pixels[x, y] := $000000;
                            end
                        else
                            begin
                                x := x + ix;
                                y := y;
                                p := p + 2 * dy;
                                form1.Canvas.Pixels[x, y] := $000000;
                            end;
                    end;
            end
        else           //slipumam > par 45 gr.
            begin
                p := 2 * dx - dy;
                for i := 1 To dy do
                    begin
                        if p > 0 then
                            begin
                                y := y + iy;
                                x := x + ix;
                                p := p + 2 * (dx - dy);
                                form1.Canvas.Pixels[x,y] := $000000;
                            end
                        else
                            begin
                                y := y + iy;
                                x := x;
                                p := p + 2 * dx;
                                form1.Canvas.Pixels[x, y] := $000000;
                            end;
                    end;
            end;  
    end;

    procedure TForm1.Button1Click(Sender: TObject);
        var m:array[1..5] of integer;
            x, y, i, xend, yend : integer;
            a11, a21, a12, a22, lenkis : real;
    begin
        for i := 1 to 5 do
            m[i] := StrToInt(TEdit(FindComponent('Edit'+IntToStr(i))).text);

        lenkis := m[5] * pi / 180;
        a11 := cos(lenkis);
        a21 := -sin(lenkis);
        a12 := sin(lenkis);
        a22 := cos(lenkis);

        x:=0;
        y:=0;

        xend := round(m[3] * a11 + m[4] * a21);
        yend := round(m[3] * a12 + m[4] * a22);

        Taisne(x, y, xend, yend);
        Taisne(x, y, m[3], m[4]);
    end;
end.
