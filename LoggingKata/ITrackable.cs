namespace LoggingKata
{
    // Create two `ITrackable` variables with initial values of `null`.
    // These will be used to store your two taco bells 
    public interface ITrackable
    {
        string Name { get; set; }
        Point Location { get; set; }
    }
}