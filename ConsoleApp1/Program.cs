using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    delegate void EventTest(int ID);
    class TestEvent 
    {
        

        public event EventTest SendEvent;

        public int ID { get; set; }
        public TestEvent(int ID) 
        {
            this.ID = ID; 
        }

        public void doshit() 
        {
            this.ID++;
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
            this.phone = age+(uint)Math.Pow(10,4);
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

    public record struct user(int FirstName, string LastName);
    public class Program
    {
        public Func<Func<int>> SEE = () =>
        {
            int shit() => 12;
            return shit;
        };

        public int testc(Func<int, int> sfa, int s)
        {
            return s + sfa(s);
        }
        public static void Main(string[] args)
        {
            var (shit, asd) = new user { FirstName = 123, LastName = "23" };
            Console.WriteLine("Hello World!" + $"\t{shit}\t{asd}");

            var prog = new Program();
            Console.WriteLine(prog.SEE()());

            Console.WriteLine(prog.testc((int s) => {
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


            test.doshit();

            var sss = new {
                Name = "TOm",
                Age = 123,
            };
        }

        public static void GetInfo(int ID) 
        {
            Console.WriteLine($"current ID: {ID}");
        }
    }

}