using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConversion;

namespace UnitConversionTests;

/// <summary>Every unit name accepted by version 1.x must still be accepted.</summary>
[TestClass]
public class BackwardCompatibilityTests
{
    [TestMethod]
    [DataRow("Mass", "kg,kilogram,gram,g,lb,lbs,pound,pounds,st,stone,oz,ounce,quintal,short ton,net ton,us ton,long ton,weight ton,gross ton,imperial ton")]
    [DataRow("Distance", "m,metre,km,kilometre,cm,centimetre,mm,millimetre,ft,foot,feet,yd,yard,mile,in,inch,au")]
    [DataRow("Area", "m²,m2,square metre,centiare,km²,km2,kilometre,cm²,cm2,centimetre,mm²,mm2,millimetre,ft²,ft2,square foot,square feet,sq ft,yd²,yd2,sq yd,square yard,a,are,ha,hectare,in²,in2,sq in,square inch,mi²,mi2,sq mi,square mile")]
    [DataRow("Volume", "l,L,lt,ltr,liter,litre,dm³,dm3,cubic decimetre,m³,m3,cubic metre,cm³,cm3,cubic centimetre,mm³,mm3,cubic millimetre,ft³,ft3,cubic foot,cubic feet,cu ft,in³,in3,cu in,cubic inch,imperial pint,imperial pt,imperial p,imperial gallon,imperial gal,imperial quart,imperial qt,US pint,US pt,US p,US gallon,US gal,US quart,US qt")]
    [DataRow("Time", "s,sec,second,ds,decisecond,deci-second,cs,centisecond,centi-second,ms,millisecond,milli-second,us,μs,microsecond,micro-second,ns,nanosecond,nano-second,min,minute,h,hour,d,day,y,year,leap year,leap-year")]
    [DataRow("Temperature", "celsius,Celsius,°C,°c,fahrenheit,Fahrenheit,°F,°f,Kelvin,kelvin,°K,°k")]
    public void EveryVersionOneUnitNameIsStillSupported(string converter, string names)
    {
        foreach (var name in names.Split(','))
        {
            var created = ConverterFactory.Create(converter, name, name);
            Assert.AreEqual(name, created.UnitLeft);
        }
    }

    [TestMethod]
    public void TheDefaultUnitsAreUnchanged()
    {
        Assert.AreEqual("kg", new MassConverter().UnitLeft);
        Assert.AreEqual("m", new DistanceConverter().UnitLeft);
        Assert.AreEqual("m²", new AreaConverter().UnitLeft);
        Assert.AreEqual("l", new VolumeConverter().UnitLeft);
        Assert.AreEqual("s", new TimeConverter().UnitLeft);
        Assert.AreEqual("celsius", new TemperatureConverter().UnitLeft);
    }
}
