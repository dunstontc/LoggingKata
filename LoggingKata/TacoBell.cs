using log4net.Core;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        // Constructor for a new TacoBell
        public TacoBell(double lon, double lat, string name)
        {
            Name = name;
            Location = new Point(lon, lat);
            Lon = lon;
            Lat = lat;
        }
        
        public string Name { get; set; }
        public Point Location { get; set; }
        public double Lat;
        public double Lon;

    }
}
