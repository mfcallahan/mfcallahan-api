namespace MfcallahanAPI.Models;

public class MapLocation
{
    public MapLocation(string location, double lat, double lon)
    {
        Location = location;
        Lat = lat;
        Lon = lon;
    }

    public string Location { get; }
    public double Lat { get; }
    public double Lon { get; }
}
