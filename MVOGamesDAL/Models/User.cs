using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGamesDAL.Models
{
    public class User
    {
        public User()
        {
            Crews = new List<Crew>();
        }
        private const int WorkFactor = 13;
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required(ErrorMessage = "A FirstName is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "A LastName is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "A StreetName is required!")]
        public string StreetName { get; set; }
        [Required(ErrorMessage = "A HouseNumber is required!")]
        public string HouseNr { get; set; }
        [Required(ErrorMessage = "A ZipCode is required!")]
        public int ZipCode { get; set; }
        [Required(ErrorMessage = "A City is required!")]
        public string City { get; set; }
        [Required(ErrorMessage = "An Email is required!")]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }
        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", WorkFactor);
        }
        public virtual List<Crew> Crews { get; set; }
        [Required]
        public virtual Role Role { get; set; }
    }
}
