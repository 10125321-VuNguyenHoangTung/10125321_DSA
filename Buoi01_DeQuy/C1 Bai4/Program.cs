using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int[] arr = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            arr[i] = rand.Next(0, 10000);
        }

        Console.WriteLine("Mang ban dau:");
        Console.WriteLine(string.Join(", ", arr));

        Array.Sort(arr);

        Console.WriteLine("\nMang sau khi sap xep tang dan:");
        Console.WriteLine(string.Join(", ", arr));
    }
}