using System;
using Task2.Library;

int column = GetData("column");
int line = GetData("line");
FoxMatrix foxMatrix = new(line, column);
int[] snailShells;
snailShells = foxMatrix.GetSnailShells();
FoxMatrixUI foxMatrixUI = new (foxMatrix);
foxMatrixUI.Print();
foxMatrixUI.PrintMatrixTrace();
foxMatrixUI.PrintSnailShells(snailShells);

static int GetData(string par)
{
    int res=0;
    while (res < 1)
    {
        Console.WriteLine("Please enter the number of " + par);
        string input = Console.ReadLine();
        int.TryParse(input, out res);
    }

    return res;
}