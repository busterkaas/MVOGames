using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BusinessLogic.CrewLogic;

namespace BusinessLogicTest.CrewLogicTest
{
    [TestFixture]
    class CrewPermissionTest
    {
        CrewPermission cp;

        [SetUp]
        public void Setup()
        {
            cp = new CrewPermission();
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void User_Join_Crew_When_Size_Is_Eight_Test()
        {
            int crewSize = 8;
            bool isFull = cp.IsFull(crewSize);
            Assert.AreEqual(isFull, false);
        }

        [Test]
        public void User_Join_Crew_When_Size_Is_Eleven_Test()
        {
            int crewSize = 11;
            bool isFull = cp.IsFull(crewSize);
            Assert.AreEqual(isFull, true);
        }
    }
}
