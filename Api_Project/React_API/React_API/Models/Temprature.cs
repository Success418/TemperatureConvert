using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React_API.Models
{
    public class Temprature
    {
        public string Celsius_Temprature { get; set; }
        public string Kelvin_Temprature { get; set; }
        public string Farenheit_Temprature { get; set; }
        public int WhatFrom { get; set; }



        public decimal ctof(decimal c)//9/5 ( C) + 32
        {
            decimal x = (9m/5m)*c + 32;
            return x;
        }
        public decimal ctok(decimal c)//C + 273
        {
            decimal x = c + 273;
            return x;
        }
        public decimal ftoc(decimal f)//5/9 ( F - 32)
        {
            decimal x = (5m/9m)*(f -32);
            return x;
        }
        public decimal ftok(decimal f)//5/9 (F - 32) + 273
        {
            decimal x = (5m/9m)*(f - 32) + 273;
            return x;
        }
        public decimal ktoc(decimal k)//K - 273
        {
            decimal x = k - 273;
            return x;
        }
        public decimal ktof(decimal k)//9/5 (K - 273) + 32
        {
            //9/5 (K - 273) + 32
            decimal x = 9m/5m *(k - 273) + 32;
            return x;
        }

    }
}
