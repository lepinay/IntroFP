using System;
using System.IO;
using System.Net;
class TimerDecoratorDesignPattern
{
    interface ICalculator
    {
        int Calculate(int input);
    }

    class AddingCalculator : ICalculator
    {
        public int Calculate(int input) { return input + 1; }
    }

    class LoggingCalculator : ICalculator
    {
        ICalculator _innerCalculator;

        public LoggingCalculator(ICalculator innerCalculator)
        {
            _innerCalculator = innerCalculator;
        }

        public int Calculate(int input)
        {
            Console.WriteLine("input is {0}", input);
            var result = _innerCalculator.Calculate(input);
            Console.WriteLine("result is {0}", result);
            return result;
        }
    }

    class TimerCalculator : ICalculator
    {
        ICalculator _innerCalculator;

        public TimerCalculator(ICalculator innerCalculator)
        {
            _innerCalculator = innerCalculator;
        }

        public int Calculate(int input)
        {
           var stopwatch = new System.Diagnostics.Stopwatch();
           stopwatch.Start() ;
           var result = _innerCalculator.Calculate(input);  //evaluate the function
           Console.WriteLine("elapsed ms is {0}", stopwatch.ElapsedMilliseconds);
           return result;
        }
    }

    public static void Main()
    {
        var add1WithLogging = new LoggingCalculator(new AddingCalculator());
        var add1WithTimer = new TimerCalculator(add1WithLogging);
        add1WithTimer.Calculate(3);

    }
}