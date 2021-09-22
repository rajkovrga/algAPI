using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {

            Console.WriteLine("Choose where you want to use the data from:");
            Console.WriteLine("Press 1 for using data from file");
            Console.WriteLine("Press 2 for using data from database");
            Console.WriteLine("Press 3 for using data for free entry ");
            string r = Console.ReadLine();
            string desc = "";
            int n;

            var isNumeric = int.TryParse(r, out n);

            if (!isNumeric)
            {
                Console.WriteLine("Format is not good. Try again:");
                r = Console.ReadLine();
            }

            if (!(new List<int> { 1, 2, 3 }).Contains(Convert.ToInt32(r)))
            {
                Console.WriteLine("Format is not good. Try again:");
                r = Console.ReadLine();
            }

            if (Convert.ToInt32(r) == 3)
            {
                Console.WriteLine("Insert text:");
                desc = Console.ReadLine();
                desc = "?Description=" + desc;
            }

            try
            {
                HttpClient client = new HttpClient();

                var result = await client.GetAsync("https://localhost:5001/api/Main/" + r + desc);
                Console.WriteLine("Result is: " + await result.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                Console.WriteLine("System error, try later");
            }

            Console.ReadLine();
            return 0;
        }
    }
}
