// See https://aka.ms/new-console-template for more information

using Vehicles.EnvironmentLibrary;
using Vehicles.Interfaces;
using Vehicles.VehicleExamples;

List<IVehicle> vehicles = new List<IVehicle>();

var passengerCar = new Car(85, IVehicle.VehicleFuelType.Electric);
passengerCar.Move();
passengerCar.Accelerate(159);

var amphibian = new Amphibian(-9, IVehicle.VehicleFuelType.Petrol, 20, Environments.WaterEnv);
amphibian.Move();
amphibian.ChangeEnvironment(Environments.WaterEnv);
amphibian.ChangeEnvironment(Environments.LandEnv);
amphibian.Accelerate(74);


var aircraftCarrier = new AircraftCarrier(95000, 280000, IVehicle.VehicleFuelType.Oil);
aircraftCarrier.Move();
aircraftCarrier.Accelerate(15);

var helicopter = new Helicopter(2000, IVehicle.VehicleFuelType.JetFuel);
helicopter.Accelerate(200);

var jetSkateboard = new JetSkateboard(); // Skateboard of future
jetSkateboard.Move();
jetSkateboard.Accelerate(200);

var raft = new Raft(0); // Has its own rules
raft.Move();
raft.Accelerate(500);
raft.Decelerate(1000);
raft.Stay();

var nuclearSubmarine = new Submarine(10000, 280000, IVehicle.VehicleFuelType.Nuclear);
nuclearSubmarine.Move();
nuclearSubmarine.Stay();

var bicycle = new Bicycle();
bicycle.Move();
bicycle.Accelerate(20);

vehicles.Add(passengerCar);
vehicles.Add(amphibian);
vehicles.Add(aircraftCarrier);
vehicles.Add(helicopter);
vehicles.Add(jetSkateboard);
vehicles.Add(raft);
vehicles.Add(nuclearSubmarine);
vehicles.Add(bicycle);


Console.WriteLine("\n/// Vehicle List ///\n");
foreach (var veh in vehicles)
{
    Console.WriteLine(veh);
}

Console.WriteLine("\n/// Land vehicles ///\n");
foreach (var veh in vehicles)
{
    if (veh.TypeOfVehicle == IVehicle.VehicleType.Land)
        Console.WriteLine(veh);
}

Console.WriteLine("\n/// Vehicles sorted in ascending order (Speed) ///\n");

foreach (var veh in vehicles.OrderBy(x => IVehicle.ConvertSpeedUnit(x.CurrentEnvironment.Unit, IEnvironment.SpeedUnit.Kmh, x.Speed)))
{
    Console.WriteLine(veh);
}

Console.WriteLine("\n/// Vehicles currently on Land Environment sorted in descending order (Speed) ///\n");

foreach (var veh in vehicles.OrderByDescending(x => IVehicle.ConvertSpeedUnit(x.CurrentEnvironment.Unit, IEnvironment.SpeedUnit.Kmh, x.Speed)))
{
    if (veh.CurrentEnvironment == Environments.LandEnv)
        Console.WriteLine(veh);
}