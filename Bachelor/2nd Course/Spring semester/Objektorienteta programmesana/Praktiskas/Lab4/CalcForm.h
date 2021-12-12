//---------------------------------------------------------------------------

#ifndef CalcFormH
#define CalcFormH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <Menus.hpp>
#include <Buttons.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
    __published : // IDE-managed Components
                  TPanel *Panel1;
    TLabel *Label1;
    TLabel *Label2;
    TLabel *Label3;
    TEdit *FirstOperand;
    TEdit *SecondOperand;
    TEdit *Result;
    TButton *Button1;
    TButton *Button2;
    TButton *Button3;
    TButton *Button4;
    TMainMenu *MainMenu1;
    TMenuItem *Operations1;
    TMenuItem *Add1;
    TMenuItem *Sub1;
    TMenuItem *Multiply1;
    TMenuItem *Divide1;
    TMenuItem *Exit1;
    TPopupMenu *PopupMenu1;
    TMenuItem *Add2;
    TMenuItem *Sub2;
    TMenuItem *Mul1;
    TMenuItem *Div1;
    TPanel *Panel2;
    TSpeedButton *SpeedButton1;
    TSpeedButton *SpeedButton2;
    TSpeedButton *SpeedButton3;
    TSpeedButton *SpeedButton4;
    TBitBtn *BitBtn1;
    void __fastcall Exit(TObject *Sender);
    void __fastcall Add(TObject *Sender);
    void __fastcall Sub(TObject *Sender);
    void __fastcall Mul(TObject *Sender);
    void __fastcall Div(TObject *Sender);

private: // User declarations
public:  // User declarations
    __fastcall TForm1(TComponent *Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
