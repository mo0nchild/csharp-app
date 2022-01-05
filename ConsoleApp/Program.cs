namespace MyProgram;
abstract class Person
{
    protected uint age;
    public uint Age 
    {
        get => this.age;
        set 
        {
            if ((age = value) >= 100) this.IsDead = true;        
        }
    }
    public string Name { get; init; }
    public bool IsDead { get; private set; } = false;
    public Person(string name = "none", uint age = 0) 
    {
        this.Name = name;
        this.Age = age;
    }

    public virtual void Print() 
    {
        Console.WriteLine($"{Name}\t{Age}");
    }

    public abstract void Move();

}

class Client : Person
{
    private static uint counter = 0;
    public uint Id { get; set; } = 0;
    public Client(string name, uint age) 
        : base(name, age)
    {
        this.Id = ++counter;
    }

    public override sealed void Move()
    {
        Console.WriteLine("Walking");
    }

    public sealed override void Print()
    {
        base.Print();
        Console.WriteLine($"Id: {Id}");
    }
}

class Premium : Client 
{
    public Premium(string name, uint age) 
        : base(name, age)
    { }

}

class Admin : Person 
{
    public override void Move() => Console.WriteLine("Running");
    public Admin(string name, uint age) 
        : base(name, age)
    { }
    public override string ToString() => $"{Name}\t{Age}";
}

public class Program
{
    public static void Main(string[] args)
    {
        var shit = new Admin("123123", 12);
        var shit2 = new Admin("123123", 12);
        Console.WriteLine(shit.Equals(shit2));

        Premium mike = new("Mike", 32);
        if (mike is Person mike_person) Console.WriteLine(mike_person.Name);
    }
}
