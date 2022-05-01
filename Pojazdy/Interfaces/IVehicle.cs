using Vehicles.EnvironmentLibrary;

namespace Vehicles.Interfaces
{
    public interface IVehicle
    {
        enum VehicleState { Moving, Stationary }
        enum VehicleFuelType { Petrol, Lpg, Electric, Oil, JetFuel, Nuclear, Other, None }
        enum VehicleType { Land, Water, Air, Multidimensional }

        bool HasEngine { get; }
        int EnginePower { get; }
        double Speed { get; set; }

        IEnvironment CurrentEnvironment { get; }
        VehicleState State { get; set; }
        VehicleFuelType FuelType { get; }
        VehicleType TypeOfVehicle { get; }

        void Move()
        {
            if (State == VehicleState.Moving || CurrentEnvironment.Equals(Environments.AirEnv)) return;
            State = VehicleState.Moving;
            Speed = CurrentEnvironment.Min;
            Console.WriteLine($"*{GetType().Name} has started*\n");
        }

        void Stay()
        {
            if (State == VehicleState.Stationary || CurrentEnvironment.Equals(Environments.AirEnv)) return;
            State = VehicleState.Stationary;
            Speed = 0;
            Console.WriteLine($"*{GetType().Name} has stopped*\n");
        }

        void Accelerate(double boost)
        {
            if (State != VehicleState.Stationary) Speed = CurrentEnvironment.Max < Speed + boost ? CurrentEnvironment.Max : Math.Round(Speed + boost,2);
        }

        void Decelerate(double reduce)
        {
            if (State != VehicleState.Stationary) Speed = CurrentEnvironment.Min > Speed - reduce ? CurrentEnvironment.Min : Math.Round(Speed - reduce, 2);
        }

        static double ConvertSpeedUnit(IEnvironment.SpeedUnit from, IEnvironment.SpeedUnit to, double speed)
        {
            switch (from, to)
            {
                case (IEnvironment.SpeedUnit.Kmh, IEnvironment.SpeedUnit.Knots):
                    return Math.Round(speed * 0.5399568, 2);
                case (IEnvironment.SpeedUnit.Kmh, IEnvironment.SpeedUnit.Ms):
                    return Math.Round(speed * 0.2777778, 2);
                case (IEnvironment.SpeedUnit.Knots, IEnvironment.SpeedUnit.Kmh):
                    return Math.Round(speed * 1.852, 2);
                case (IEnvironment.SpeedUnit.Knots, IEnvironment.SpeedUnit.Ms):
                    return Math.Round(speed * 1.514444, 2);
                case (IEnvironment.SpeedUnit.Ms, IEnvironment.SpeedUnit.Kmh):
                    return Math.Round(speed * 3.6, 2);
                case (IEnvironment.SpeedUnit.Ms, IEnvironment.SpeedUnit.Knots):
                    return Math.Round(speed * 1.943844, 2);
                default:
                    return speed;
            }
        }
    }
}
