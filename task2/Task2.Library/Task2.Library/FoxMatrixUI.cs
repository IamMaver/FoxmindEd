using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    public class FoxMatrixUI
    {
        private readonly FoxMatrix foxMatrix;
        public FoxMatrixUI(FoxMatrix foxMatrix)
        {
            this.foxMatrix = foxMatrix;
        }

        public void Print()
        {
            for (int i = 0; i < foxMatrix.LinesCount; i++)
            {
                for (int j = 0; j < foxMatrix.ColumnCount; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0}", (foxMatrix[i, j].ToString()).PadLeft(4));
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0}", (foxMatrix[i, j].ToString()).PadLeft(4));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void PrintMatrixTrace()
        {
            Console.WriteLine("\nMatrix trace = " + foxMatrix.GetMatrixTrace() + "\n");
        }


        public void PrintSnailShells(int [] snailShells)
        {
            Console.WriteLine("SnailShells:\n");
            foreach (var ss in snailShells)
            {
                Console.Write(ss.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}