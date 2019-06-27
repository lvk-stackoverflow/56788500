using System;

namespace SO56788500
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new TextSectionParser().Parse("My name is {John|Tom|Bob} and I live in {a {big|small} city|the {beautiful|large} country}");

            var rnd = new Random();
            for (int index = 0; index < 10; index++)
                Console.WriteLine(text.GetText(rnd));
        }
    }
}