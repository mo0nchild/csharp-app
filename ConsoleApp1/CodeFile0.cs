namespace MyApp;

public class Task 
{
    public Func<Func<int>> SEE = () =>
    {
        int shit() => 12;
        return shit;
    };

    public int Testc(Func<int, int> sfa, int s)
    {
        return s + sfa(s);
    }
    public static void Run()
    {
        var (shit, asd) = new Usser { FirstName = 123, LastName = "23" };
        Console.WriteLine("Hello World!" + $"\t{shit}\t{asd}");

        var prog = new Task();
        Console.WriteLine(prog.SEE()());

        Console.WriteLine(prog.Testc((int s) => {
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


        User user = new Human("Mike", "shit@gmail.com", 14);
        Console.WriteLine(user.Get_Data());
        user.Print_Info();




        var test = new TestEvent(120);
        test.SendEvent += GetInfo;
        test.SendEvent += (int ID) => {
            Console.WriteLine("\t\tASDASDASDASDASds" + ID);
        };
        test.Doshit();

        var sss = new
        {
            Name = "TOm",
            Age = 123,
        };
    }

    public static void GetInfo(int ID)
    {
        Console.WriteLine($"current ID: {ID}");
    }
}


