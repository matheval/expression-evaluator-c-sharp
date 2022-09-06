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
PM> Install-Package org.matheval -Version 1.0.0.2
```
# Official document

[https://matheval.org/math-expression-eval-for-c-sharp/](https://matheval.org/math-expression-eval-for-c-sharp/)

# Supported operators, contants, functions

[https://matheval.org/math-expression-eval-for-c-sharp/#op-constants-funcs](https://matheval.org/math-expression-eval-for-c-sharp/#op-constants-funcs)

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
