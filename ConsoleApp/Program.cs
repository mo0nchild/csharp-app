namespace MyProgram;

public class Program
{
    
    public static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };

        int index = 0;
        try
        {
            while (true)
            {
                Console.WriteLine(arr[index++]);
            }
        }
        catch  
        {
            Console.WriteLine(index);
        }
        
    }
}
