using System;
class Program 
{
    static double Luythua(double x, double n) 
    {
       if (n == 0)
            return 1;
       return x * Luythua(x,n-1);

    }
    static void Main() 
    {
        Console.WriteLine("tinh x mu N");
        Console.WriteLine("Nhap x :");
        double x =double.Parse(Console.ReadLine());
        Console.WriteLine("Nhap n:");
        double n = double.Parse(Console.ReadLine());
        Console.WriteLine(x+"^"+n+"="+Luythua(x,n));
    }
}
