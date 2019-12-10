using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidation.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30,ErrorMessage = "Ad en az 2 en fazla 30 karakter olabilir",MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(30,ErrorMessage = "Soyad en az 2 en fazla 30 karakter olabilir",MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",ErrorMessage = "En az 1 büyük 1 küçük harf, sayı ve özel karakter içermelidir")]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Onay şifresi ile şifre eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(18,Int32.MaxValue)]
        public int Age { get; set; }

        [Required]
        [CreditCard]
        public string CreditCard { get; set; }

        [Url]
        public string WebPage { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }






    }
}