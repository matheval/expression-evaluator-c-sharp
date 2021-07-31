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
using System.Globalization;
using static org.matheval.Common.Afe_Common;

namespace org.matheval
{
    public class Lexer
    {
        /// <summary>
        /// Input expression
        /// </summary>
        private string FomulaInput;

        /// <summary>
        /// Current token
        /// </summary>
        public Token CurrentToken { get; set; }

        /// <summary>
        /// Previous token
        /// </summary>
        public Token PreviousToken { get; set; }

        /// <summary>
        /// Last char, default is white space
        /// </summary>
        //private string LastChar = Afe_Common.Const_WhiteSpace;
        private char LastChar = Afe_Common.Const_WhiteSpace;

        /// <summary>
        /// Last char position;
        /// </summary>
        public int LexerPosition = 0;

        /// <summary>
        /// Create new object parser
        /// </summary>
        private Parser Parser;

        /// <summary>
        /// Initializes a new instance structure to a specified type token value and string value
        /// </summary>
        /// <param name="fomulaInput">fomulaInput</param>
        /// <param name="parser">parser</param>
        public Lexer(string fomulaInput, Parser parser)
        {
            this.FomulaInput = fomulaInput;
            this.Parser = parser;
        }

        /// <summary>
        /// Get processing char of expression
        /// </summary>
        /// <returns>char</returns>
        private char GetChar()
        {
            if (LexerPosition < FomulaInput.Length)
            {
                //return FomulaInput.ToCharArray()[LexerPosition++].ToString();
                return FomulaInput[LexerPosition++];
            }
            else
            {
                //return null;
                return (char)0;
            }
        }

        /// <summary>
        /// View next char of processing char
        /// </summary>
        /// <returns> Position char next in string</returns>
        /*private string ViewNextChar()
        {
            if (LexerPosition < FomulaInput.Length)
            {
                return FomulaInput.ToCharArray()[LexerPosition].ToString();
            }
            return "10";
        }*/
        private char ViewNextChar()
        {
            if (LexerPosition < FomulaInput.Length)
            {
                return FomulaInput[LexerPosition];
            }
            return (char)0;
        }

        /// <summary>
        /// Check if end of expression
        /// </summary>
        /// <returns>Boolean true if end of expression, otherwise false</returns>
        private bool IsEof()
        {
            //return LastChar == null;
            return LastChar == (char)0;
            
        }
        /// <summary>
        /// Reset lexer
        /// </summary>
        public void resetLexer()
        {
            this.LastChar = Afe_Common.Const_WhiteSpace;
            this.LexerPosition = 0;
            this.CurrentToken = null;
            this.PreviousToken = null;
        }

        /// <summary>
        /// Get next token of expression string
        /// Current token will be assigned to previous token
        /// </summary>
        public void GetToken()
        {
            if (CurrentToken != null)
            {
                PreviousToken = CurrentToken;
            }
            this.Next();
        }

        /// <summary>
        /// Get next token of expression string
        /// </summary>
        private void Next()
        {
            //remove all white space
            //while (!IsEof() && string.IsNullOrWhiteSpace(this.LastChar))
            while (!IsEof() && this.LastChar == Afe_Common.Const_WhiteSpace)
            {
                this.LastChar = this.GetChar();
            }

            if (IsEof())
            {
                CurrentToken = new Token(TokenType.TOKEN_EOF);
                return;
            }

            //identifier
            if (Afe_Common.IsAlpha(this.LastChar))
            {
                string identifierTemp = this.LastChar.ToString();
                this.LastChar = this.GetChar();
                while (!IsEof() && Afe_Common.IsAlphaNumeric(this.LastChar))
                {
                    identifierTemp += this.LastChar;
                    this.LastChar = this.GetChar();
                }
                if (this.Parser.GetOperators().ContainsKey(identifierTemp))
                {
                    CurrentToken = new Token(TokenType.TOKEN_OP, identifierTemp);
                    return;
                }
                if (identifierTemp.ToUpper().Equals(Afe_Common.Const_IF) && !IsEof() && this.LastChar.Equals(Afe_Common.Const_BRACKETS_OPEN))
                {
                    CurrentToken = new Token(TokenType.TOKEN_IF, identifierTemp);
                    return;
                }
                else if (identifierTemp.ToUpper().Equals(Afe_Common.Const_CASE) && !IsEof() && this.LastChar.Equals(Afe_Common.Const_BRACKETS_OPEN))
                {
                    CurrentToken = new Token(TokenType.TOKEN_CASE, identifierTemp);
                    return;
                }
                else if (identifierTemp.ToUpper().Equals(Afe_Common.Const_SWITCH) && !IsEof() && this.LastChar.Equals(Afe_Common.Const_BRACKETS_OPEN))
                {
                    CurrentToken = new Token(TokenType.TOKEN_CASE, identifierTemp);
                    return;
                }
                Token identifierTok = new Token(TokenType.TOKEN_IDENTIFIER, identifierTemp);
                CurrentToken = identifierTok;
                return;
            }
            //number 
            else if (Afe_Common.IsNumeric(this.LastChar) || (this.LastChar.Equals(Afe_Common.Const_PERIODT) && Afe_Common.IsNumeric(ViewNextChar())))
            {
                string numberTemp = this.LastChar.ToString();
                this.LastChar = this.GetChar();
                while (!IsEof() && 
                        (
                          Afe_Common.IsNumeric(this.LastChar) ||
                          this.LastChar.Equals(Afe_Common.Const_PERIODT) ||
                          (
                              this.LastChar.ToString().ToLower().Equals("e") &&
                              !numberTemp.ToLower().Contains("e") &&
                              (ViewNextChar().Equals('+') || ViewNextChar().Equals('-'))
                          ) ||
                          (
                            this.LastChar.Equals('-') && numberTemp.Length > 0 &&
                            Afe_Common.Right(numberTemp,1).ToLower().Equals("e") &&
                            Afe_Common.IsNumeric(ViewNextChar())
                          ) ||
                          (
                            this.LastChar.Equals('+') && numberTemp.Length > 0 &&
                            Afe_Common.Right(numberTemp,1).ToLower().Equals("e") &&
                            Afe_Common.IsNumeric(ViewNextChar())
                          )
                        )
                    )
                {
                    numberTemp += this.LastChar;
                    this.LastChar = this.GetChar();
                }
                if (numberTemp.ToLower().Contains("e"))
                {
                    CurrentToken = new Token(
                        TokenType.TOKEN_NUMBER_DECIMAL, 
                        decimal.Parse(numberTemp, System.Globalization.NumberStyles.Float)
                        );
                }
                else
                {
                    CurrentToken = new Token(
                        TokenType.TOKEN_NUMBER_DECIMAL,
                        decimal.Parse(numberTemp)
                        );
                }
                return;
            }
            //else if (this.LastChar.Equals(Afe_Common.Const_MARKS_QUOTATION))
            else if (this.LastChar == Afe_Common.Const_DOUBLE_QUOTATION)
            {
                string str_Temp = string.Empty;
                this.LastChar = this.GetChar();
                while (!IsEof())
                {
                    if (this.LastChar.Equals(Afe_Common.Const_DOUBLE_QUOTATION))
                    {
                        char nextChar = this.ViewNextChar();
                        if (nextChar.Equals(Afe_Common.Const_DOUBLE_QUOTATION))
                        {
                            this.LastChar = this.GetChar();
                            str_Temp += this.LastChar;
                            this.LastChar = this.GetChar();
                        }
                        else break;
                    }
                    else
                    {
                        str_Temp += this.LastChar;
                        this.LastChar = this.GetChar();
                    }
                }
                if (!IsEof() && this.LastChar.Equals(Afe_Common.Const_DOUBLE_QUOTATION))
                {
                    Token strTok = new Token(TokenType.TOKEN_STRING, str_Temp);
                    CurrentToken = strTok;
                    this.LastChar = this.GetChar();
                    return;
                }
                throw new Exception("Quote is expected!");

            }
            else if (this.LastChar == Afe_Common.Const_SINGLE_QUOTATION)
            {
                string str_Temp = string.Empty;
                this.LastChar = this.GetChar();
                while (!IsEof())
                {
                    if (this.LastChar.Equals(Afe_Common.Const_SINGLE_QUOTATION))
                    {
                        char nextChar = this.ViewNextChar();
                        if (nextChar.Equals(Afe_Common.Const_SINGLE_QUOTATION))
                        {
                            this.LastChar = this.GetChar();
                            str_Temp += this.LastChar;
                            this.LastChar = this.GetChar();
                        }
                        else break;
                    }
                    else
                    {
                        str_Temp += this.LastChar;
                        this.LastChar = this.GetChar();
                    }
                }
                if (!IsEof() && this.LastChar.Equals(Afe_Common.Const_SINGLE_QUOTATION))
                {
                    Token strTok = new Token(TokenType.TOKEN_STRING, str_Temp);
                    CurrentToken = strTok;
                    this.LastChar = this.GetChar();
                    return;
                }
                throw new Exception("Quote is expected!");

            }
            else if (this.LastChar.Equals(Afe_Common.Const_BRACKETS_OPEN))
            {
                CurrentToken = new Token(TokenType.TOKEN_PAREN_OPEN);
                this.LastChar = this.GetChar();
                return;
            }
            else if (this.LastChar.Equals(Afe_Common.Const_BRACKETS_CLOSE))
            {
                CurrentToken = new Token(TokenType.TOKEN_PAREN_CLOSE);
                this.LastChar = this.GetChar();
                return;
            }
            else if (this.LastChar.Equals(Afe_Common.Const_COMMA))
            {
                CurrentToken = new Token(TokenType.TOKEN_COMMA);
                this.LastChar = this.GetChar();
                return;
            }
            else
            {
                string strTemp = string.Empty;
                string matchedOp = string.Empty;
                int lastMatchedPos = -1;
                string matchedUop = string.Empty;
                int lastMatchedUopPos = -1;

                while (!IsEof() &&
                      !Afe_Common.IsAlpha(this.LastChar) &&
                      !Afe_Common.IsNumeric(this.LastChar) &&
                      //!string.IsNullOrWhiteSpace(this.LastChar) &&
                      this.LastChar != Afe_Common.Const_WhiteSpace &&
                      !this.LastChar.Equals(Afe_Common.Const_BRACKETS_OPEN) &&
                      !this.LastChar.Equals(Afe_Common.Const_BRACKETS_CLOSE) &&
                      !this.LastChar.Equals(Afe_Common.Const_COMMA) &&
                      !this.LastChar.Equals(Afe_Common.Const_DOUBLE_QUOTATION) &&
                      !this.LastChar.Equals(Afe_Common.Const_SINGLE_QUOTATION)
                      )
                {
                    strTemp += this.LastChar;
                    if (this.Parser.GetOperators().ContainsKey(strTemp))
                    {
                        matchedOp = strTemp;
                        lastMatchedPos = this.LexerPosition;
                    }
                    if (this.Parser.GetUnaryOperators().ContainsKey(strTemp))
                    {
                        matchedUop = strTemp;
                        lastMatchedUopPos = this.LexerPosition;
                    }
                    this.LastChar = this.GetChar();
                }
                if (PreviousToken == null ||
                   PreviousToken.Type == TokenType.TOKEN_OP ||
                   PreviousToken.Type == TokenType.TOKEN_UOP ||
                   PreviousToken.Type == TokenType.TOKEN_PAREN_OPEN ||
                   PreviousToken.Type == TokenType.TOKEN_COMMA)
                {
                    if (lastMatchedUopPos != -1)
                    {
                        CurrentToken = new Token(TokenType.TOKEN_UOP, matchedUop);
                        this.LexerPosition = lastMatchedUopPos;
                        this.LastChar = this.GetChar();
                        return;
                    }
                }
                else
                {
                    if (lastMatchedPos != -1)
                    {
                        CurrentToken = new Token(TokenType.TOKEN_OP, matchedOp);
                        this.LexerPosition = lastMatchedPos;
                        this.LastChar = this.GetChar();
                        return;
                    }
                }
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                              new String[] { strTemp, this.LexerPosition.ToString() }));
            }
        }
    }
}
