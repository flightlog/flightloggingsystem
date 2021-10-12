using System.Text.RegularExpressions;

namespace FLS.RulesEngine.Conditions
{
    internal class MatchesRegex : ICondition
    {
        private readonly string _text;
        private readonly string _pattern;

        public MatchesRegex(string text, string pattern)
        {
            _text = text;
            _pattern = pattern;
        }

        public bool IsSatisfied()
        {
            var match = Regex.Match(_text, _pattern, RegexOptions.IgnoreCase);

            return match.Success;
        }

        public override string ToString()
        {
            return $"(text: '{_text}' matches pattern: {_pattern} ==> {IsSatisfied()})";
        }
    }
}
