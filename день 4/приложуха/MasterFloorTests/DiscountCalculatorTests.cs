using Microsoft.VisualStudio.TestTools.UnitTesting;
using Master_floor;

namespace MasterFloorTests
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        [TestMethod]
        public void Test_0Percent()
        {
            Assert.AreEqual("0%", DiscountCalculator.CalculateDiscount(5000));
        }

        [TestMethod]
        public void Test_5Percent()
        {
            Assert.AreEqual("5%", DiscountCalculator.CalculateDiscount(15000));
        }

        [TestMethod]
        public void Test_10Percent()
        {
            Assert.AreEqual("10%", DiscountCalculator.CalculateDiscount(60000));
        }

        [TestMethod]
        public void Test_15Percent()
        {
            Assert.AreEqual("15%", DiscountCalculator.CalculateDiscount(400000));
        }

        [TestMethod]
        public void Test_BoundaryValue()
        {
            // Граничное значение 10000 должно давать 5%
            Assert.AreEqual("5%", DiscountCalculator.CalculateDiscount(10000));
        }
    }
}