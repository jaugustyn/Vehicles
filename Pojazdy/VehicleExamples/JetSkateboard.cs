using Vehicles.Interfaces;
using Vehicles.VehicleLibrary;

namespace Vehicles.VehicleExamples
{
    public class JetSkateboard: LandVehicle
    {
        private readonly IVehicle _vehicle;

        public JetSkateboard() : base(4, true, 1000, IVehicle.VehicleFuelType.JetFuel)
        {
            _vehicle = this;
        }

        public void Move() => _vehicle.Move();
        public void Stay() => _vehicle.Stay();
        public void Accelerate(double boost) => _vehicle.Accelerate(boost);
        public void Decelerate(double reduce) => _vehicle.Decelerate(reduce);
    }
}
