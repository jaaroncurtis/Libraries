namespace JAC.Core
{
    public interface IParserContext
    {
        IParserContext ProcessCharacter(char character, out bool consumed, out bool complete);
        void Complete();
    }
}