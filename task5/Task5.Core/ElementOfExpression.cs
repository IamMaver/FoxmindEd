namespace Task5.Core
{
    public class ElementOfExpression
    {
        private string _eExpr;
        private CalcOperation _typeOp;
        private int _order = 0;

        public ElementOfExpression(string eExpr)
        {
            _eExpr = eExpr;
            switch (_eExpr)
            {
                case "*":
                    _order = 2;
                    _typeOp = CalcOperation.Mul;
                    break;
                case "/":
                    _order = 2;
                    _typeOp = CalcOperation.Div;
                    break;
                case "+":
                    _order = 1;
                    _typeOp = CalcOperation.Sum;
                    break;
                case "-":
                    _order = 1;
                    _typeOp = CalcOperation.Sub;
                    break;
                default:
                    _typeOp = CalcOperation.None;
                    break;
            }
        }

        public int Order { get { return _order; } }
        public CalcOperation TypeOp { get { return _typeOp; } }
        public double EExpr
        {
            get => Convert.ToDouble(_eExpr);
            set
            {
                _eExpr = Convert.ToString(value);
            }
        }
        public string EExprString
        {
            get { return _eExpr; }
            set { _eExpr = value; }
        }
    }
}