unit cubic;

interface

uses
    Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
    Dialogs, StdCtrls;

type
    TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
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

var Form1: TForm1;

implementation

{$R *.dfm}

    procedure Taisne(x0, y0, x1, y1: Integer);
        var x, y, dx, dy, ix, iy, p, i: Integer;
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
                
                for i := 1 to dx do
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
                        if p > 0 Then
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
        var x, y, h: integer;
    begin
        x := strtoint(Edit1.Text);
        y := strtoint(Edit2.Text);
        h := strtoint(Edit3.Text);

        Taisne(x, y, x, y + h);
        Taisne(x+h, y, x + h, y + h);
        Taisne(x, y+h, x + h, y + h);
        Taisne(x, y, x + h, y);
        Taisne(x + h, y + h, x + 50 + h, y + h - 50);
        Taisne(x + h,y, x + h + 50, y - 50);
        Taisne(x, y + h, x + 50, y + h - 50);
        Taisne(x, y, x + 50, y - 50);
        Taisne(x + h + 50, y + h - 50, x + h + 50, y - 50);
        Taisne(x + h + 50, y - 50, x + 50, y - 50);
        Taisne(x + 50, y - 50, x + 50, y + h - 50);
        Taisne(x + 50, y + h - 50, x + h + 50, y + h - 50);
    end;

end.
