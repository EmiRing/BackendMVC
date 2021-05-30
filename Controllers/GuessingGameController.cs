using BackendTaskMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Controllers
{
    [Route("GuessingGame")]
    public class GuessingGameController : Controller
    {
        private readonly GuessingGame _guessingGame;
        private readonly Random rnd = new Random();
        string message;
        public GuessingGameController(GuessingGame guessingGame)
        {
            _guessingGame = guessingGame;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Guesses.MadeGuesses.Clear();
            
            Guesses.NumberToGuess = rnd.Next(100) + 1;
            Guesses.GuessCount = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int guess, string submitButton)
        {
            switch (submitButton)
            {
                case "Check":
                    if (guess > 0 && guess <= 100)
                    {
                        message = _guessingGame.MakeGuess(guess);
                        ViewBag.GuessMessage = message;

                    }
                    if (guess == Guesses.NumberToGuess)
                    {
                        Guesses.NumberToGuess = rnd.Next(100) + 1;
                        Guesses.GuessCount = 0;
                    }
                    return View();
                case "Reset":
                    
                    return Index();
                default:
                    return View();
                    
            }
            
        }
    }
}
