using Task3.Core;
namespace Task3.Tests;

public class TestMaxSumElements
{
    [Fact]
    public void TestGetLineWithMaxSum()
    {
        //Arrange

        string input1 = "50,500";
        string input2 = "100.5,10000";
        List<LineOfElements> lines = new();
        LineOfElements line = new(input1);
        lines.Add(line);
        lines.Add(line = new LineOfElements(input2));
        MaxSumOfElements testMSEclass = new(lines);
        int expected = 1;
        int actual;

        //Act

        actual = testMSEclass.GetNumberMaxSumLine();

        //Assert

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestetNumbersWrongFormatLines()
    {
        //Arrange
        string input1 = "qw50,500";
        string input2 = "50,500";
        string input3 = "104343,fdvrf";
        string input4 = "300,10";
        List<LineOfElements> lines = new();
        LineOfElements line = new(input1);
        lines.Add(line);
        lines.Add(line = new LineOfElements(input2));
        lines.Add(line = new LineOfElements(input3));
        lines.Add(line = new LineOfElements(input4));
        MaxSumOfElements testMSEclass = new(lines);
        int[] expected = { 0, 2 };
        int[] actual;

        //Act

        actual = testMSEclass.GetNumbersWrongFormatLines();

        //Assert

        Assert.Equal(expected, actual);
    }
}