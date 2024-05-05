using System.Globalization;

namespace Task3.Core
{
    public class LineOfElements
    {
        private readonly bool _isRightFormat;
        private readonly double[] _elements;
        private readonly double _sum;

        public LineOfElements(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                _isRightFormat = false;
                return;
            }
            else
            {
                _isRightFormat = true;
            }
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            string[] strings = inputString.Split(',');
            _elements = new double[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                _isRightFormat = true;
                if (!(Double.TryParse(strings[i], formatter, out _elements[i])))
                {
                    _isRightFormat = false;
                    break;
                }
                _sum += _elements[i];
            }
        }

        public double GetSum()
        {
            return _sum;
        }

        public bool IsRightFormat()
        {
            return _isRightFormat;
        }
    }
}
