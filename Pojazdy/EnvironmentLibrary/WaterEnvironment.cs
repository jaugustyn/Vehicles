using Vehicles.Interfaces;

namespace Vehicles.EnvironmentLibrary
{
    public class WaterEnvironment : IEnvironment
    {
        public int Min { get; init; } = 1;
        public int Max { get; init; } = 40;

        public IEnvironment.EnvType Type => IEnvironment.EnvType.Water;
        public IEnvironment.SpeedUnit Unit => IEnvironment.SpeedUnit.Knots;
    }
}
