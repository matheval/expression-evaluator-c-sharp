//using org.matheval;


//Expression expression = new("minute(now())");
//var val = expression.Eval();
//Console.WriteLine(val);


//Console.WriteLine("datevalue test");
//expression = new("datevalue('2023-01-15')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("datevalue('2023/01/15')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("datevalue('12-25-2022')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("datevalue('12/25/2022')");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("Time test");
//expression = new("time(10,15,32)");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("time(23,59,59)");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("time(1111,59,59)");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("second test");
//expression = new("second('01:23:20')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("second('03/30/2022 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);
////expression = new("second('03/30/2022')");
////val = expression.Eval();
////Console.WriteLine(val);


//Console.WriteLine("minute test");
//expression = new("minute('01:23:20')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("minute('03/30/2022 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);

////expression = new("minute('03/30/2022')");
////val = expression.Eval();
////Console.WriteLine(val);

//Console.WriteLine("hour test");
//expression = new("hour('01:23:20')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("hour('03/30/2022 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("day test");
//expression = new("day('03/15/2022')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("day('05/30/2022 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);


//Console.WriteLine("month test");
//expression = new("month('03/15/2022')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("month('05/30/2022 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("now test");
//expression = new("now()");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("edate test");
//expression = new("edate('05/30/2022 04:50:45',5)");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("edate('05/30/2022',20)");
//val = expression.Eval();
//Console.WriteLine(val);


//Console.WriteLine("weekday test");
//DateTime date = new DateTime();
//for (int i = 0; i < 8; i++)
//{
//    date = DateTime.UtcNow.AddDays(i);
//    expression = new("weekday('" + date.ToString() + "')");
//    val = expression.Eval();
//    Console.WriteLine(date.DayOfWeek + ": " + val.ToString());
//}

//Console.WriteLine("weeknum test");
//expression = new("weeknum('01/01/2022 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("weeknum('12/20/2022')");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("workday test");
//expression = new("workday('01/01/2023 04:50:45',3)");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("workday('01/01/2023 04:50:45',-3)");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("workday('01/01/2023',20)");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("workday('01/01/2023',99)");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("networkday test");
//expression = new("networkdays('01/01/2023 04:50:45','01/25/2023 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("networkdays('01/01/2023 04:50:45','02/25/2023 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("networkdays('01/01/2023 04:50:45','01/01/2023 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("eomonth test");
//expression = new("eomonth('01/01/2023 04:50:45',2)");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("eomonth('01/01/2023',2)");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("eomonth('01/01/2023 04:50:45',11)");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("datedif test");
//expression = new("datedif('01/01/2023 04:50:45','02/05/2023 04:50:45','day')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("datedif('01/01/2023','01/01/2024','day')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("datedif('01/01/2023','04/08/2023','day')");
//val = expression.Eval();
//Console.WriteLine(val);

//expression = new("datedif('01/01/2023','03/03/2023','month')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("datedif('01/01/2023','04/25/2024','month')");
//val = expression.Eval();
//Console.WriteLine(val);

//expression = new("datedif('01/01/2023','07/01/2023','year')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("datedif('01/01/2023','04/25/2025','year')");
//val = expression.Eval();
//Console.WriteLine(val);

//Console.WriteLine("days test");
//expression = new("days('01/01/2023 04:50:45','01/05/2023 04:50:45')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("days('01/01/2023','01/01/2024')");
//val = expression.Eval();
//Console.WriteLine(val);
//expression = new("days('01/01/2023','04/08/2023')");
//val = expression.Eval();
//Console.WriteLine(val);
