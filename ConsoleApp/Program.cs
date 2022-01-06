namespace MyProgram;

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

public class Program
{
    static void Check(int m = 0)
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
    }
    public static void Main(string[] args)
    {
        Check(0);

        /*Console.Write("Input message: ");
        string? msg = Console.ReadLine();
        Messenger<EmailMessage>.SendMessage(new EmailMessage($"Hello, {msg}", "test@gmail.com"));*/
    }
}

class TestException : Exception 
{
    public string Value { get; init; }
    public TestException(string msg, string value)
        : base(msg) => Value = value;
}