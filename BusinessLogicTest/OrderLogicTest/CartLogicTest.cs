using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;
using NUnit.Util;
using BusinessLogic.OrderLogic;

namespace BusinessLogicTest.OrderLogicTest
{
    [TestFixture]
    class CartLogicTest
    {
        CartLogic cl;

        [SetUp]
        public void Setup()
        {
            cl = new CartLogic();
        }

        [TearDown]
        public void Teardown()
        {
            
        }
        [Test]
        public void Calculate_Price_Of_One_Item_Test()
        {
            int quantity = 1;
            decimal price= 400;
            decimal sum = cl.CalculateTotalPrice(quantity, price);
            Assert.AreEqual(sum, 400);
        }

        [Test]
        public void Calculate_Price_Of_three_Item_Test()
        {
            int quantity = 3;
            decimal price = 400;
            decimal sum = cl.CalculateTotalPrice(quantity, price);
            Assert.AreEqual(sum, 1200);
        }
    }
}
