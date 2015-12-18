using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.Models
{
    public class FakePayment {
        public FakePayment(string cardType, int cardNumber, int expMonth, int expYear, int cvv, string owner)
        {
            CardType = cardType;
            CardNumber = cardNumber;
            ExpMonth = expMonth;
            ExpYear = expYear;
            Cvv = cvv;
            CardOwner = owner;
        }
        public FakePayment()
        {

        }
        
        [Required]
        [DisplayName("Card type:")]
        public string CardType { get; set; }
        [Required]
        [DisplayName("Card number:")]
        //[MaxLength(16)]
        //[MinLength(16)]
        public long CardNumber { get; set; }
        [Required]
        [Range(1, 12)]
        public int ExpMonth { get; set; }
        [Required]
        [Range(15, 25)]
        public int ExpYear { get; set; }
        [Required]
        [DisplayName("CVV:")]
        //[MaxLength(3)]
        //[MinLength(3)]
        public int Cvv { get; set; }
        [Required]
        [DisplayName("Card owner:")]
        [StringLength(30, MinimumLength =3, ErrorMessage = "Invalid")]
        public string CardOwner { get; set; }
    }
}