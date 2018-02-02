using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geolocation;
using log4net;

namespace LoggingKata
{
    class Program
    {
        // QUESTION: Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Grab the path from Environment.CurrentDirectory + the name of your file
        //public static string mainPath = Path.Combine(Environment.CurrentDirectory, "..", "..");
        //public static string filePath = Path.Combine(mainPath, @"Taco_Bell-US-AL-Alabama.csv");
        //public static string[] dataFile = Directory.GetFiles(filePath);
        
        static void Main(string[] args)
        {
            // TODO: Find the two TacoBells in Alabama that are the furthurest from one another.
            // HINT: You'll need two nested forloops
    
            Logger.Info("Log initialized");
            
            if (args.Length == 0)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }

            var lines = File.ReadAllLines(args[0]);
            
            switch (lines.Length)
            {
                case 0:
                    Logger.Error("0 lines read from file.");
                    break;
                case 1:
                    Logger.Warn("Only 1 line read from file.");
                    break;
                default:
                    Logger.Debug($"{lines.Length} lines read from file.");
                    break;
            }

            var parser = new TacoParser();
            
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(line => parser.Parse(line));
            var locations = lines.Select(line => parser.Parse(line));

            ITrackable locA = null;
            ITrackable locB = null;
            double distance = 0;


            foreach (var curLocA in locations)
            {
                var origin = new Coordinate
                {
                    Latitude = curLocA.Location.Latitude,
                    Longitude = curLocA.Location.Longitude
                };

                foreach (var curLocB in locations)
                {
                    var destination = new Coordinate
                    {
                        Longitude = curLocB.Location.Longitude,
                        Latitude = curLocB.Location.Latitude
                    };
                    var result = GeoCalculator.GetDistance(origin, destination, 1);
                
                    if (result > distance)
                    {
                        locA = curLocA;
                        locB = curLocB;
                        distance = result;
                    }

                }
            }

            Console.WriteLine($"The Taco Bells in Alabama furthest from each other are {locA.Name} and {locB.Name}.");
            Console.Write($"They are {distance} miles apart.");
        }
    }
}