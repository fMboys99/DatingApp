﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]

    public class ValuesController : ControllerBase
    {

        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        private static readonly string[] Summaries = new[]
        {
            "fMboys", "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            // private readonly ILogger<WeatherForecastController> _logger;

            // public WeatherForecastController(ILogger<WeatherForecastController> logger)
            // {
            //     _logger = logger;
            // }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }
        // public IEnumerable<MyWeatherForecast> Get()
        // {
        //     var values = 
        //     // var rng = new Random();
        //     // return Enumerable.Range(1, 5).Select(index => new MyWeatherForecast
        //     // {
        //     //     Date = DateTime.Now.AddDays(index),
        //     //     TemperatureC = rng.Next(-20, 55),
        //     //     Summary = Summaries[rng.Next(Summaries.Length)]
        //     // })
        //     // .ToArray();
        // }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id) 
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }
    }
}