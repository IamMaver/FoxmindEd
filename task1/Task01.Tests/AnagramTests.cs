namespace Task01test
{
    [TestFixture]
    public class AnagramTests
    {
        private readonly Anagram testClass = new();

        [TestCase("abcd efgh", "dcba hgfe")]
        [TestCase("a1bcd efg!h", "d1cba hgf!e")]
        [TestCase("  a1bcd    efg!h", "  d1cba    hgf!e")]
        [TestCase("  a1bc�!(::", "  c1ba�!(::")]
        [TestCase("Str td!@#$%^&a1bc�!()bn:: dsss-v", "rtS nb!@#$%^&c1ba�!()dt:: vsss-d")]
        [TestCase(null, "")]
        [TestCase("   ", "   ")]

        public void TestReverseWholeString(string inputString, string expectedResult)
        {
            //Arrange

            //Act

            string result = testClass.Reverse(inputString);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("test", "tset")]
        [TestCase("tes*t", "tse*t")]
        [TestCase(null, "")]
        [TestCase("   ", "   ")]

        public void TestReverseSingleWord(string inputString, string expectedResult)
        {
            //Arrange

            //Act

            string result = testClass.ReverseWord(inputString);

            //Assert

            Assert.AreEqual(expectedResult, result);
        }
    }
}