using System;
using System.Linq;

class Program
{
    static void Bai1()
    {
        Random rand = new Random();
        int[] arr = new int[1000];
        for (int i = 0; i < 1000; i++) arr[i] = rand.Next(0, 10000);

        int max = arr[0], min = arr[0];
        foreach (int x in arr)
        {
            if (x > max) max = x;
            if (x < min) min = x;
        }
        Console.WriteLine($"Max: {max}, Min: {min}");
    }
}
 