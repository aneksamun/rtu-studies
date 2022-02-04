#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <graphics.h>
#include <dos.h>
#include "shape.h"
#include "file.h"

#define MAXSTR 512

long long_min(long a, long b)
{
    return (a > b) ? b : a;
}

long long_max(long a, long b)
{
    return (a > b) ? a : b;
}

void main(int argc, char *argv[])
{
    int errorcode, step, input, input1 = 0, input2 = 0, current = 0, Exist;
    char *szTemp, szSourceString[MAXSTR], ch;
    char szSourcePath[MAXPATH] = {NULL}, szResultPath[MAXPATH] = {NULL}, szLastPath[MAXPATH] = {NULL};
    SourceFileDescription szDescriptor;
    double dbProgress;

    errorcode = initGraphic();

    if (errorcode == grOk)
    {
        for (step = 0; step < 3; step++)
        {
            setBackground(3);
            switch (step)
            {
            case 0:
                drawPicture(10, 15, 128, 162);
                drawTitle();
                settextstyle(SMALL_FONT, HORIZ_DIR, 4);
                outtextxy(170, 200, "Ievadiet faila nosaukumu (fails ar paplasinajumu *.c ):");
                drawTextBox(170, 220, 220, "");
                outtextxy(170, 245, "Ievadiet rezultejosa faila nosaukumu :");
                drawTextBox(170, 265, 220, "");

                szTemp = strrchr(argv[0], '\\');

                if (szTemp != 0)
                {
                    *(szTemp + 1) = '\0';
                }

                outtextxy(30, 360, "Pirmaja teksta lauka janorada cels lidz mapei, kur atrodas fails un faila nosaukums.");
                outtextxy(30, 380, "<ENTER> - Taustins janospiez katru reizi, kad ir viekta ievade.");
                outtextxy(30, 400, "<TAB> - Lai parslegtos starp teksta laukiem.");
                setcolor(RED);
                outtextxy(30, 420, "<ESC> - Lai izietu no programmas.");

                while ((input1 != 1) || (input2 != 1))
                {
                    if (current == 0)
                        input = ReadInputString(170, 220, 220, szSourcePath);
                    else
                        input = ReadInputString(170, 265, 220, szResultPath);

                    if (input == -1)
                        exit(0);

                    if (input == 0)
                    {
                        if (CloseSourceFile())
                        {
                            input1 = 0;
                            setcolor(3);
                            outtextxy(170, 300, "Fails ir vieksmigi atverts.");
                            outtextxy(170, 300, "Fails ir veiksmigi atverts. Iespejams, ka fails nesatur valodas C pirmtekstu.");
                        }

                        if (CloseResultFile())
                        {
                            input2 = 0;
                            setcolor(3);
                            outtextxy(170, 320, "Fails ir vieksmigi atverts.");
                        }

                        current = (current == 1) ? 0 : 1;

                        drawTextBox(170, 220, 220, szSourcePath);
                        drawTextBox(170, 265, 220, szResultPath);
                    }

                    if (input == 1)
                    {
                        if (current == 0)
                        {
                            if (OpenSourceFile(argv[0], szSourcePath))
                            {
                                current = 1;
                                input1 = 1;
                                drawTextBox(170, 220, 220, szSourcePath);
                                setcolor(3);
                                outtextxy(170, 300, "Neizdevas atvert failu, parliecinieties, ka tas eksiste.");
                                outtextxy(170, 300, "Fails ir veiksmigi atverts. Iespejams, ka fails nesatur valodas C pirmtekstu.");
                                outtextxy(170, 300, "Fails ir vieksmigi atverts.");
                                if (IsC() == 1)
                                {
                                    setcolor(1);
                                    outtextxy(170, 300, "Fails ir veiksmigi atverts.");
                                }
                                else
                                {
                                    setcolor(6);
                                    outtextxy(170, 300, "Fails ir veiksmigi atverts. Iespejams, ka fails nesatur valodas C pirmtekstu.");
                                }
                            }
                            else
                            {
                                setcolor(RED);
                                outtextxy(170, 300, "Neizdevas atvert failu, parliecinieties, ka tas eksiste.");
                            }
                        }
                        else
                        {
                            if (strcmp(szLastPath, szResultPath) == 0)
                                Exist = 1;
                            else
                                Exist = 0;

                            if ((Exist == 0 && ResultFileExists(argv[0], szResultPath)))
                            {
                                sprintf(szLastPath, "%s", szResultPath);
                                Exist = 1;
                                setcolor(3);
                                outtextxy(170, 320, "Neizdevas izveidot failu, parliecinieties, ka nosaukums ir pareizs.");
                                outtextxy(170, 320, "Fails ir veiksmigi atverts.");
                                setcolor(RED);
                                outtextxy(170, 320, "Fails jau eksiste, Enter - parrakstit failu.");
                            }
                            else
                            {
                                if (OpenResultFile(argv[0], szResultPath))
                                {
                                    input2 = 1;
                                    current = 0;
                                    Exist = 0;
                                    drawTextBox(170, 265, 220, szResultPath);
                                    setcolor(3);
                                    outtextxy(170, 320, "Neizdevas izveidot failu, parliecinieties, ka nosaukums ir pareizs.");
                                    outtextxy(170, 320, "Fails jau eksiste, Enter - parrakstit failu.");
                                    setcolor(1);
                                    outtextxy(170, 320, "Fails ir veiksmigi atverts.");
                                }
                                else
                                {
                                    setcolor(3);
                                    outtextxy(170, 320, "Fails jau eksiste, Enter - parrakstit failu.");
                                    outtextxy(170, 320, "Fails ir veiksmigi atverts.");
                                    setcolor(RED);
                                    outtextxy(170, 320, "Neizdevas izveidot failu, parliecinieties, ka nosaukums ir pareizs.");
                                }
                            }
                        }
                    }
                }
                break;
            case 1:
                drawPicture(10, 15, 128, 162);
                drawTitle();

                current = 0;
                szDescriptor.JointlyRows = 0;
                szDescriptor.JointlyBytes = 0;
                szDescriptor.CreatedComments = 0;
                szDescriptor.iSingleOffset = 0;
                szDescriptor.iCurrentOffset = 0;
                szDescriptor.CreatedLines = 0;
                szDescriptor.iSetOffset = 0;
                szDescriptor.iComment = 0;

                while ((current = ReadString(szSourceString)) >= -1)
                {
                    szDescriptor.JointlyRows++;
                    szDescriptor.JointlyBytes += current;

                    if (current == -1)
                    {
                        szDescriptor.JointlyBytes += strlen(szSourceString) + 1;
                        break;
                    }
                }

                current = 0;
                input = 0;

                fseek(hSourceFile, 0, SEEK_SET);

                while ((current = ReadString(szSourceString)) >= -1)
                {

                    AnalizeText(szSourceString, &szDescriptor);
                    if (current == -1)
                        break;
                }

                setcolor(BLUE);
                outtextxy(30, 195, "Faila apstrade ir pabeigta.");
                settextstyle(SMALL_FONT, HORIZ_DIR, 4);
                outtextxy(30, 220, "Apstrades gaita par failu tika sakopota sekojosa informacija:");
                setcolor(DARKGRAY);
                sprintf(szSourceString, "Faila pirmteksts satureja %i rindas.", szDescriptor.JointlyRows);
                outtextxy(40, 250, szSourceString);
                sprintf(szSourceString, "Faila pirmteksts satureja %d simbolus.", szDescriptor.JointlyBytes);
                outtextxy(40, 270, szSourceString);
                if (szDescriptor.CreatedComments != 0)
                    sprintf(szSourceString, "Tika pievienoti %i komentari.", szDescriptor.CreatedComments);
                else
                    sprintf(szSourceString, "Jauni komentari netika pievienoti.");
                outtextxy(40, 290, szSourceString);
                if (szDescriptor.CreatedLines != szDescriptor.JointlyRows)
                {
                    sprintf(szSourceString, "Programma tika %s par %i rindam.", (long_min(szDescriptor.CreatedLines, szDescriptor.JointlyRows) == szDescriptor.CreatedLines) ? "samazinata" : "palielinata",
                            long_max(szDescriptor.CreatedLines, szDescriptor.JointlyRows) - long_min(szDescriptor.CreatedLines, szDescriptor.JointlyRows));
                    outtextxy(40, 310, szSourceString);
                }
                else
                    outtextxy(40, 310, "Programmas rindu skaits netika mainits.");
                setcolor(BLUE);
                outtextxy(30, 400, "<ENTER> - Apskatit rezultejosa faila saturu.");
                setcolor(RED);
                outtextxy(30, 420, "<ESC> - Iziet no programmas.");

                ch = 0x00;

                while (ch != VK_ESCAPE && ch != VK_RETURN)
                {
                    ch = getch();
                    if (ch != VK_ESCAPE && ch != VK_RETURN)
                    {
                        setcolor(RED);
                        outtextxy(110, 360, "Tika ievadita nekorekta informacija, ludzu, meginiet velreiz");
                    }
                }
                if (ch == VK_ESCAPE)
                    step = 3;

                break;
            case 2:
                setcolor(BLUE);
                settextstyle(SMALL_FONT, HORIZ_DIR, 6);
                outtextxy(230, 5, "Faila saturs:");

                CloseSourceFile();
                hSourceFile = hResultFile;
                input = 0;
                input1 = 1;
                input2 = 0;
                current = 0;
                dbProgress = 0;
                ch = 0x00;

                settextstyle(SMALL_FONT, HORIZ_DIR, 4);
                setcolor(DARKGRAY);

                while (input1)
                {
                    fseek(hSourceFile, 0, SEEK_SET);

                    if (szDescriptor.CreatedLines >= 41)
                        dbProgress = (input2 / (double)(szDescriptor.CreatedLines - 41)) * 100;

                    drawListBox(5, 30, 630, 440, (int)dbProgress);

                    input = 0;
                    while ((current = ReadString(szSourceString)) >= -1)
                    {
                        if (input >= input2)
                        {
                            current = 0;
                            while (textwidth(szSourceString) > 600)
                                szSourceString[strlen(szSourceString) - 1] = '\0';
                            outtextxy(10, 35 + ((input - input2) * 10), szSourceString);
                        }
                        input++;
                        if (current == -1 || (input - input2) > 41)
                            break;
                    }

                    ch = getch();
                    if (ch == 0x00)
                        ch = getch();

                    if (ch == VK_UP && input2 != 0)
                        input2--;
                    if (ch == VK_DOWN && input2 < (szDescriptor.CreatedLines - 41))
                        input2++;

                    input1 = (ch != VK_ESCAPE);
                }

                CloseResultFile();
                break;
            }
        }
        closegraph();
    }
    else
    {
        printf("Graphic initialization error: %s \n", errorcode);
        printf("Press any key to halt :");
        getch();
        exit(1);
    }
}