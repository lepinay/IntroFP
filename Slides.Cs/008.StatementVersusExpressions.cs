using System;
using System.Collections.Generic;
using System.Linq;

public class StatementsVersusExpressions
{
    private static bool aBool;

    public static void Main()
    {
        int result=0;
        if (aBool)
        {
            result = 42;
        }
        Console.WriteLine("result={0}", result);

        int result2 = (aBool) ? 42 : 0;
        Console.WriteLine("result={0}", result2);
    }


}