using System.Collections.Generic;
using System.Linq;

public class Encapsulation
{

    public static IEnumerable<int> Evens(IEnumerable<int> list)
    {
        foreach (var item in list)
        {
            if (item % 2 == 0) yield return item;
        }
        //return list.Where(isEven);
    }

    public static bool isEven(int n)
    {
        return n % 2 == 0;
    }

    public static void Main()
    {
        Evens(new List<int>{2, 3, 4, 5});
    }
}