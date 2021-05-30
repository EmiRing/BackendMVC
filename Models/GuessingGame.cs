using BackendTaskMVC.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Models
{
    public class GuessingGame
    {
        public static GuessingGame StartGame(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            string gameId = session.GetString("GameId") ?? Guid.NewGuid().ToString();

            session.SetString("GameId", gameId);

            return new GuessingGame();
        }

        public string MakeGuess(int guess)
        {
            Guesses.GuessCount++;
            if (guess < Guesses.NumberToGuess)
            {
                return $"Guess nr: {Guesses.GuessCount}. Your guess is too low.";
            }
            if (guess > Guesses.NumberToGuess)
            {
                return $"Guess nr: {Guesses.GuessCount}. Your guess is too high.";
            }
            
            return $"Congratulations. You were right. You needed {Guesses.GuessCount} guesses";
        }

    }
}
