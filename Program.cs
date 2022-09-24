using System;
using System.Data;
using System.Diagnostics;//used for Stopwatch class

using MySql.Data;
using MySql.Data.MySqlClient;

using MySqlAccess;
using BusinessLogic;
using System.Collections;

Console.WriteLine("The current time is " + DateTime.Now);

Stopwatch stopwatch = new Stopwatch();

int userInput = 0;
do
{
    Console.WriteLine("_____________________");
    Console.WriteLine("Please chose a task:");
    Console.WriteLine("1 - create empty tables");
    Console.WriteLine("2 - fill costumer and order details");
    Console.WriteLine("3 - generate invoice for a costumer");
    Console.WriteLine("4 - generate total sales and average price for order");
    Console.WriteLine("5 - generate the most common flavor");
    Console.WriteLine("6 - generate the most common toping");
    Console.WriteLine("7 - show tables data (Costumers/Orders)");
    Console.WriteLine("8 - show status orders");
    Console.WriteLine("9 - Enter random values to fill MySQL tables");
    Console.WriteLine("10 - Test MongoDB connection");
    Console.WriteLine("11 - Fill MongoDB data");

    Console.WriteLine("");
    Console.WriteLine("(-1) - for exit");

    userInput = Int32.Parse(Console.ReadLine());

    switch (userInput)
    {
        case 1:
            BusinessLogic.Logic.createTables();
            break;
        case 2:
            Console.WriteLine("How much orders you would like to make (MYSQL)?");
            int order_amount = Int32.Parse(Console.ReadLine());
            BusinessLogic.Logic.fill_table(order_amount);
            break;
        case 3:
            Console.WriteLine("Please enter costumer ID");
            int costumer_id = Int32.Parse(Console.ReadLine());
            string o = MySqlAccess.MySqlAccess.invoice(costumer_id);
            Console.WriteLine(o);
            break;
        case 4:
            Console.WriteLine("Please enter date in format MM/dd/yyyy");
            string date = Console.ReadLine();
            var resul = MySqlAccess.MySqlAccess.total(date);
            Console.WriteLine("Total sales for " + date + " is :"+resul);
            break;
        case 5:
            Console.WriteLine("Generating the most common flavor...");
            string fal = MySqlAccess.MySqlAccess.most_common_flavor();
            Console.WriteLine(fal);
            break;
        case 6:
            Console.WriteLine("Generating the most common toping...");
            string tp = MySqlAccess.MySqlAccess.most_common_toping();
            Console.WriteLine(tp);
            break;
        case 7:
            Console.WriteLine("Enter table name (Costumers/Orders)");
            string tableName = Console.ReadLine();
            ArrayList results = BusinessLogic.Logic.getTableData(tableName);
            foreach (Object obj in results)
                Console.WriteLine("   {0}", obj);
            Console.WriteLine();
            break;
        case 8:
            Console.WriteLine("chose orders status(done = 1/ else = 0)");
            int status = Int32.Parse(Console.ReadLine());
            ArrayList results_done = MySqlAccess.MySqlAccess.orderDone(status);
            foreach (Object obj in results_done)
                Console.WriteLine(obj);
            Console.WriteLine();
            break;
        case 9:
            Console.WriteLine("Please enter orders size ");
            int size = Int32.Parse(Console.ReadLine());
            BusinessLogic.Logic.fillTables(size);
            break;
        case 10:
            MongoAccess.MongoAccess.test();
            break;
        case 11:
            Console.WriteLine("How much orders you would like to make?");
            int db_amount = Int32.Parse(Console.ReadLine());
            BusinessLogic.Logic.fillCollection(db_amount);
            break;

    }

} while (userInput != -1);

Console.WriteLine("Thank you for your time");
Console.ReadKey();


