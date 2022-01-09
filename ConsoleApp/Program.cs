namespace MyProgram;

class Engine 
{
    public int Power { get; init; }
    public string Company { get; init; }

    public Engine(int power, string company) 
    {
        Power = power;
        Company = company;
    }

    public override string ToString() => $"Power: {Power}\tCompany: {Company}";

}

interface IDrive 
{
    void Drive();
    delegate void DriveDelegate(Person person, string message);
    event DriveDelegate StartDrive;
}

abstract class Person
{
    private int age;
    public string FullName { get; init; }

    public Person(string name, int age) 
    {
        FullName = name;
        this.age = age;
    }
    public override string ToString() => $"FullName: {FullName}\tAge: {age}";

}

class Driver : Person, IDrive
{
    public int Experience { get; init; }
    public Driver(string name, int age, int exp)
        : base(name, age) => Experience = exp;

    public event IDrive.DriveDelegate? StartDrive;

    public void Drive()
    {
        Console.WriteLine("Drive!");
        StartDrive?.Invoke(this, "Im start drive");
    }
}

abstract class Car 
{
    public string CarClass { get; init; }
    public string Marka { get; init; }
    public Engine InstalledEngine { get; init; }
    public Driver CurrentDriver { get; init; }

    public Car(string carClass, string marka, Engine engine, Driver driver)
    {
        CurrentDriver = driver;
        InstalledEngine = engine;
        CarClass = carClass;
        Marka = marka;
    }

    public void Start() => Console.WriteLine("Поехали");
    public void Stop() => Console.WriteLine("Останавливаемся");
    public void TurnRight() => Console.WriteLine("Поворот направо");
    public void TurnLeft() => Console.WriteLine("Поворот налево");
    public override string ToString() => $"CarClass: {CarClass}\tMarka: {Marka}\n" +
        $"InstalledEngine: {InstalledEngine.Power}\tCurrentDriver: {CurrentDriver.FullName}";

}

class Lorry : Car 
{
    public int Carrying { get; init; }
    public Lorry(int carry, string carClass, string marka, Engine engine, Driver driver)
        : base(carClass, marka, engine, driver) => Carrying = carry;
    public override string ToString() => $"Carrying: {Carrying}";
}

class SportCar : Car 
{
    public double Speed { get; init; }
    public SportCar(double speed, string carClass,
        string marka, Engine engine, Driver driver)
        : base(carClass, marka, engine, driver) => Speed = speed;
}

public static class Racing 
{
    static void TestCar(Car car) => Console.WriteLine(car.ToString());
    static void Race(IDrive drive) => drive.Drive();

    public static void Start()
    {
        var person = new Driver("Ivan", 30, 100);
        TestCar(
            new SportCar(
                speed: 30.2,
                carClass: "SuperCar",
                marka: "Lada",
                engine: new Engine(30, "LadaEndine"),
                driver: person
            )
        );
        person.StartDrive += (Person p, string m) => Console.WriteLine($"{p.FullName} -> {m}");
        Race(person);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Racing.Start();
    }
}
