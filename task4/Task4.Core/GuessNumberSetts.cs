namespace Task4.Core
{
    public class GuessNumberSetts
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public int MinValue
        {
            get { return _minValue; }
        }

        public int MaxValue
        {
            get { return _maxValue; }
        }

        public GuessNumberSetts(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }
    }
}
