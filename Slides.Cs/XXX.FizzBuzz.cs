using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FizzBuzz
{

    public static void Main()
    {
        for (int x = 1; x <= 100; x++)
        {
            string output = "";
            if (x % 3 == 0) output += "Fizz";
            if (x % 5 == 0) output += "Buzz";
            if (output == "") output = x.ToString();
            Console.WriteLine(output);
        }
    }
}