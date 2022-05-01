using System.Text;
using Vehicles.EnvironmentLibrary;
using Vehicles.Interfaces;

namespace Vehicles.VehicleLibrary
{
    public class WaterVehicle : IVehicle
    {
        public bool HasEngine { get; set; }
        public int EnginePower { get; set; }
        public int Displacement { get; set; }
        public double Speed { get; set; } = 0;
        public IEnvironment CurrentEnvironment { get; init; } = Environments.WaterEnv;
        public IVehicle.VehicleState State { get; set; } = IVehicle.VehicleState.Stationary;
        public IVehicle.VehicleFuelType FuelType { get; init; }
        public IVehicle.VehicleType TypeOfVehicle { get; init; } = IVehicle.VehicleType.Water;

        public WaterVehicle(int displacement, bool hasEngine, int enginePower, IVehicle.VehicleFuelType fuelType)
        {
            Displacement = displacement > 0 ? displacement : 0;
            if (hasEngine)
            {
                HasEngine = hasEngine;
                EnginePower = enginePower > 0 ? enginePower : 1;
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
                $"Displacement: {Displacement} t\n" +
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