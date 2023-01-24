using org.matheval;

Expression expression = new("date(2022, 3, 30)");
var val = expression.Eval();
Console.WriteLine(val);