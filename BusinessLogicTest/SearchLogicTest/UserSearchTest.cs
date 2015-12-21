using BusinessLogic.SearchLogic;
using DTOModels.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTest.SearchLogicTest
{
    [TestFixture]
    class UserSearchLogicTest
    {
        SearchLogic sl;
        List<UserDTO> users;
        [SetUp]
        public void Setup()
        {
            sl = new SearchLogic();
            users = populateUser();
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void Search_by_User_Name_Test()
        {

            var names = sl.UserSearch(users, "Ole");
            Assert.AreEqual(2, names.Count());
        }

        [Test]
        public void Search_by_User_Email_Test()
        {

            var emails = sl.UserSearch(users, "Hotmail.com");
            Assert.AreEqual(3, emails.Count());
        }

        [Test]
        public void Search_by_User_Username_Test()
        {

            var userNames = sl.UserSearch(users, "45");
            Assert.AreEqual(1, userNames.Count());
        }



        public List<UserDTO> populateUser()
        {
            users = new List<UserDTO>();
            UserDTO userDTO = new UserDTO() {Id=1, Username = "Ole123", PasswordHash = "hejmeddig", FirstName = "Ole", LastName = "Hansen", City = "Esbjerg", ZipCode = 6700, StreetName = "OlesVej", HouseNr = "99", Email = "OleH@hotmail.com", RoleId = 2};
            UserDTO userDTO1 = new UserDTO() { Id = 2, Username = "Hans99", PasswordHash = "hejmeddig", FirstName = "Hans", LastName = "Petersen", City = "Varde", ZipCode = 6800, StreetName = "Skovbrynet", HouseNr = "1", Email = "Hans1@hotmail.com", RoleId = 2 };
            UserDTO userDTO2 = new UserDTO() { Id = 3, Username = "Grete45", PasswordHash = "hejmeddig", FirstName = "Grete", LastName = "Olesen", City = "København", ZipCode = 1000, StreetName = "Egernvej", HouseNr = "192", Email = "Grete@Gmail.com", RoleId = 1 };
            UserDTO userDTO3 = new UserDTO() { Id = 4, Username = "1Lars1", PasswordHash = "hejmeddig", FirstName = "Lars", LastName = "Nielsen", City = "Århus", ZipCode = 9000, StreetName = "Hyldehaven", HouseNr = "45", Email = "Lars@Live.com", RoleId = 2 };
            UserDTO userDTO4 = new UserDTO() { Id = 5, Username = "28Peter", PasswordHash = "hejmeddig", FirstName = "Peter", LastName = "Mortensen", City = "Varde", ZipCode = 6800, StreetName = "HansensGade", HouseNr = "76", Email = "Peter@hotmail.com", RoleId = 1 };
            UserDTO userDTO5 = new UserDTO() { Id = 6, Username = "5Char1otte", PasswordHash = "hejmeddig", FirstName = "Charlotte", LastName = "Henriksen", City = "Skjern", ZipCode = 6850, StreetName = "Blomstervangen", HouseNr = "1", Email = "Charlotte@Live.dk", RoleId = 2 };
            UserDTO userDTO6 = new UserDTO() { Id = 7, Username = "Loui54se", PasswordHash = "hejmeddig", FirstName = "Louise", LastName = "Jensen", City = "Esbjerg", ZipCode = 6700, StreetName = "Bredegade", HouseNr = "36", Email = "Louise@Gmail.com", RoleId = 2 };

            users.Add(userDTO);
            users.Add(userDTO1);
            users.Add(userDTO2);
            users.Add(userDTO3);
            users.Add(userDTO4);
            users.Add(userDTO5);
            users.Add(userDTO6);

            return users;
        }


    }
}
