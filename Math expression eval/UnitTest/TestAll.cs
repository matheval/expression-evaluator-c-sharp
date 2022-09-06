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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.matheval;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace UnitTest
{
    [TestClass]
    public class TestAll
    {
        [TestMethod]
        public void Math_Operator_Add_Test()
        {

            Expression expr1 = new Expression("1+3.5");
            Assert.AreEqual(4.5M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("1+3.5");
            Assert.AreEqual(4, expr2.Eval<int>());
        }

        [TestMethod]
        public void Math_Operator_Subtract_Test()
        {

            Expression expr1 = new Expression("1-3.5");
            Assert.AreEqual(-2.5M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("1-3.5");
            Assert.AreEqual(-2, expr2.Eval<int>());

            Expression expr3 = new Expression("17769832984123423.82372423-17769832984123423.82372423");
            Assert.AreEqual(0, expr3.Eval<decimal>());

            Expression expr4 = new Expression("17769832984123423.82372423-1");
            Assert.AreEqual(17769832984123422.823724m, expr4.Eval<decimal>());
        }

        [TestMethod]
        public void Math_Operator_Mul_Test()
        {

            Expression expr1 = new Expression("2.4*3");
            Assert.AreEqual(7.2M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("2.4*-3.33");
            Assert.AreEqual(-7.992M, expr2.Eval<decimal>());

            Expression expr3 = new Expression("2785864653.34352334 * 6564653.35335343");
            Assert.AreEqual(18288235738559151.145413M, expr3.Eval<decimal>());
        }

        [TestMethod]
        public void Math_Operator_Div_Test()
        {

            Expression expr1 = new Expression("2.4/-3.33");
            Assert.AreEqual(-0.720721M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("6/3");
            Assert.AreEqual(2M, expr2.Eval<decimal>());

            Expression expr3 = new Expression("5/3*3");
            Assert.AreEqual(5M, expr3.Eval<decimal>());
        }

        [TestMethod]
        public void Math_Operator_Power_Test()
        {

            Expression expr1 = new Expression("2^-3.3");
            expr1.SetScale(3);
            Assert.AreEqual(0.102M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("2^3");
            Assert.AreEqual(8M, expr2.Eval<decimal>());

            Expression expr3 = new Expression("-2^2");
            Assert.AreEqual(-4M, expr3.Eval<decimal>());

            Expression expr4 = new Expression("3*2^-1.5^0.4%0.11-3");
            Assert.AreEqual(-2.992342M, expr4.Eval<decimal>());
        }

        [TestMethod]
        public void Math_Operator_Mod_Test()
        {
            Expression expr1 = new Expression("2%3");
            Assert.AreEqual(2M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("21%20");
            Assert.AreEqual(1M, expr2.Eval<decimal>());
        }

        [TestMethod]
        public void Math_Operator_Ge_Test()
        {

            Expression expr1 = new Expression("a >= 1.23");
            Assert.AreEqual(true, expr1.Bind("a", 1.23).Eval<bool>());

            Expression expr2 = new Expression("a >= 1.23");
            Assert.AreEqual(true, expr2.Bind("a", 1.24).Eval<bool>());

            Expression expr3 = new Expression("a >= 1.23");
            Assert.AreEqual(false, expr3.Bind("a", 1.22).Eval<bool>());

            Expression expr4 = new Expression("a >= 1.23");
            Assert.AreEqual(true, expr4.Bind("a", 3).Eval<bool>());

            Expression expr5 = new Expression("true >= false");
            Assert.AreEqual(true, expr5.Eval<bool>());
        }

        [TestMethod]
        public void Math_Operator_Gt_Test()
        {

            Expression expr1 = new Expression("a > 1.23");
            Assert.AreEqual(false, expr1.Bind("a", 1.23).Eval<bool>());

            Expression expr2 = new Expression("a > 1.23");
            Assert.AreEqual(true, expr2.Bind("a", 1.24).Eval<bool>());

            Expression expr3 = new Expression("true > false");
            Assert.AreEqual(true, expr3.Eval<bool>());

            Expression expr4 = new Expression("false > true");
            Assert.AreEqual(false, expr4.Eval<bool>());
        }

        [TestMethod]
        public void Math_Operator_Le_Test()
        {

            Expression expr1 = new Expression("a <= 1.23");
            Assert.AreEqual(true, expr1.Bind("a", 1.23).Eval<bool>());

            Expression expr2 = new Expression("a <= 1.23");
            Assert.AreEqual(true, expr2.Bind("a", 1.22d).Eval<bool>());

        }

        [TestMethod]
        public void Math_Operator_Lt_Test()
        {

            Expression expr1 = new Expression("a < 1.23");
            Assert.AreEqual(false, expr1.Bind("a", 1.23).Eval<bool>());

            Expression expr2 = new Expression("a < 1.23");
            Assert.AreEqual(true, expr2.Bind("a", 1.22m).Eval<bool>());

            Expression expr3 = new Expression("a < (373434*13214235.64)");
            Assert.AreEqual(true, expr3.Bind("a", (373434 * 13214235.64) - 1).Eval<bool>());

        }

        [TestMethod]
        public void Math_Operator_Eq_Test()
        {

            Expression expr1 = new Expression("a = null");
            Assert.AreEqual(true, expr1.Bind("a", null).Eval<bool>());

            Expression expr2 = new Expression("a = 1.23");
            Assert.AreEqual(true, expr2.Bind("a", 1.23).Eval<bool>());

            Expression expr3 = new Expression("a = (373434*13214235.64)");
            Assert.AreEqual(true, expr3.Bind("a", 373434 * 13214235.64).Eval<bool>());

            Expression expr4 = new Expression("a = 1.22");
            Assert.AreEqual(false, expr4.Bind("a", 1.23).Eval<bool>());

            Expression expr5 = new Expression("a = b");
            Assert.AreEqual(true, expr5.Bind("a", decimal.MaxValue).Bind("b", decimal.MaxValue).Eval<bool>());

            Expression expr6 = new Expression("a = b");
            Assert.AreEqual(false, expr6.Bind("a", decimal.MaxValue).Bind("b", decimal.MaxValue - 1).Eval<bool>());

        }

        [TestMethod]
        public void Math_Operator_Neq_Test()
        {

            Expression expr1 = new Expression("a <> null");
            Assert.AreEqual(true, expr1.Bind("a", 1).Eval<bool>());

            Expression expr1b = new Expression("a <> null");
            Assert.AreEqual(false, expr1b.Bind("a", null).Eval<bool>());

            Expression expr2 = new Expression("a <> 1.23");
            Assert.AreEqual(false, expr2.Bind("a", 1.23).Eval<bool>());

            Expression expr2b = new Expression("a <> 1.23");
            Assert.AreEqual(true, expr2b.Bind("a", 1.22).Eval<bool>());

            Expression expr2c = new Expression("a <> 1.23");
            Assert.AreEqual(true, expr2c.Bind("a", null).Eval<bool>());

            Expression expr3 = new Expression("a <> (373434*13214235.64)");
            Assert.AreEqual(false, expr3.Bind("a", 373434 * 13214235.64).Eval<bool>());

            Expression expr4 = new Expression("a <> 1.22");
            Assert.AreEqual(true, expr4.Bind("a", 1.23).Eval<bool>());

            Expression expr5 = new Expression("a <> b");
            Assert.AreEqual(false, expr5.Bind("a", decimal.MaxValue).Bind("b", decimal.MaxValue).Eval<bool>());

            Expression expr6 = new Expression("a <> b");
            Assert.AreEqual(true, expr6.Bind("a", decimal.MaxValue).Bind("b", decimal.MaxValue - 1).Eval<bool>());

        }

        [TestMethod]
        public void Math_Unary_Operator_Test()
        {
            Expression expr1 = new Expression("-9---+(-(++-2))+3");
            Assert.AreEqual(-8m, expr1.Eval<decimal>());


            expr1 = new Expression("34 - +(--++3.1 ^ --+0.1)");
            Assert.AreEqual(32.880211m, expr1.Eval<decimal>());

            expr1 = new Expression("--1==1");
            Assert.AreEqual(true, expr1.Eval<bool>());
        }

        [TestMethod]
        public void Math_Operator_Precedence_Test()
        {
            Expression expr1 = new Expression("-2^2");
            Assert.AreEqual(-4m, expr1.Eval<decimal>());

            Expression expr2 = new Expression("9+8*3.2-1.1/6^(1.5%2+3)");
            Assert.AreEqual(34.599653m, expr2.Eval<decimal>());

            Expression expr3 = new Expression("1-2*1+6");
            Assert.AreEqual(5m, expr3.Eval<decimal>());

            Expression expr4 = new Expression("1 ^ 1.2 ^ 3 % 0.7 / 1 * 6.5");
            Assert.AreEqual(1.95m, expr4.Eval<decimal>());

            Expression expr5 = new Expression("1 ^ 1.2 ^ --3 % 0.7 / 1 * 6.5 % -1.1 ^ exp(3) ^ -3.11");
            Assert.AreEqual(-0.050017m, expr5.Eval<decimal>());

            Expression expr6 = new Expression("1 - 3 / 4 + 10 + 1 + 2");
            Assert.AreEqual(13.25m, expr6.Eval<decimal>());

            Expression expr7 = new Expression("e^0.1-pi^e/1.0*5/3*5");
            Assert.AreEqual(-186.054477m, expr7.Eval<decimal>());

            Expression expr8 = new Expression("(1>2 || 6<7 || 1.2+1==2) && true || not(false)");
            Assert.AreEqual(true, expr8.Eval<bool>());

        }

        [TestMethod]
        public void Math_Operator_Precedence_Test2()
        {
            Expression expr1 = new Expression("6.78-2*3^-1.5+e/pi%3");
            Assert.AreEqual(7.260356m, expr1.Eval<decimal>());

            expr1.SetFomular("6.78-2*3^-1.5+e/pi%3%(tan(pi/1.3)-0.12^-1.3/5)");
            expr1.SetScale(3);
            Assert.AreEqual(3.226m, expr1.Eval<decimal>());

            expr1.SetFomular("5/3*5^pi-1.32*-e%(-3.6*1.78)");
            expr1.SetScale(7);
            Assert.AreEqual(265.2423742m, expr1.Eval<decimal>());

            expr1.SetScale(6);
            expr1.SetFomular("PI()-+(--+---PI()/3*3)");
            Assert.AreEqual(6.283185m, expr1.Eval<decimal>());

        }

        [TestMethod]
        public void Math_Wrong_Expr_Test()
        {
            Expression expr1 = new Expression("2+1*");
            Assert.AreNotEqual(0, expr1.GetError().Count);

            Expression expr2 = new Expression("2+1)");
            Assert.AreNotEqual(0, expr2.GetError().Count);

            Expression expr3 = new Expression("()");
            Assert.AreNotEqual(0, expr3.GetError().Count);

            Expression expr4 = new Expression("(3+2");
            Assert.AreNotEqual(0, expr4.GetError().Count);

        }

        [TestMethod]
        public void Math_AndOr_Test()
        {
            Expression expr1 = new Expression("true&&false");
            Assert.AreEqual(false, expr1.Eval<bool>());

            Expression expr2 = new Expression("(3>2) && (1>3 || 8>7)");
            Assert.AreEqual(true, expr2.Eval<bool>());

            Expression expr3 = new Expression("1>2 || 3 > 2 && 6 > 7 ");
            Assert.AreEqual(false, expr3.Eval<bool>());

            Expression expr4 = new Expression("(a && true)");
            Assert.AreEqual(false, expr4.Bind("a", false).Eval<bool>());

            Expression expr5 = new Expression("(a || false)");
            Assert.AreEqual(false, expr5.Bind("a", false).Eval<bool>());

            Expression expr6 = new Expression("(a || false) && (2 > b)");
            Assert.AreEqual(false, expr5.Bind("a", false).Bind("b", 1).Eval<bool>());

            expr6.SetFomular("not(x<7 || sqrt(max(x,9,3,min(4,3))) <= 3)");
            Assert.AreEqual(true, expr6.Bind("x", 22.9m).Eval<bool>());
        }

        [TestMethod]
        public void Math_Ifelse_Test()
        {
            Expression expr1 = new Expression("if(a>b,true,false)");
            Assert.AreEqual(true, expr1.Bind("a", 10).Bind("b", 9).Eval<bool>());

            Expression expr2 = new Expression("if(a>b,true,if(1>2,true,false))");
            Assert.AreEqual(false, expr2.Bind("a", 8).Bind("b", 9).Eval<bool>());

            Expression expr3 = new Expression("if(a>b,true,3)");
            Assert.AreNotEqual(0, expr3.Bind("a", 10).Bind("b", 9).GetError().Count);

            Expression expr4 = new Expression("if(if(true,true,false),true,3)");
            Assert.AreNotEqual(0, expr4.Bind("a", 10).Bind("b", 9).GetError().Count);

            Expression expr5 = new Expression("if(true,12)");
            Assert.AreNotEqual(0, expr5.GetError().Count);

            Expression expr6 = new Expression("if(2>1)");
            Assert.AreNotEqual(0, expr6.GetError().Count);

            Expression expr7 = new Expression("if(2>1,true,false");
            Assert.AreNotEqual(0, expr7.GetError().Count);

            Expression expr8 = new Expression("if(2+1,true,false)");
            Assert.AreNotEqual(0, expr8.GetError().Count);

        }

        [TestMethod]
        public void Math_SwitchCase_Test()
        {
            Expression expr1 = new Expression("switch(a,1,\"apple\",2,\"mango\",\"n/a\")");
            Assert.AreEqual("mango", expr1.Bind("a", 2).Eval().ToString());

            Expression expr2 = new Expression("switch(a,1,pi,2,\"mango\",e)");
            Assert.AreNotEqual(0, expr2.Bind("a", 2).GetError().Count);

            Expression expr3 = new Expression("switch(a)");
            Assert.AreNotEqual(0, expr3.Bind("a", 2).GetError().Count);

            Expression expr4 = new Expression("switch(a,1,2,3,4)");
            Assert.AreNotEqual(0, expr4.Bind("a", 2).GetError().Count);

            Expression expr5 = new Expression("switch(a,1(2,3;4;5)");
            Assert.AreNotEqual(0, expr5.Bind("a", 2).GetError().Count);
        }

        [TestMethod]
        public void Math_Bitwise_Test()
        {
            Expression expr1 = new Expression("BITAND(13,25)");
            Assert.AreEqual(9m, expr1.Eval<decimal>());

            Expression expr2 = new Expression("BITOR(23,10)");
            Assert.AreEqual(31m, expr2.Eval<decimal>());

            Expression expr3 = new Expression("BITXOR(5,3)");
            Assert.AreEqual(6m, expr3.Eval<decimal>());

            Expression expr4 = new Expression("BITNOT(6)");
            Assert.AreEqual(-7m, expr4.Eval<decimal>());

            Expression expr5 = new Expression("BITLSHIFT(4,2)");
            Assert.AreEqual(16m, expr5.Eval<decimal>());

            Expression expr6 = new Expression("BITRSHIFT(13,2)");
            Assert.AreEqual(3, expr6.Eval<int>());

            Expression expr7 = new Expression("VALUE(\"123\")");
            Assert.AreEqual(123, expr7.Eval<int>());

        }

        [TestMethod]
        public void Math_Logical_Test()
        {
            Expression expr1 = new Expression("AND(2>1,3<9/2)");
            Assert.AreEqual(true, expr1.Eval<bool>());

            Expression expr2 = new Expression("OR(2>1,3>9/2)");
            Assert.AreEqual(true, expr2.Eval<bool>());

            Expression expr3 = new Expression("IF(OR(2>1,3>9/2),1,2)");
            Assert.AreEqual(1, expr3.Eval<int>());

            Expression expr4 = new Expression("XOR(2>1,3<9/2)");
            Assert.AreEqual(false, expr4.Eval<bool>());

            Expression expr5 = new Expression("XOR(2>1,3<9/2,6<10,100<200)");
            Assert.AreEqual(false, expr5.Eval<bool>());

            Expression expr6 = new Expression("XOR(2>1,3<9/2,6<10)");
            Assert.AreEqual(true, expr6.Eval<bool>());

            Expression expr7 = new Expression("NOT(true)");
            Assert.AreEqual(false, expr7.Eval<bool>());
        }

        [TestMethod]
        public void Math_SumMinMaxavg_Test()
        {
            Expression expr1 = new Expression("SUM(1,2,3.1)");
            Assert.AreEqual(6.1m, expr1.Eval<decimal>());

            Expression expr2 = new Expression("SUM(abc)");
            expr2.Bind("abc", new List<decimal>() { 1, 2, 3 });
            Assert.AreEqual(6m, expr2.Eval<decimal>());

            Expression expr3 = new Expression("MIN(1,2,--1.2,-+3.4,3.1)");
            Assert.AreEqual(-3.4m, expr3.Eval<decimal>());

            Expression expr4 = new Expression("MIN(abc)");
            expr4.Bind("abc", new List<byte>() { 1, 2, 3 });
            Assert.AreEqual(1m, expr4.Eval<decimal>());


            Expression expr5 = new Expression("MAX(1,2,--1.2,-+3.4,3.1)");
            Assert.AreEqual(3.1d, expr5.Eval<double>());

            Expression expr6 = new Expression("MAX(abc)");
            expr6.Bind("abc", new List<int>() { 1, 2, 3 });
            Assert.AreEqual(3m, expr6.Eval<decimal>());


            Expression expr7 = new Expression("AVERAGE(1,2^(2-1.34%0.32)%0.5,--1.2,-+3.4,3.1)");
            Assert.AreEqual(0.447411m, expr7.Eval<decimal>());

            Expression expr8 = new Expression("AVERAGE(abc)");
            expr8.Bind("abc", new List<int>() { 1, 2, 3 });
            Assert.AreEqual(2m, expr8.Eval<decimal>());

            Expression expr9 = new Expression("AVERAGE(1,MOD(2^(2-MOD(1.34,0.32)),0.5),--1.2,-3.4,3.1)");
            Assert.AreEqual(0.447411m, expr9.Eval<decimal>());
        }

        [TestMethod]
        public void Math_Trigonometric_Test1()
        {
            Expression expr1 = new Expression("SIN(PI()/2)");
            Assert.AreEqual(1M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("SINH(PI()/2)");
            Assert.AreEqual(2.301299M, expr2.Eval<decimal>());

            Expression expr3 = new Expression("ASIN(0.5)");
            Assert.AreEqual(0.523599M, expr3.Eval<decimal>());

            Expression expr4 = new Expression("COS(PI())");
            Assert.AreEqual(-1m, expr4.Eval<decimal>());

            Expression expr5 = new Expression("COSH(4)");
            Assert.AreEqual(27.3082m, expr5.SetScale(4).Eval<decimal>());

            Expression expr6 = new Expression("ACOS(-0.5)*180/PI()");
            Assert.AreEqual(120m, expr6.SetScale(4).Eval<decimal>());

            Expression expr7 = new Expression("TANH(0)");
            Assert.AreEqual(0m, expr7.SetScale(4).Eval<decimal>());

            Expression expr8 = new Expression("TANH(-2)");
            Assert.AreEqual(-0.96403m, expr8.SetScale(5).Eval<decimal>());
        }

        [TestMethod]
        public void Math_Trigonometric_Test2()
        {
            Expression expr1 = new Expression("ATAN(1)");
            Assert.AreEqual(0.7854M, expr1.SetScale(4).Eval<decimal>());

            Expression expr2 = new Expression("ATAN(1)*180/PI()");
            Assert.AreEqual(45, expr2.Eval<int>());

            Expression expr2b = new Expression("ATAN(1)*180/PI()");
            Assert.AreEqual(45M, expr2b.Eval<decimal>());

            Expression expr3 = new Expression("DEGREES(ATAN(1))");
            Assert.AreEqual(45M, expr3.Eval<decimal>());

            Expression expr4 = new Expression("ATAN2(1, 1)");
            Assert.AreEqual(0.785398m, expr4.Eval<decimal>());

            Expression expr5 = new Expression("SEC(PI()/6)");
            Assert.AreEqual(1.1547m, expr5.SetScale(4).Eval<decimal>());

            Expression expr6 = new Expression("CSC(PI()/6)");
            Assert.AreEqual(2m, expr6.Eval<decimal>());

            Expression expr7 = new Expression("COT(PI()/6)");
            Assert.AreEqual(1.7321m, expr7.SetScale(4).Eval<decimal>());

            Expression expr8 = new Expression("ACOT(PI()/6)");
            Assert.AreEqual(1.088448m, expr8.Eval<decimal>());

            Expression expr9 = new Expression("COTH(PI()/6)");
            Assert.AreEqual(2.081283m, expr9.Eval<decimal>());

            Expression expr10 = new Expression("COTH(PI()*6)");
            Assert.AreEqual(1m, expr10.Eval<decimal>());
        }

        [TestMethod]
        public void Math_Trigonometric_Test3()
        {
            Expression expr1 = new Expression("SQRT(16)");
            Assert.AreEqual(4M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("SQRT(1/3)");
            Assert.AreEqual(0.57735m, expr2.Eval<decimal>());

            Expression expr2b = new Expression("MOD(16,3)");
            Assert.AreEqual(1, expr2b.Eval<int>());

            Expression expr3 = new Expression("MOD(6.25,1)");
            Assert.AreEqual(0.25M, expr3.Eval<decimal>());

            Expression expr4 = new Expression("LN(e)");
            Assert.AreEqual(1m, expr4.Eval<decimal>());

            Expression expr5 = new Expression("LN(10)");
            Assert.AreEqual(2.3026m, expr5.SetScale(4).Eval<decimal>());

            Expression expr6 = new Expression("LOG10(10^5)");
            Assert.AreEqual(5m, expr6.Eval<decimal>());

            Expression expr7 = new Expression("RAND()");
            Assert.AreEqual(true, expr7.SetScale(4).Eval<decimal>() >= 0);

            Expression expr8 = new Expression("RAND()");
            Assert.AreEqual(true, expr8.SetScale(4).Eval<decimal>() <= 1);

        }

        [TestMethod]
        public void Math_Trigonometric_Test4()
        {
            Expression expr1 = new Expression("EXP(3)");
            Assert.AreEqual(20.085537M, expr1.Eval<decimal>());

            Expression expr2 = new Expression("ABS(-1.1)");
            Assert.AreEqual(1.1m, expr2.Eval<decimal>());

            Expression expr2b = new Expression("FACT(8)");
            Assert.AreEqual(40320, expr2b.Eval<int>());

            Expression expr3 = new Expression("PI()");
            Assert.AreEqual(3.14M, expr3.SetScale(2).Eval<decimal>());

            Expression expr4 = new Expression("RADIANS(180.5)");
            Assert.AreEqual(3.1503m, expr4.SetScale(4).Eval<decimal>());

            Expression expr5 = new Expression("DEGREES(PI())");
            Assert.AreEqual(180m, expr5.Eval<decimal>());

            Expression expr6 = new Expression("INT(123.4)");
            Assert.AreEqual(123, expr6.Eval<int>());

        }

        [TestMethod]
        public void Math_RoundCeil_Test()
        {
            Expression expr1 = new Expression("CEILING(2.1)");
            Assert.AreEqual(3M, expr1.Eval<decimal>());

            expr1.SetFomular("CEILING(4.5, 1)");
            Assert.AreEqual(5M, expr1.Eval<decimal>());

            expr1.SetFomular("CEILING(-2.5, -2)");
            Assert.AreEqual(-4M, expr1.Eval<decimal>());

            expr1.SetFomular("CEILING(4.5, 1)");
            Assert.AreEqual(5M, expr1.Eval<decimal>());

            expr1.SetFomular("FLOOR(3.7)");
            Assert.AreEqual(3M, expr1.Eval<decimal>());

            expr1.SetFomular("FLOOR(3.7,2)");
            Assert.AreEqual(2M, expr1.Eval<decimal>());

            expr1.SetFomular("FLOOR(-2.5,-2)");
            Assert.AreEqual(-2M, expr1.Eval<decimal>());

            expr1.SetFomular("ROUND(20.085537,2)");
            Assert.AreEqual(20.09M, expr1.Eval<decimal>());

            /* expr1.SetFomular("ROUND(20126.08,-1)");
             Assert.AreEqual(20130M, expr1.Eval<decimal>());*/

            expr1.SetFomular("POWER(-2, 3)");
            Assert.AreEqual(-8M, expr1.Eval<decimal>());
        }

        [TestMethod]
        public void Math_Combination_Test()
        {
            var randomAngle = Math.PI / 6.03d;

            Expression expr1 = new Expression("MOD(EXP(5.4),1.3)*5/_a_*3^PI()");
            Assert.AreEqual(21.366845M, expr1.Bind("_a_", 3).Eval<decimal>());

            expr1.SetFomular("3^PI()^0.1");
            Assert.AreEqual(3.42758M, expr1.Eval<decimal>());

            expr1.SetFomular("sin(x)^2+cos(x)^2");
            Assert.AreEqual(1M, expr1.Bind("x", 0.1).Eval<decimal>());

            expr1.SetFomular("1+cot(x)^2=1/sin(x)^2");
            Assert.AreEqual(true, expr1.Bind("x", randomAngle).Eval<bool>());

            expr1.SetFomular("1+cot(x)^2=1/sin(x)^2");
            Assert.AreEqual(true, expr1.Bind("x", randomAngle).Eval<bool>());

            expr1.SetFomular("sin(y)^6+cos(y)^6 = (sin(y)^2+cos(y)^2)*(sin(y)^4-sin(y)^2*cos(y)^2+cos(y)^4)");
            Assert.AreEqual(true, expr1.Bind("y", randomAngle).Eval<bool>());

            expr1.SetFomular("tan(a)^3-((3*sin(a)-sin(3*a))/(3*cos(a)+cos(3*a)))");
            Assert.AreEqual(0, expr1.Bind("a", Math.PI / 6).Eval<decimal>());

            expr1.SetFomular("tan(a)^3-((3*sin(a)-sin(3*a))/(3*cos(a)+cos(3*a)))");
            Assert.AreEqual(0, expr1.Bind("a", randomAngle).Eval<decimal>());

            expr1.SetFomular("if(tan(a)^3-((3*sin(a)-sin(3*a))/(3*cos(a)+cos(3*a)))==0,if(sin(a) - cos(a) = SQRT(2) * sin(a - pi / 4),true,false),false)");
            Assert.AreEqual(true, expr1.Bind("a", randomAngle).Eval<bool>());

            expr1.SetFomular("sin(a) - cos(a) = SQRT(2) * sin(a - pi / 4)");
            Assert.AreEqual(true, expr1.Bind("a", randomAngle).Eval<bool>());

            expr1.SetFomular("(a>b)||(PI()<(d-e+power(f,2)))&&(4+6>8)");
            expr1.Bind("a", 3).Bind("b", 2).Bind("d", 21.45m).Bind("e", 0.2).Bind("f", 0.1);
            Assert.AreEqual(true, expr1.Eval<bool>());

            expr1.SetFomular("(3.4 + -4.1) / 2");
            Assert.AreEqual(-0.35m, expr1.Eval<decimal>());

            expr1.SetFomular("SQRT(a^2 + b^2)");
            expr1.Bind("a", 2.4).Bind("b", 9.253);
            Assert.AreEqual(9.559185m, expr1.Eval<decimal>());

        }

        [TestMethod]
        public void Math_E_Notation_Test()
        {

            Expression expr1 = new Expression("2e+3-1");
            Assert.AreEqual(1999m, expr1.Eval<decimal>());

            Expression expr2 = new Expression("-2e-3-1");
            Assert.AreEqual(-1.002m, expr2.Eval<decimal>());

            Expression expr3 = new Expression("2e+3-2e-3");
            Assert.AreEqual(1999.998m, expr3.Eval<decimal>());
        }


        [TestMethod]
        public void Text_Concat_Test()
        {

            Expression expr1 = new Expression("\"hello\"+\"word\"");
            Assert.AreEqual("helloword", expr1.Eval<string>());

            Expression expr2 = new Expression("\"hello\"+1.5");
            Assert.AreEqual("hello1.5", expr2.Eval<string>());

            Expression expr3 = new Expression("\"hello\"+1.5");
            Assert.AreEqual("hello1.5", expr3.Eval<string>());

            Expression expr4 = new Expression("pi+\"hello\"");
            Assert.AreEqual("3.141593hello", expr4.Eval<string>());

            Expression expr5 = new Expression("\"hello\"&\"word\"");
            Assert.AreEqual("helloword", expr5.Eval<string>());

            Expression expr6 = new Expression("\"hel\"\"lo\"&123");
            Assert.AreEqual("hel\"lo123", expr6.Eval<string>());
        }


        [TestMethod]
        public void Text_Operator_Ge_Test()
        {
            Expression expr1 = new Expression("a >= \"abc\"");
            Assert.AreEqual(true, expr1.Bind("a", "abc").Eval<bool>());

            Expression expr2 = new Expression("a >= \"axyz\"");
            Assert.AreEqual(true, expr2.Bind("a", "bxyz").Eval<bool>());

            Expression expr3 = new Expression("a >= \"axyz\"");
            Assert.AreEqual(false, expr3.Bind("a", null).Eval<bool>());
        }

        [TestMethod]
        public void Text_Operator_Gt_Test()
        {
            Expression expr1 = new Expression("a > \"abc\"");
            Assert.AreEqual(false, expr1.Bind("a", "abc").Eval<bool>());

            Expression expr2 = new Expression("a > \"axyz\"");
            Assert.AreEqual(true, expr2.Bind("a", "baaa").Eval<bool>());

            Expression expr3 = new Expression("a > \"axyz\"");
            Assert.AreEqual(false, expr3.Bind("a", null).Eval<bool>());

        }

        [TestMethod]
        public void Text_Operator_Le_Test()
        {
            Expression expr1 = new Expression("a <= \"abc\"");
            Assert.AreEqual(true, expr1.Bind("a", "abc").Eval<bool>());

            Expression expr2 = new Expression("a <= \"bxyz\"");
            Assert.AreEqual(true, expr2.Bind("a", "a123").Eval<bool>());

            Expression expr3 = new Expression("a <= \"bxyz\"");
            Assert.AreEqual(false, expr3.Bind("a", "c").Eval<bool>());

            Expression expr4 = new Expression("a <= \"bxyz\" || b <= \"bxyz\"");
            Assert.AreEqual(true, expr4.Bind("a", "a123").Bind("b", "c").Eval<bool>());

            Expression expr5 = new Expression("a <= \"bxyz\" && b <= \"bxyz\"");
            Assert.AreEqual(false, expr5.Bind("a", "a123").Bind("b", "c").Eval<bool>());

            Expression expr6 = new Expression("a <= \"bxyz\" && b <= \"bxyz\" || 6 > 4");
            Assert.AreEqual(true, expr6.Bind("a", "d").Bind("b", "c").Eval<bool>());

            Expression expr7 = new Expression("a <= \"bxyz\" && (b <= \"bxyz\" || 6 > 4)");
            Assert.AreEqual(false, expr7.Bind("a", "dd").Bind("b", "c").Eval<bool>());
        }

        [TestMethod]
        public void Text_Operator_Lt_Test()
        {
            Expression expr1 = new Expression("a < \"abc\"");
            Assert.AreEqual(false, expr1.Bind("a", "abc").Eval<bool>());

            Expression expr2 = new Expression("a < \"bxyz\"");
            Assert.AreEqual(true, expr2.Bind("a", "a123").Eval<bool>());

            Expression expr3 = new Expression("a < \"bxyz\"");
            Assert.AreEqual(false, expr3.Bind("a", null).Eval<bool>());

            Expression expr4 = new Expression("a < b");
            Assert.AreEqual(false, expr4.Bind("b", null).Bind("a", null).Eval<bool>());
        }

        [TestMethod]
        public void Text_Operator_eq_Test()
        {
            Expression expr1 = new Expression("a == \"abc\"");
            Assert.AreEqual(true, expr1.Bind("a", "abc").Eval<bool>());

            Expression expr2 = new Expression("a == \"bxyz\"");
            Assert.AreEqual(false, expr2.Bind("a", "a123").Eval<bool>());

            Expression expr2b = new Expression("a == b");
            Assert.AreEqual(true, expr2b.Bind("b", "").Bind("a", "").Eval<bool>());

            Expression expr2c = new Expression("a == b");
            Assert.AreEqual(false, expr2c.Bind("b", "abc").Bind("a", "aBc").Eval<bool>());

            Expression expr3 = new Expression("a == \"bxyz\"");
            Assert.AreEqual(false, expr3.Bind("a", null).Eval<bool>());

            Expression expr4 = new Expression("a == b");
            Assert.AreEqual(true, expr4.Bind("b", null).Bind("a", null).Eval<bool>());
        }

        [TestMethod]
        public void Text_Operator_neq_Test()
        {
            Expression expr1 = new Expression("a <> \"abc\"");
            Assert.AreEqual(false, expr1.Bind("a", "abc").Eval<bool>());

            Expression expr2 = new Expression("a <> \"bxyz\"");
            Assert.AreEqual(true, expr2.Bind("a", "a123").Eval<bool>());

            Expression expr2b = new Expression("a <> b");
            Assert.AreEqual(false, expr2b.Bind("b", "").Bind("a", "").Eval<bool>());

            Expression expr2c = new Expression("a <> b");
            Assert.AreEqual(true, expr2c.Bind("b", "abc").Bind("a", "aBc").Eval<bool>());

            Expression expr3 = new Expression("a <> \"bxyz\"");
            Assert.AreEqual(true, expr3.Bind("a", null).Eval<bool>());

            Expression expr4 = new Expression("a <> b");
            Assert.AreEqual(false, expr4.Bind("b", null).Bind("a", null).Eval<bool>());
        }

        [TestMethod]
        public void Text_Function_left_right_Test()
        {
            Expression expr1 = new Expression("left(\"helloword\",2)");
            Assert.AreEqual("he", expr1.Eval<string>());

            expr1.SetFomular("left(a,20)");
            Assert.AreEqual("helloword", expr1.Bind("a", "helloword").Eval<string>());

            expr1.SetFomular("right(\"helloword\",2)");
            Assert.AreEqual("rd", expr1.Eval<string>());

            expr1.SetFomular("right(\"helloword\",20)");
            Assert.AreEqual("helloword", expr1.Eval<string>());

            expr1.SetFomular("right(\"helloword\",9)");
            Assert.AreEqual("helloword", expr1.Eval<string>());

            expr1.SetFomular("right(\"hello\nword\",9)");
            Assert.AreEqual("ello\nword", expr1.Eval<string>());

        }

        [TestMethod]
        public void Text_Function_Mid_Test()
        {
            Expression expr1 = new Expression("MID(\"abcd\",1,2)");
            Assert.AreEqual("ab", expr1.Eval<string>());

            expr1.SetFomular("MID(\"abcd\",2,1)");
            Assert.AreEqual("b", expr1.Eval<string>());

            expr1.SetFomular("MID(\"abcd\",1,20)");
            Assert.AreEqual("abcd", expr1.Eval<string>());

            expr1.SetFomular("MID(\"abcd\",-1,20)");
            Assert.AreEqual("", expr1.Eval<string>());

            expr1.SetFomular("MID(\"abcd\",10,20)");
            Assert.AreEqual("", expr1.Eval<string>());

            expr1.SetFomular("MID(\"abcd\",0,20)");
            Assert.AreEqual("", expr1.Eval<string>());

            expr1.SetFomular("MID(\"abcd\",4,20)");
            Assert.AreEqual("d", expr1.Eval<string>());

            expr1.SetFomular("MID(\"zofH4xQcr2KGLrh0Sg9LkMQj0fJLJGgHErVeS1Q1hdoj\nJuI6c9ANVb\nnbF9jIkrsDiV34M32XkobJ2XPubJeJgLueRA2u73fgYPrxLEiO3v2sb98NK9vgWVw6e6OYSuowaWMCSbQGYemqaieWP724mQYW7jTu2sLO\",100,200)");
            Assert.AreEqual("PrxLEiO3v2sb98NK9vgWVw6e6OYSuowaWMCSbQGYemqaieWP724mQYW7jTu2sLO", expr1.Eval<string>());

            expr1.SetFomular("LPAD(\"1\",10,\"0\")");
            Assert.AreEqual("0000000001", expr1.Eval<string>());

            expr1.SetFomular("RPAD(\"1\",10,\"0\")");
            Assert.AreEqual("1000000000", expr1.Eval<string>());

            expr1.SetFomular("RPAD(\"1\",10,\"\")");
            Assert.AreEqual("1", expr1.Eval<string>());

            expr1.SetFomular("RPAD(\"\",10,\"0\")");
            Assert.AreEqual("0000000000", expr1.Eval<string>());

        }

        [TestMethod]
        public void Text_Function_Reverse_Test()
        {
            Expression expr1 = new Expression("reverse(\"abcd\")");
            Assert.AreEqual("dcba", expr1.Eval<string>());

            expr1.SetFomular("left(reverse(\"abcd\"),2)");
            Assert.AreEqual("dc", expr1.Eval<string>());

            expr1.SetFomular("reverse(\"01%663854137#90644.7;973030 4637515397360822@9\")");
            Assert.AreEqual("9@2280637935157364 030379;7.44609#731458366%10", expr1.Eval<string>());

            expr1.SetFomular("left(reverse(\"abcd\"),2)==\"dc\"");
            Assert.AreEqual(true, expr1.Eval<bool>());
        }

        [TestMethod]
        public void Text_Function_IsNumber_Test()
        {
            Expression expr1 = new Expression("ISNUMBER(\"0.23\")");
            Assert.AreEqual(true, expr1.Eval<bool>());

            expr1.SetFomular("ISNUMBER(\"0.2a3\")");
            Assert.AreEqual(false, expr1.Eval<bool>());

            expr1.SetFomular("IF(ISNUMBER(\"0.2a3\")==FALSE,TRUE,false)");
            Assert.AreEqual(true, expr1.Eval<bool>());

            expr1.SetFomular("ISNUMBER(\"\")");
            Assert.AreEqual(false, expr1.Eval<bool>());

            expr1.SetFomular("ISNUMBER(null)");
            Assert.AreEqual(false, expr1.Eval<bool>());

        }

        [TestMethod]
        public void Text_Function_LowerUpper_Test()
        {
            Expression expr1 = new Expression("LOWER(\"aBc\")");
            Assert.AreEqual("abc", expr1.Eval<string>());

            expr1.SetFomular("UPPER(\"aBc\")");
            Assert.AreEqual("ABC", expr1.Eval<string>());

            expr1.SetFomular("UPPER(\"neW york\")");
            Assert.AreEqual("NEW YORK", expr1.Eval<string>());
        }

        [TestMethod]
        public void Text_Function_Proper_Test()
        {
            Expression expr1 = new Expression("PROPER(\"capitalize the first\")");
            Assert.AreEqual("Capitalize The First", expr1.Eval<string>());

            Expression expr2 = new Expression("PROPER(\"capitalize th\ne first\")");
            Assert.AreEqual("Capitalize Th\ne First", expr2.Eval<string>());

            Expression expr3 = new Expression("PROPER(\"\")");
            Assert.AreEqual("", expr3.Eval<string>());

            Expression expr4 = new Expression("PROPER(null)");
            Assert.AreEqual("", expr4.Eval<string>());
        }

        [TestMethod]
        public void Text_Function_Trim_Rept_Test()
        {
            Expression expr1 = new Expression("TRIM(\" abc \")");
            Assert.AreEqual("abc", expr1.Eval<string>());

            Expression expr2 = new Expression("TRIM(\" a\nb c \")");
            Assert.AreEqual("a\nb c", expr2.Eval<string>());

            Expression expr3 = new Expression("TRIM(\"\")");
            Assert.AreEqual("", expr3.Eval<string>());

            Expression expr4 = new Expression("if(TRIM(null)==\"\",true,false)");
            Assert.AreEqual(true, expr4.Eval<bool>());

            Expression expr5 = new Expression("REPT(\"x\",5)");
            Assert.AreEqual("xxxxx", expr5.Eval<string>());

            Expression expr6 = new Expression("REPT(\"\",5)");
            Assert.AreEqual("", expr6.Eval<string>());

            Expression expr7 = new Expression("REPT(a,5)");
            Assert.AreEqual("", expr7.Bind("a", null).Eval<string>());
        }

        [TestMethod]
        public void Text_Function_Len_Test()
        {
            Expression expr1 = new Expression("len(\"abcd\")");
            Assert.AreEqual(4, expr1.Eval<int>());

            Expression expr2 = new Expression("len(\"\")");
            Assert.AreEqual(0, expr2.Eval<int>());

            Expression expr3 = new Expression("len(\" \")");
            Assert.AreEqual(1, expr3.Eval<int>());

            Expression expr4 = new Expression("len(\"\r2\n\")");
            Assert.AreEqual(3, expr4.Eval<int>());

            Expression expr5 = new Expression("If(len(a)>0,\"passed with score:\"&a,\"fail\")");
            Assert.AreEqual("passed with score:50", expr5.Bind("a", "50").Eval<string>());

            Expression expr6 = new Expression("len(null)");
            Assert.AreEqual(0, expr6.Eval<int>());
        }

        [TestMethod]
        public void Text_Function_Text_Test()
        {
            Expression expr1 = new Expression();
            expr1.SetFomular("TEXT(0.1,\"h\")");
            Assert.AreEqual("2", expr1.Eval<string>());

            expr1.SetFomular("TEXT(2.61,\"[hh]\")");
            Assert.AreEqual("62", expr1.Eval<string>());

            expr1.SetFomular("TEXT(2.61,\"hh-mm-ss\")");
            Assert.AreEqual("14-38-24", expr1.Eval<string>());

            expr1.SetFomular("TEXT(123.005)");
            Assert.AreEqual("123.005", expr1.Eval<string>());

            expr1.SetFomular("TEXT(1234.567,\"$#,##0.00\")");
            Assert.AreEqual("$1,234.57", expr1.Eval<string>());

            expr1.SetFomular("TEXT(0.285,\"0.0%\")");
            Assert.AreEqual("28.5%", expr1.Eval<string>());

            expr1.SetFomular("TEXT(122*100000,\"0.00E+00\")");
            Assert.AreEqual("1.22E+07", expr1.Eval<string>());

            expr1.SetFomular("TEXT(122*100000,\"uyfeg\")");
            Assert.AreEqual("uyfeg", expr1.Eval<string>());
        }

        [TestMethod]
        public void Text_Function_Ascii_Test()
        {
            Expression expr1 = new Expression("CHAR(97)");
            Assert.AreEqual("a", expr1.Eval<string>());

            expr1.SetFomular("CODE(\"a\")");
            Assert.AreEqual(97, expr1.Eval<int>());

            expr1.SetFomular("CODE(\"\t\")");
            Assert.AreEqual(9, expr1.Eval<int>());

            expr1.SetFomular("CHAR(0)");
            Assert.AreEqual("\0", expr1.Eval<string>());
        }

        [TestMethod]
        public void Text_Function_Replace_Test()
        {
            Expression expr1 = new Expression("REPLACE(\"ABC123\",4,3,\"456\")");
            Assert.AreEqual("ABC456", expr1.Eval<string>());

            expr1.SetFomular("REPLACE(\"123-455-3321\",\"-\",\"\")");
            Assert.AreEqual("1234553321", expr1.Eval<string>());

            expr1.SetFomular("REPLACE(\"123-455-3321\",\"-\",\"@\")");
            Assert.AreEqual("123@455@3321", expr1.Eval<string>());

            expr1.SetFomular("SUBSTITUTE(\"123-455-3321\",\"-\",\"\")");
            Assert.AreEqual("1234553321", expr1.Eval<string>());

        }

        [TestMethod]
        public void Text_Function_Find_Test()
        {
            Expression expr1 = new Expression("FIND(\"ab\",\"ABCDabcABCabc\",6)");
            Assert.AreEqual(11, expr1.Eval<int>());

            expr1.SetFomular("FIND(\"a\",\"ABCDabcABCabc\")");
            Assert.AreEqual(5, expr1.Eval<int>());

            expr1.SetFomular("FIND(\"\",\"ABCDabcABCabc\")");
            Assert.AreEqual(1, expr1.Eval<int>());

            expr1.SetFomular("FIND(\"\",\"\")");
            Assert.AreEqual(1, expr1.Eval<int>());

            expr1.SetFomular("SEARCH(\"A\",\"ABC\")");
            Assert.AreEqual(1, expr1.Eval<int>());

            expr1.SetFomular("SEARCH(\"A\",\"AEHABC\",4)");
            Assert.AreEqual(4, expr1.Eval<int>());

            expr1.SetFomular("SEARCH(\"A\n\",\"AEHA\nBC\")");
            Assert.AreEqual(4, expr1.Eval<int>());

            expr1.SetFomular("SEARCH(\"Ax\",\"AEHABC\",4)");
            Assert.AreEqual(-1, expr1.Eval<int>());

            expr1.SetFomular("SEARCH(\"\",\"\",4)");
            Assert.AreEqual(-1, expr1.Eval<int>());

            expr1.SetFomular("SEARCH(\"\",\"\")");
            Assert.AreEqual(1, expr1.Eval<int>());

            expr1.SetFomular("SEARCH(\"Sample\",\"this is a sample string. Just a sample\")");
            Assert.AreEqual(11, expr1.Eval<int>());

            expr1.SetFomular("FIND(\"Sample\",\"this is a sample string. Just a sample\")");
            Assert.AreEqual(-1, expr1.Eval<int>());

            expr1.SetFomular("IF(SEARCH(\"A\",\"AEHABC\",4)>1,CONCAT(LEFT(name,2),\"WORD\"),\"N/A\")");
            Assert.AreEqual("HEWORD", expr1.Bind("name", "HELLO").Eval<string>());

            expr1.SetFomular("IF(SEARCH(\"A\",\"AEHABC\",4)>100,CONCAT(LEFT(name,2),\"WORD\"),\"N/A\")");
            Assert.AreEqual("N/A", expr1.Bind("name", "HELLO").Eval<string>());
        }

        [TestMethod]
        public void Text_Function_Concat_Test()
        {
            Expression expr1 = new Expression("CONCAT(\"ab\",\"ABCDabcABCabc\")");
            Assert.AreEqual("abABCDabcABCabc", expr1.Eval<string>());

            expr1.SetFomular("CONCAT(\"\",\"ABCDabc\nAB;C\"\"abc\")");
            Assert.AreEqual("ABCDabc\nAB;C\"abc", expr1.Eval<string>());

            expr1.SetFomular("CONCAT(null,\"ABCDabc\nAB;C\"\"abc\")");
            Assert.AreEqual("ABCDabc\nAB;C\"abc", expr1.Eval<string>());

            expr1.SetFomular("CONCAT(null,null)");
            Assert.AreEqual("", expr1.Eval<string>());
        }

        [TestMethod]
        public void Text_Function_Isblank_Test()
        {
            Expression expr1 = new Expression("ISBLANK(\"ab\")");
            Assert.AreEqual(false, expr1.Eval<bool>());

            expr1.SetFomular("ISBLANK(\"\")");
            Assert.AreEqual(true, expr1.Eval<bool>());

            expr1.SetFomular("ISBLANK(null)");
            Assert.AreEqual(true, expr1.Eval<bool>());

            expr1.SetFomular("ISBLANK(\"\n\")");
            Assert.AreEqual(false, expr1.Eval<bool>());
        }

        [TestMethod]
        public void Literals_Operation_Test()
        {
            var formular = "(((((4134+14.73*11.4000*100/90.5600+52.39*1.5200*100/90.5600+9.25*2.7200*100/90.5600-44.6*1.5700*100/90.5600+0.0000)*85.0082/100)*0.8357)*0.6638/1700)*(90.5600/100)*1.0000*0.9600+((1.88*0.8753-0.4028)*(90.5600-1.5700)/100)*0.0000+((1.88*0.8753-0.4028)*(90.5600-1.5700)/100)*0.0000+((1.39*0.8753-0.0375)*(90.5600-1.5700)/100)*0.0000+((1.39*0.8753-0.0375)*(90.5600-1.5700)/100)*0.0000)*1.0000";
            var expr = new Expression(formular).SetScale(4);
            Assert.AreEqual(1.0509M, expr.Eval<decimal>());

            var expr2 = new Expression(formular).SetScale(4).SetWorkingCulture(new CultureInfo("es-ES"));
            Assert.ThrowsException<OverflowException>(() => expr2.Eval<decimal>());
        }

        [TestMethod]
        public void Or_Operator_Test()
        {
            // false, false = false
            var expr = new Expression("OR (a>0, b>0)")
                .Bind("a", 0)
                .Bind("b", 0);
            Assert.AreEqual(false, expr.Eval<bool>());
            
            // false, true = true
            var expr2 = new Expression("OR (a>0, b>0)")
                .Bind("a", 0)
                .Bind("b", 1);
            Assert.AreEqual(true, expr2.Eval<bool>());
            
            // true, false = true
            var expr3 = new Expression("OR (a>0, b>0)")
                .Bind("a", 1)
                .Bind("b", 0);
            Assert.AreEqual(true, expr3.Eval<bool>());
            
            // true, true = true
            var expr4 = new Expression("OR (a>0, b>0)")
                .Bind("a", 1)
                .Bind("b", 1);
            Assert.AreEqual(true, expr4.Eval<bool>());
        }
    }
}
