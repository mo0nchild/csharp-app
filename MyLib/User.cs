namespace MyLib;

public class User
{
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

    internal void Print() => Console.WriteLine("Hello, " + this.Name);
}
