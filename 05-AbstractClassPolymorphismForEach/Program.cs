using System;

class Vehicle
{
    public string Brand;
    public string Model;
    public int Year;
    public string PlateNumber;
    public double FuelLevel;

    public Vehicle(string brand, string model, int year, string plateNumber)
    {
        this.Brand = brand;
        this.Model = model;
        this.Year = year;
        this.PlateNumber = plateNumber;
        this.FuelLevel = 100;
    }

    public string GetVehicleInfo()
    {
        return $"{Brand} {Model} ({Year}) - Plate: {PlateNumber}";
    }

    public void ShowBasicInfo()
    {
        Console.WriteLine(GetVehicleInfo());
    }
}

// ---------------- CAR ----------------
class Car : Vehicle
{
    public int DoorsCount;
    public int TrunkCapacity;
    public bool IsAutomatic;
    public int MaxSpeed;

    public Car(string brand, string model, int year, string plate,
        int doors, int trunk, bool isAuto, int maxSpeed)
        : base(brand, model, year, plate)
    {
        this.DoorsCount = doors;
        this.TrunkCapacity = trunk;
        this.IsAutomatic = isAuto;
        this.MaxSpeed = maxSpeed;
    }

    public void ShowCarInfo()
    {
        ShowBasicInfo();
        Console.WriteLine($"Qapı: {DoorsCount}, Baqaj: {TrunkCapacity}L, Avtomat: {IsAutomatic}, MaxSpeed: {MaxSpeed}");
    }

    public double CalculateFuelCost(double distance)
    {
        return (distance / 100) * 8 * 1.5;
    }
}

// ---------------- MOTORCYCLE ----------------
class Motorcycle : Vehicle
{
    public int EngineCapacity;
    public bool HasSidecar;
    public int MaxSpeed;
    public string Type;

    public Motorcycle(string brand, string model, int year, string plate,
        int engine, bool sidecar, int maxSpeed, string type)
        : base(brand, model, year, plate)
    {
        this.EngineCapacity = engine;
        this.HasSidecar = sidecar;
        this.MaxSpeed = maxSpeed;
        this.Type = type;
    }

    public void ShowMotorcycleInfo()
    {
        ShowBasicInfo();
        Console.WriteLine($"Engine: {EngineCapacity}cc, Type: {Type}, Sidecar: {HasSidecar}, MaxSpeed: {MaxSpeed}");
    }

    public double CalculateFuelCost(double distance)
    {
        return (distance / 100) * 4 * 1.5;
    }
}

// ---------------- TRUCK ----------------
class Truck : Vehicle
{
    public double CargoCapacity;
    public int AxleCount;
    public double CurrentLoad;
    public int MaxSpeed;

    public Truck(string brand, string model, int year, string plate,
        double capacity, int axle, double load, int maxSpeed)
        : base(brand, model, year, plate)
    {
        this.CargoCapacity = capacity;
        this.AxleCount = axle;
        this.CurrentLoad = load;
        this.MaxSpeed = maxSpeed;
    }

    public void ShowTruckInfo()
    {
        ShowBasicInfo();
        Console.WriteLine($"Tutum: {CargoCapacity} ton, Yük: {CurrentLoad} ton, Ox: {AxleCount}, MaxSpeed: {MaxSpeed}");
    }

    public void LoadCargo(double weight)
    {
        if (CurrentLoad + weight <= CargoCapacity)
        {
            CurrentLoad += weight;
            Console.WriteLine("Yük əlavə edildi");
        }
        else
        {
            Console.WriteLine("Tutumdan çoxdur!");
        }
    }

    public double CalculateFuelCost(double distance)
    {
        return (distance / 100) * (25 + CurrentLoad * 2) * 1.8;
    }
}

// ---------------- PROGRAM ----------------
class Program
{
    static void Main()
    {
        // Cars
        Car c1 = new Car("Mercedes", "E200", 2023, "10-AA-001", 4, 500, true, 220);
        Car c2 = new Car("BMW", "320i", 2022, "10-AA-002", 4, 480, true, 235);
        Car c3 = new Car("Toyota", "Camry", 2021, "10-AA-003", 4, 524, true, 210);

        // Motorcycles
        Motorcycle m1 = new Motorcycle("Yamaha", "R1", 2023, "10-BB-001", 998, false, 299, "Sport");
        Motorcycle m2 = new Motorcycle("Harley-Davidson", "HD", 2022, "10-BB-002", 1868, true, 180, "Cruiser");

        // Trucks
        Truck t1 = new Truck("MAN", "TGX", 2020, "10-CC-001", 18, 3, 12, 120);
        Truck t2 = new Truck("Volvo", "FH16", 2021, "10-CC-002", 25, 4, 18, 110);

        // Show info + fuel cost
        Console.WriteLine("---- Cars ----");
        c1.ShowCarInfo(); Console.WriteLine(c1.CalculateFuelCost(500));
        c2.ShowCarInfo(); Console.WriteLine(c2.CalculateFuelCost(500));
        c3.ShowCarInfo(); Console.WriteLine(c3.CalculateFuelCost(500));

        Console.WriteLine("---- Motorcycles ----");
        m1.ShowMotorcycleInfo(); Console.WriteLine(m1.CalculateFuelCost(300));
        m2.ShowMotorcycleInfo(); Console.WriteLine(m2.CalculateFuelCost(300));

        Console.WriteLine("---- Trucks ----");
        t1.ShowTruckInfo(); Console.WriteLine(t1.CalculateFuelCost(800));
        t2.ShowTruckInfo(); Console.WriteLine(t2.CalculateFuelCost(800));

        // Load cargo
        t1.LoadCargo(5);
        Console.WriteLine("Yeni xərc: " + t1.CalculateFuelCost(800));

        // Statistikalar
        int total = 7;

        double avgSpeed = (c1.MaxSpeed + c2.MaxSpeed + c3.MaxSpeed +
                           m1.MaxSpeed + m2.MaxSpeed +
                           t1.MaxSpeed + t2.MaxSpeed) / 7.0;

        Console.WriteLine("Ümumi say: " + total);
        Console.WriteLine("Orta sürət: " + avgSpeed);

        double maxCost = Math.Max(
            Math.Max(c1.CalculateFuelCost(500), c2.CalculateFuelCost(500)),
            Math.Max(c3.CalculateFuelCost(500),
            Math.Max(m1.CalculateFuelCost(300),
            Math.Max(m2.CalculateFuelCost(300),
            Math.Max(t1.CalculateFuelCost(800), t2.CalculateFuelCost(800))))))
        );

        Console.WriteLine("Ən bahalı xərc: " + maxCost);
    }
}
