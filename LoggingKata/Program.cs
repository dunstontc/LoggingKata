using System;
using System.IO;
using System.Linq;
using Geolocation;
using log4net;

namespace LoggingKata
{
    internal static class Program
    {
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
        {
            Logger.Info("Log initialized");
            
            var dataFile = Path.Combine(Environment.CurrentDirectory, @"Taco_Bell-US-AL-Alabama.csv");
            
            var lines = File.ReadAllLines(dataFile);
            
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

            var locations = lines.Select(TacoParser.Parse);

            ITrackable locA = null;
            ITrackable locB = null;
            double distance = 0;


            // TODO: find a more efficient way than nested loops.
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
                    
                    var result = GeoCalculator.GetDistance(origin, destination);
                
                    if (result > distance)
                    {
                        locA = curLocA;
                        locB = curLocB;
                        distance = result;
                    }

                }
            }

            Console.WriteLine($"The two Taco Bells in Alabama furthest from each other are in {locA.Name} and {locB.Name}.");
            Console.WriteLine($"They are {distance} miles apart.");
        }
    }
}