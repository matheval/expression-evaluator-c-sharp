/*
    The MIT License

    Copyright (c) 2021 MathEval.org

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
using org.matheval.Common;
using System;
using System.Collections.Generic;

namespace org.matheval.Functions
{
    /// <summary>
    /// Capitalizes words given text string
    /// PROPER("capitalize the first letter in each word") -> Capitalize The First Letter In Each Word
    /// </summary>
    public class properFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                    new FunctionDef(Afe_Common.Const_Proper, new System.Type[]{ typeof(string) }, typeof(string), 1)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>To Title Case</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            return this.ToTitleCase(Afe_Common.ToString(args[Afe_Common.Const_Key_One]));
        }

        /// <summary>
        /// To Title Case
        /// </summary>
        /// <param name="phrase">phrase</param>
        /// <returns>To Title Case</returns>
        public string ToTitleCase(string phrase)
        {
            string titlePhrase = string.Empty;
            List<string> forceLower = new List<string>();

            if (phrase != null && phrase.Length > 0)
            {
                string[] splitPhrase = phrase.Trim().Split(' ');

                for (int i = 0; i < splitPhrase.Length; i++)
                {
                    if (!forceLower.Contains(splitPhrase[i].ToLower()) || i == 0 || i == (splitPhrase.Length - 1))
                    {
                        titlePhrase += splitPhrase[i].Substring(0, 1).ToUpper() + splitPhrase[i].Substring(1).ToLower() + " ";
                    }
                    else
                    {
                        titlePhrase += splitPhrase[i].ToLower() + " ";
                    }
                }
            }
            return titlePhrase.Trim();
        }
    }
}
