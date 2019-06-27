using System;

namespace SO56788500
{
    public class RandomTextSection : TextSection
    {
        private readonly TextSection[] _Sections;
        public RandomTextSection(TextSection[] sections) => _Sections = sections;
        public override string GetText(Random rnd) => _Sections[rnd.Next(_Sections.Length)].GetText(rnd);
    }
}