using Vehicles.Interfaces;
using Vehicles.VehicleLibrary;

namespace Vehicles.VehicleExamples
{
    public class Amphibian : MultidimensionalVehicle
    {
        private readonly IVehicle _vehicle;

        public Amphibian(int horsePower, IVehicle.VehicleFuelType fuelType, int displacement,
            IEnvironment currentEnvironment) : base(true, true, false, 0, displacement, true, horsePower, fuelType,
            currentEnvironment)
        {
            _vehicle = this;
        }

        public void Move() => _vehicle.Move();
        public void Stay() => _vehicle.Stay();
    }
}
