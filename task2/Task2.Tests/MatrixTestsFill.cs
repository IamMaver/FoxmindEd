using System.Data.Common;
using Task2.Library;
using Xunit;

namespace Task2.Tests
{
    public class MatrixTestsFill
    {

        [Fact]

        public void TestMatrixTrace()
        {
            //Arrange

            int line = 2, column = 2;
            int[,] matrix = { { 5, 10 }, { 1, 5 } };
            FoxMatrix a = new(line, column, matrix);
            int trace, expectedTrace = 10;

            //Act

            trace = a.GetMatrixTrace();

            //Assert

            Assert.Equal(expectedTrace, trace);
        }

        [Fact]

        public void TestMatrixSnailShells()
        {
            //Arrange

            int line = 3, column = 3;
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            FoxMatrix a = new(line, column, matrix);
            int[] expectedSS = { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            int[] actualSS;

            //Act

            actualSS = a.GetSnailShells();

            //Assert

            Assert.Equal(expectedSS, actualSS);
        }

        [Fact]

        public void TestMatrixRightParameters()
        {
            //Arrange

            int line = 4, column = 3;
            FoxMatrix a = new(line, column);
            int expectedLine = 4, expectedColumn = 3;
            int actualLine, actualColumn;

            //Act

            actualLine = a.LinesCount;
            actualColumn = a.ColumnCount;

            //Assert

            Assert.Equal(expectedLine, actualLine);
            Assert.Equal(expectedColumn, actualColumn);
        }

        [Fact]
        public void TestErrorIfWrongParameters()
        {
            //Arrange

            int line = -2, column = -5;

            //Act
            //Assert 

            Assert.Throws<Exception>(() => (new FoxMatrix(line, column)));
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(8, 8)]
        [InlineData(20, 20)]

        public void TestFillMatrix(int line, int column)
        {
            //Arrange

            //Act

            FoxMatrix a = new FoxMatrix(line, column);

            //Assert

            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Assert.True((a[i, j] >= 0) && (a[i, j] <= 100));
                }
            }
        }
    }
}