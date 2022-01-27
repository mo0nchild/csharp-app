using System.Reflection;
namespace MyProgram.Shit;

class Attr : System.Attribute 
{
    public string Name { get; set; }
    public Attr(string n) => Name = n;
}

[Attr("Users")] 
public class MyClass
{

    public string Name { get; set; }

    public void DoShit() => Console.WriteLine("SHIT");

    public MyClass(string name = "Null")
    {
        Name = name;
    }
}

public class Program
{

    static void Main(string[] args)
    {
        Type? t = Type.GetType("MyProgram.Shit.MyClass", false, true);
        if (t != null) 
        {
            Attr? attr = t.GetCustomAttribute<Attr>();

            Console.WriteLine(attr?.Name);
        }

    }
}