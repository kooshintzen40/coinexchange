using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static CoinExchange.Models.Database.Model.EnumColl;
using System.ComponentModel.DataAnnotations.Schema;
using CoinExchange.Utilities;

namespace CoinExchange.Models.Database.Model
{
    public class Transaction
    { 
        public Transaction()
        {
            this.CreationDate = DateTime.Now;
        }

        [Key]
        public int TransactionID { get; set; }

        [Column("Action")]
        public string ActionString
        {
            get { return Action.ToString(); }
            private set { Action = value.ParseEnum<TradeType>(); }
        }

        public DateTime CreationDate { get; set; }

        [NotMapped]
        public TradeType Action { get; set; }

        [Display(Name = "Coin name")]
        [StringLength(30)]
        public string CoinName { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "A quantity is required")]
        public float Quantity { get; set; }
        
        [Column(TypeName = "decimal(18,7)")]
        public decimal Price { get; set; }

        [ForeignKey("Wallet")]
        public int WalletID { get; set; }

        public virtual Wallet Wallet { get; set; }

    }
}
