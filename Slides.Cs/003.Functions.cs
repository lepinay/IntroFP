using System;

public class Functions
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