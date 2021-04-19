using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecommerce.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod("Valid Names and LastName")]
        [DataTestMethod]
        [DataRow(null, false, DisplayName = "ValidName(null) ➞ false")]
        [DataRow("", false, DisplayName = "ValidName('') ➞ false")]
        [DataRow("Edgard Allan Poe Edgard Allan Poe", false, DisplayName = "ValidName('Edgard Allan Poe Edgard Allan Poe') ➞ false")]
        [DataRow("E. Poe", true, DisplayName = "ValidName('E. Poe') ➞ true")]
        [DataRow("E. A. Poe", true, DisplayName = "ValidName('E.A.Poe') ➞ true")]
        [DataRow("Edgard A. Poe", true, DisplayName = "ValidName('Edgard A. Poe') ➞ true")]
        [DataRow("Edgard9 A. Poe", false, DisplayName = "ValidName('Edgard9 A. Poe') ➞ false")]
        [DataRow("Edgard Allan Poe", false, DisplayName = "ValidName('Edgard Allan Poe') ➞ false")]
        [DataRow("E. Allan Poe", false, DisplayName = "ValidName('Edgard Allan Poe') ➞ false")]
        [DataRow("Edgard", false, DisplayName = "ValidName('Edgard') ➞ false")]
        [DataRow("EdgArd Poe", false, DisplayName = "ValidName('EdgArd Poe') ➞ false")]
        [DataRow("Edgard Poe.", false, DisplayName = "ValidName('Edgard Poe.') ➞ false")]
        [DataRow("Ed. Poe", false, DisplayName = "ValidName('Ed. Poe') ➞ false")]

        public void ValidNameTest(string name, bool expected)
        {
            // Arrange

            // Act
            bool actual = Validator.ValidName(name);

            // Assert           
            Assert.AreEqual(expected, actual);
        }
    }
}