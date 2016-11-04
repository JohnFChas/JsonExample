using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = String.Format("{0}{1}",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "\\Files");

            var file = String.Format("{0}{1}", directory, "/data.json");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(file))
                File.Create(file);

            Person[] myArray = new Person[]
            {
                new Person { Name = "Oliver Twist", Age = 5 },
                new Person { Name = "Donald Trump", Age = 69 },
                new Person { Name = "Nisse Persson", Age = 34 }
            };

            string jsonString = JsonConvert.SerializeObject(myArray);
            Console.WriteLine(jsonString);

            File.WriteAllText(file, jsonString);

            string jsonFromFile = File.ReadAllText(file);

            Person[] myDeserializedArray = JsonConvert.DeserializeObject<Person[]>(jsonFromFile);

            foreach (var person in myDeserializedArray)
            {
                Console.WriteLine("Name: {0}, Age: {1}", person.Name, person.Age);
            }
        }
    }
}
