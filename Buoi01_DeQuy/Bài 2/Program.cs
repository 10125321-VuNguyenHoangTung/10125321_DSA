using System;
class Program 
{
    static void Main() 
    {
        Console.WriteLine("Tinh tong cac so tu 1 den N binh phuong");
        Console.WriteLine("Nhap N:");
        int N = int.Parse(Console.ReadLine());
        int tong = Tinhtong(N);
        Console.WriteLine("Tong binh phuong tu 1 den N la: " + tong);

    }
    static  int Tinhtong(int N) 
    {
        if (N == 0)
            return 0;
        if (N == 1) 
            return 1;
        return N * N +(N - 1);

    }
}