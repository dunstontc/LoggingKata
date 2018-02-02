namespace LoggingKata
{
    public class TacoBell
    {
        // Constructor for a new TacoBell
        public TacoBell(ITrackable data)
        {
            Data = data;
            Data.Name = data.Name;
            Data.Location = data.Location;
        }
        
        public ITrackable Data { get; set; }
    }
}
