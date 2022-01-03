
namespace MyApp;

delegate void EventTest(int ID);
class TestEvent
{
    public event EventTest SendEvent;

    public int ID { get; set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public TestEvent(int ID)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    {
        this.ID = ID;
    }

    public void Doshit()
    {
        this.ID += 8;
        SendEvent(this.ID);
    }

}

public abstract class User
{
    protected string name;
    protected string email;
    protected uint age;
    public User(string name, string email, uint age)
    {
        this.age = age;
        this.name = name;
        this.email = email;
    }

    public virtual void Print_Info()
    {
        Console.WriteLine(@$"
        {age}->
        {name} == {email}");
    }
    public abstract object Get_Data();
}

public class Human : User
{
    public uint phone;
    public Human(string name, string email, uint age) : base(name, email, age)
    {
        this.phone = age + (uint)Math.Pow(10, 4);
    }
    public override object Get_Data()
    {
        return phone;
    }
    public override void Print_Info()
    {
        base.Print_Info();
        Console.WriteLine($"{this.phone}\t->\t{this.name}");
    }
}

public record struct Usser(int FirstName, string LastName);
