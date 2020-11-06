using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TestDeserialization
{
    public class DataPoint
    {
        public string Date { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }

    public class PriceClass
    {
        //[JsonProperty("price")]
        public int Price { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var itemsList = new List<DataPoint>();
            const string jsonString = "{\n" +
                " {\"2020-01-01\": \n { \"price\" : 100 } },  {\"2020-01-02\": \n { \"price\" : 200 } } " +
                "\n}";
            #region workingwitharrays
            //var jsonObjects = JsonConvert.DeserializeObject<IEnumerable<JObject>>(jsonString);

            //foreach (var jsonObject in jsonObjects)
            //{
            //    const string priceProperty = "price";
            //    var dateProperty = jsonObject.First.Path;
            //    var price = jsonObject[dateProperty][priceProperty].Value<int>();

            //    var dataPoint = new DataPoint
            //    {
            //        Price = price,
            //        Date = dateProperty
            //    };

            //    itemsList.Add(dataPoint);
            //}
            //foreach (var item in itemsList )
            //{
            //    Console.WriteLine($"{item.Date} -- {item.Price}");
            //}
            #endregion
            try
            {

                var results = JsonConvert.DeserializeObject<Dictionary<string, PriceClass>>(jsonString);
                var items = new List<DataPoint>();
                foreach (var item in results)
                {
                    items.Add(new DataPoint { Date = item.Key, Price = item.Value.Price });
                }

                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Date} -- {item.Price}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

        }
    }
}
