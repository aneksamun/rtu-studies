#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <conio.h>
#include <errno.h>

#define MAXPATH 256
#define MAXSTR 512

FILE *hSourceFile = NULL;
FILE *hResultFile = NULL;

int IsC();
int CloseResultFile();
int CloseSourceFile();
void StripSpaces(char *szString);
int ReadString(char *inString);
int InText(char *szString, int iPos);
int IsEnding(char *szString, int iPos);
int InBrackets(char *szString, int iPos);
int FindChar(char *szString, char chChar);
int ReverseFindChar(char *szString, char chChar);
int FindWord(char *szString, char *szWord);
int IsComment(char *szString, int iComment);
int FindSubString(char *szText, char *szSubString);
int OpenSourceFile(char *inPathName, char *inFileName);
int OpenResultFile(char *inPathName, char *inFileName);
int ResultFileExists(char *szPathName, char *szFileName);
int AnalizeText(char *szString, struct SourceFileDescription *szDescriptor);

typedef struct SourceFileDescription
{
    long JointlyRows;
    long CreatedLines;
    long JointlyBytes;
    char chLastSeparator;
    int iSingleOffset;
    int iCurrentOffset;
    int CreatedComments;
    int iSetOffset;
    int iComment;
};

#define min(a, b) a > b ? b : a

int IsFunction(char *szString, struct SourceFileDescription *szDescriptor)
{
    int i;

    if (((i = FindChar(szString, '(')) != -1) &&
        (InText(szString, i) == 0) &&
        (szDescriptor->iCurrentOffset == 0))
    {
        return (szDescriptor->chLastSeparator != ';');
    }

    return 0;
}

int FindDivider(char *szString, struct SourceFileDescription *szDescriptor)
{
    int a, b, c, x;

    a = FindChar(szString, ';');
    b = FindChar(szString, '{');
    c = FindChar(szString, '}');

    if (InBrackets(szString, a) != 0)
        return -1;

    if (a == -1)
        a = strlen(szString) + 1;
    if (b == -1)
        b = strlen(szString) + 1;
    if (c == -1)
        c = strlen(szString) + 1;

    x = min(min(a, b), c);

    if (x == a)
        szDescriptor->chLastSeparator = ';';
    if (x == b)
        szDescriptor->chLastSeparator = '{';
    if (x == c)
        szDescriptor->chLastSeparator = '}';

    if (x == (strlen(szString) + 1))
        return -1;
    return x;
}

int InBrackets(char *szString, int iPos)
{
    int InBrackets = 0, i;

    for (i = 0; i < iPos; i++)
    {
        if ((szString[i] == '(') && (InText(szString, i) == 0))
        {
            InBrackets = 1;
        }
        if ((szString[i + 1] == ')') && (InText(szString, i) == 0))
        {
            InBrackets = 0;
        }
    }

    if (szString[iPos - 1] == ')')
        InBrackets = 0;

    return InBrackets;
}

int IsEnding(char *szString, int iPos)
{
    int i;
    for (i = iPos; i < strlen(szString); i++)
        if (szString[i] != ' ' && szString[i] != '\t' && szString[i] != '\r')
            return 0;
    return 1;
}

int InComment(char *szString, int iComment)
{
    int i;

    if (iComment == 1)
        iComment = 0;

    for (i = 0; i < strlen(szString); i++)
    {
        if (iComment == 0)
        {
            if ((szString[i] == '/' && szString[i + 1] == '*') || (szString[i] == '/' && szString[i + 1] == '/'))
            {
                iComment = 1;
            }
            else if (szString[i] != ' ' && szString[i] != '\t' && szString[i] != '\r')
                return 0;
        }
    }
    return iComment;
}

int AnalizeText(char *szString, struct SourceFileDescription *szDescriptor)
{
    int iDivider = -1, iSubDivider = -1, iOffset = 0, i, x, iPrint = 1;
    char chCharDiv, chTemp;

    StripSpaces(szString);

    if (strlen(szString) == 0)
        return 0;

    while ((iDivider = FindDivider(szString + iOffset, szDescriptor)) != -1)
    {
        iOffset += iDivider;

        if (InText(szString, iOffset) == 0)
            break;
        else
            iDivider = -1;

        iOffset++;
    }

    if (iDivider != -1)
    {
        iSubDivider = iOffset + 1;
        iDivider = iOffset;
        while ((iDivider < (strlen(szString) - 1)) && (szString[iDivider + 1] == ' ' ||
                                                       szString[iDivider + 1] == '\t' || szString[iDivider + 1] == '\r'))
            iDivider++;
        if (iDivider >= (strlen(szString) - 1))
            iDivider = -1;
        else
            iDivider++;
    }

    if (iDivider != -1)
    {
        chCharDiv = szString[iSubDivider];

        szString[iSubDivider] = '\0';
    }

    if (((i = FindChar(szString, '}')) != -1) && (InText(szString, i) == 0))
    {
        szDescriptor->iCurrentOffset--;
    }

    while (((i = FindWord(szString, "#include")) != -1) && (InText(szString, i) == 0) && ((x = FindChar(szString + i, '>')) != -1) && (IsEnding(szString, x + 1) == 0))
    {
        chTemp = szString[i + x + 1];
        szString[i + x + 1] = '\0';

        for (i = 0; i < szDescriptor->iCurrentOffset; i++)
            fputs("    ", hResultFile);
        fprintf(hResultFile, "%s\n", szString);

        szString[i + x + 1] = chTemp;
        szString += i + x + 1;
        iDivider -= i + x + 1;
        iSubDivider -= i + x + 1;

        if (chTemp == ' ' || chTemp == '\t')
        {
            szString++;
            iDivider--;
            iSubDivider--;
        }
        szDescriptor->CreatedLines++;
    }

    if ((szString[0] == '}') && (IsEnding(szString, 1) == 0))
    {
        for (i = 0; i < szDescriptor->iCurrentOffset; i++)
            fputs("    ", hResultFile);

        fprintf(hResultFile, "}\n");

        if (szString[1] == ' ' || szString[1] == '\t')
        {
            szString += 2;
            iDivider -= 2;
            iSubDivider -= 2;
        }
        else
        {
            szString++;
            iDivider--;
            iSubDivider--;
        }
    }

    if (IsFunction(szString, szDescriptor) && szDescriptor->iComment == 0)
    {
        fprintf(hResultFile, "\n");
        fprintf(hResultFile, "/*-------------------------------\n");
        fprintf(hResultFile, "         Funkcijas apraksts      \n");
        fprintf(hResultFile, "-------------------------------*/\n");
        szDescriptor->CreatedLines += 4;
        szDescriptor->CreatedComments++;
    }

    if ((i = FindWord(szString, "case")) != -1 && (x = FindChar(szString + i + 4, ':')) != -1)
    {
        if (szDescriptor->iComment == 0)
        {
            fputs("\n", hResultFile);
            for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                fputs("    ", hResultFile);

            fputs("// Nosacijuma komentars\n", hResultFile);

            szDescriptor->CreatedLines += 2;
            szDescriptor->CreatedComments++;
            szDescriptor->iSetOffset = 1;
        }
    }

    if (FindWord(szString, "case") == -1 && szDescriptor->iSetOffset == 1)
    {
        szDescriptor->iCurrentOffset++;
        szDescriptor->iSetOffset = 0;
    }

    if (FindWord(szString, "break") != -1)
    {
        szDescriptor->iCurrentOffset--;
    }

    if ((i = FindWord(szString, "for")) != -1)
    {
        if (szDescriptor->iComment == 0)
        {
            fputs("\n", hResultFile);
            for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                fputs("    ", hResultFile);

            fputs("// Cikla komentars\n", hResultFile);
            szDescriptor->CreatedLines += 2;
            szDescriptor->CreatedComments++;
        }

        if (szDescriptor->chLastSeparator != '{' && ((x = FindChar(szString, ')')) != -1))
        {
            if (IsEnding(szString, x + 1) != 0)
            {
                szDescriptor->iSingleOffset = 1;
            }
        }
        if (szDescriptor->chLastSeparator == ';' && ((x = FindChar(szString, ')')) != -1))
        {
            if ((IsEnding(szString, x + 1) == 0) && (szString[x + 1] != '{'))
            {
                iPrint = 0;
                chTemp = szString[x + 1];
                szString[x + 1] = '\0';

                for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                    fputs("    ", hResultFile);
                fprintf(hResultFile, "%s\n", szString);

                szString[x + 1] = chTemp;

                for (i = 0; i <= szDescriptor->iCurrentOffset; i++)
                    fputs("    ", hResultFile);
                fprintf(hResultFile, "%s\n", szString + (x + 1));
            }
        }
    }

    if (((i = FindWord(szString, "while")) != -1))
    {
        if (szDescriptor->iComment == 0)
        {
            fputs("\n", hResultFile);
            for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                fputs("    ", hResultFile);

            fputs("// Cikla komentars\n", hResultFile);
            szDescriptor->CreatedLines += 2;
            szDescriptor->CreatedComments++;
        }

        if (szDescriptor->chLastSeparator != '{' && ((x = ReverseFindChar(szString, ')')) != -1))
        {
            if (IsEnding(szString, x + 1) != 0)
            {
                szDescriptor->iSingleOffset = 1;
            }
            else
            {
                iPrint = 0;
                chTemp = szString[x + 1];
                szString[x + 1] = '\0';

                for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                    fputs("    ", hResultFile);
                fprintf(hResultFile, "%s\n", szString);

                szString[x + 1] = chTemp;

                for (i = 0; i <= szDescriptor->iCurrentOffset; i++)
                    fputs("    ", hResultFile);
                fprintf(hResultFile, "%s\n", szString + (x + 1));
            }
        }
    }

    if ((i = FindWord(szString, "if")) != -1)
    {
        if (szDescriptor->iComment == 0)
        {
            fputs("\n", hResultFile);
            for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                fputs("    ", hResultFile);

            fputs("// Nosacijuma komentars\n", hResultFile);
            szDescriptor->CreatedLines += 2;
            szDescriptor->CreatedComments++;
        }

        if (szDescriptor->chLastSeparator != '{' && ((x = ReverseFindChar(szString, ')')) != -1))
        {
            if (IsEnding(szString, x + 1) != 0)
            {
                szDescriptor->iSingleOffset = 1;
            }
            else
            {
                iPrint = 0;
                chTemp = szString[x + 1];
                szString[x + 1] = '\0';

                for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                    fputs("    ", hResultFile);
                fprintf(hResultFile, "%s\n", szString);

                szString[x + 1] = chTemp;

                for (i = 0; i <= szDescriptor->iCurrentOffset; i++)
                    fputs("    ", hResultFile);
                fprintf(hResultFile, "%s\n", szString + (x + 1));
            }
        }
    }

    if ((i = FindWord(szString, "else")) != -1 && (IsEnding(szString, i + 5) != 0) && (szDescriptor->chLastSeparator != '{'))
    {
        szDescriptor->iSingleOffset = 1;
    }

    if ((x = FindWord(szString, "else")) != -1 && (IsEnding(szString, x + 5) == 0) && (szDescriptor->chLastSeparator != '{'))
    {
        iPrint = 0;
        chTemp = szString[x + 5];
        szString[x + 5] = '\0';

        for (i = 0; i < szDescriptor->iCurrentOffset; i++)
            fputs("    ", hResultFile);
        fprintf(hResultFile, "%s\n", szString);

        szString[x + 5] = chTemp;

        for (i = 0; i <= szDescriptor->iCurrentOffset; i++)
            fputs("    ", hResultFile);
        fprintf(hResultFile, "%s\n", szString + (x + 5));
    }

    if ((szString[0] == '{') && (IsEnding(szString, 1) != 0))
    {
        szDescriptor->iSingleOffset = 0;
    }

    if (iPrint == 1)
    {
        if (szDescriptor->iSingleOffset == 2)
        {
            fputs("    ", hResultFile);
            szDescriptor->iSingleOffset = 0;
        }

        if (szDescriptor->iSingleOffset == 1)
            szDescriptor->iSingleOffset = 2;

        for (i = 0; i < szDescriptor->iCurrentOffset; i++)
            fputs("    ", hResultFile);

        if (((i = FindChar(szString, '{')) != -1) && (InText(szString, i) == 0) && (IsEnding(szString, i + 1) != 0))
        {
            if (i != 0)
            {
                szString[i] = '\0';
                fprintf(hResultFile, "%s\n", szString);

                for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                    fputs("    ", hResultFile);
            }

            fprintf(hResultFile, "{\n");
            szDescriptor->CreatedLines += 2;
            szDescriptor->iCurrentOffset++;
        }
        else
        {
            if (((i = FindChar(szString, '}')) != -1) && (InText(szString, i) == 0) && (IsEnding(szString, i + 1) != 0))
            {
                if (i != 0)
                {
                    szString[i] = '\0';
                    fprintf(hResultFile, "%s\n", szString);

                    for (i = 0; i < szDescriptor->iCurrentOffset; i++)
                        fputs("    ", hResultFile);
                }

                fprintf(hResultFile, "}\n");
                szDescriptor->CreatedLines += 2;
            }
            else
            {
                fprintf(hResultFile, "%s\n", szString);
                szDescriptor->CreatedLines++;
            }
        }
    }

    szDescriptor->iComment = InComment(szString, szDescriptor->iComment);

    if (iDivider != -1)
    {
        szString[iSubDivider] = chCharDiv;
        AnalizeText(szString + iDivider, szDescriptor);
    }
    return 0;
}

int FindWord(char *szString, char *szWord)
{
    int iCurrentPos = 0, iLastPos, i, x;
    char szTerminatingChars[] = {" ();.\t\r\n"};

    while ((iLastPos = FindSubString(szString + iCurrentPos, szWord)) != -1)
    {

        iCurrentPos += iLastPos;

        if (InText(szString, iCurrentPos) == 0)
        {
            x = 0;

            if (iCurrentPos != NULL)
            {
                for (i = 0; i < strlen(szTerminatingChars); i++)
                {
                    if (szString[iCurrentPos - 1] == szTerminatingChars[i])
                    {
                        x = 1;
                        break;
                    }
                }
            }
            else
                x = 1;

            if (x == 1)
            {
                if (iCurrentPos + strlen(szWord) != strlen(szString))
                {
                    for (i = 0; i < strlen(szTerminatingChars); i++)
                        if (szString[strlen(szWord) + iCurrentPos] == szTerminatingChars[i])
                            return iCurrentPos;
                }
                else
                    return iCurrentPos;
            }
        }
        iCurrentPos++;
    }
    return -1;
}

int FindSubString(char *szText, char *szSubString)
{

    int iLettersFound = 0, i, a;

    char szString[MAXSTR];
    strcpy(szString, szText);

    if (strlen(szString) < strlen(szSubString))
        return -1;

    for (i = 0; i < strlen(szString); i++)
    {
        iLettersFound = 0;
        if (szString[i] == szSubString[0])
        {
            iLettersFound = 1;
            for (a = 1; a < strlen(szSubString); a++)
            {
                if (szString[i + a] == szSubString[a])
                {
                    iLettersFound++;
                    if (iLettersFound == strlen(szSubString))
                        return i;
                }
                else
                    break;
            }
        }
    }
    return -1;
}

int FindChar(char *szString, char chChar)
{
    int i;

    for (i = 0; i < strlen(szString); i++)
        if (szString[i] == chChar)
            return i;

    return -1;
}

int ReverseFindChar(char *szString, char chChar)
{
    int i;

    for (i = (strlen(szString) - 1); i >= 0; i--)
        if (szString[i] == chChar)
            return i;

    return -1;
}

int InText(char *szString, int iPos)
{
    int iFound = 0, iOffset = 0, iInText = 0;

    if (iPos == 0)
        return 0;

    while ((iFound = FindChar(szString + iOffset, '"')) != -1)
    {
        iOffset += iFound;
        if (iOffset > iPos)
            return iInText;
        iInText = (iInText == 0) ? 1 : 0;
        iOffset++;
    }

    return iInText;
}

void strip_spaces(char *szString)
{
    int i = 0, iSpaces = 0;

    while ((i < strlen(szString)) && ((szString[i] == ' ') || (szString[i] == '\t') || (szString[i] == '\r')))
    {
        iSpaces++;
        i++;
    }

    if (iSpaces > 0)
    {
        for (i = 0; i < strlen(szString) - iSpaces; i++)
        {
            szString[i] = szString[i + iSpaces];
        }
        szString[i] = '\0';
    }
}

int IsC()
{
    char szString[MAXSTR];
    int i, iCurrent = 0, iReturn = 0;

    fseek(hSourceFile, 0, SEEK_SET);

    while ((iCurrent = read_string(szString)) >= -1)
    {

        strip_spaces(szString);

        if ((FindWord(szString, "#include") == 0) && (InText(szString, i) == 0))
        {
            iReturn = 1;
        }

        for (i = 0; i < strlen(szString); i++)
        {
            if (szString[i] != ' ' && szString[i] != '\t' && szString[i] != '\r' && szString[i] != '\n' && iReturn == 0)
                return 0;
        }
        if (iCurrent == -1)
            break;
    }

    fseek(hSourceFile, 0, SEEK_SET);
    return iReturn;
}

int OpenSourceFile(char *inPathName, char *inFileName)
{
    char szTempFileName[(2 * MAXPATH) + 5] = {NULL};

    hSourceFile = fopen(inFileName, "r");

    if (hSourceFile == NULL)
    {
        strcat(szTempFileName, inPathName);
        strcat(szTempFileName, inFileName);

        hSourceFile = fopen(szTempFileName, "r");
        if (hSourceFile == NULL)
        {
            strcat(szTempFileName, ".c");
            hSourceFile = fopen(szTempFileName, "r");
        }
    }

    if (hSourceFile != NULL)
        fseek(hSourceFile, 0, SEEK_SET);
    return (hSourceFile != NULL);
}

int OpenResultFile(char *inPathName, char *inFileName)
{
    char szTempFileName[(2 * MAXPATH) + 5] = {NULL};

    hResultFile = fopen(inFileName, "w+");

    if (hResultFile == NULL)
    {
        strcat(szTempFileName, inPathName);
        strcat(szTempFileName, inFileName);

        hResultFile = fopen(szTempFileName, "w+");
        if (hResultFile == NULL)
        {
            strcat(szTempFileName, ".c");
            hResultFile = fopen(szTempFileName, "w+");
        }
    }

    return (hResultFile != NULL);
}

int ReadString(char *szString)
{
    int iLength = 0;
    memset(szString, 0, MAXSTR);

    for (iLength = 0; iLength < MAXSTR; iLength++)
    {
        if (fread(szString + iLength, sizeof(char), 1, hSourceFile) != NULL)
        {
            if (szString[iLength] == '\n')
                break;
        }
        else
        {
            break;
        }
    }

    if (feof(hSourceFile) == NULL)
    {
        if (szString[iLength] == '\n')
        {
            szString[iLength] = '\0';
            return iLength + 1;
        }
        else
            return -2;
    }

    szString[iLength] = '\0';
    return -1;
}

int ResultFileExists(char *szPathName, char *szFileName)
{
    char szTempFileName[(2 * MAXPATH) + 5] = {NULL};

    FILE *hTempFile = fopen(szFileName, "r");

    if (hTempFile == NULL)
    {
        if (errno == ENOFILE)
        {
            return 0;
        }
    }
    else
    {
        fclose(hTempFile);
        return 1;
    }

    strcat(szTempFileName, szPathName);
    strcat(szTempFileName, szFileName);

    hTempFile = fopen(szTempFileName, "r");
    if (hTempFile == NULL)
    {
        if (errno == ENOFILE)
        {
            return 0;
        }
    }
    else
    {
        fclose(hTempFile);
        return 1;
    }

    strcat(szTempFileName, ".c");
    hTempFile = fopen(szTempFileName, "r");

    if (hTempFile == NULL)
    {
        return (errno != ENOFILE);
    }
    else
    {
        fclose(hTempFile);
        return 1;
    }
}

int CloseSourceFile()
{
    if (hSourceFile != NULL)
    {
        fclose(hSourceFile);
        hSourceFile = NULL;
        return 1;
    }
    return 0;
}

int CloseResultFile()
{
    if (hResultFile != NULL)
    {
        fclose(hResultFile);
        hResultFile = NULL;
        return 1;
    }
    return 0;
}