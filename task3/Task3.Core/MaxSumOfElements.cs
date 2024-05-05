namespace Task3.Core
{
    public class MaxSumOfElements
    {
        private readonly List<LineOfElements> _lines = new();
        private readonly List<int> _numbersWrongLines = new();
        private int _numberLineMaxSum;
        bool _maxSumNotYetSetted = true;

        public MaxSumOfElements(string path)
        {
            FileInfo fileInfo = new(path);
            if (!fileInfo.Exists) throw new ArgumentNullException("Input file not found");

            using (StreamReader stream = new(path))
            {
                string? line;
                while ((line = stream.ReadLine()) != null)
                {
                    this.PutNewLine(line);
                }
            }
            ParseLines();
        }

        public MaxSumOfElements(List<LineOfElements> lines)
        {
            _lines = lines;
            ParseLines();
        }

        public void PutNewLine(string inputString)
        {
            _lines.Add(new LineOfElements(inputString));
        }

        private void ParseLines()
        {
            if (_lines.Count == 0) throw new ArgumentNullException("Wrong input data");
            double curMaxSum = 0;
            for (int i = 0; i < _lines.Count; i++)
            {
                if (_lines[i].IsRightFormat())
                {
                    if (_maxSumNotYetSetted)
                    {
                        curMaxSum = _lines[i].GetSum();
                        _numberLineMaxSum = i + 1;
                        _maxSumNotYetSetted = false;
                    }

                    if (!_maxSumNotYetSetted && (_lines[i].GetSum() > curMaxSum))
                    {
                        curMaxSum = _lines[i].GetSum();
                        _numberLineMaxSum = i + 1;
                    }
                }
                else
                {
                    _numbersWrongLines.Add(i + 1);
                }

            }
        }

        public int GetNumberMaxSumLine()
        {
            return _numberLineMaxSum;
        }

        public int[] GetNumbersWrongFormatLines()
        {
            return _numbersWrongLines.ToArray();
        }

        public bool IsMaxSumFound()
        {
            return !_maxSumNotYetSetted;
        }
    }
}