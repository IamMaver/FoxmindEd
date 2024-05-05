using Task5.Core;
string expr, inputP, outputP;
while (true)
{
    Console.WriteLine("\nPlease input work mode:\nPress 'C' for console input\nPress 'F' for file input\nPress other key to exit\n");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.C:
            Console.WriteLine("Please insert math expression");
            expr = Console.ReadLine();
            CalculatorUI CalcUI = new(expr);
            Console.WriteLine("Result\n" + CalcUI.GetResult());
            break;
        case ConsoleKey.F:
            Console.WriteLine("Please enter name of the input file (example.txt for example)");
            inputP = Console.ReadLine();
            if (inputP == string.Empty)
            {
                break;
            }
            FileInfo fileInfo = new(inputP);
            if (!fileInfo.Exists)
            {
                Console.WriteLine("File does not exist");
                break;
            }
            Console.WriteLine("Please enter name of the output file");
            outputP = Console.ReadLine();
            CalculatorUI CalcUI1 = new(inputP, outputP);
            break;
        default:
            return;
    }
}