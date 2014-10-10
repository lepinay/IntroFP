using System;

public class HelloWorld
{
    class MyMath
    {
        internal static int Square(int x)
        {
            return x * x;
        }
    }

    public static void Main()
    {
        MyMath.Square(3);
    }
}