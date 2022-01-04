using MyLib;
namespace MyProgram;

public class Program
{
    
    public static void Main(string[] args)
    {
        
        var steve = new User("Steve", 18);
        Console.WriteLine(steve.Email);
        
    }
}
