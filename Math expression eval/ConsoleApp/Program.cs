using org.matheval;

Console.WriteLine("date test");
Expression expression = new("date(2022, 3, 30)");
var val = expression.Eval();
Console.WriteLine(val);
/*
Console.WriteLine("datevalue test");
expression = new("datevalue('2023-01-15')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("datevalue('2023/01/15')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("datevalue('12-25-2022')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("datevalue('12/25/2022')");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("Time test");
expression = new("time(10,15,32)");
val = expression.Eval();
Console.WriteLine(val);
expression = new("time(23,59,59)");
val = expression.Eval();
Console.WriteLine(val);
expression = new("time(1111,59,59)");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("second test");
expression = new("second('01:23:20')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("second('03/30/2022 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("minute test");
expression = new("minute('01:23:20')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("minute('03/30/2022 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("hour test");
expression = new("hour('01:23:20')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("hour('03/30/2022 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("day test");
expression = new("day('03/15/2022')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("day('05/30/2022 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("month test");
expression = new("month('03/15/2022')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("month('05/30/2022 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("now test");
expression = new("now()");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("edate test");
expression = new("edate('05/30/2022 04:50:45',5)");
val = expression.Eval();
Console.WriteLine(val);
expression = new("edate('05/30/2022',20)");
val = expression.Eval();
Console.WriteLine(val);


Console.WriteLine("weekday test");
DateTime date = new DateTime();
for (int i = 0; i < 8; i++)
{
    date = DateTime.UtcNow.AddDays(i);
    expression = new("weekday('" + date.ToString() + "')");
    val = expression.Eval();
    Console.WriteLine(date.DayOfWeek +": "+ val.ToString());
}

Console.WriteLine("weeknum test");
expression = new("weeknum('01/01/2022 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("weeknum('12/20/2022')");
val = expression.Eval();
Console.WriteLine(val);

Console.WriteLine("workday test");
expression = new("workday('01/01/2023 04:50:45',3)");
val = expression.Eval();
Console.WriteLine(val);
expression = new("workday('01/01/2023',20)");
val = expression.Eval();
Console.WriteLine(val);
expression = new("workday('01/01/2023',99)");
val = expression.Eval();
Console.WriteLine(val);
*/

Console.WriteLine("workday test");
expression = new("networkdays('01/01/2023 04:50:45','01/25/2023 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("networkdays('01/01/2023 04:50:45','02/25/2023 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);
expression = new("networkdays('01/01/2023 04:50:45','01/01/2023 04:50:45')");
val = expression.Eval();
Console.WriteLine(val);