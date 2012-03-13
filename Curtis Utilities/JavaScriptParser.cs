using System.IO;

namespace JAC.Core
{
    public sealed class JavaScriptParser : Parser
    {
        private JavaScriptParser(TextReader buffer, IParserContext rootBlock)
            : base(buffer, rootBlock)
        {
        }

        public static JavascriptBlock Parse(TextReader buffer)
        {
            var block = new JavascriptBlock();
            using (var parser = new JavaScriptParser(buffer, block))
            {
                parser.Execute();
            }
            return block;
        }
    }
}