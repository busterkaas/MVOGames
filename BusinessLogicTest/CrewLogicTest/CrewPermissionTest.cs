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
            bool isFull = cp.CrewIsFull(crewSize);
            Assert.AreEqual(isFull, false);
        }

        [Test]
        public void User_Join_Crew_When_Size_Is_Eleven_Test()
        {
            int crewSize = 11;
            bool isFull = cp.CrewIsFull(crewSize);
            Assert.AreEqual(isFull, true);
        }

        [Test]
        public void User_Joins_Second_Crew_Test()
        {
            int crews = 1;
            bool crewLimitIsFull = cp.MaxCrewsJoined(crews);
            Assert.AreEqual(crewLimitIsFull, false);
        }

        [Test]
        public void User_Joins_Fourth_Crew_Test()
        {
            int crews = 3;
            bool crewLimitIsFull = cp.MaxCrewsJoined(crews);
            Assert.AreEqual(crewLimitIsFull, true);
        }

        [Test]
        public void ExpDate_For_CrewGameSuggestion_Is_Valid_Date_Before_Today_Test()
        {
            DateTime date = new DateTime(2015, 10, 14);
            TimeSpan time = new TimeSpan(0);
            bool validateDate = cp.IsDateValid(date, time);

            Assert.AreEqual(validateDate, false);
        }
        [Test]
        public void ExpDate_For_CrewGameSuggestion_Is_Valid_Date_After_Today_Test()
        {
            DateTime date = DateTime.Today;
            date = date.AddMonths(1);
            TimeSpan time = new TimeSpan(0);

            bool validateDate = cp.IsDateValid(date,time);

            Assert.AreEqual(validateDate, true);
        }
        [Test]
        public void ExpDate_For_CrewGameSuggestion_Is_Valid_Date_One_Minute_From_Now_Test()
        {
            DateTime date = DateTime.Now;
            TimeSpan time = TimeSpan.FromMinutes(1);            
            
            bool validateDate = cp.IsDateValid(date, time);

            Assert.AreEqual(validateDate, false);
        }
        [Test]
        public void ExpDate_For_CrewGameSuggestion_Is_Valid_Date_Four_Minutes_From_Now_Test()
        {
            DateTime date = DateTime.Now;
            TimeSpan time = TimeSpan.FromMinutes(4);

            bool validateDate = cp.IsDateValid(date, time);

            Assert.AreEqual(validateDate, false);
        }
        [Test]
        public void ExpDate_For_CrewGameSuggestion_Is_Valid_Date_Six_Minutes_From_Now_Test()
        {
            DateTime date = DateTime.Now;
            TimeSpan time = TimeSpan.FromMinutes(6);

            bool validateDate = cp.IsDateValid(date, time);

            Assert.AreEqual(validateDate, true);
        }
    }
}
