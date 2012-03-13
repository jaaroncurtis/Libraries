namespace JAC.Core
{
    public sealed class Whitespace:JavascriptContext
    {
        protected override IParserContext ProcessCharacter(char character, out bool consumed, out bool complete)
        {
            if(char.IsWhiteSpace(character))
            {
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