using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoinExchange.Models.Database.Model
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(20)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(30)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public int Age { get; set; }

        [StringLength(30)]
        [Display(Name = "Street name")]
        public string StreetName { get; set; }

        [RegularExpression("[0-9]{4}[A-Z]{2}")]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        
        [StringLength(20)]
        public string Country { get; set; }

        public virtual ICollection<Wallet> Wallets { get; set; }

    }
}
