# About MathEval
[![NuGet version (org.matheval)](https://img.shields.io/nuget/v/org.matheval.svg?style=flat-square)](https://www.nuget.org/packages/org.matheval/)
Matheval is a mathematical expressions evaluator library written in C#. Allows to evaluate mathematical, boolean, string and datetime expressions

Code is written in pure C#, run on the fly. We don't use any third party libaries or pakages

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
Expression expression = new Expression("(a + b) / 2 ");
expression.Bind("a", 3);
expression.Bind("b",5);
Object value = expression.Eval(); // will return 4
```

## Conditional statements

```cs
Expression expression = new Expression("IF(time>8, (HOUR_SALARY*8) + (HOUR_SALARY*1.25*(time-8)), HOUR_SALARY*time)");
//bind variable
expression.Bind("HOUR_SALARY", 10);
expression.Bind("time", 9);
//eval
Decimal salary = expression.Eval<Decimal>(); // will return 92.5
```

## Validate expression
```cs
Expression expression = new Expression("SUM(1,2,3) + true");
//validate expression
List<String> errors = expression.GetError(); 
if(errors.Count == 0)
{
  //No error
}
```

## Min, max, sum, avg
```cs
Expression expr = new Expression("SUM(a)");
expr.Bind("a", new List<Decimal> { 2m, 3m, 16m });
Decimal sum = expr.Eval<Decimal>(); // return 21
expr.SetFomular("AVERAGE(a)");
Decimal avg = expr.Eval<Decimal>(); // return 7
```
## Round, floor, ceiling
```cs
Expression expr = new Expression("ROUND(2.149, 1)");
Object value = expr.Eval(); //return 2.1
```

## Deal with string
```cs
Expression taxExpr = new Expression("IF(LOWER(TAX_CODE)='vat',amount*10/100,IF(LOWER(TAX_CODE)='gst',amount*15/100,0))");
taxExpr.Bind("TAX_CODE","GST");
taxExpr.Bind("amount", 5005m);
Decimal value = taxExpr.Eval<Decimal>();
```

## License
MIT lisence