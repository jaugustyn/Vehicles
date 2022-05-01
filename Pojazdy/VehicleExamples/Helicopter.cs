using Vehicles.Interfaces;
using Vehicles.VehicleLibrary;

namespace Vehicles.VehicleExamples
{
    public class Helicopter: AirVehicle
    {
        private readonly IVehicle _vehicle;

        public Helicopter(int enginePower, IVehicle.VehicleFuelType fuelType) : base(true, enginePower, fuelType)
        {
            _vehicle = this;
        }

        public void Move() => _vehicle.Move();
        public void Stay() => _vehicle.Stay();
    }
}
