using System;
class Program 
{
    static int Tinhtong(int N) 
    {
       if (N == 0) return 0;
        if(N == 1) return 1;
        return N + Tinhtong(N - 1);
    }
    static void Main() 
    {
        Console.WriteLine("Tinh tong tu 1 den N");
        Console.WriteLine("Nhap N: ");
        int N = int.Parse(Console.ReadLine());
        int tong = Tinhtong(N);
        Console.WriteLine("Tong tu 1 den N la: " + tong);
    }
    
}