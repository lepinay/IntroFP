using System;
using System.IO;
using System.Net;
class StrategyDesignPattern
{
    interface IMakeNoiseStrategy
    {
        string MakeNoise();
    }

    class MeowingStrategy : IMakeNoiseStrategy
    {
        public string MakeNoise()
        {
            return "Meow";
        }
    }

    class WoofOrBarkStrategy : IMakeNoiseStrategy
    {
        public string MakeNoise()
        {
            if (System.DateTime.Now.Second % 2 == 0)
                return "Woof";
            else return "Bark";
        }
    }

    class Animal
    {
        private IMakeNoiseStrategy noiseStrategy;
        public Animal(IMakeNoiseStrategy strategy)
        {
            noiseStrategy = strategy;
        }

        public void MakeNoise()
        {
            Console.WriteLine(noiseStrategy.MakeNoise());
        }
    }

    public static void Main()
    {
        var cat = new Animal(new MeowingStrategy());
        cat.MakeNoise();

        var dog = new Animal(new WoofOrBarkStrategy());
        dog.MakeNoise();
        dog.MakeNoise();  //try again a second later
    }
}