using Vehicles.Interfaces;
using Vehicles.VehicleLibrary;

namespace Vehicles.VehicleExamples
{
    public class Submarine: WaterVehicle
    {
        private readonly IVehicle _vehicle;

        public Submarine(int displacement, int enginePower, IVehicle.VehicleFuelType fuelType) : base(displacement, true, enginePower, fuelType)
        {
            _vehicle = this;
        }

        public void Move() => _vehicle.Move();
        public void Stay() => _vehicle.Stay();
        public void Accelerate(double boost) => _vehicle.Accelerate(boost);
        public void Decelerate(double reduce) => _vehicle.Decelerate(reduce);
    }
}
