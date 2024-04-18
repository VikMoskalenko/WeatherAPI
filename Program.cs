using System;

using System.Net.Http;

using Newtonsoft.Json;



namespace WeatherApp

{

    class Program

    {

        static async System.Threading.Tasks.Task Main(string[] args)

        {
            Console.WriteLine("Welcome to the weather Application");

            Console.Write("Enter the name of the city: ");

            string city = Console.ReadLine().ToLower();



            string apiKey = "d08ad6e40cde9d975197c31787297107";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";



            using (var client = new HttpClient())

            {

                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();



                var stringResult = await response.Content.ReadAsStringAsync();

                var weatherData = JsonConvert.DeserializeObject<WeatherData>(stringResult);



                Console.WriteLine($"Weather forecast for {weatherData.Name}:");

                Console.WriteLine($"Temperature: {weatherData.Main.Temp}°C");

                Console.WriteLine($"Description: {weatherData.Weather[0].Description}");

                Console.WriteLine($"Wind Speed: {weatherData.Wind.Speed} m/s");

                Console.WriteLine($"Wind Direction: {weatherData.Wind.Deg}°");

            }

        }

    }



    public class WeatherData

    {

        public string Name { get; set; }

        public Main Main { get; set; }

        public Weather[] Weather { get; set; }

        public Wind Wind { get; set; }

    }



    public class Main

    {

        public double Temp { get; set; }



    }



    public class Weather

    {

        public string Description { get; set; }

    }



    public class Wind

    {

        public double Speed { get; set; }

        public double Deg { get; set; }

    }

}