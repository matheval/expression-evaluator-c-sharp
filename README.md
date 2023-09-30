# About MathEval
[![NuGet version (org.matheval)](https://img.shields.io/nuget/v/org.matheval.svg?style=flat-square)](https://www.nuget.org/packages/org.matheval/)

Matheval is a mathematical expressions evaluator library written in C#. Allows to evaluate mathematical, boolean, string and datetime expressions

Code is written in pure C#, run on the fly. We don't use any third party libraries or packages

If you get any bugs please let me know by creating a new issue.



**Many thanks to our contributors:**

[Thanhrin](https://github.com/ThanhRin) (from Da Nang, VietNam)

[Eduardo Salinas](https://github.com/butulia) (from Huesca, Spain)

# Installation

Using Package Manager

```bash
PM> Install-Package org.matheval -Version 1.0.0.3
```
# Official document

[https://matheval.org/math-expression-eval-for-c-sharp/](https://matheval.org/math-expression-eval-for-c-sharp/)

# Supported operators, contants, functions

## Supported Operators
<table>

<tbody>

<tr>

<th>Operator</th>

<th>Description</th>

</tr>

<tr>

<td>+</td>

<td>Additive operator / Unary plus / Concatenate string / Datetime addition</td>

</tr>

<tr>

<td>&</td>

<td>Concatenate string</td>

</tr>

<tr>

<td>–</td>

<td>Subtraction operator / Unary minus / Datetime subtraction</td>

</tr>

<tr>

<td>*</td>

<td>Multiplication operator, can be omitted in front of an open bracket</td>

</tr>

<tr>

<td>/</td>

<td>Division operator</td>

</tr>

<tr>

<td>%</td>

<td>Remainder operator (Modulo)</td>

</tr>

<tr>

<td>^</td>

<td>Power operator</td>

</tr>

</tbody>

</table>


## Supported conditional statements

<table>

<tbody>

<tr>

<th>Conditional statement</th>

<th>Description</th>

</tr>

<tr>

<td>IF(logical_condition, value_if_true, value_if_false)</td>

<td>Example:  
`IF(2>1,"Pass","Fail")`</td>

</tr>

<tr>

<td>SWITCH(expression, val1,result1, [val2,result2], …, [default])</td>

<td>Example:  
`SWITCH(3+2,5,"Apple",7,"Mango",3,"Good","N/A")`</td>

</tr>

</tbody>

</table>

## Supported logical and math functions

<table>

<tbody>

<tr>

<th>Function<sup>*</sup></th>

<th>Description</th>

</tr>

<tr>

<td>AND(logical1, [logical2], …)</td>

<td>Determine if all conditions are TRUE</td>

</tr>

<tr>

<td>OR(logical1, [logical2], …)</td>

<td>Determine if any conditions in a test are TRUE</td>

</tr>

<tr>

<td>NOT(_logical_)</td>

<td>To confirm one value is not equal to another</td>

</tr>

<tr>

<td>XOR(logical1, [logical2], …)</td>

<td>Exclusive OR function</td>

</tr>

<tr>

<td>SUM(number1, [number2],…)</td>

<td>Return sum of numbers supplied</td>

</tr>

<tr>

<td>AVERAGE(number1, [number2],…)</td>

<td>Return average of numbers supplied</td>

</tr>

<tr>

<td>MIN(number1, [number2],…)</td>

<td>Return the smallest value from the numbers supplied</td>

</tr>

<tr>

<td>MAX(number1, [number2],…)</td>

<td>Return the biggest value from the numbers supplied</td>

</tr>

<tr>

<td>MOD(number, divisor)</td>

<td>Get remainder of two given numbers after division operator.</td>

</tr>

<tr>

<td>ROUND(number, num_digits)</td>

<td>Returns the rounded approximation of given number using half-even rounding mode  
( you can change to another rounding mode)</td>

</tr>

<tr>

<td>FLOOR(number, significance)</td>

<td>Rounds a given number towards zero to the nearest multiple of a specified significance</td>

</tr>

<tr>

<td>`CEILING`(number, significance)</td>

<td>Rounds a given number away from zero, to the nearest multiple of a given number</td>

</tr>

<tr>

<td>POWER(number, power)</td>

<td>Returns the result of a number raised to a given power</td>

</tr>

<tr>

<td>RAND()</td>

<td>Produces a random number between 0 and 1</td>

</tr>

<tr>

<td>SIN(number)</td>

<td>Returns the trigonometric sine of the angle given in radians</td>

</tr>

<tr>

<td>SINH(number)</td>

<td>Returns the hyperbolic sine of a number</td>

</tr>

<tr>

<td>ASIN(number)</td>

<td>Returns the arc sine of an angle, in the range of -pi/2 through pi/2</td>

</tr>

<tr>

<td>COS(number)</td>

<td>Returns the trigonometric cos of the angle given in radians</td>

</tr>

<tr>

<td>COSH(number)</td>

<td>Returns the hyperbolic cos of a number</td>

</tr>

<tr>

<td>ACOS(number)</td>

<td>Returns the arc cosine of an angle, in the range of 0.0 through pi</td>

</tr>

<tr>

<td>TAN(number)</td>

<td>Returns the tangent of the angle given in radians</td>

</tr>

<tr>

<td>TANH(number)</td>

<td>Returns the hyperbolic tangent of a number</td>

</tr>

<tr>

<td>ATAN(number)</td>

<td>Returns the arc tangent of an angle given in radians</td>

</tr>

<tr>

<td>ATAN2(x_number, y_number)</td>

<td>Returns the arctangent from x- and y-coordinates</td>

</tr>

<tr>

<td>COT(number)</td>

<td>Returns the cotangent of an angle given in radians.</td>

</tr>

<tr>

<td>COTH(number)</td>

<td>Returns the hyperbolic cotangent of a number</td>

</tr>

<tr>

<td>SQRT(number)</td>

<td>Returns the correctly rounded positive square root of given number</td>

</tr>

<tr>

<td>LN(number)</td>

<td>Returns the natural logarithm (base _e_) of given number</td>

</tr>

<tr>

<td>LOG10(number)</td>

<td>Returns the logarithm (base 10) of given number</td>

</tr>

<tr>

<td>EXP(number)</td>

<td>Returns e raised to the power of given number</td>

</tr>

<tr>

<td>ABS(number)</td>

<td>Returns the absolute value of given number</td>

</tr>

<tr>

<td>FACT(number)</td>

<td>Returns the factorial of a given number</td>

</tr>

<tr>

<td>SEC(number)</td>

<td>Returns the secant of an angle given in radians</td>

</tr>

<tr>

<td>CSC(number)</td>

<td>Returns the cosecant of an angle given in radians</td>

</tr>

<tr>

<td>PI()</td>

<td>Return value of Pi</td>

</tr>

<tr>

<td>RADIANS(degrees)</td>

<td>Convert degrees to radians</td>

</tr>

<tr>

<td>DEGREES(radians)</td>

<td>Convert radians to degrees</td>

</tr>

<tr>

<td>INT(number)</td>

<td>Returns the Integer value of given number</td>

</tr>

</tbody>

</table>

## Supported Constants

<table>

<tbody>

<tr>

<th>Constant</th>

<th>Description</th>

</tr>

<tr>

<td>e</td>

<td>The value of _e_</td>

</tr>

<tr>

<td>PI</td>

<td>The value of _PI_</td>

</tr>

<tr>

<td>TRUE</td>

<td>The boolean true value</td>

</tr>

<tr>

<td>FALSE</td>

<td>The boolean false value</td>

</tr>

<tr>

<td>NULL</td>

<td>The null value</td>

</tr>

</tbody>

</table>

## Supported text functions

<table>

<tbody>

<tr>

<th>Function</th>

<th>Description</th>

</tr>

<tr>

<td>LEFT(text, num_chars)</td>

<td>Extracts a given number of characters from the left side of a supplied text string</td>

</tr>

<tr>

<td>RIGHT(text, num_chars)</td>

<td>Extracts a given number of characters from the right side of a supplied text string</td>

</tr>

<tr>

<td>MID(text, start_num, num_chars)</td>

<td>Extracts a given number of characters from the middle of a supplied text string</td>

</tr>

<tr>

<td>REVERSE(text)</td>

<td>Reverse a string</td>

</tr>

<tr>

<td>ISNUMBER(text)</td>

<td>Check if a value is a number</td>

</tr>

<tr>

<td>LOWER(text)</td>

<td>Converts all letters in the specified string to lowercase</td>

</tr>

<tr>

<td>UPPER(text)</td>

<td>Converts all letters in the specified string to uppercase</td>

</tr>

<tr>

<td>PROPER(text)</td>

<td>Capitalizes words given text string</td>

</tr>

<tr>

<td>TRIM(text)</td>

<td>Removes extra spaces from text</td>

</tr>

<tr>

<td>LEN(text)</td>

<td>Returns the length of a string/ text</td>

</tr>

<tr>

<td>TEXT(value, [format_text])</td>

<td>Convert a numeric value into a text string. You can use the TEXT function to embed formatted numbers inside text  
Example:  
`

<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-n1">123</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">123</span></span></div>

`TEXT(123) -> 123`  

<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-m0">DATEVALUE</span><span class="enlighter-g1">(</span><span class="enlighter-s0">"2021-01-23"</span><span class="enlighter-g1">)</span><span class="enlighter-text">,</span><span class="enlighter-s0">"dd-MM-yyyy"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">23</span><span class="enlighter-text">-</span><span class="enlighter-n4">01</span><span class="enlighter-text">-</span><span class="enlighter-n1">2021</span></span></div>

`TEXT(DATEVALUE("2021-01-23"),"dd-MM-yyyy") -> 23-01-2021`  

<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-n0">2.61</span><span class="enlighter-text">,</span><span class="enlighter-s0">"hh:mm"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">14</span><span class="enlighter-text">:</span><span class="enlighter-n1">38</span></span></div>

`TEXT(2.61,"hh:mm") -> 14:38`  

<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-n0">2.61</span><span class="enlighter-text">,</span><span class="enlighter-s0">"[hh]"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">62</span></span></div>

`TEXT(2.61,"[hh]") -> 62`  

<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-n0">2.61</span><span class="enlighter-text">,</span><span class="enlighter-s0">"hh-mm-ss"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">14</span><span class="enlighter-text">-</span><span class="enlighter-n1">38</span><span class="enlighter-text">-</span><span class="enlighter-n1">24</span></span></div>

`TEXT(2.61,"hh-mm-ss") -> 14-38-24`  

<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-m0">DATEVALUE</span><span class="enlighter-g1">(</span><span class="enlighter-s0">"2021-01-03"</span><span class="enlighter-g1">)</span><span class="enlighter-text">-</span><span class="enlighter-m0">DATEVALUE</span><span class="enlighter-g1">(</span><span class="enlighter-s0">"2021-01-01"</span><span class="enlighter-g1">)</span><span class="enlighter-text">,</span><span class="enlighter-s0">"[h]"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-n1">48</span></span></div>

`TEXT(DATEVALUE("2021-01-03")-DATEVALUE("2021-01-01"),"[h]") -> 48`  

<div class="enlighter-default enlighter-v-inline enlighter-t-enlighter "><span class="enlighter"><span class="enlighter-m0">TEXT</span><span class="enlighter-g1">(</span><span class="enlighter-m0">TIME</span><span class="enlighter-g1">(</span><span class="enlighter-n1">12</span><span class="enlighter-text">,</span><span class="enlighter-n4">00</span><span class="enlighter-text">,</span><span class="enlighter-n4">00</span><span class="enlighter-g1">)</span><span class="enlighter-text">-</span><span class="enlighter-m0">TIME</span><span class="enlighter-g1">(</span><span class="enlighter-n1">10</span><span class="enlighter-text">,</span><span class="enlighter-n1">30</span><span class="enlighter-text">,</span><span class="enlighter-n1">10</span><span class="enlighter-g1">)</span><span class="enlighter-text">,</span><span class="enlighter-s0">"hh hours and mm minutes and ss seconds"</span><span class="enlighter-g1">)</span> <span class="enlighter-text">-</span><span class="enlighter-g1">></span> <span class="enlighter-text"></span> <span class="enlighter-s0">"01 hours and 29 minutes and 50 seconds"</span></span></div>

`TEXT(TIME(12,00,00)-TIME(10,30,10),"hh hours and mm minutes and ss seconds") -> "01 hours and 29 minutes and 50 seconds"``</td>

</tr>

<tr>

<td>REPLACE(old_text, start_num, num_chars, new_text)</td>

<td>Replaces characters specified by location in a given text string with another text string</td>

</tr>

<tr>

<td>SUBSTITUTE(text, old_text, new_text)</td>

<td>Replaces a set of characters with another</td>

</tr>

<tr>

<td>FIND(find_text, within_text, [start_num])</td>

<td>Returns the location of a substring in a string (case sensitive)</td>

</tr>

<tr>

<td>SEARCH(find_text, within_text, [start_num])</td>

<td>Returns the location of a substring in a string (case insensitive)</td>

</tr>

<tr>

<td>CONCAT(text1, text2, text3,…)</td>

<td>Combines the text from multiple strings</td>

</tr>

<tr>

<td>ISBLANK(text)</td>

<td>Returns TRUE when a given string is null or empty, otherwise return FALSE</td>

</tr>

<tr>

<td>REPT(text, repeat_time)</td>

<td>Repeats characters a given number of times</td>

</tr>

<tr>

<td>CHAR(char_code)</td>

<td>Return character from ascii code</td>

</tr>

<tr>

<td>CODE(char)</td>

<td>Returns a ascii code of a character</td>

</tr>

<tr>

<td>VALUE(text)</td>

<td>Convert numbers stored as text to numbers</td>

</tr>

</tbody>

</table>

# Usage examples

## Basic evaluator
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expression = new Expression("(a + b) / 2 ");
		expression.Bind("a", 3);
		expression.Bind("b",5);
		Object value = expression.Eval();
		Console.WriteLine("Result: "+value); //Result: 4
		
	}
}
```

## Conditional statements

```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expression = new Expression("IF(time>8, (HOUR_SALARY*8) + (HOUR_SALARY*1.25*(time-8)), HOUR_SALARY*time)");
		//bind variable
		expression.Bind("HOUR_SALARY", 10);
		expression.Bind("time", 9);
		//eval
		Decimal salary = expression.Eval<Decimal>();	
		Console.WriteLine(salary); //return 92.5
	}
}
```

## Validate expression
```cs
Expression expression = new Expression("SUM(1,2,3) + true");
List<String> errors = expression.GetError(); 
if(errors.Count > 0)
{
  foreach(String error in errors)
  {
  	Console.WriteLine(error);
  }
}	
```

## Min, max, sum, avg
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expr = new Expression("MIN(2,3,16)");
		int min = expr.Eval<int>(); 
		Console.WriteLine(min);// return 2 (min)
		
		expr.SetFomular("Max(2,3,16)");
		int max = expr.Eval<int>(); 
		Console.WriteLine(max);// return 16 (max)
		
		expr.SetFomular("Sum(2,3,16)");
		decimal sum = expr.Eval<decimal>(); 
		Console.WriteLine(sum);// return 21	(sum)
		
		expr.SetFomular("average(2,3,16)");
		decimal average = expr.Eval<decimal>(); 
		Console.WriteLine(average);// return 7 (average)	
	}
}
```
## Round, floor, ceiling
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expr = new Expression("ROUND(2.149, 1)");
		Object value = expr.Eval<Decimal>(); 
		Console.WriteLine("ROUND(2.149, 1) = "+value); //return 2.1
		
		expr = new Expression("FLOOR(2.149)");
		value = expr.Eval(); 
		Console.WriteLine("FLOOR(2.149) = "+value); //return 2	
		
		expr = new Expression("FLOOR(3.7,2)");
		value = expr.Eval(); 
		Console.WriteLine("FLOOR(3.7,2) = "+value);	//return 2
		
		expr = new Expression("CEILING(2.149)");
		value = expr.Eval(); 
		Console.WriteLine("CEILING(2.149) = "+value); //return 3
		
		expr = new Expression("CEILING(1.5, 0.1)");
		value = expr.Eval(); 
		Console.WriteLine("CEILING(1.5, 0.1) = "+value); //return 1.5	
	}
}
```
## Trigonometry
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expr = new Expression("tan(a)^3-((3*sin(a)-sin(3*a))/(3*cos(a)+cos(3*a)))");
		Decimal value = expr.Bind("a", Math.PI/6).Eval<Decimal>(); 
		Console.WriteLine(value); //return 0		
	}
}
```

## Deal with string
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression taxExpr = new Expression("IF(LOWER(TAX_CODE)='vat',amount*10/100,IF(LOWER(TAX_CODE)='gst',amount*15/100,0))");
		taxExpr.Bind("TAX_CODE","GST");
		taxExpr.Bind("amount", 5005m);
		Decimal value = taxExpr.Eval<Decimal>();
		Console.WriteLine(value);
	}
}
```
## Concatenate strings
```cs
using System;
using org.matheval;
					
public class Program
{
	public static void Main()
	{
		Expression expr = new Expression("CONCAT('The United States of ', 'America')");
		String value = expr.Eval<String>();	
		Console.WriteLine(value);//The United States of America	
	}
}
```

## License
MIT license
