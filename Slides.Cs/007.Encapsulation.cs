using System.Collections.Generic;
using System.Linq;

public class Encapsulation
{
    public static void Main()
    {
        new List<int> { 2, 3, 4, 5 }.Where(n => n % 2 == 0);
    }

}