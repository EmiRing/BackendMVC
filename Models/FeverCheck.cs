using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTaskMVC.Models
{
    public static class FeverCheck
    {
        
        public static string CalculateTemp(double temperature, string scale)
        {
            if (scale == "fahrenheit") 
            {
                temperature = (temperature - 32) / 1.8;
            }
            if (temperature >= 37.8) return "You have a fever.";
            if (temperature <= 35) return "You have Hypothermia.";

            return "You are feeling well.";
            
        }
    }
}
