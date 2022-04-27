using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using React_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public Temprature Post([FromBody]Temprature model)
        {
            
            Temprature temprature = new Temprature();
            temprature.WhatFrom = model.WhatFrom;
            try
            {
                if (model.WhatFrom == 1)
                {

                    temprature.Farenheit_Temprature = temprature.ctof(decimal.Parse(model.Celsius_Temprature)).ToString();
                    temprature.Kelvin_Temprature = temprature.ctok(decimal.Parse(model.Celsius_Temprature)).ToString();
                }
                if (model.WhatFrom == 2)
                {
                    temprature.Celsius_Temprature = temprature.ftoc(decimal.Parse(model.Farenheit_Temprature)).ToString();
                    temprature.Kelvin_Temprature = temprature.ftok(decimal.Parse(model.Farenheit_Temprature)).ToString();
                }
                if (model.WhatFrom == 3)
                {
                    temprature.Farenheit_Temprature = temprature.ktof(decimal.Parse(model.Kelvin_Temprature)).ToString();
                    temprature.Celsius_Temprature = temprature.ktoc(decimal.Parse(model.Kelvin_Temprature)).ToString();
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return temprature;
        }





    }
}
