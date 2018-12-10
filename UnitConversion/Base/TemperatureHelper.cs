using System.Collections.Generic;

namespace UnitConversion.Base
{
    public class TemperatureHelper
    {
        public static List<string> Celsius = new List<string>() { "celsius", "Celsius", "°C", "°c" };
        public static List<string> Fahrenheit = new List<string>() { "fahrenheit", "Fahrenheit", "°F", "°f" };
        public static List<string> Kelvin = new List<string>() { "Kelvin", "kelvin", "°K", "°k" };
        
        //Reference: https://www.thoughtco.com/temperature-conversion-formulas-609324
        public static double AToB(double value, string startUnit, string endUnit)
        {
            if (Celsius.Contains(startUnit) && Fahrenheit.Contains(endUnit))
            {
                //Celsius to Fahrenheit : °F = 9/5 (°C) + 32
                return (((9d / 5) * value) + 32);
            }
            else if (Kelvin.Contains(startUnit) && Fahrenheit.Contains(endUnit))
            {
                //Kelvin to Fahrenheit: °F = 9 / 5(K - 273.15) + 32
                return ((9d / 5) * (value - 273.15) + 32);
            }
            else if (Fahrenheit.Contains(startUnit) && Celsius.Contains(endUnit))
            {
                //Fahrenheit to Celsius: °C = 5/9 (°F - 32)
                return ((5d / 9) * (value - 32));
            }
            else if (Celsius.Contains(startUnit) && Kelvin.Contains(endUnit))
            {
                //Celsius to Kelvin: K = °C + 273.15
                return value + 273.15;
            }
            else if (Kelvin.Contains(startUnit) && Celsius.Contains(endUnit))
            {
                //Kelvin to Celsius: °C = K - 273.15
                return value - 273.15;
            }
            else if (Fahrenheit.Contains(startUnit) && Kelvin.Contains(endUnit))
            {
                //Fahrenheit to Kelvin: K = 5 / 9(°F - 32) + 273.15
                return ((5d / 9) * (value - 32) + 273.15);
            }
            //Used "else" for corner case "both units are same"
            else
            {
                return value;
            }
        }
    }
}
