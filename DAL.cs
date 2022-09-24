using MySql.Data;
using MySql.Data.MySqlClient;

using BusinessEntities;
using BusinessLogic;
using System.Collections;

namespace MySqlAccess
{
    class MySqlAccess
    {

        static string connStr = "server=localhost;user=root;port=3306;database=icecreamshop;password=fenixRider9595";

        /*
        this call will represent CRUD operation
        CRUD stands for Create,Read,Update,Delete
        */
        public static void createTables()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                string sql = "DROP DATABASE IF EXISTS IceCreamShop;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "CREATE DATABASE IceCreamShop;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database created successfully :)");

                // create Costumers
                sql = 
                      "CREATE TABLE `IceCreamShop`.`Costumers` ("+
                      "`costumer_id` INT NOT NULL AUTO_INCREMENT, "+
                      "`name` VARCHAR(45) NOT NULL, "+
                      "`order_id` INT NOT NULL, "+
                      "PRIMARY KEY (`costumer_id`));";

                cmd = new MySqlCommand(sql,conn);
                cmd.ExecuteNonQuery();

                // create Orders
                sql = 
                      "CREATE TABLE `IceCreamShop`.`Orders` ("+
                      "`order_id` INT NOT NULL, "+
                      "`cone_type` VARCHAR(45) NOT NULL, "+
                      "`ball_amount` VARCHAR(45) NOT NULL, "+
                      "`flavors` VARCHAR(150) NOT NULL, "+
                      "`topings` VARCHAR(150) NULL, "+
                      "`date` VARCHAR(45) NOT NULL, "+
                      "`price` INT NOT NULL, "+
                       "`status` INT NOT NULL, "+
                      "PRIMARY KEY (`order_id`));"+
                      
                      "FOREIGN KEY (order_id) REFERENCES Costumers(order_id));";

                cmd = new MySqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    public static string invoice(int costumer_id){
            string all = "";
            try{
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySql...");
                conn.Open();
                string sql = "Select price,date,name,flavors,topings,cone_type "+
                             "FROM IceCreamShop.Orders JOIN IceCreamShop.Costumers "+
                             "WHERE Orders.order_id = Costumers.order_id "+
                             "AND Costumers.costumer_id = " + costumer_id + ";";

                MySqlCommand cmd = new MySqlCommand(sql,conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read()){

                    var price = rdr.GetString(0);
                    var name = rdr.GetString(1);
                    var date = rdr.GetString(2);
                    var fal = rdr.GetString(3);
                    var top = rdr.GetString(4);
                    var cone = rdr.GetString(5);
                    Invoice i = new Invoice(price, date , name, fal,top,cone);
                    all = i.ToString();
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return all;
        }

  public static int total(string askedDate) {
               int price=0;

    try{
            String sql = $"SELECT SUM(price) FROM Orders WHERE date LIKE '{askedDate}%'";
            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql,connection);
            
            MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read()){
                    price = rdr.GetInt32(0);
                }
                rdr.Close();
                connection.Close();}
                            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return price;
        }

        public static string most_common_flavor(){
                       string fal ="";

            try{
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT flavors, COUNT(flavors) AS flavor_counter "+ 
                             "FROM IceCreamShop.Orders "+ 
                             "GROUP BY flavors "+ 
                             "ORDER BY flavor_counter DESC "+ 
                             "LIMIT 1;";
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read()){
                    fal = rdr.GetString(0);
                }
                rdr.Close();
                conn.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return fal;
        }

        public static string most_common_toping(){
            string tp ="";
            try{
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT topings, COUNT(topings) AS topings_counter "+ 
                             "FROM IceCreamShop.Orders "+ 
                             "GROUP BY topings "+ 
                             "ORDER BY topings_counter DESC "+ 
                             "LIMIT 1;";
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read()){
                    tp = rdr.GetString(0);

                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return tp;
        }



        public static void insertObject(Object obj)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = null;

                if (obj is Costumer)
                {
                    Costumer costumer = (Costumer)obj;
                    sql = "INSERT INTO `IceCreamShop`.`Costumers` (`Costumer_ID`, `Name`, `Order_ID`) "+
                    "VALUES ('" + costumer.getId() + "', '" + costumer.getName() + "', '" + costumer.getOrder_id() + "');";
                }

                if(obj is Order)
                {
                    Order order = (Order)obj;
                    sql = "INSERT INTO `IceCreamShop`.`Orders` (`order_id`, `cone_type`, `ball_amount`, `flavors`, `topings`, `date`, `price`,`status` )" +
                    "VALUES ('" + order.getOrder_id() + "', '" + order.getCon_type() + "', '" + order.getBall_amount() + "', '" + order.flavor_toString() +
                    "', '" + order.toping_toString() + "', '" + order.getTime() + "', '" + order.getPrice() + "', '"+order.get_status()+"');";
                    // sql = "INSERT INTO `IceCreamShop`.`Orders` (`Order_ID`, `Flavors`, `Topings`, `Cone_type`, `Ball_amount`, `Date`, `Price`) " +
                    // "VALUES ('" + order.getOrder_id() + "', '" + order.flavor_toString() + "', '" + order.toping_toString() + "', '" + order.getCon_type() +
                    // "', '" + order.getBall_amount() + "', '" + order.getTime() + "', '" + order.getPrice() + "');";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }




 public static  ArrayList  orderDone(int status){
            ArrayList all = new ArrayList();
             try{
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySql...");
                conn.Open();
                string sql = $"SELECT price,date,flavors,topings,cone_type  FROM Orders WHERE status LIKE '{status}%'";
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                string temp="";
                while(rdr.Read()){

                    var price = rdr.GetString(0);
                     var date = rdr.GetString(1);                   
                    var fal = rdr.GetString(2);
                    var top = rdr.GetString(3);
                    var cone = rdr.GetString(4);
                    Invoice i = new Invoice(price, date, fal,top,cone);
                    temp=i.ToString();

                    all.Add(temp);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return all;
        }

        public static ArrayList readAll(string tableName)
        {
            ArrayList all = new ArrayList();

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM `IceCreamShop`."+tableName;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                    Object[] numb = new Object[rdr.FieldCount];
                    rdr.GetValues(numb);
                    //Array.ForEach(numb, Console.WriteLine);
                    all.Add(numb);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return all;
        }
    }

}