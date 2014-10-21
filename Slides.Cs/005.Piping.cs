using System.Collections.Generic;
using System.Linq;

public class Piping
{
    private static int Square(int i)
    {
        return i * i;
    }
    public static void Main()
    {
        int sum = 0;
        for (int i = 1; i <= 100; i++)
        {
            sum += Square(i);
        }

        #region LINQ
        Enumerable.Range(1, 100)
            .Select(Square)
            .Sum();
        
        (from n in Enumerable.Range(1, 100) 
         select Square(n)
         ).Sum();
        #endregion
    }


}