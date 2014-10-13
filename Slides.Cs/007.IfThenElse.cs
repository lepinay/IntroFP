using System.Collections.Generic;
using System.Linq;

public class Piping
{

    private static string checkSign(int p)
    {
        if (p < 0) return "p is negative";
        else if (p == 0) return "p is nul";
        else return "p is positive";
    }

    public static void Main()
    {
        checkSign(10);
    }
}