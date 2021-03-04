using Enterprise.Models;
using Enterprise.Services.Rules;
using NUnit.Framework;

namespace Enterprise.Services.Tests
{
    [TestFixture]
    public class TaxRuleTests
    {
        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void GetTax_ShouldReturn0_WhenUnderLimit(double value)
        {
            // Arrange
            var config = new ConfigEntity() { MinTaxAmount = 100 };
            var sut = new TaxRule(config);

            // Act
            var tax = sut.GetTax(value);

            // Assert
            Assert.AreEqual(0, tax);
        }

        [TestCase(1000, 90)]
        [TestCase(5000, 490)]
        [TestCase(200, 10)]
        public void GetTax_ShouldReturnValue_WhenAboveLimit(double value, double expectedTax)
        {
            // Arrange
            var config = new ConfigEntity() { MinTaxAmount = 100, TaxPercentage = 0.1 };
            var sut = new TaxRule(config);

            // Act
            var tax = sut.GetTax(value);

            // Assert
            Assert.AreEqual(expectedTax, tax);
        }
    }
}