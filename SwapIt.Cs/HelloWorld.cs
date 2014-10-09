using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static void Main()
    {
        // Hello World
        Console.WriteLine("Hello world !");

        // Basic Types
        int myInt = 5;
        float myFloat = 3.14f;
        string myString = "hello";   

        // Lists
        var twoToFive = new List<int>{2,3,4,5};
        var oneToFive = new List<int>(twoToFive);
        oneToFive.Insert(0,1);
        var zeroToFive = new List<int>{0,1}.Concat(twoToFive);

        // Functions
        square(3);
    }

    public static int square(int x)
    {
        return x * x;
    }
}