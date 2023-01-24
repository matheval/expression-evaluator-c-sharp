using org.matheval;

var date = DateTime.Now;
Expression expression = new Expression("year('2021-03-30')");
var val = expression.Eval();
Console.WriteLine(val);