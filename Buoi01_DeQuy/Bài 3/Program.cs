using System;
class Program
{
    static double Tinhtong(int N)
    {
        if (N == 0) return 0;
        if (N == 1) return 1;
        return 1.0 / N + Tinhtong(N - 1);
    }
    static void Main()
    {
        Console.WriteLine("Tinh tong tu 1 den 1/n");
        Console.WriteLine("Nhap N:");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine("Tong tu 1 den 1/n la: " + Tinhtong(N));
    }
}