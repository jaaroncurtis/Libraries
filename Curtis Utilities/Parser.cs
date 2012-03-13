using System;
using System.Collections.Generic;
using System.IO;

namespace JAC.Core
{
    public abstract class Parser : IDisposable
    {
        private readonly TextReader _buffer;
        private readonly Stack<IParserContext> _contexts;

        protected Parser(TextReader buffer, IParserContext rootContext)
        {
            _buffer = buffer;
            _contexts = new Stack<IParserContext>();
            _contexts.Push(rootContext);
        }

        private IParserContext Context
        {
            get { return _contexts.Count == 0 ? null : _contexts.Peek(); }
        }

        protected void Execute()
        {
            var data = _buffer.Read();
            while(data > -1)
            {                
                var character = (char) data;
                while(true)
                {
                    bool consumed, complete;
                    var subContext = Context.ProcessCharacter(character, out consumed, out complete);
                    if(subContext != null)
                    {
                        _contexts.Push(subContext);
                    }
                    else if(complete)
                    {
                        _contexts.Pop();
                        if(Context == null)
                        {
                            if (consumed)
                            {
                                return;
                            }
                            throw new InvalidOperationException("Stack Imbalance Exception");
                        }
                    }
                    if(consumed)
                    {
                        break;
                    }
                }
            }
        }

        public void Dispose()
        {
            _buffer.Dispose();
        }
    }
}