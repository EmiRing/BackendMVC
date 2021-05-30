using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Models
{
    public static class Guesses
    {
        public static int NumberToGuess { get; set; }
        public static int GuessCount { get; set; } = 0;
        public static List<int> MadeGuesses { get; set; } = new List<int>();
    }
}
