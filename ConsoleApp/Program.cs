namespace MyProgram;

class Person
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
}

class Client : Person
{
    private static uint counter = 0;
    public uint Id { get; set; } = 0;
    public Client(string name, uint age) : base(name, age)
    {
        this.Id = ++counter;
    }
}

class Admin : Person 
{
    public Admin(string name, uint age) : base(name, age)
    { }
}

public class Program
{
    
    public static void Main(string[] args)
    {
        Client mike = new("Mike", 32);
        if (mike is Person mike_person) Console.WriteLine(mike_person.Name);
    }
}
