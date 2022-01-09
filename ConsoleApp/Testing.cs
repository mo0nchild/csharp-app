namespace MyApp;

public class Task 
{
    public static Func<Func<int>> Closure = () =>
    {
        int shit() => 12;
        return shit;
    };

    public static int Testc(Func<int, int> sfa, int s) => s + sfa(s);

    public static void Run()
    {
        var (var1, var2) = (123, "message");
        Console.WriteLine("Hello World!" + $"\t{var1}\t{var2}");

        Console.WriteLine(Closure()());
        Console.WriteLine(Testc((int s) => {
            return 12 + s;
        }, 20));

        unsafe
        {
            int a = 100;
            int* p = &a;
            (*p)++;
            Console.WriteLine($"{(*p)} {a}");
        }


        new List<int> { 1123, 2123, 3123, 4234 }.ForEach((e) => {
            Console.WriteLine(e);
        });

        var Object = new
        {
            Name = "Tom",
            Age = 123,
        };
    }
}


