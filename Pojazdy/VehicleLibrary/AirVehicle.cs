using System.Text;
using Vehicles.EnvironmentLibrary;
using Vehicles.Interfaces;

namespace Vehicles.VehicleLibrary
{
    public class AirVehicle : IVehicle
    {
        public bool HasEngine { get; set; }
        public int EnginePower { get; set; }
        public double Speed { get; set; } = 0;
        public IEnvironment CurrentEnvironment { get; set; } = Environments.LandEnv;
        public IVehicle.VehicleState State { get; set; } = IVehicle.VehicleState.Stationary;
        public IVehicle.VehicleFuelType FuelType { get; set; }
        public IVehicle.VehicleType TypeOfVehicle { get; init; } = IVehicle.VehicleType.Air;

        public AirVehicle(bool hasEngine, int enginePower, IVehicle.VehicleFuelType fuelType)
        {
            if (hasEngine)
            {
                HasEngine = hasEngine;
                EnginePower = (enginePower > 0) ? enginePower : 1;
                FuelType = fuelType;
            }
            else
            {
                HasEngine = false;
                EnginePower = 0;
                FuelType = IVehicle.VehicleFuelType.None;
            }
        }
        public void Accelerate(double boost)
        {
            if (State == IVehicle.VehicleState.Stationary) return;

            Speed = Environments.AirEnv.Max < Speed + boost ? Environments.AirEnv.Max : Math.Round(Speed + boost, 3);
            var speedMs = IVehicle.ConvertSpeedUnit(IEnvironment.SpeedUnit.Kmh, IEnvironment.SpeedUnit.Ms, Speed);

            if (speedMs >= Environments.AirEnv.Min && !CurrentEnvironment.Equals(Environments.AirEnv))
            {
                Speed = speedMs;
                CurrentEnvironment = Environments.AirEnv;
            }
        }

        public void Decelerate(double reduce)
        {
            if (State == IVehicle.VehicleState.Stationary) return;
            Speed = Environments.AirEnv.Min > Speed - reduce ? Environments.AirEnv.Min : Math.Round(Speed - reduce, 3);

            if (Speed <= Environments.AirEnv.Min && CurrentEnvironment.Equals(Environments.AirEnv))
            {
                CurrentEnvironment = Environments.LandEnv;
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