using CoinExchange.Models.Database.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoinExchange.Controllers
{
    [Route("api")]
    public class ApiController : ControllerBase
    {
        static readonly DateTime startDate = new(2020, 1, 1);
        readonly Int32 unixTimeStampBegin = (Int32)startDate.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        readonly Int32 unixTimeStampNow = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


        // GET: api/<ApiController>
        [HttpGet]
        [Route("Prices")]
        public async Task<List<CoinInfo>> GetPrices()
        {
            HttpClient http = new();
            string jsonData = await http.GetStringAsync("https://api.coingecko.com/api/v3/coins/");
            var coins = JsonConvert.DeserializeObject<List<CoinInfo>>(jsonData);

            return coins;
        }


        [HttpGet]
        [Route("Prices/{coin}")]
        public async Task<string> GetPrices(string coin)
        {
            HttpClient http = new();
            string jsonData = await http.GetStringAsync("h" + $"ttps://api.coingecko.com/api/v3/coins/{coin}");
            var coins = JsonConvert.SerializeObject(jsonData);

            return coins;
        }

        [HttpGet]
        [Route("Price/{coin}")]
        public async Task<CoinInfo> GetPrice(string c)
        {
            HttpClient http = new();
            string jsonData = await http.GetStringAsync("h" + $"ttps://api.coingecko.com/api/v3/coins/{c}");
            var coin = JsonConvert.DeserializeObject<CoinInfo>(jsonData);

            return coin;
        }


        // GET api/<ApiController>
        [HttpGet]
        [Route("Json/{coin}")]
        public async Task<string> GetGraph(string coin)
        {
            var http = new HttpClient();
            string url;

            if (coin == "{coin}")
            {
                url = "h" + $"ttps://api.coingecko.com/api/v3/coins/bitcoin/market_chart/range?vs_currency=eur&from={unixTimeStampBegin.ToString()}&to={unixTimeStampNow.ToString()}";
            }
            else
            {
                url = "h" + $"ttps://api.coingecko.com/api/v3/coins/{coin}/market_chart/range?vs_currency=eur&from={unixTimeStampBegin.ToString()}&to={unixTimeStampNow.ToString()}";
            }
            string graphData = await http.GetStringAsync(url);
            var graph = JsonConvert.SerializeObject(graphData);
            return graph;
        }
    }
}
