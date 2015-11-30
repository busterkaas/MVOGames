using BusinessLogic.OrderLogic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTest.OrderLogicTest
{
    [TestFixture]
    class CrewDiscountTest
    {
        CrewDiscount cd;
        [SetUp]
        public void Setup()
        {
             cd = new CrewDiscount();
        }

        [TearDown]
        public void Teardown()
        {
           
        }

        [Test]
        public void Crew_Discount_One_Member_Test()
        {
            int crewMembers = 1;
            
            decimal expectedDiscount = cd.CalculateDiscount(crewMembers);
            
            Assert.AreEqual(expectedDiscount, 0);
        }
    }

}
