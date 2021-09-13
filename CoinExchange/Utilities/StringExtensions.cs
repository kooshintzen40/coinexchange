﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinExchange.Utilities
{
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value){
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
