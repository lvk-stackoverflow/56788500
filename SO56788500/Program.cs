using System;

namespace SO56788500
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new TextSectionParser().Parse("123 {a {x|y}|b {k|l}|c {f|j}} 456");

            var rnd = new Random();
            for (int index = 0; index < 10; index++)
                Console.WriteLine(text.GetText(rnd));
        }
    }
}