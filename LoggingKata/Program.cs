using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace LoggingKata
{
    class Program
    {
        // Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

//        Grab the path from Environment.CurrentDirectory + the name of your file
//        public static string mainPath = Path.Combine(Environment.CurrentDirectory, "..", "..");
//        public static string filePath = Path.Combine(mainPath, @"Taco_Bell-US-AL-Alabama.csv");
//        public static string[] dataFile = Directory.GetFiles(filePath);
        
        static void Main(string[] args)
        {
            // TODO: Find the two TacoBells in Alabama that are the furthurest from one another.
            // HINT: You'll need two nested forloops
            // DON'T FORGET TO LOG YOUR STEPS
    
            
            if (args.Length == 0)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }

            Logger.Info("Log initialized");
            // Use File.ReadAllLines(path) to grab all the lines from your csv file
            Console.WriteLine(args[0]);
            var lines = File.ReadAllLines(args[0]);
            // TODO: Log and error if you get 0 lines and a warning if you get 1 line
            
            // Create a new instance of your TacoParser class
            var parser = new TacoParser();
            
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(line => parser.Parse(line));
            var locations = lines.Select(line => parser.Parse(line));

            // Create two `ITrackable` variables with initial values of `null`.
            // These will be used to store your two taco bells that are the furthest from each other.

            // Create a `double` variable to store the distance.

            // Include the Geolocation toolbox, so you can compare locations.
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // Create a new Coordinate with your locA's lat and long.

            // Now, do another loop on the locations with the scope of your first loop,
            // so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long.
            // Now, compare the two using `GeoCalculator.GetDistance(origin, destination)`, which returns a double.

            // If the distance is greater than the currently saved distance,
            // update the distance and the two `ITrackable` variables you set above.

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
        }
    }
}