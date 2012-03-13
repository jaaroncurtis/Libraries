using System;
using System.Collections.Generic;

namespace JAC.Core
{
    public sealed class JavascriptBlock : JavascriptContext
    {
        protected override JavascriptContext ProcessCharacter(char character, out bool consumed, out bool complete)
        {
            switch (character)
            {
                case '{':

                case '[':
                case '+':
                case '-':
                case '"':
                case '*':
                case ';':

                    

            }
        }
    }
}