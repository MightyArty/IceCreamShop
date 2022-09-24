
using System;

using System.Collections;
using System;

namespace BusinessEntities
{

    public class Costumer
    {

        public int id;
        public string name;
        public int order_id;

        public Costumer(int id, string name, int order_id)
        {
            this.id = id;
            this.name = name;
            this.order_id = order_id;
        }

        public int getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public int getOrder_id()
        {
            return order_id;
        }

        public override string ToString()
        {
            return $"(id: {id}, name: {name}, order id: {order_id})";
        }
    }
    public class Invoice
    {
        string price;
        string name;
        string date;
        string flavor;
        string toping;
        string cone;

        public Invoice(string p, string n, string d, string f, string t, string c)
        {
            this.price = p;
            this.name = n;
            this.date = d;
            this.flavor = f;
            this.toping = t;
            this.cone = c;
        }

        public Invoice(string p, string d, string f, string t, string c)
        {
            this.price = p;
            this.name = "";
            this.date = d;
            this.flavor = f;
            this.toping = t;
            this.cone = c;
        }

        public override string ToString()
        {
            return "{price: " + price + " , name: " + name + ", order date: " + date + " , cone type: " + cone + ", flavors: " + flavor + " , topings: " + toping + "}";
        }
    }
    public class Order
    {
        public string cone;
        public string[] flavor;
        public string[] toping;
        public int toping_amount;
        public string order_time;
        public int price;
        public int order_id;

        public int status;


        public Order(int order_id, string con_type, string[] flavor, string[] toping, int status)
        {
            this.order_id = order_id;
            this.cone = con_type;
            this.status = status;
            this.order_time = DateTime.Now.ToString("MM/dd/yyyy");
            this.flavor = flavor;
            this.toping = toping;
            this.toping_amount = flavor.Length;
            if (("Regular".Equals(con_type) || "Special".Equals(con_type)) && flavor.Length <= 3 && flavor.Length >= 1)
            {
                //* One ice cream ball*//
                if (flavor.Length == 1)
                {
                    if ("Regular".Equals(con_type))
                    {
                        price = 7;
                    }
                    else if ("Special".Equals(con_type))
                    {
                        price = 9 + (toping.Length) * 2;
                    }
                }

                else if (flavor.Length == 2)
                {
                    // if (!badMatch(con_type, flavor, toping))
                    // {
                    //     throw new InvalidOperationException("Bad match- Choose better !");

                    // }
                    // else
                    // {
                    if ("Regular".Equals(con_type) && toping.Length == 1)
                    {
                        price = 12 + 2;
                    }
                    else if ("Special".Equals(con_type))
                    {
                        price = 14 + 2 * (toping.Length);
                    }
                    else if ("Regular".Equals(con_type))
                    {
                        price = 12;
                    }
                    // }
                }

                else if (flavor.Length == 3)
                {
                    // if (!badMatch(con_type, flavor, toping))
                    // {
                    //     throw new InvalidOperationException("Bad match- Choose better !");
                    // }


                    if ("Regular".Equals(con_type) && toping.Length == 1)
                    {
                        price = 18 + 2;
                    }
                    else if ("Special".Equals(con_type))
                    {
                        price = 20 + 2 * (toping.Length);
                    }
                    else if ("Regular".Equals(con_type))
                    {
                        price = 18;
                    }

                }
            }
            else if ("Box".Equals(con_type))
            {
                if (flavor.Length == 1)
                {
                    price = 5 + 7 + 2 * (toping.Length);
                }
                else
                {
                    price = 5 + (flavor.Length * 6) + (toping.Length * 2);
                }
            }
        }
        public Order(int order_id, string con_type, string fla, string top, int status)
        {

            string[] fl = fla.Split(",");
            string[] tp = top.Split(",");
            this.status = status;
            this.order_id = order_id;
            this.cone = con_type;
            this.order_time = DateTime.Now.ToString("MM/dd/yyyy");
            this.flavor = fl;
            this.toping = tp;
            this.toping_amount = flavor.Length;
            if (("Regular".Equals(con_type) || "Special".Equals(con_type)) && flavor.Length <= 3 && flavor.Length >= 1)
            {
                //* One ice cream ball*//
                if (flavor.Length == 1)
                {
                    if ("Regular".Equals(con_type))
                    {
                        price = 7;
                    }
                    else if ("Special".Equals(con_type))
                    {
                        price = 9 + (toping.Length) * 2;
                    }
                }

                else if (flavor.Length == 2)
                {
                    // if (!badMatch(con_type, flavor, toping))
                    // {
                    //     throw new InvalidOperationException("Bad match- Choose better !");

                    // }
                    // else
                    // {
                    if ("Regular".Equals(con_type) && toping.Length == 1)
                    {
                        price = 12 + 2;
                    }
                    else if ("Special".Equals(con_type))
                    {
                        price = 14 + 2 * (toping.Length);
                    }
                    else if ("Regular".Equals(con_type))
                    {
                        price = 12;
                    }
                    // }
                }

                else if (flavor.Length == 3)
                {
                    // if (!badMatch(con_type, flavor, toping))
                    // {
                    //     throw new InvalidOperationException("Bad match- Choose better !");
                    // }


                    if ("Regular".Equals(con_type) && toping.Length == 1)
                    {
                        price = 18 + 2;
                    }
                    else if ("Special".Equals(con_type))
                    {
                        price = 20 + 2 * (toping.Length);
                    }
                    else if ("Regular".Equals(con_type))
                    {
                        price = 18;
                    }

                }
            }
            else if ("Box".Equals(con_type))
            {
                if (flavor.Length == 1)
                {
                    price = 5 + 7 + 2 * (toping.Length);
                }
                else
                {
                    price = 5 + (flavor.Length * 6) + (toping.Length * 2);
                }
            }
        }
        public bool badMatch(string con_type, string[] flavor, string[] toppings)
        {
            if ("Regular".Equals(con_type) && toppings.Length >= 1)
            {
                string find_chocolate = Array.Find(flavor,
                    ele => ele.StartsWith("Chocolate", StringComparison.Ordinal));
                string find_vanilla =
                    Array.Find(flavor, ele => ele.StartsWith("Vanilla", StringComparison.Ordinal));
                string find_maple = Array.Find(toppings, ele => ele.StartsWith("Maple", StringComparison.Ordinal));
                string find_hot = Array.Find(toppings,
                    ele => ele.StartsWith("Hot Chocolate", StringComparison.Ordinal));

                if ("Hot Chocolate".Equals(find_hot) && "Chocolate".Equals(find_chocolate))
                {
                    return false;
                }

                if ("Maple".Equals(find_maple) && "Vanilla".Equals(find_vanilla))
                {
                    return false;
                }
            }

            return true;
        }

        public string flavor_toString()
        {
            string str = string.Join(",", this.flavor);

            return "{" + str + "}";
        }

        public int get_status()
        {

            return status;
        }

        public string toping_toString()
        {
            string str;
            if (this.toping == null)
            {
                str = string.Join(",", "null");
            }
            else
            {
                str = string.Join(",", this.toping);
                return "{" + str + "}";
            }
            return "{" + str + "}";
        }



        public int getOrder_id()
        {
            return this.order_id;
        }

        public string getCon_type()
        {
            return cone;
        }

        public string[] getFlavor()
        {
            return flavor;
        }

        public string[] getToping()
        {
            return toping;
        }

        public int getBall_amount()
        {
            return flavor.Length;
        }

        public string getTime()
        {
            return order_time;
        }

        public int getPrice()
        {
            return price;
        }

        public override string ToString()
        {
            return "{order id: " + order_id + " , order time: " + order_time + " , cone type: " + cone + ", ball amount: " + flavor.Length + " , flavors: " + flavor_toString() + " , topings: " + toping_toString() + " , price: " + price + ",status:" + status + "}";
        }
    }




    public class MongoOrder
    {
        Costumer costumer;
        Order order;
        string orderDate;
        string completeDate;
        int completed;
        int payed;

        public void setStatus(string orderDate, string completeDate, int completed, int payed)
        {
            this.orderDate = orderDate;
            this.completeDate = completeDate;
            this.completed = completed;
            this.payed = payed;
        }

        public void setCostumer(Costumer c)
        {
            costumer = c;
        }

        public void setOrder(Order o)
        {
            order = o;
        }

        public Costumer getCostumer()
        {
            return this.costumer;
        }

        public Order getOrder()
        {
            return this.order;
        }

        public string getOrderDate() { return orderDate; }
        public string getCompleteDate() { return completeDate; }
        public int getCompleted() { return completed; }
        public int getPayed() { return payed; }
    }


}
