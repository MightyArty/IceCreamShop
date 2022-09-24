using System.Collections;

using BusinessEntities;

namespace BusinessLogic
{
    public class Logic
    {

        static string[] flavors = { "Chocolate", "Mekupelet", "Vanilla", "Strawberry", "Fistuk", "Bamba", "Coffee", "Begale", "Diet", "Gluten Free" };
        static string[] topings = { "Hot Chocolate", "Peanuts", "Maple" };
        static string[] cones = { "Regular", "Special", "Box" };

        static string[] names = { "Bar", "Tom", "Nikol", "David", "Yosi", "Avigail", "Ariel", "Elad", "Yona", "Arkadi", "Boaz", "Doron", "Adi", "Robert", "Messi" };

        public static void createTables()
        {
            MySqlAccess.MySqlAccess.createTables();
        }

        public static void fill_table(int n)
        {

            for (int i = 1; i <= n; i++)
            {
                /* -------------- CREATE COSTUMER -------------- */
                Console.WriteLine("Enter your id :");
                int costumer_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter your name: ");
                string costumer_name = Console.ReadLine();
                int order_id = i;
                Costumer costumer = new Costumer(costumer_id, "" + costumer_name, order_id);
                MySqlAccess.MySqlAccess.insertObject(costumer);

                /* -------------- CREATE ORDER -------------- */
                string toping = "";
                int status;
                Console.WriteLine("Enter cone type (Regular/Special/Box) :");
                string cone_type = Console.ReadLine();
                Console.WriteLine("Enter ice cream ball amount (1/2/3) or more for Box cone type :");
                int ball_amount = Int32.Parse(Console.ReadLine());
                if ("Regular".Equals(cone_type) || "Special".Equals(cone_type))
                {
                    if (ball_amount == 1 && "Regular".Equals(cone_type))
                    {
                        Console.WriteLine("Choose one flavor from the given list of flavors: ");
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        string flavor = Console.ReadLine();
                        string[] final_flavor = { "" + flavor };
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                        status = Int32.Parse(Console.ReadLine());
                        Order order = new Order(order_id, cone_type, final_flavor, null, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }
                    else if (ball_amount == 1 && "Special".Equals(cone_type))
                    {
                        Console.WriteLine("Choose one flavor from the given list of flavors: ");
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        string flavor = Console.ReadLine();
                        if ("Chocolate".Equals(flavor) || "Mekupelet".Equals(flavor))
                        {
                            Console.WriteLine("Choose your toping (Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        else if ("Vanilla".Equals(flavor))
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts): ");
                            toping = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts/Maple)");
                            toping = Console.ReadLine();
                        }
                        string[] final_flavor = { "" + flavor };
                        string[] final_toping = { "" + toping };

                        Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                        status = Int32.Parse(Console.ReadLine());
                        Order order = new Order(order_id, cone_type, final_flavor, final_toping, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }
                    else if (ball_amount == 2)
                    {
                        Console.WriteLine("Choose two flavors from the given list of flavors: ");
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        string first_flavor = Console.ReadLine();
                        string second_flavor = Console.ReadLine();
                        if ("Chocolate".Equals(first_flavor) || "Chocolate".Equals(second_flavor) || "Mekupelet".Equals(first_flavor) || "Mekupelet".Equals(second_flavor))
                        {
                            Console.WriteLine("Choose your toping (Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        else if ("Vanilla".Equals(first_flavor) || "Vanilla".Equals(second_flavor))
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts): ");
                            toping = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        // string[] final_flavors = { "" + first_flavor + ", " + second_flavor };
                        string[] final_flavors = new string[2];
                        final_flavors[0] = "" + first_flavor;
                        final_flavors[1] = "" + second_flavor;
                        string[] final_toping = { "" + toping };
                        Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                        status = Int32.Parse(Console.ReadLine());
                        Order order = new Order(order_id, cone_type, final_flavors, final_toping, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }
                    else if (ball_amount == 3)
                    {
                        Console.WriteLine("Choose three flavors from the given list of flavors: ");
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        string first_flavor = Console.ReadLine();
                        string second_flavor = Console.ReadLine();
                        string third_flavor = Console.ReadLine();
                        if ("Chocolate".Equals(first_flavor) || "Chocolate".Equals(second_flavor) || "Mekupelet".Equals(first_flavor) || "Mekupelet".Equals(second_flavor)
                        || "Chocolate".Equals(third_flavor) || "Mekupelet".Equals(third_flavor))
                        {
                            Console.WriteLine("Choose your toping (Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        else if ("Vanilla".Equals(first_flavor) || "Vanilla".Equals(second_flavor) || "Vanilla".Equals(third_flavor))
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts)");
                            toping = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        string[] final_flavors = { "" + first_flavor + ", " + second_flavor + ", " + third_flavor };
                        string[] final_toping = { "" + toping };
                        Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                        status = Int32.Parse(Console.ReadLine());
                        Order order = new Order(order_id, cone_type, final_flavors, final_toping, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }
                }
                else if ("Box".Equals(cone_type))
                {
                    string[] flavors = new string[ball_amount];
                    Console.WriteLine("Choose flavors from the given list of flavors: ");
                    Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                    for (int j = 0; j < ball_amount; j++)
                    {
                        string flavor = Console.ReadLine();
                        flavors[j] = "" + flavor;
                    }
                    Console.WriteLine("How much topings would you like to add to your tasty ice cream? (should be < then ice cream balls)");
                    int top = Int32.Parse(Console.ReadLine());
                    string[] topings = new string[top];
                    Console.WriteLine("Choose your topings (Hot Chocolate/Maple/Peanuts)");
                    for (int k = 0; k < top; k++)
                    {
                        toping = Console.ReadLine();
                        topings[k] = "" + toping;
                    }
                    Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                    status = Int32.Parse(Console.ReadLine());
                    Order order = new Order(order_id, cone_type, flavors, topings, status);
                    MySqlAccess.MySqlAccess.insertObject(order);
                }

            }
        }

        /* -------------- IF YOU WANT TO RANDOMIZE UNCOMMENT THIS SECTION -------------- */

        public static void fillTables(int num)
        {
            Random r = new Random();


            /* Generate random values for costumers */
            for (int i = 1; i < num; i++)
            {
                int costumer_id = r.Next(1, 1000);
                int order_id = i;
                int costumer_name = r.Next(0, names.Length);
                Costumer costumer = new Costumer(costumer_id, "" + names[costumer_name], order_id);
                MySqlAccess.MySqlAccess.insertObject(costumer);
                // Console.WriteLine("Costumer" + costumer);
            }

            /* Generate random values for order */
            for (int i = 0; i < num; i++)
            {
                int order_id = i;   // 0
                int cone = r.Next(0, 3);
                int status = r.Next(0, 2);

                int toping;
                int flavor_amount;
                int first_flavor, second_flavor, third_flavor;

                // Regular cone
                if (cone == 0)
                {
                    flavor_amount = r.Next(1, 4); // randomly pick falvor amount
                    if (flavor_amount == 1)
                    { // one ice cream ball -> no topings
                        first_flavor = r.Next(0, flavors.Length);
                        string[] final_flavor = { flavors[first_flavor] };
                        Order order = new Order(order_id, "Regular", final_flavor, null, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }

                    else if (flavor_amount == 2)
                    { // two ice cream balls -> one toping
                        first_flavor = r.Next(0, flavors.Length);
                        second_flavor = r.Next(0, flavors.Length);
                        if (flavors[first_flavor] == "Chocolate" || flavors[second_flavor] == "Chocolate"
                        || flavors[first_flavor] == "Mekupelet" || flavors[second_flavor] == "Mekupelet")
                        {
                            toping = r.Next(1, 2);
                        }
                        else if (flavors[first_flavor] == "Vanilla" || flavors[second_flavor] == "Vanilla")
                        {
                            toping = r.Next(0, 1);
                        }
                        else
                        {
                            toping = r.Next(0, 3);
                        }
                        string[] final_flavors = { flavors[first_flavor], flavors[second_flavor] };
                        string[] final_toping = { topings[toping] };
                        Order order = new Order(order_id, "Regular", final_flavors, final_toping, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }

                    else if (flavor_amount == 3)
                    { //trhee ice cream balls -> one toping
                        first_flavor = r.Next(0, flavors.Length);
                        second_flavor = r.Next(0, flavors.Length);
                        third_flavor = r.Next(0, flavors.Length);
                        if (flavors[first_flavor] == "Chocolate" || flavors[second_flavor] == "Chocolate"
                        || flavors[third_flavor] == "Chocolate" || flavors[first_flavor] == "Mekupelet"
                        || flavors[second_flavor] == "Mekupelet" || flavors[third_flavor] == "Mekupelet")
                        {
                            toping = r.Next(1, topings.Length);
                        }
                        else if (flavors[first_flavor] == "Vanilla" || flavors[second_flavor] == "Vanilla" || flavors[third_flavor] == "Vanilla")
                        {
                            toping = r.Next(0, topings.Length - 1);
                        }
                        else
                        {
                            toping = r.Next(0, topings.Length);
                        }
                        string[] final_flavors = { flavors[first_flavor], flavors[second_flavor], flavors[third_flavor] };
                        string[] final_toping = { topings[toping] };
                        Order order = new Order(order_id, "Regular", final_flavors, final_toping, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }
                    // else {
                    //     Console.WriteLine("Choose correct amount of ice cream balls!");
                    // }
                }

                // Special cone
                else if (cone == 1)
                {
                    flavor_amount = r.Next(1, 4); // randomly pick falvor amount
                    // one ice cream ball
                    if (flavor_amount == 1)
                    {
                        first_flavor = r.Next(0, flavors.Length);
                        if (flavors[first_flavor] == "Chocolate" || flavors[first_flavor] == "Mekupelet")
                        {
                            toping = r.Next(1, topings.Length);
                        }
                        else if (flavors[first_flavor] == "Vanilla")
                        {
                            toping = r.Next(0, topings.Length - 1);
                        }
                        else
                        {
                            toping = r.Next(0, topings.Length);
                        }
                        string[] final_flavors = { flavors[flavor_amount] };
                        string[] final_toping = { topings[toping] };
                        Order order = new Order(order_id, "Special", final_flavors, final_toping, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }
                    // two ice cream ball
                    else if (flavor_amount == 2)
                    {
                        first_flavor = r.Next(0, flavors.Length);
                        second_flavor = r.Next(0, flavors.Length);
                        if (flavors[first_flavor] == "Chocolate" || flavors[first_flavor] == "Mekupelet"
                        || flavors[second_flavor] == "Chocolate" || flavors[second_flavor] == "Mekupelet")
                        {
                            toping = r.Next(1, topings.Length);
                        }
                        else if (flavors[first_flavor] == "Vanilla" || flavors[second_flavor] == "Vanilla")
                        {
                            toping = r.Next(0, topings.Length - 1);
                        }
                        else
                        {
                            toping = r.Next(0, topings.Length);
                        }
                        string[] final_flavors = { flavors[first_flavor], flavors[second_flavor] };
                        string[] final_topings = { topings[toping] };
                        Order order = new Order(order_id, "Special", final_flavors, final_topings, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }
                    else if (flavor_amount == 3)
                    {
                        first_flavor = r.Next(0, flavors.Length);
                        second_flavor = r.Next(0, flavors.Length);
                        third_flavor = r.Next(0, flavors.Length);
                        if (flavors[first_flavor] == "Chocolate" || flavors[first_flavor] == "Mekupelet"
                        || flavors[second_flavor] == "Chocolate" || flavors[second_flavor] == "Mekupelet"
                        || flavors[third_flavor] == "Chocolate" || flavors[third_flavor] == "Mekupelet")
                        {
                            toping = r.Next(1, topings.Length);
                        }
                        else if (flavors[first_flavor] == "Vanilla" || flavors[second_flavor] == "Vanilla" || flavors[third_flavor] == "Vanilla")
                        {
                            toping = r.Next(0, topings.Length - 1);
                        }
                        else
                        {
                            toping = r.Next(0, topings.Length);
                        }
                        string[] final_flavors = { flavors[first_flavor], flavors[second_flavor], flavors[third_flavor] };
                        string[] final_toping = { topings[toping] };
                        Order order = new Order(order_id, "Special", final_flavors, final_toping, status);
                        MySqlAccess.MySqlAccess.insertObject(order);
                    }
                }

                // Box
                else if (cone == 2)
                {
                    flavor_amount = r.Next(1, 10);  // assuming that in box you can fit up to 10 flavors (simple logic :))
                    string[] final_flavors = new string[flavor_amount];
                    string[] final_topings = new string[flavor_amount];
                    for (int j = 0; j < flavor_amount; j++)
                    {
                        int curr_flavor = r.Next(1, 10);
                        int curr_toping = r.Next(0, 3);
                        final_flavors[j] = flavors[curr_flavor];
                        final_topings[j] = topings[curr_toping];
                    }
                    Order order = new Order(order_id, "Box", final_flavors, final_topings, status);
                    MySqlAccess.MySqlAccess.insertObject(order);
                }
            }
        }

        public static void fillCollection(int n)
        {
            MongoOrder Mongo;
            List<MongoOrder> data = new List<MongoOrder>(n);
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                /* -------------- CREATE COSTUMER -------------- */
                Mongo = new MongoOrder();
                Console.WriteLine("Enter your id: ");
                int costumer_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter your name: ");
                string costumer_name = Console.ReadLine();
                int order_id = i;
                Costumer costumer = new Costumer(costumer_id, "" + costumer_name, order_id);
                Mongo.setCostumer(costumer);

                /* -------------- CREATE ORDER -------------- */
                string toping = "";
                int status;
                Console.WriteLine("Enter cone type (Regular/Special/Box) :");
                string cone_type = Console.ReadLine();
                Console.WriteLine("Enter ice cream ball amount (1/2/3) or more for Box cone type :");
                int ball_amount = Int32.Parse(Console.ReadLine());
                if ("Regular".Equals(cone_type) || "Special".Equals(cone_type))
                {
                    if (ball_amount == 1 && "Regular".Equals(cone_type))
                    {
                        Console.WriteLine("Choose one flavor from the given list of flavors: ");
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        string flavor = Console.ReadLine();
                        string[] final_flavor = { "" + flavor };
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                        status = Int32.Parse(Console.ReadLine());
                        Order order = new Order(order_id, cone_type, final_flavor, null, status);
                        Mongo.setOrder(order);
                    }
                    else if (ball_amount == 1 && "Special".Equals(cone_type))
                    {
                        Console.WriteLine("Choose one flavor from the given list of flavors: ");
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        string flavor = Console.ReadLine();
                        if ("Chocolate".Equals(flavor) || "Mekupelet".Equals(flavor))
                        {
                            Console.WriteLine("Choose your toping (Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        else if ("Vanilla".Equals(flavor))
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts): ");
                            toping = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts/Maple)");
                            toping = Console.ReadLine();
                        }
                        string[] final_flavor = { "" + flavor };
                        string[] final_toping = { "" + toping };

                        Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                        status = Int32.Parse(Console.ReadLine());
                        Order order = new Order(order_id, cone_type, final_flavor, final_toping, status);
                        Mongo.setOrder(order);
                    }
                    else if (ball_amount == 2)
                    {
                        Console.WriteLine("Choose two flavors from the given list of flavors: ");
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        string first_flavor = Console.ReadLine();
                        string second_flavor = Console.ReadLine();
                        if ("Chocolate".Equals(first_flavor) || "Chocolate".Equals(second_flavor) || "Mekupelet".Equals(first_flavor) || "Mekupelet".Equals(second_flavor))
                        {
                            Console.WriteLine("Choose your toping (Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        else if ("Vanilla".Equals(first_flavor) || "Vanilla".Equals(second_flavor))
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts): ");
                            toping = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        // string[] final_flavors = { "" + first_flavor + ", " + second_flavor };
                        string[] final_flavors = new string[2];
                        final_flavors[0] = "" + first_flavor;
                        final_flavors[1] = "" + second_flavor;
                        string[] final_toping = { "" + toping };
                        Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                        status = Int32.Parse(Console.ReadLine());
                        Order order = new Order(order_id, cone_type, final_flavors, final_toping, status);
                        Mongo.setOrder(order);
                    }
                    else if (ball_amount == 3)
                    {
                        Console.WriteLine("Choose three flavors from the given list of flavors: ");
                        Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                        string first_flavor = Console.ReadLine();
                        string second_flavor = Console.ReadLine();
                        string third_flavor = Console.ReadLine();
                        if ("Chocolate".Equals(first_flavor) || "Chocolate".Equals(second_flavor) || "Mekupelet".Equals(first_flavor) || "Mekupelet".Equals(second_flavor)
                        || "Chocolate".Equals(third_flavor) || "Mekupelet".Equals(third_flavor))
                        {
                            Console.WriteLine("Choose your toping (Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        else if ("Vanilla".Equals(first_flavor) || "Vanilla".Equals(second_flavor) || "Vanilla".Equals(third_flavor))
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts)");
                            toping = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Choose your toping (Hot Chocolate/Peanuts/Maple): ");
                            toping = Console.ReadLine();
                        }
                        string[] final_flavors = { "" + first_flavor + ", " + second_flavor + ", " + third_flavor };
                        string[] final_toping = { "" + toping };
                        Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                        status = Int32.Parse(Console.ReadLine());
                        Order order = new Order(order_id, cone_type, final_flavors, final_toping, status);
                        Mongo.setOrder(order);
                    }
                }
                else if ("Box".Equals(cone_type))
                {
                    string[] flavors = new string[ball_amount];
                    Console.WriteLine("Choose flavors from the given list of flavors: ");
                    Console.WriteLine("Chocolate, Mekupelet, Vanilla, Strawberry, Fistuk, Bamba, Coffee, Begale, Diet, Gluten Free");
                    for (int j = 0; j < ball_amount; j++)
                    {
                        string flavor = Console.ReadLine();
                        flavors[j] = "" + flavor;
                    }
                    Console.WriteLine("How much topings would you like to add to your tasty ice cream? (should be < then ice cream balls)");
                    int top = Int32.Parse(Console.ReadLine());
                    string[] topings = new string[top];
                    Console.WriteLine("Choose your topings (Hot Chocolate/Maple/Peanuts)");
                    for (int k = 0; k < top; k++)
                    {
                        toping = Console.ReadLine();
                        topings[k] = "" + toping;
                    }
                    Console.WriteLine("To confirm a transaction,plase press 1 : else 0 ");
                    status = Int32.Parse(Console.ReadLine());
                    Order order = new Order(order_id, cone_type, flavors, topings, status);
                    Mongo.setOrder(order);
                }
                int year = r.Next(1990,2023);
                int month = r.Next(1,13);
                int day = r.Next(1,29);
                string orderDate = "" + year + "-" + month + "-" + day;

                day = day + r.Next(1,29);
                if(day > 29){
                    day = day % 29;
                    month = month + 1;
                }
                if (month > 12){
                    month = 1;
                    year = year+1;
                }
                string completeDate = "" + year + "-" + month + "-" + day;
                int completed = r.Next(0,2);
                int payed = r.Next(0,2);
                Mongo.setStatus(orderDate, completeDate, completed, payed);
                data.Add(Mongo);
            }
            MongoAccess.MongoAccess.fillDocuments(data);
        }

        public static ArrayList getTableData(string tableName)
        {
            ArrayList all = MySqlAccess.MySqlAccess.readAll(tableName);
            ArrayList results = new ArrayList();

            if (tableName == "Costumers")
            {
                foreach (Object[] row in all)
                {
                    Costumer c = new Costumer((int)row[0], "" + row[1], (int)row[2]); // [order_id, name, costumer_id]
                    results.Add(c);
                }
            }

            else if (tableName == "Orders")
            {
                foreach (Object[] row in all)
                {
                    Order o = new Order((int)row[0], "" + row[1], (string)row[2], (string)row[3], (int)row[7]);
                    results.Add(o);
                }
            }
            return results;
        }
    }
}