using CoinExchange.Models;
using CoinExchange.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinExchange.Models.Database.Model;
using CoinExchange.Controllers;
using System.Net.Http;
using Newtonsoft.Json;

namespace CoinExchange.Utilities
{
    public class TransactionHelper : Controller
    {
        private readonly ExchangeDbContext _context;

        public TransactionHelper(ExchangeDbContext context)
        {
            _context = context;
        }

        public void CreateTransaction(Transaction transaction)
        {
            var wallet = _context.Wallets.Find(transaction.WalletID);
            wallet.Transactions.Add(transaction);
            var balance = wallet.CashBalance;

            switch (transaction.Action)
            {
                case EnumColl.TradeType.Buy:
                    wallet.CashBalance = balance - ((float)transaction.Price*transaction.Quantity); 
                    _context.Update(wallet);
                    break;
                case EnumColl.TradeType.Sell:
                    wallet.CashBalance = balance + ((float)transaction.Price * transaction.Quantity);
                    _context.Update(wallet);
                    break;
            }
            _context.SaveChanges();
        }
    }
}
