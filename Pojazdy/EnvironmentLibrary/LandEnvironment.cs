using Vehicles.Interfaces;

namespace Vehicles.EnvironmentLibrary
{
    public class LandEnvironment: IEnvironment
    {
        public int Min { get; init; } = 1;
        public int Max { get; init; } = 350;

        public IEnvironment.EnvType Type => IEnvironment.EnvType.Land;
        public IEnvironment.SpeedUnit Unit => IEnvironment.SpeedUnit.Kmh;
    }
}
