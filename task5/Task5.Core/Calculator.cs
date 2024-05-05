using System.Text.RegularExpressions;

namespace Task5.Core
{
    public class Calculator
    {
        private readonly List<ElementOfExpression> _elemExp = new();
        private CalcError _error;

        public Calculator(string inputString)
        {
            if (!CheckRightBrackets(inputString)) 
            {
                _error = CalcError.WrongFormat;
                return;
            }
            List<string> inputElement = new();
            inputElement = Parse4Calc(inputString);
            if (_error != CalcError.None) return;
            foreach (var ie in inputElement)
            {
                _elemExp.Add(new ElementOfExpression(ie));
            }
            try
            {
                CalcExpression(_elemExp);
            }
            catch (Exception ex)
            {
                _error = CalcError.WrongFormat;
                return;
            }
        }

        private List<string> Parse4Calc(string inputStr)
        {
            for (int i = 0; i < inputStr.Length; i++)
            {
                if (char.IsNumber(inputStr[i]))
                {
                    continue;
                }
                switch (inputStr[i])
                {
                    case '(':
                        continue;
                    case ')':
                        continue;
                    case '*':
                        continue;
                    case '/':
                        continue;
                    case '+':
                        continue;
                    case '-':
                        continue;
                    default:
                        _error = CalcError.WrongFormat;
                        return null;
                }
            }
            List<string> result = new();
            int countResChar = 0;
            foreach (var match in Regex.Matches(inputStr, @"([*+/\-)(])|([0-9.]+|.)"))
            {
                string cString = match.ToString();

                countResChar += cString.Length;

                result.Add(cString);
            }
            if (result[0] == "-")
            {
                result[0] = "-1";
                result.Insert(1, "*");
            }

            return result;
        }

        public string GetResult()

        {
            switch (_error)
            {
                case CalcError.None:
                    return _elemExp[0].EExprString;
                case CalcError.DevideByZero:
                    return "Exception. Divide by zero.";
                case CalcError.WrongFormat:
                    return "Exception. Wrong input.";
                default:
                    return String.Empty;
            }
        }

        private int GetIndexEndBracket(List<ElementOfExpression> inputExp, int startIndex)
        {
            int countBrackets = 1;
            for (int i = startIndex + 1; i < inputExp.Count; i++)
            {
                if (inputExp[i].EExprString == ")")
                {
                    countBrackets--;
                    if (countBrackets == 0) return i;
                }
                if (inputExp[i].EExprString == "(")
                {
                    countBrackets++;
                }
            }

            return inputExp.Count - 1;
        }

        private ElementOfExpression CalcExpression(List<ElementOfExpression> elemExp)
        {
            ElementOfExpression result;

            for (int i = 0; i < elemExp.Count; i++)
            {
                if (elemExp[i].EExprString == "(")
                {
                    int indexEB = this.GetIndexEndBracket(elemExp, i);
                    List<ElementOfExpression> subString = new();
                    subString = elemExp.GetRange(i + 1, indexEB - i - 1);
                    result = CalcExpression(subString);
                    elemExp[i] = result;
                    elemExp.RemoveRange(i + 1, indexEB - i);
                }
            }

            for (int prior = 2; prior > 0; prior--)
            {
                for (int i = 0; i < elemExp.Count; i++)
                {
                    if (elemExp[i].Order == prior)
                    {
                        PerformOperation(elemExp[i - 1], elemExp[i], elemExp[i + 1]);
                        elemExp.RemoveAt(i);
                        elemExp.RemoveAt(i);
                        i -= 2;
                    }
                }
            }
            return elemExp[0];
        }

        private void PerformOperation(ElementOfExpression first, ElementOfExpression second, ElementOfExpression third)
        {
            switch (second.TypeOp)
            {
                case CalcOperation.Mul:
                    first.EExpr *= third.EExpr;
                    break;
                case CalcOperation.Div:
                    if (third.EExpr == 0)
                    {
                        _error = CalcError.DevideByZero;
                        return;
                    }
                    first.EExpr /= third.EExpr;
                    break;
                case CalcOperation.Sum:
                    first.EExpr += third.EExpr;
                    break;
                case CalcOperation.Sub:
                    first.EExpr -= third.EExpr;
                    break;
            }
        }

        private bool CheckRightBrackets(string inputString)
        {
            int countBracket = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                switch (inputString[i])
                {
                    case '(':
                        countBracket++;
                        break;
                    case ')':
                        countBracket--;
                        break;
                }
                if (countBracket < 0) return false;
            }
            if (countBracket == 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}