namespace Vehicles.Interfaces
{
    public interface IEnvironment
    {
        enum SpeedUnit { Kmh, Knots, Ms }
        enum EnvType { Land, Water, Air }
        int Min { get; }
        int Max { get; }
        SpeedUnit Unit { get; }
        EnvType Type { get; }
    }
}
