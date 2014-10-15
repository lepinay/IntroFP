using System.Collections.Generic;
using System.Linq;

public class Lists
{
    public static void Main()
    {
        var twoToFive = new List<int> { 2, 3, 4, 5 };
        var oneToFive = new List<int>(twoToFive);
        oneToFive.Insert(0, 1);
        var zeroToFive = new List<int> { 0, 1 }.Concat(twoToFive);
    }
}