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
            
            double expectedDiscount = cd.CalculateDiscount(crewMembers);
            
            Assert.AreEqual(expectedDiscount, 0);
        }

        [Test]
        public void Crew_Discount_Two_Members_Test()
        {
            int crewMembers = 2;
            double expectedDiscount = cd.CalculateDiscount(crewMembers);

            Assert.AreEqual(expectedDiscount, 10);
        }
          [Test]
        public void Crew_Discount_Three_Members_Test()
        {
            int crewMembers = 3;
            double expectedDiscount = cd.CalculateDiscount(crewMembers);

            Assert.AreEqual(expectedDiscount, 12.5);
        }

        [Test]
        public void Crew_Discount_Nine_Members_Test()
        {
            int crewMembers = 9;
            double expectedDiscount = cd.CalculateDiscount(crewMembers);

            Assert.AreEqual(expectedDiscount, 27.5);
        }
        [Test]
        public void Crew_Discount_Ten_Members_Test()
        {
            int crewMembers = 10;
            double expectedDiscount = cd.CalculateDiscount(crewMembers);

            Assert.AreEqual(expectedDiscount, 35);
        }

    }

}
