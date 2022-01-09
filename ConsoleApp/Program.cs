namespace MyProgram;

class Counter 
{
    public int Value { get; init; }

    public Counter(int value)
    {
        Value = value;
    }

    public static Counter operator + (Counter x, Counter y) => new Counter(x.Value + y.Value);
}

public class Program
{
    public static void Main(string[] args)
    {
        Counter counter1 = new(123);
        Counter counter2 = new(123);
        counter1 += counter2;

        Console.WriteLine(counter1.Value);
    }
}
