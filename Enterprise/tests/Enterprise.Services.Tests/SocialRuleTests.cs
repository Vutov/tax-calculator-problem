using Enterprise.Models;
using Enterprise.Services.Rules;
using NUnit.Framework;

namespace Enterprise.Services.Tests
{
    [TestFixture]
    public class SocialRuleTests
    {
        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void GetTax_ShouldReturn0_WhenUnderLimit(double value)
        {
            // Arrange
            var config = new ConfigEntity() { MinTaxAmount = 100 };
            var sut = new SocialRule(config);

            // Act
            var tax = sut.GetTax(value);

            // Assert
            Assert.AreEqual(0, tax);
        }

        [TestCase(1000, 90)]
        [TestCase(3000, 290)]
        [TestCase(200, 10)]
        public void GetTax_ShouldReturnValue_WhenInTaxLimit(double value, double expectedTax)
        {
            // Arrange
            var config = new ConfigEntity() { MinTaxAmount = 100, SocialPercentage = 0.1, MaxSocialAmount = 3000 };
            var sut = new SocialRule(config);

            // Act
            var tax = sut.GetTax(value);

            // Assert
            Assert.AreEqual(expectedTax, tax);
        }

        [TestCase(2000, 190)]
        [TestCase(5000, 190)]
        public void GetTax_ShouldReturnValue_WhenAboveLimit(double value, double expectedTax)
        {
            // Arrange
            var config = new ConfigEntity() { MinTaxAmount = 100, SocialPercentage = 0.1, MaxSocialAmount = 2000 };
            var sut = new SocialRule(config);

            // Act
            var tax = sut.GetTax(value);

            // Assert
            Assert.AreEqual(expectedTax, tax);
        }
    }
}