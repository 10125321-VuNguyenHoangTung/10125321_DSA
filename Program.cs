using System;

class Program
{
    static string DaoNguoc(string s)
    {
        if (s.Length <= 1)
            return s;

        return DaoNguoc(s.Substring(1)) + s[0];
    }

    static void Main()
    {
        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine();

        Console.WriteLine("Chuoi dao nguoc: " + DaoNguoc(s));
    }
}
