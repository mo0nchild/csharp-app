// C# Event System Testing 
namespace MyEvent 
{
    public class UserMessage
    {
        public string Text { get; init; }
        public UserMessage(string text) => Text = text;
    }

    public class User
    {
        public delegate void UserEvent(User person, UserMessage e);
        public event UserEvent? UserAction;

        string? name;
        public string Name
        {
            get => name ?? "none";
            init
            {
                name = value;
                Email = $"{name}@gmail.com";
            }
        }
        public string Email { get; init; }
        public uint Age { get; init; }

        public User(string name, uint age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void UserMoving()
        {
            Console.WriteLine("User is moving");
            UserAction?.Invoke(this, new("Moving"));
        }

        public void Calculate(double x1, double x2)
        {
            Console.WriteLine((x1+x2).ToString());
            UserAction?.Invoke(this, new("User is calculating"));
        }

        internal void Print() => Console.WriteLine("Hello, " + this.Name);
    }

    public static class TestUser 
    {
        public static void Run() 
        {
            var person = new User("Mike", 18);
            person.UserAction += delegate (User u, UserMessage e)
            {
                Console.WriteLine($"{u.Name}\t->\t{e.Text}");
            };
            person.UserMoving();
            person.Calculate(123, 123);
        }
    }
}


// Simple Messenger prototype (Test Inheritance & Generic)
namespace MyInheritance
{
    class Messenger<T> where T : Message
    {
        public static void SendMessage(T msg) => Console.WriteLine(msg.MessageText);
    }

    abstract class Message
    {
        public string MessageText { get; init; }
        public Message(string text) => MessageText = text;
    }

    class SmsMessage : Message
    {
        public uint PhoneNumber { get; init; }
        public SmsMessage(string msg, uint number)
            : base(msg) => PhoneNumber = number;
    }

    class EmailMessage : Message
    {
        public string Email { get; init; }
        public EmailMessage(string msg, string email)
            : base(msg) => Email = email;
    }

    public static class RunMessenger
    {
        public static void Run(string[] args)
        {
            Console.Write("Input message: ");
            string? msg = Console.ReadLine();
            Messenger<EmailMessage>.SendMessage(new EmailMessage($"Hello, {msg}", "test@gmail.com"));
        }
    }
}




// Working with C# Exception (&personal class)
namespace MyException 
{
    class TestException : Exception
    {
        public string Value { get; init; }
        public TestException(string msg, string value)
            : base(msg) => Value = value;
    }

    class MyException
    {
        public static void Check(int m = 0)
        {
            try
            {
                throw new TestException("Exception Message", "Value");
            }
            catch (TestException e)
            {
                Console.WriteLine($"{e.Value}");
            }
            catch (Exception e) when (m == 0)
            {
                Console.WriteLine($"m=0\t{e.Message}");
            }
            finally
            {
                Console.WriteLine("end game");
            }
        }
    }
}