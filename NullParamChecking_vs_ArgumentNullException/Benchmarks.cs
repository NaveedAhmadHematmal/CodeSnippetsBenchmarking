using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark(Baseline = true)]
    public void NullParamCheckingFeature()
    {
        foreach (var item in Enumerable.Range(1, 1000000))
        {
            NullParamCheckingMethod(item);
        }
    }

    [Benchmark]
    public void ArgumentNullExceptionFeature()
    {
        foreach (var item in Enumerable.Range(1, 1000000))
        {
            ArgumentNullExceptionMethod(item);
        }
    }

    [Benchmark]
    public void Argument_ThrowIfNullMethodFeature()
    {
        foreach (var item in Enumerable.Range(1, 1000000))
        {
            Argument_ThrowIfNullMethod(item);
        }
    }

    public void NullParamCheckingMethod(object param)
    {
        if(param == null)
        {
            throw new ArgumentNullException(nameof(param));
        }
    }

    public void ArgumentNullExceptionMethod(object param!!)
    {

    }

    public void Argument_ThrowIfNullMethod(object param)
    {
        ArgumentNullException.ThrowIfNull(param);
    }
}