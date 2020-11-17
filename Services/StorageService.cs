using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using numsortAPI.Interfaces;
using numsortAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortYourIntegers.Services
{
    public class StorageService : IStorage
    {
        public void SaveMyArray(double[] array)
        {
            string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Database", $"database.json"));

            List<MyArray> result = JObject.Parse(jsonString).SelectToken("MyArrayList").ToObject<List<MyArray>>();

            result.Add(new MyArray() { Id = result.Count, Data = array });

            MyArrays products = new MyArrays() { MyArrayList = result };

            string productArraySerialized = JsonConvert.SerializeObject(products);

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Database", $"database.json"), productArraySerialized);
        }

        public double[] LoadStoredArrayById(int id)
        {
            string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Database", $"database.json"));

            JToken token = JObject.Parse(jsonString).SelectToken("MyArrayList").ElementAtOrDefault(id);

            if(token == null)
            {
                return new double[] { };
            }
            
            MyArray result = token.ToObject<MyArray>();

            return result.Data;
        }
    }
}
