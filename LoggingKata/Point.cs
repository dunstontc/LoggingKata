namespace LoggingKata
{
    public struct Point
    {
        public Point(double longitude, double latitude) : this()
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Longitude { get; }

        public double Latitude { get; }
    }
}