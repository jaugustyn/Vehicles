using Vehicles.Interfaces;

namespace Vehicles.EnvironmentLibrary
{
    public class AirEnvironment: IEnvironment
    {
        public int Min { get; init; } = 20;
        public int Max { get; init; } = 200;

        public IEnvironment.EnvType Type => IEnvironment.EnvType.Air;
        public IEnvironment.SpeedUnit Unit => IEnvironment.SpeedUnit.Ms;
    }
}
