using System.Collections.Generic;

namespace JAC.Core
{
    public abstract class JavascriptContext : IParserContext
    {
        private readonly List<JavascriptContext> _contexts = new List<JavascriptContext>();

        IParserContext IParserContext.ProcessCharacter(char character, out bool consumed, out bool complete)
        {
            var context = ProcessCharacter(character, out consumed, out complete);
            if(context != null)
            {
                _contexts.Add(context);
            }
        }

        void IParserContext.Complete()
        {

        }

        protected abstract JavascriptContext ProcessCharacter(char character, out bool consumed, out bool complete);
    }
}