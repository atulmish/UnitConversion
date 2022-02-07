using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using UnitConversion;

namespace UnitConversionBenchmark;

public class CompareUnitConversionBenchmark
{
    [Params(10, 100, 1000, 10000)]
    public int Count { get; set; }
    
    private readonly MassConverter _gToLbs = new("g", "lbs");

    public IList<double> CreateRandomDoubleList(int count)
    {
        var rng = new Random();
        var result = new List<double>(count);
        
        for (var i = 0; i < count; i++)
        {
            result.Add(rng.Next(0, 10000));
        }

        return result;
    }

    [Benchmark]
    public double ConvertWithUnitConversion()
    {
        var doubleList = CreateRandomDoubleList(Count);

        var result = 0d;
        
        foreach (var value in doubleList)
        {
            result += _gToLbs.LeftToRight(value);
        }

        return result;
    }

    [Benchmark]
    public double ConvertWithDirectFactor()
    {
        var doubleList = CreateRandomDoubleList(Count);

        var result = 0d;
        
        foreach (var value in doubleList)
        {
            result += value * 2_204.62262185;
        }

        return result;
    }
    
}
