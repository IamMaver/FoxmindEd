using System.Text.RegularExpressions;

namespace Task5.Core
{
    public class CalculatorUI
    {
        private readonly Calculator _calc;

        public CalculatorUI(string inputStr)
        {
            _calc = new Calculator(inputStr);
        }

        public CalculatorUI(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new(inputFilePath))
            {
                StreamWriter writer = new(outputFilePath, false);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    CalculatorUI CalcUI = new(line);
                    writer.WriteLine(line + " = " + CalcUI.GetResult());
                }
                writer.Close();
            }
        }

        public string GetResult()
        {
            return _calc.GetResult();
        }
    }
}