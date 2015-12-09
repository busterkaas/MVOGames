using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.Models
{
    public class FakePayment {
        public FakePayment(string cardType, int cardNumber, DateTime expDate, int cvv, string owner)
        {
            CardType = cardType;
            CardNumber = cardNumber;
            ExpirationDate = expDate;
            Cvv = cvv;
            CardOwner = owner;
        }
        public FakePayment()
        {

        }
        [Required]
        public string CardType { get; set; }
        [Required]
        public int CardNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public int Cvv { get; set; }
        [Required]
        [StringLength(30, MinimumLength =3, ErrorMessage = "Invalid")]
        public string CardOwner { get; set; }
    }
}