using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinExchange.Models.Database.Model
{
    public class Wallet
    {
        public int WalletID { get; set; }
       
        [Required(ErrorMessage = "Wallet name is required")]
        [StringLength(30)]
        [Display(Name = "Wallet name")]
        public string WalletName { get; set; }

        [Display(Name = "Cash balance")]
        public float? CashBalance { get; set; }
        
        [Display(Name = "Total current value")]
        public float? TotalCurrentValue { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }

        public virtual Account Account { get; set; }
    }
}
