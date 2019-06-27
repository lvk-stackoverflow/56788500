using System;
using System.Linq;

namespace SO56788500
{
    public class SequentialTextSection : TextSection
    {
        private readonly TextSection[] _Sections;
        public SequentialTextSection(TextSection[] sections) => _Sections = sections;
        public override string GetText(Random rnd) =>
            string.Join("", _Sections.Select(section => section.GetText(rnd)));
    }
}