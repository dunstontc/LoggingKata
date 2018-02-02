using System;
using System.Collections;
using System.Collections.Generic;
using log4net;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
//        public TacoParser() => ;

        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                Logger.Error("Line found without 3 cells.");
                return null;
            }

            double.TryParse(cells[0], out var lon);
            double.TryParse(cells[1], out var lat);
            // Your going to need to parse your string as a `double` which is similar to parse a string as an `int`
            var name = cells[2];
            
            // You'll need to create a TacoBell class that conforms to ITrackable
            // Then, you'll need an instance of the TacoBell class with the name and point set correctly
            var tBell = new TacoBell(lon, lat, name);

            // Then, return the instance of your TacoBell class, since it conforms to ITrackable
            return tBell;
            
            // TODO: DO not fail if one record parsing fails, return null
            return null;
        }
    }
}