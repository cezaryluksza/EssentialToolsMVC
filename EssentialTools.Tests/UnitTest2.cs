using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
using System.Linq;
using Moq;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products =
        {
            new Product {Name = "Kajak", Category = "Sporty wodne", Price = 275M},
            new Product {Name = "Kamizelka ratunkowa", Category = "Sporty wodne", Price = 48.95M},
            new Product {Name = "Piłka nożna", Category = "Piłka nożna", Price = 19.50M},
            new Product {Name = "Flaga narożna", Category = "Piłka nożna", Price = 34.95M}
        };
        [TestMethod]
        public void Sum_Product_Correctly()
        {
            //arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);

            //act
            var result = target.ValueProducts(products);

            //assert
            Assert.AreEqual(products.Sum(e => e.Price), result);
        }
    }
}
