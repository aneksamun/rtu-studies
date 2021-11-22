unit pagrieziens;

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
    Edit6: TEdit;
    Edit7: TEdit;
    Edit8: TEdit;
    Edit9: TEdit;
    Edit10: TEdit;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
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
    procedure Taisne(x0, y0, x1, y1: Integer);
        var x, y, dx, dy, ix, iy, p, i: Integer;
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
        var m : array[1..9] of integer;
            i, xs, ys, x2s, y2s, xb, yb, x2b, y2b : integer;
            a11, a21, a12, a22, lenkis, increase : real;
    begin
        increase := StrToInt(Edit10.Text);
        
        for i := 1 to 9 do
            m[i] := StrToInt(TEdit(FindComponent('Edit' + IntToStr(i))).Text);
        
        lenkis:=m[9]*Pi/180;
        
        a11 := cos(lenkis) * increase;
        a21 := -sin(lenkis) * increase;
        a12 := Sin(lenkis) * increase;
        a22 := Cos(lenkis) * increase;

        xs := round(m[1] * a11 + m[3] * a21);
        ys := round(m[1] * a12 + m[3] * a22);
        xb := round(m[2] * a11 + m[4] * a21);
        yb := round(m[2] * a12 + m[4] * a22);
        x2s := round(m[5] * a11 + m[7] * a21);
        y2s := round(m[5] * a12 + m[7] * a22);
        x2b := round(m[6] * a11 + m[8] * a21);
        y2b := round(m[6] * a12 + m[8] * a22);

        Taisne(xs, ys, xb, yb);
        Taisne(xb, yb, x2s, y2s);
        Taisne(x2s, y2s, x2b, y2b);
        Taisne (x2b, y2b, xs, ys);

        Taisne(m[1] + 100, m[3], m[2] + 100, m[4]);
        Taisne(m[5] + 100, m[7], m[6] + 100, m[8]);
        Taisne(m[1] + 100, m[3], m[6] + 100, m[8]);
        Taisne(m[5] + 100, m[7], m[2] + 100, m[4]);
    end;
end.
