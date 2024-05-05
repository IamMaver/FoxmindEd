using Task5.Core;

namespace Task5.Tests
{
    public class CalcTests
    {
        [Theory]
        [InlineData("*", 2, CalcOperation.Mul)]
        [InlineData("/", 2, CalcOperation.Div)]
        [InlineData("+", 1, CalcOperation.Sum)]
        [InlineData("-", 1, CalcOperation.Sub)]
        [InlineData(")", 0, CalcOperation.None)]

        public void TestElementofExpressionConstr(string expr, int order, CalcOperation co)
        {

            //Arrange
            //Act

            ElementOfExpression eoe = new(expr);

            //Assert

            Assert.Equal(order, eoe.Order);
            Assert.Equal(co, eoe.TypeOp);
        }

        [Theory]
        [InlineData("200*5+50","1050")]
        [InlineData("2+2*3", "8")]
        [InlineData("2/0", "Exception. Divide by zero.")]
        [InlineData("1+2*(3+2)", "11")]
        [InlineData("1+x+4", "Exception. Wrong input.")]
        [InlineData("2+15/3+4*2", "15")]
        [InlineData("--5+2", "Exception. Wrong input.")]

        public void TestCalcUI(string input, string expected)
        {

            //Arrange
            //Act

            CalculatorUI CalcUI = new(input);

            //Assert

            Assert.Equal(expected, CalcUI.GetResult());
        }
    }
}