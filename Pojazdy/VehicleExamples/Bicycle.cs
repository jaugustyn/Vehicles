using Vehicles.Interfaces;
using Vehicles.VehicleLibrary;

namespace Vehicles.VehicleExamples
{
    public class Bicycle: LandVehicle
    {
        private readonly IVehicle _vehicle;

        public Bicycle() : base(2, false, 0, IVehicle.VehicleFuelType.None)
        {
            _vehicle = this;
        }

        public void Move() => _vehicle.Move();
        public void Stay() => _vehicle.Stay();
        public void Accelerate(double boost) => _vehicle.Accelerate(boost);
        public void Decelerate(double reduce) => _vehicle.Decelerate(reduce);
    }
}
