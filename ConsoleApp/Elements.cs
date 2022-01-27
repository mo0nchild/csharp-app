// Simple Exaple C# OOP
namespace RaceModeling 
{
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
}

// Create Enumerator
namespace MyEnumerator 
{
    class Company : IEnumerable<Person>
    {
        Person[] people;
        public Person? this[int index]
        {
            get
            {
                if (index >= people.Length || index < 0) return null;
                return people[index];
            }
            set
            {
                if (index >= people.Length || index < 0) throw new ArgumentOutOfRangeException();
                people[index] = value ?? new Person("None", -1);
            }
        }

        public Company(Person[] people)
        {
            this.people = people;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return new CompanyEnumerator(people);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// iterator GetEnum
        /// </summary>
        /// <returns>element of people array</returns>
        public IEnumerable<Person> GetEnum()
        {
            Console.WriteLine("asdasdas");
            for (int i = 0; i < 2; i++)
            {
                yield return people[i];
            }
        }
    }

    internal class CompanyEnumerator : IEnumerator<Person>
    {
        Person[] people;
        int position = -1;
        public CompanyEnumerator(Person[] people)
        {
            this.people = people;
        }

        public Person Current
        {
            get
            {
                if (position == -1 || position >= people.Length)
                    throw new ArgumentException();
                return people[position];
            }
        }

        object IEnumerator.Current => throw new Exception("Уебак?");

        public void Dispose()
        { }

        public bool MoveNext()
        {
            if (position < people.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset() => position = -1;
    }

    public record Person(string Name, int Id);

    public class Program
    {
        public static void Run(string[] args)
        {
            Company facebook = new(new Person[] {
                new("Mike", 1),
                new("Tom", 2),
                new("Kate", 3),
                new("Adolf", 4),
            });

            foreach (var person in facebook) Console.WriteLine($"{person.Name}\t->\t{person.Id}");
            foreach (var person in facebook.GetEnum()) Console.WriteLine($"{person.Name}\t->\t{person.Id}");
        }

    }
}

// C# Event System Testing 
namespace MyEvent 
{
    public class UserMessage
    {
        public string Text { get; init; }
        public UserMessage(string text) => Text = text;
    }

    public class User
    {
        public delegate void UserEvent(User person, UserMessage e);
        public event UserEvent? UserAction;

        string? name;
        public string Name
        {
            get => name ?? "none";
            init
            {
                name = value;
                Email = $"{name}@gmail.com";
            }
        }
        public string Email { get; init; }
        public uint Age { get; init; }

        public User(string name, uint age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void UserMoving()
        {
            Console.WriteLine("User is moving");
            UserAction?.Invoke(this, new("Moving"));
        }

        public void Calculate(double x1, double x2)
        {
            Console.WriteLine((x1+x2).ToString());
            UserAction?.Invoke(this, new("User is calculating"));
        }

        internal void Print() => Console.WriteLine("Hello, " + this.Name);
    }

    public static class TestUser 
    {
        public static void Run() 
        {
            var person = new User("Mike", 18);
            person.UserAction += delegate (User u, UserMessage e)
            {
                Console.WriteLine($"{u.Name}\t->\t{e.Text}");
            };
            person.UserMoving();
            person.Calculate(123, 123);
        }
    }
}

// Simple Messenger prototype (Test Inheritance & Generic)
namespace MyInheritance
{
    class Messenger<T> where T : Message
    {
        public static void SendMessage(T msg) => Console.WriteLine(msg.MessageText);
    }

    abstract class Message
    {
        public string MessageText { get; init; }
        public Message(string text) => MessageText = text;
    }

    class SmsMessage : Message
    {
        public uint PhoneNumber { get; init; }
        public SmsMessage(string msg, uint number)
            : base(msg) => PhoneNumber = number;
    }

    class EmailMessage : Message
    {
        public string Email { get; init; }
        public EmailMessage(string msg, string email)
            : base(msg) => Email = email;
    }

    public static class RunMessenger
    {
        public static void Run(string[] args)
        {
            Console.Write("Input message: ");
            string? msg = Console.ReadLine();
            Messenger<EmailMessage>.SendMessage(new EmailMessage($"Hello, {msg}", "test@gmail.com"));
        }
    }
}

// Working with C# Exception (&personal class)
namespace MyException 
{
    class TestException : Exception
    {
        public string Value { get; init; }
        public TestException(string msg, string value)
            : base(msg) => Value = value;
    }

    class MyException
    {
        public static void Check(int m = 0)
        {
            try
            {
                throw new TestException("Exception Message", "Value");
            }
            catch (TestException e)
            {
                Console.WriteLine($"{e.Value}");
            }
            catch (Exception e) when (m == 0)
            {
                Console.WriteLine($"m=0\t{e.Message}");
            }
            finally
            {
                Console.WriteLine("end game");
            }
        }
    }
}