using System;
using log4net;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public static class TacoParser
    {
        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static ITrackable Parse(string line)
        {
            if (string.IsNullOrEmpty(line)) return null;
            
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                Logger.Error("Line found without 3 cells.");
                return null;
            }

            double lat;
            double lon;
            var name = cells[2];
            try
            { 
                lat = Convert.ToDouble(cells[0]);
                lon = Convert.ToDouble(cells[1]);
            }
            catch (Exception e)
            {
                Logger.Error("Error parsing coorinates: ", e);
                return null;
            }

            var tBell = new TacoBell(lon, lat, name);

            return tBell;


        }
    }
}