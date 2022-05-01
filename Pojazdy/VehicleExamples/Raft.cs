using Vehicles.Interfaces;
using Vehicles.VehicleLibrary;

namespace Vehicles.VehicleExamples
{
    public class Raft: WaterVehicle
    {
        private readonly IVehicle _vehicle;

        public Raft(int displacement) : base(displacement, false, 0, IVehicle.VehicleFuelType.None)
        {
            _vehicle = this;
            _vehicle.State = IVehicle.VehicleState.Moving;
            _vehicle.Speed = 1;
        }

        public void Move()
        {
            Console.WriteLine("*Raft is moving! Water does a good job*\n");
        }

        public void Stay()
        {
            Console.WriteLine("*Raft stopped... But did it really work?*\n");
        }

        public void Accelerate(double boost)
        {
            Console.WriteLine($"*And how are you going to accelerate that raft by {boost} {CurrentEnvironment.Unit}?*\n");
        }

        public void Decelerate(double reduce)
        {
            Console.WriteLine($"*Raft is trying to slow down the water current by {reduce} {CurrentEnvironment.Unit}*\n*Failed...*\n");
        }
    }
}
