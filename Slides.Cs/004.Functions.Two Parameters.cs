using System;

public class FunctionsTwoParameters
{
    class MyMath
    {
        internal static int Add(int x, int y)
        {
            return x + y;
        }
    }

    public static void Main()
    {
        MyMath.Add(3,4);
    }
}