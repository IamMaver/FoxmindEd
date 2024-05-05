using Task4.Core;

namespace Task4.Tests
{
    public class TestGuessNumber
    {
        [Fact]
        public void TestForRandomNumber()
        {

            //Arrange

            int min = 0; int max = 100;
            int actual;

            //Act

            GuessNumberSetts gns = new GuessNumberSetts(min, max);
            GuessNumber gn = new GuessNumber(gns);
            actual = gn.Number;

            //Assert

            Assert.InRange(actual, min, max);
        }

        [Fact]

        public void TestForCheckNumberEqual()
        {
            //Arrange

            int min = 0; int max = 100;
            int number;

            //Act

            GuessNumberSetts gns = new GuessNumberSetts(min, max);
            GuessNumber gn = new GuessNumber(gns);
            number = gn.Number;

            //Assert

            Assert.Equal(Answers.Equal, gn.CheckNumber(number));
        }

        [Fact]

        public void TestForCheckNumberLess()
        {
            //Arrange

            int min = 0; int max = 100;
            int number;

            //Act

            GuessNumberSetts gns = new GuessNumberSetts(min, max);
            GuessNumber gn = new GuessNumber(gns);
            number = gn.Number;

            //Assert

            Assert.Equal(Answers.Less, gn.CheckNumber(number-1));
        }

        [Fact]

        public void TestForCheckNumberMore()
        {
            //Arrange

            int min = 0; int max = 100;
            int number;

            //Act

            GuessNumberSetts gns = new GuessNumberSetts(min, max);
            GuessNumber gn = new GuessNumber(gns);
            number = gn.Number;

            //Assert

            Assert.Equal(Answers.More, gn.CheckNumber(number + 1));
        }
    }
}