using HexInnovation;
using System.Globalization;

namespace CentralSystem.Converters;

sealed class CustomAnd : ArbitraryArgFunction
{
    public override object Evaluate(CultureInfo cultureInfo, Func<object>[] arguments)
    {
        var args = arguments.Select(x=> x());
        if (args.Any(x => x == null)) return false;
        foreach (var x in args)
        {
            if (TryConvert<bool>(x, out var d))
            {
                if (d == false) return false;
            }
            else if(TryConvert<string>(x, out var k))
            {
                if (string.IsNullOrEmpty(k)) return false;
            }
        }
        return true;
    }
}