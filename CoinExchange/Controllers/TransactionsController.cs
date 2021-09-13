using CoinExchange.Models;
using CoinExchange.Models.Database.Model;
using CoinExchange.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoinExchange.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ExchangeDbContext _context;
        private readonly TransactionHelper _transactionHelper;

        public TransactionsController(ExchangeDbContext context, TransactionHelper transactionHelper)
        {
            _context = context;
            _transactionHelper = transactionHelper;
        }

        public IActionResult Index()
        {
            var TransactionDbContext = _context.Transactions.Include(a => a.Wallet);
            return View(TransactionDbContext);
        }

        public IActionResult Trade()
        {
            ViewData["WalletID"] = new SelectList(_context.Wallets, "WalletID", "WalletName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Trade([Bind("TransactionID, Action, CoinName, Quantity, WalletID")] Transaction t)
        {
            if (ModelState.IsValid)
            {
                var api = new ApiController();
                var coin = api.GetPrice(t.CoinName).Result;
                t.Price = decimal.Parse(coin.market_data.current_price.eur, CultureInfo.InvariantCulture);
                
                _context.Add(t);
                await _context.SaveChangesAsync();

                _transactionHelper.CreateTransaction(t);

                return RedirectToAction(nameof(Index));
            }
            return View(t);
        }

    }
}
