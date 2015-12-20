using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class UserDTO
    {
        private const int WorkFactor = 13;
        public int Id { get; set; }
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Firstname")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Lastname")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Streetname")]
        public string StreetName { get; set; }
        [Required]
        [DisplayName("House nr.")]
        public string HouseNr { get; set; }
        [Required]
        [DisplayName("Zip code")]
        public int ZipCode { get; set; }
        [Required]
        [DisplayName("City")]
        public string City { get; set; }
        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        [Required]
        [DisplayName("Password")]
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
    }
}
