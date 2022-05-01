using System.Text;
using Vehicles.EnvironmentLibrary;
using Vehicles.Interfaces;

namespace Vehicles.VehicleLibrary
{
    public class MultidimensionalVehicle : IVehicle
    {
        private readonly bool _isLandVehicle;
        private readonly bool _isWaterVehicle;
        private readonly bool _isAirVehicle;
        public bool HasEngine { get; set; }
        public int EnginePower { get; set; }
        public double Speed { get; set; }
        public int Wheels { get; set; }
        public int Displacement { get; set; }
        public IEnvironment CurrentEnvironment { get; set; } = Environments.LandEnv;
        public IVehicle.VehicleState State { get; set; } = IVehicle.VehicleState.Stationary;
        public IVehicle.VehicleFuelType FuelType { get; set; }
        public IVehicle.VehicleType TypeOfVehicle { get; init; } = IVehicle.VehicleType.Multidimensional;

        public MultidimensionalVehicle(bool isLandVehicle, bool isWaterVehicle, bool isAirVehicle, int wheels, int displacement, bool hasEngine, int enginePower,
                                        IVehicle.VehicleFuelType fuelType, IEnvironment currentEnvironment)
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

            _isLandVehicle = isLandVehicle;
            _isWaterVehicle = isWaterVehicle;
            _isAirVehicle = isAirVehicle;

            Wheels = (wheels > 0) ? wheels : 0;
            Displacement = (displacement > 0 && _isWaterVehicle) ? displacement : 0;

            if (currentEnvironment.Equals(Environments.AirEnv))
                throw new Exception("Vehicle cannot be created in air.");
            if (!_isLandVehicle && currentEnvironment.Equals(Environments.LandEnv))
                throw new Exception("It's not land vehicle, so it cannot operate in Land Environment!");
            if (!_isWaterVehicle && currentEnvironment.Equals(Environments.WaterEnv))
                throw new Exception("It's not water vehicle, so it cannot operate in Water Environment!");
            if (!_isAirVehicle && currentEnvironment.Equals(Environments.AirEnv))
                throw new Exception("It's not air vehicle, so it cannot operate in Air Environment!");
        }

        public void ChangeEnvironment(IEnvironment to)
        {
            if (State == IVehicle.VehicleState.Stationary) return;
            if (to.Equals(Environments.AirEnv) || CurrentEnvironment.Equals(Environments.AirEnv))
                throw new Exception("You cannot suddenly change to/from air environment");

            Speed = IVehicle.ConvertSpeedUnit(CurrentEnvironment.Unit, to.Unit, Speed);
            CurrentEnvironment = to;

            if (Speed > CurrentEnvironment.Max) Speed = CurrentEnvironment.Max;
            if (Speed < CurrentEnvironment.Min) Speed = CurrentEnvironment.Min;
        }

        public void Accelerate(double boost)
        {
            if (State == IVehicle.VehicleState.Stationary) return;

            if (CurrentEnvironment.Equals(Environments.LandEnv))
                Speed = Environments.LandEnv.Max < Speed + boost ? Environments.LandEnv.Max : Math.Round(Speed + boost, 3);
            else if (CurrentEnvironment.Equals(Environments.WaterEnv))
                Speed = Environments.WaterEnv.Max < Speed + boost ? Environments.WaterEnv.Max : Math.Round(Speed + boost, 3);
            else
                Speed = Environments.AirEnv.Max < Speed + boost ? Environments.AirEnv.Max : Math.Round(Speed + boost, 3);

            if (!CurrentEnvironment.Equals(Environments.AirEnv) && _isAirVehicle)
            {
                var speedMs = IVehicle.ConvertSpeedUnit(CurrentEnvironment.Unit, IEnvironment.SpeedUnit.Ms, Speed);

                if (speedMs >= Environments.AirEnv.Min && !CurrentEnvironment.Equals(Environments.AirEnv))
                {
                    Speed = speedMs;
                    CurrentEnvironment = Environments.AirEnv;
                }
            }
        }

        public void Decelerate(double reduce)
        {
            if (State == IVehicle.VehicleState.Stationary) return;

            if (CurrentEnvironment.Equals(Environments.LandEnv))
                Speed = Environments.LandEnv.Min > Speed - reduce ? Environments.LandEnv.Min : Math.Round(Speed - reduce, 3);
            else if (CurrentEnvironment.Equals(Environments.WaterEnv))
                Speed = Environments.WaterEnv.Min > Speed - reduce ? Environments.WaterEnv.Min : Math.Round(Speed - reduce, 3);
            else
                Speed = Environments.AirEnv.Min > Speed - reduce ? Environments.AirEnv.Min : Math.Round(Speed - reduce, 3);

            if (CurrentEnvironment.Equals(Environments.AirEnv) && Speed <= CurrentEnvironment.Min) CurrentEnvironment = Environments.LandEnv;
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

            info.Append(
                $"Land vehicle: {_isLandVehicle}\n" +
                $"Water vehicle: {_isWaterVehicle}\n" +
                $"Air vehicle: {_isAirVehicle}\n"
            );
            return info.ToString();
        }
    }
}
