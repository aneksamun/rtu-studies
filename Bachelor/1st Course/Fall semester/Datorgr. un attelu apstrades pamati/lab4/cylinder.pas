unit cilindrs;

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
        Button1: TButton;
        Label1: TLabel;
        Label2: TLabel;
        Label3: TLabel;
        Label4: TLabel;
        Label5: TLabel;
    procedure Button1Click(Sender: TObject);
    private
        { Private declarations }
    public
        { Public declarations }
    end;

var
    Form1: TForm1;

implementation

    procedure Zimet(x,y,xc,yc:Integer);
    begin
        Form1.Canvas.Pixels[x + xc, y + yc] := $000000;
        Form1.Canvas.Pixels[-x + xc, y + yc] := $000000;
        Form1.Canvas.Pixels[x + xc, -y + yc] := $000000;
        Form1.Canvas.Pixels[-x + xc, -y + yc] := $000000;
    end;

   procedure Ellipse(xc, yc, rx, ry : Integer);
    var x, y:Integer;
        Rx2y, Ry2x, Rx2, Ry2, p : Real;
    begin
        x := -1;
        y := Ry;
        Rx2 := sqr(Rx);
        Ry2 := sqr(Ry);
        Rx2y := 2 * Rx2 * y;
        Ry2x := 2 * Ry2 * x;
        p := Ry2 - Rx2 + 0.25 * Rx2;
        
        While Ry2x <= Rx2y do
            begin
                if p < 0 then
                    begin
                        x :=x + 1;
                        Ry2x :=2 * Ry2 * x;
                        p := p + Ry2x + Ry2;
                    end
                else
                    begin
                        x := x + 1;
                        y := y - 1;
                        Rx2y := 2 * Rx2 * y;
                        Ry2x := 2 * Ry2 * x;
                        p := p + Ry2x - Rx2y + Ry2;
                    end;
                    
                    Zimet(x,y,xc,yc);
            end;
            
         p := Ry2 * sqr(x + 0.5) + Rx2 * sqr(y - 1) - Rx2 * Ry2;

        while y >= 0 do
            begin
                If p > 0 then
                    begin
                        y := y - 1;
                        Rx2y := 2 * Rx2 * y;
                        p := p - Rx2y + Rx2;
                    end
                else
                    begin
                        x := x + 1;
                        y := y - 1;
                        rx2y := 2 * Rx2 * y;
                        ry2x := 2 * Ry2 * x;
                        p := p + Ry2x - Rx2y + Rx2;
                    end;
                    
                Zimet(x,y,xc,yc);
           end;
    end;

   procedure Taisne(x0, y0, x1, y1:Integer);
        var x, y, dx, dy, ix, iy, p, i:Integer;
    begin
        dx := abs(x1-x0);
        dy := abs(y1-y0);
        x := x0;
        y := y0;
        
        if ( x1 - x0 ) < 0 then    
            ix:=-1
        else 
            ix:=1;
            
        if y1 - y0 < 0 then 
            iy := -1
        else 
            iy := 1;

        if dx >= dy then
            begin
                p:=2*dy-dx;
                
                for i := 1 to dx do
                    begin
                        if p > 0 Then
                            begin
                                x := x + ix;
                                y := y + iy;
                                p := p + 2 * (dy - dx);
                                form1.Canvas.Pixels[x,y] := $000000;
                            end
                        else
                            begin
                                x := x + ix;
                                y := y;
                                p := p + 2 * dy;
                                form1.Canvas.Pixels[x,y] := $000000;
                            end;
                    end;
            end
        else    //slipumam > par 45 gr.
            begin
                p := 2 * dx - dy;
                
                for i := 1 to dy do   
                    begin              
                        if p > 0 Then                    
                            begin                        
                                y := y + iy;                   
                                x := x + ix;                   
                                p := p + 2 * (dx - dy);
                                form1.Canvas.Pixels[x, y] := $000000;        
                            end                          
                        else                           
                            begin                         
                                y := y + iy;                     
                                x := x;                        
                                p := p + 2 * dx;
                                form1.Canvas.Pixels[x,y]:=$000000;                  
                            end;                          
                    end;
            end;
    end;

    procedure TForm1.Button1Click(Sender: TObject);
        var x, y, h, r1, r2 : integer;
    begin
        x := strtoint(Edit1.Text);
        y := strtoint(Edit2.Text);
        h := strtoint(Edit3.Text);
        r1 := strtoint(Edit4.Text);
        r2 := strtoint(Edit5.Text);
        Taisne(x, y, x, y + h);
        Ellipse(x + r1, y, r1, r2);
        Ellipse(x + r1, y + h, r1, r2);
        Taisne(x + 2 * r1, y, x + 2 * r1, y + h);
    end;
end.
