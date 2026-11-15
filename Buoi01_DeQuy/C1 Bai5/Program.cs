using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap so nguyen duong n: ");
        int n = int.Parse(Console.ReadLine());

        if (n == 0)
        {
            Console.WriteLine("So Fibonacci thu 0 la: 0");
            return;
        }
        if (n == 1)
        {
            Console.WriteLine("So Fibonacci thu 1 la: 1");
            return;
        }

        long f0 = 0, f1 = 1, fn = 0;
        for (int i = 2; i <= n; i++)
        {
            fn = f0 + f1;
            f0 = f1;
            f1 = fn;
        }

        Console.WriteLine($"So Fibonacci thu {n} la: {fn}");
    }
}