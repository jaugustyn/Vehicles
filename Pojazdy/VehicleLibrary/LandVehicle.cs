using System.Text;
using Vehicles.EnvironmentLibrary;
using Vehicles.Interfaces;

namespace Vehicles.VehicleLibrary
{
    public class LandVehicle : IVehicle
    {
        public bool HasEngine { get; set; }
        public int EnginePower { get; set; }
        public double Speed { get; set; }
        public int Wheels { get; set; }
        public IEnvironment CurrentEnvironment { get; init; } = Environments.LandEnv;
        public IVehicle.VehicleState State { get; set; } = IVehicle.VehicleState.Stationary;
        public IVehicle.VehicleFuelType FuelType { get; set; }
        public IVehicle.VehicleType TypeOfVehicle { get; init; } = IVehicle.VehicleType.Land;

        public LandVehicle(int wheels, bool hasEngine, int enginePower, IVehicle.VehicleFuelType fuelType)
        {
            Wheels = wheels > 0 ? wheels : 0;
            if (hasEngine)
            {
                HasEngine = hasEngine;
                EnginePower = (enginePower) > 0 ? enginePower : 1;
                FuelType = fuelType;
            }
            else
            {
                HasEngine = false;
                EnginePower = 0;
                FuelType = IVehicle.VehicleFuelType.None;
            }
        }

        public override string ToString()
        {
            var info = new StringBuilder(
                $"Object type: {GetType().Name}\n" +
                $"Vehicle type: {TypeOfVehicle}\n" +
                $"Current environment: {CurrentEnvironment.Type}\n" +
                $"State: {State}\n" +
                $"Minimum speed: {CurrentEnvironment.Min} {CurrentEnvironment.Unit}\n" +
                $"Maximum speed: {CurrentEnvironment.Max} {CurrentEnvironment.Unit}\n" +
                $"Current speed: {Speed} {CurrentEnvironment.Unit}\n" +
                $"Number of wheels: {Wheels}\n" +
                $"Has engine: {HasEngine}\n"
                );

            if (HasEngine)
            {
                info.Append(
                    $"Engine power: {EnginePower}\n" +
                    $"Fuel type: {FuelType}\n"
                    );
            }
            return info.ToString();
        }
    }
}
