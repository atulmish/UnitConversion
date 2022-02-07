using BenchmarkDotNet.Running;
using UnitConversionBenchmark;

var summary = BenchmarkRunner.Run<CompareUnitConversionBenchmark>();
