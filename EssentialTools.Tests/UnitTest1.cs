﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            //arrange (przygotowanie)
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            //act (działanie)
            var discountedTotal = target.ApplyDiscount(total);

            //assert (asercje)
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            //arrange
            IDiscountHelper target = getTestObject();
            //act
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarDiscount = target.ApplyDiscount(50);
            //assert
            Assert.AreEqual(5, TenDollarDiscount, "rabat w wysokości 10 zł jest nieprawidłowy");
            Assert.AreEqual(95, HundredDollarDiscount, "rabat w wysokości 100 zł jest nieprawidłowy");
            Assert.AreEqual(45, FiftyDollarDiscount, "rabat w wysokości 50 zł jest nieprawidłowy");
        }
        [TestMethod]
        public void Discount_Less_Than_10()
        {
            //arrange
            IDiscountHelper target = getTestObject();
            //act
            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);
            //assert
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            //arrange
            IDiscountHelper target = getTestObject();
            //act
            target.ApplyDiscount(-1);
        }
    }
}
