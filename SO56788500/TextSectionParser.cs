using System;
using System.Collections.Generic;
using System.Linq;

namespace SO56788500
{
    public class TextSectionParser
    {
        public TextSection Parse(string expression)
        {
            int index = 0;
            var sections = new List<TextSection>();

            while (index < expression.Length)
            {
                int oldIndex = index;

                sections.Add(ParseSection(expression, ref index));

                if (index == oldIndex)
                    throw new InvalidOperationException($"Parser got stuck at position {index} in '{expression}'");
            }

            if (sections.Count == 0)
                return null;

            if (sections.Count == 1)
                return sections[0];

            return new SequentialTextSection(sections.ToArray());
        }

        private TextSection ParseSection(string expression, ref int index)
        {
            if (expression[index] == '{')
                return ParseSubExpression(expression, ref index);
            
            return ParseStaticText(expression, ref index);
        }

        private TextSection ParseStaticText(string expression, ref int index)
        {
            int start = index;
            while (index < expression.Length && expression[index] != '{')
                index++;

            return new StaticTextSection(expression.Substring(start, index - start));
        }

        private TextSection ParseSubExpression(string expression, ref int index)
        {
            int start = index;
            index++;
            int level = 1;

            var subExpressions = new List<string>();
            int startOfLastSubExpression = index;
            while (index < expression.Length && level > 0)
            {
                if (expression[index] == '{')
                    level++;
                else if (expression[index] == '}')
                {
                    if (level == 1 && index > startOfLastSubExpression)
                        subExpressions.Add(expression.Substring(startOfLastSubExpression, index - startOfLastSubExpression));
                    level--;
                }
                else if (expression[index] == '|' && level == 1)
                {
                    subExpressions.Add(expression.Substring(startOfLastSubExpression, index - startOfLastSubExpression));
                    startOfLastSubExpression = index + 1;
                }

                index++;
            }

            return new RandomTextSection(subExpressions.Select(Parse).ToArray());
        }
    }
}