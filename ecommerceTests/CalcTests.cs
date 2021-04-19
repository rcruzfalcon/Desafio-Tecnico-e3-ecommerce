using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecommerce.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod("Calculate Greatest Common Divisor")]
        [DataTestMethod]
        [DataRow(4, 6, "2/3", DisplayName = "Simplificar('4/6') ➞ '2/3'")]
        [DataRow(10, 11, "10/11", DisplayName = "Simplificar('10/11') ➞ '10/11'")]
        [DataRow(100, 400, "1/4", DisplayName = "Simplificar('100/400') ➞ '1/4'")]
        [DataRow(400, 300, "4/3", DisplayName = "Simplificar('400/300') ➞ '4/3'")]
        [DataRow(400, 100, "4", DisplayName = "Simplificar('400/100') ➞ '4'")]
        [DataRow(0, 100, "0", DisplayName = "Simplificar('0/100') ➞ '0'")]
        [DataRow(400, 0, null, DisplayName = "Simplificar('400/0') ➞ null")]

        public void ReduceTest(int numerator, int denominator, string expected)
        {
            // Arrange

            // Act
            string actual = Calc.Reduce(numerator, denominator);

            // Assert           
            Assert.AreEqual(expected, actual);
        }
    }
}