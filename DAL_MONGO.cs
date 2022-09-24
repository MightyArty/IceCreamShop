
using MongoDB.Driver;
using MongoDB.Bson;

using BusinessEntities;
using BusinessLogic;
using System.Collections;

namespace MongoAccess
{
    class MongoAccess
    {
        public static void test()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://data_geek:1234@cluster0.mky4qbt.mongodb.net/test");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("IceCream");

            var dbList = database.ListCollectionNames().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }

            public static void fillDocuments (List<MongoOrder> orders) //to make it by interface, rename to fillData
            {

                 List<BsonDocument> documents = new List<BsonDocument>();

                //build list of all documents
                foreach (var mongoOrderd in orders) {
                    var document = new BsonDocument { 
                        { "Costumer", new BsonDocument 
                            {
                                {"Name", mongoOrderd.getCostumer().getName()},
                                {"Costumer_ID", mongoOrderd.getCostumer().getId()},
                                {"Order_ID", mongoOrderd.getCostumer().getOrder_id()}
                            }
                        }, 
                        { "Order", new BsonDocument 
                            { 
                                {"Order_ID", mongoOrderd.getOrder().getOrder_id()},
                                { "ball_amount", mongoOrderd.getOrder().getBall_amount()},
                                { "flavors" , mongoOrderd.getOrder().flavor_toString()},
                                { "topings", mongoOrderd.getOrder().toping_toString()},
                                {"price", mongoOrderd.getOrder().getPrice()}, 
                                {"cone_type", mongoOrderd.getOrder().getCon_type()}
                            }
                        }, 
                        { "orderd_date", mongoOrderd.getOrderDate() },
                        { "complete_date",DateTime.Now},
                        { "completed", mongoOrderd.getCompleted() },
                        { "payed", mongoOrderd.getPayed() }
                    };

                    documents.Add(document);
                }

                Console.WriteLine("list is ok");
                //add them all to mongo

                var settings = MongoClientSettings.FromConnectionString("mongodb+srv://data_geek:1234@cluster0.mky4qbt.mongodb.net/test");
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                var client = new MongoClient(settings);
                var database = client.GetDatabase("IceCream");
                var collection = database.GetCollection<BsonDocument> ("Orders");


                collection.InsertMany(documents);
                //await collection.InsertOneAsync (document);
            }
        }
    }