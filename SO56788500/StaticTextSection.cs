using System;

namespace SO56788500
{
    public class StaticTextSection : TextSection
    {
        private readonly string _Text;
        public StaticTextSection(string text) => _Text = text;
        public override string GetText(Random rnd) => _Text;
    }
}