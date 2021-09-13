using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoinExchange.Models.Database.Model
{
    public class CoinInfo
    {
        [Display(Name = "ID")]
        public string id { get; set; }

        [Display(Name = "Symbol")]
        public string symbol { get; set; }

        [Display(Name = "Coin")]
        public string name { get; set; }

        public MarketData market_data { get; set; }
    
    }

    public class MarketData
    {
        public Current_Price current_price { get; set; }
    }
     
    public class Current_Price
    {
        [Display(Name = "EUR")]
        public string eur { get; set; }
    }
}
