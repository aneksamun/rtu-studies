#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include <graphics.h>

#define VK_TAB 0x09
#define VK_CLEAR 0x08
#define VK_RETURN 0x0D
#define VK_ESCAPE 0x1B
#define VK_LEFT 0x4b
#define VK_RIGHT 0x4d
#define VK_UP 0x48
#define VK_DOWN 0x50
#define VK_DELETE 0x53

#define MAXPATH 256

int CharInsert(char *iString, char chChar, int Pos);
int drawTextBox(int x, int y, int cx, char *iText);
int GetCursorPos(char *iText, int cx, int Cursor);
int ReadInputString(int x, int y, int cx, char *iText);
int initGraphics();
void drawTitle();
void setBackground(int i);
void CharDelete(char *iString, int Pos);
void drawListBox(int x, int y, int cx, int cy, int iOX);
void drawPicture(int x, int y, int cx, int cy);

int initGraphic()
{
    int graphicDriver = VGA, graphicMode = VGAHI;
    //initgraph ( &graphicDriver, &graphicMode, "C:\\BORLANDC\\BGI" );
    initgraph(&graphicDriver, &graphicMode, "BGI");
    return graphresult();
}

void setBackground(int i)
{
    setbkcolor(i);
    cleardevice();
}

void drawTitle()
{
    setcolor(BLUE);
    settextstyle(1, HORIZ_DIR, 1);
    outtextxy(190, 100, "PROGRAMMA TEKSTA IZVADEI");
    settextstyle(SMALL_FONT, HORIZ_DIR, 5);
    outtextxy(190, 130, "ATBILSTOSI PROGRAMMESANAS STILA PRASIBAM.");
}

void drawPicture(int x, int y, int cx, int cy)
{
    char szText[2];
    int i, z, iX, iY, jX, jY, iOffset, iChX = 0, iChY = 10, maxx;
    int iColors[] = {WHITE, DARKGRAY, LIGHTGRAY, LIGHTBLUE};
    int Triangle[6];

    for (i = 0; i < 4; i++)
    {
        setcolor(iColors[i]);

        line(x + (cx + i) - 111, (y + i) + 9, x + (cx - i) + 17, (y + i) + 9);
        line(x + (cx - i) + 17, (y + i) + 9, x + (cx - i) + 17, (y - i) + 171);
        line(x + (cx - i) + 17, (y - i) + 171, x + (cx + i) - 111, (y - i) + 171);
        line(x + (cx + i) - 111, (y - i) + 171, x + (cx + i) - 111, (y + i) + 9);

        if (i == 0)
        {
            setfillstyle(SOLID_FILL, WHITE);
            floodfill(x + (cx + 4), y + (cy + 4), iColors[i]);
        }
    }

    settextstyle(SMALL_FONT, HORIZ_DIR, 4);

    for (jY = y + 20; jY < y + (cy - 10); jY += iChY)
    {

        for (jX = x + 27; jX < x + 130; jX += iChX)
        {
            setcolor(iColors[rand() % 4]);

            sprintf(szText, "%c", '0' + rand() % ('z' - '0'));
            iChX = textwidth(szText);

            outtextxy(jX, jY, szText);
        }
    }

    setcolor(WHITE);
    rectangle(cx - 9, y - 4, cx + 3, cy - 55);
    setcolor(DARKGRAY);
    rectangle(cx - 8, y - 3, cx + 2, cy - 56);
    setcolor(LIGHTGRAY);
    rectangle(cx - 7, y - 2, cx + 1, cy - 57);
    setcolor(LIGHTBLUE);
    rectangle(cx - 6, y - 1, cx, cy - 58);
    setfillstyle(INTERLEAVE_FILL, WHITE);
    bar(cx - 5, y, cx - 1, cy - 59);

    setfillstyle(SOLID_FILL, WHITE);
    bar(cx - 9, cy - 46, cx + 3, cy - 55);
    setcolor(DARKGRAY);
    rectangle(cx - 8, cy - 47, cx + 2, cy - 55);
    setcolor(LIGHTGRAY);
    rectangle(cx - 7, cy - 48, cx + 1, cy - 54);

    setcolor(DARKGRAY);
    Triangle[0] = cx - 8;
    Triangle[1] = cy - 47;
    Triangle[2] = cx - 3;
    Triangle[3] = cy - 42;
    Triangle[4] = cx + 2;
    Triangle[5] = cy - 47;
    setfillstyle(SOLID_FILL, DARKGRAY);
    fillpoly(3, Triangle);
}

int drawTextBox(int x, int y, int cx, char *iText)
{
    int cy = 20;
    int Offset = 0;

    setcolor(BLUE);
    rectangle(x, y, x + cx, y + cy);
    setcolor(LIGHTBLUE);
    rectangle(x + 1, y + 1, x + cx - 1, y + cy - 1);

    setfillstyle(SOLID_FILL, WHITE);
    bar(x + 2, y + 2, x + cx - 2, y + cy - 2);

    setcolor(BLUE);
    settextstyle(SMALL_FONT, HORIZ_DIR, 4);
    while (textwidth(iText + Offset) > cx - 10)
        Offset++;
    outtextxy(x + 5, y + 5, iText + Offset);

    return textwidth(iText + Offset);
}

int ReadInputString(int x, int y, int cx, char *iText)
{
    int Continue = 1, Cursor;
    int CursorPos = strlen(iText);
    char chNewChar = 0x00;

    Cursor = GetCursorPos(iText, cx, CursorPos);
    setcolor(BLUE);
    line(x + 3 + Cursor, y + 17, x + 9 + Cursor, y + 17);

    while (Continue == 1)
    {
        chNewChar = getch();
        if (chNewChar == 0x00)
        {
            chNewChar = getch();

            if (chNewChar == VK_LEFT && CursorPos != 0)
                CursorPos--;
            if (chNewChar == VK_RIGHT && CursorPos != strlen(iText))
                CursorPos++;
            if (chNewChar == VK_DELETE && strlen(iText) != 0 && CursorPos != strlen(iText))
                CharDelete(iText, CursorPos);
        }
        else
        {
            if (chNewChar == VK_ESCAPE)
                return -1;
            if (chNewChar == VK_TAB)
                return 0;
            if (chNewChar == VK_RETURN)
                return 1;

            if (chNewChar == VK_CLEAR && CursorPos != 0)
            {
                CursorPos--;
                CharDelete(iText, CursorPos);
            }
            else
            {
                CursorPos += CharInsert(iText, chNewChar, CursorPos);
            }
        }

        drawTextBox(x, y, cx, iText);
        Cursor = GetCursorPos(iText, cx, CursorPos);
        setcolor(BLUE);
        line(x + 3 + Cursor, y + 17, x + 9 + Cursor, y + 17);
    }
    return 0;
}

int GetCursorPos(char *iText, int cx, int Cursor)
{
    int Offset = 0, iReturn;
    char chTemp;

    chTemp = iText[Cursor];
    iText[Cursor] = '\0';

    while (textwidth(iText + Offset) > cx - 10)
        Offset++;

    iReturn = textwidth(iText + Offset);
    iText[Cursor] = chTemp;

    return iReturn;
}

void CharDelete(char *iString, int Pos)
{
    if (strlen(iString) == Pos + 1)
    {
        iString[Pos] = '\0';
    }
    else
    {
        int i;
        for (i = Pos; i < strlen(iString); i++)
        {
            iString[i] = iString[i + 1];
        }
        iString[strlen(iString)] = '\0';
    }
}

int CharInsert(char *iString, char chChar, int Pos)
{
    if (strlen(iString) != MAXPATH)
    {
        if (strlen(iString) == Pos)
        {
            iString[Pos] = chChar;
        }
        else
        {
            int i;
            for (i = strlen(iString); i > Pos; i--)
            {
                iString[i] = iString[i - 1];
            }
            iString[Pos] = chChar;
        }
        return 1;
    }
    return 0;
}

void drawListBox(int x, int y, int cx, int cy, int iOX)
{
    int Triangle[6];
    double dbLength = 0.0;

    setcolor(DARKGRAY);
    rectangle(x, y, x + cx, y + cy);
    setcolor(3);
    rectangle(x + 1, y + 1, x + cx - 1, y + cy - 1);

    setfillstyle(SOLID_FILL, WHITE);
    bar(x + 2, y + 2, x + cx - 22, y + cy - 2);

    setcolor(3);
    rectangle(x + cx - 20, y + 1, x + cx - 1, y + cy - 1);
    setcolor(DARKGRAY);
    line(x + cx - 21, y, x + cx - 21, y + cy);

    setfillstyle(INTERLEAVE_FILL, BROWN);
    bar(x + cx - 19, y + 2, x + cx - 2, y + cy - 2);

    setcolor(DARKGRAY);
    line(x + cx - 21, y + 20, x + cx, y + 20);
    line(x + cx - 21, y + cy - 20, x + cx, y + cy - 20);

    setcolor(3);
    rectangle(x + cx - 19, y + 2, x + cx - 2, y + 19);
    rectangle(x + cx - 19, y + cy - 2, x + cx - 2, y + cy - 19);

    setfillstyle(INTERLEAVE_FILL, WHITE);
    bar(x + cx - 18, y + 3, x + cx - 3, y + 18);
    bar(x + cx - 18, y + cy - 3, x + cx - 3, y + cy - 18);

    setfillstyle(SOLID_FILL, DARKGRAY);
    Triangle[0] = x + cx - 16;
    Triangle[1] = y + 15;

    Triangle[2] = x + cx - 4;
    Triangle[3] = y + 15;

    Triangle[4] = x + cx - 10;
    Triangle[5] = y + 5;
    fillpoly(3, Triangle);

    Triangle[0] = x + cx - 16;
    Triangle[1] = y + cy - 15;

    Triangle[2] = x + cx - 4;
    Triangle[3] = y + cy - 15;

    Triangle[4] = x + cx - 10;
    Triangle[5] = y + cy - 5;
    fillpoly(3, Triangle);

    dbLength = (iOX / 100.0) * (cy - 70);

    setcolor(DARKGRAY);
    rectangle(x + cx - 19, y + 20 + (int)dbLength, x + cx - 2, y + 50 + (int)dbLength);
    setfillstyle(INTERLEAVE_FILL, WHITE);
    bar(x + cx - 18, y + 21 + (int)dbLength, x + cx - 3, y + 49 + (int)dbLength);
}