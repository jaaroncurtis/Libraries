using System.Collections.Generic;

namespace JAC.Core
{
    public sealed class Identifier:JavascriptContext
    {
        private List<char> _chars = new List<char>();

        protected override IParserContext ProcessCharacter(char character, out bool consumed, out bool complete)
        {
            if(char.IsLetterOrDigit(character) || character == '$' || character == '_')
            {
                _chars.Add(character);
                consumed = true;
                complete = false;
                return null;
            }
            consumed = false;
            complete = true;
            return null;
        }
    }
}