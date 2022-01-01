namespace MyProgram;

public class Program
{
    public static void Main(string[] args)
    {
        sbyte[] arr = { 1, 2, 3, 4, 5, 6, 7 };
        for (int i = 0; i < arr.Length / 2; i++)
        {
            //(arr[i], arr[^i]) = (arr[^i], arr[i]);
            int buffer = arr[^i];
            arr[^i] = arr[i];
            arr[i] = (sbyte)buffer;
        }

        foreach (int i in arr) Console.Write($"{i}\t");
    }
}
