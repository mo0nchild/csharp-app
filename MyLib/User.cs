namespace MyLib;

public class UserMessage 
{
    public string Text { get; init; }
    public UserMessage(string text) => Text = text;
}

public class User
{
    public delegate void UserEvent(User person, UserMessage e);
    public event UserEvent? UserAction;

    string name = "";
    public string Name 
    {
        get => name;
        init 
        {
            name = value;
            Email = $"{name}@gmail.com";
        } 
    }
    public string Email { get; init; } = "";
    public uint Age { get; init; }

    public User(string name, uint age) 
    {
        this.Name = name;
        this.Age = age;
    }

    public void UserMoving() 
    {
        Console.WriteLine("Person is moving");
        UserAction?.Invoke(this, new("Moving"));
    }

    public double Calculate(double x1, double x2) 
    {
        UserAction?.Invoke(this, new("Person is calculating"));
        return x1 + x2;
    } 

    internal void Print() => Console.WriteLine("Hello, " + this.Name);
}
