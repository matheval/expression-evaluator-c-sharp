using org.matheval;

Expression expression = new("1+1");
var val = expression.Eval();
Console.WriteLine(val);