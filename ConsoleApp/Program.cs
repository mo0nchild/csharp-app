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
    public static void Main(string[] args)
    {
        Messenger<EmailMessage>.SendMessage(new EmailMessage("Hello, From Program", "test@gmail.com"));
    }
}
