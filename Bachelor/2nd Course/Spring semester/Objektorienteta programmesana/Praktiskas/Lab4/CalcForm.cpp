//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "CalcForm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent *Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Add(TObject *Sender)
{
    try
    {
        Result->Text = FloatToStr(StrToFloat(FirstOperand->Text) + StrToFloat(SecondOperand->Text));
    }
    catch (...)
    {
        MessageDlg("Error in operands !", mtError, TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Sub(TObject *Sender)
{
    try
    {
        Result->Text = FloatToStr(StrToFloat(FirstOperand->Text) - StrToFloat(SecondOperand->Text));
    }
    catch (...)
    {
        MessageDlg("Error in operands !", mtError, TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Mul(TObject *Sender)
{
    try
    {
        Result->Text = FloatToStr(StrToFloat(FirstOperand->Text) * StrToFloat(SecondOperand->Text));
    }
    catch (...)
    {
        MessageDlg("Error in operands !", mtError, TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Div(TObject *Sender)
{
    try
    {
        Result->Text = FloatToStr(StrToFloat(FirstOperand->Text) / StrToFloat(SecondOperand->Text));
    }
    catch (EConvertError &E)
    {
        MessageDlg("Operand isn't a number!", mtError, TMsgDlgButtons() << mbOK, 0); // 1/a
    }
    catch (EZeroDivide &E)
    {
        MessageDlg("Division by zero!", mtError, TMsgDlgButtons() << mbOK, 0); // 1/0
    }
    catch (...)
    {
        MessageDlg("Error in operands !", mtError, TMsgDlgButtons() << mbOK, 0); // 0/0
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Exit(TObject *Sender)
{
    Close();
}
//---------------------------------------------------------------------------
