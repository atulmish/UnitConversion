using UnitConversion.Base;

namespace UnitConversion
{
    public class TemperatureConverter: BaseUnitConverter
    {
        UnitFactors units = new UnitFactors("celsius")
        {
            { new UnitFactorSynonyms("celsius", "Celsius", "°C", "°c"),1 },
            { new UnitFactorSynonyms("fahrenheit", "Fahrenheit", "°F", "°f"),1 },
            { new UnitFactorSynonyms("Kelvin", "kelvin", "°K", "°k"),1 },
        };
        
        public TemperatureConverter(string leftUnit, string rightUnit)
        {
            Instantiate(units, leftUnit, rightUnit);
        }
        public TemperatureConverter() : base()
        {
            Instantiate(units);
        }
    }
}
