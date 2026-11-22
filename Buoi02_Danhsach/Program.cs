//Bài 1
using System;

class Program
{
    static void Main()
    {
        // a. Nhập n và danh sách n số nguyên dương
        Console.Write("Nhập số lượng phần tử n: ");
        int n = int.Parse(Console.ReadLine());

        int[] a = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write($"Nhập a[{i}] (số nguyên dương): ");
                a[i] = int.Parse(Console.ReadLine());
            } while (a[i] <= 0);
        }

        // b. Hiển thị danh sách ra màn hình, các phần tử cách nhau 1 khoảng trống
        Console.WriteLine("\nDanh sách ban đầu:");
        HienThi(a, n);

        // c. Chèn phần tử x vào vị trí k của dãy
        Console.Write("\nNhập giá trị x cần chèn: ");
        int x = int.Parse(Console.ReadLine());

        int k;
        do
        {
            Console.Write($"Nhập vị trí k cần chèn (từ 0 đến {n}): ");
            k = int.Parse(Console.ReadLine());
        } while (k < 0 || k > n);

        for (int i = n; i > k; i--)
        {
            a[i] = a[i - 1];
        }

        a[k] = x;
        n++;

        Console.WriteLine("\nDanh sách sau khi chèn:");
        HienThi(a, n);
    }

    static void HienThi(int[] a, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }
}

//Bài 2
using System;

struct NhanVien
{
    public string MaNV;
    public string HoTen;
    public int NamSinh;
    public string PhongBan;
    public int LuongCoBan;
    public int Thuong;
    public int ThucLinh;
}

class Program
{
    static void Main()
    {
        Console.Write("Nhập số lượng nhân viên: ");
        int n = int.Parse(Console.ReadLine());
        NhanVien[] ds = new NhanVien[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập thông tin nhân viên thứ {i + 1} ---");
            Console.Write("Mã nhân viên: ");
            ds[i].MaNV = Console.ReadLine();
            Console.Write("Họ và tên: ");
            ds[i].HoTen = Console.ReadLine();
            Console.Write("Năm sinh: ");
            ds[i].NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Phòng ban: ");
            ds[i].PhongBan = Console.ReadLine();
            Console.Write("Lương cơ bản: ");
            ds[i].LuongCoBan = int.Parse(Console.ReadLine());
            Console.Write("Thưởng: ");
            ds[i].Thuong = int.Parse(Console.ReadLine());
            ds[i].ThucLinh = ds[i].LuongCoBan + ds[i].Thuong;
        }

        // a. Tính tổng thực lĩnh tháng của tất cả nhân viên
        long tongThucLinh = 0;
        for (int i = 0; i < n; i++)
        {
            tongThucLinh += ds[i].ThucLinh;
        }
        Console.WriteLine($"\na. Tổng thực lĩnh tháng của công ty: {tongThucLinh}");

        // b. In danh sách nhân viên có mức lương cơ bản thấp nhất
        if (n > 0)
        {
            int minLuong = ds[0].LuongCoBan;
            for (int i = 1; i < n; i++)
            {
                if (ds[i].LuongCoBan < minLuong)
                    minLuong = ds[i].LuongCoBan;
            }

            Console.WriteLine($"\nb. Nhân viên có lương cơ bản thấp nhất ({minLuong}):");
            for (int i = 0; i < n; i++)
            {
                if (ds[i].LuongCoBan == minLuong)
                    InNhanVien(ds[i]);
            }
        }

        // c. Đếm số lượng nhân viên có mức thưởng >= 1200000
        int demThuong = 0;
        for (int i = 0; i < n; i++)
        {
            if (ds[i].Thuong >= 1200000)
                demThuong++;
        }
        Console.WriteLine($"\nc. Số lượng nhân viên có mức thưởng >= 1.200.000: {demThuong}");

        // d. Sắp xếp tăng dần theo phòng ban, trùng thì giảm dần theo mã nhân viên
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int cmpPhong = string.Compare(ds[i].PhongBan, ds[j].PhongBan, StringComparison.OrdinalIgnoreCase);
                bool canDoiCho = false;

                if (cmpPhong > 0)
                {
                    canDoiCho = true;
                }
                else if (cmpPhong == 0 && string.Compare(ds[i].MaNV, ds[j].MaNV, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    canDoiCho = true;
                }

                if (canDoiCho)
                {
                    NhanVien tmp = ds[i];
                    ds[i] = ds[j];
                    ds[j] = tmp;
                }
            }
        }

        Console.WriteLine("\nd. Danh sách sau khi sắp xếp (Phòng ban tăng dần, Mã NV giảm dần):");
        for (int i = 0; i < n; i++)
        {
            InNhanVien(ds[i]);
        }

        // e. Cập nhật tăng lương cơ bản của tất cả nhân viên lên 5% và tính lại thực lĩnh
        for (int i = 0; i < n; i++)
        {
            ds[i].LuongCoBan = (int)(ds[i].LuongCoBan * 1.05);
            ds[i].ThucLinh = ds[i].LuongCoBan + ds[i].Thuong;
        }

        Console.WriteLine("\ne. Danh sách sau khi tăng lương cơ bản lên 5%:");
        for (int i = 0; i < n; i++)
        {
            InNhanVien(ds[i]);
        }
    }

    static void InNhanVien(NhanVien nv)
    {
        Console.WriteLine($"Mã: {nv.MaNV} | Tên: {nv.HoTen} | NS: {nv.NamSinh} | Phòng: {nv.PhongBan} | LCB: {nv.LuongCoBan} | Thưởng: {nv.Thuong} | Thực lĩnh: {nv.ThucLinh}");
    }
}

//Bài 3

using System;

class Program
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Nhập kích thước ma trận vuông n (0 <= n < 100): ");
            n = int.Parse(Console.ReadLine());
        } while (n < 0 || n >= 100);

        int[,] a = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"a[{i},{j}] = ");
                a[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine($"\na. Tổng tất cả phần tử: {TinhTong(a, n)}");

        int minDuong = TimDuongNhoNhat(a, n);
        if (minDuong == int.MaxValue)
            Console.WriteLine("b. Ma trận không có phần tử dương.");
        else
            Console.WriteLine($"b. Giá trị dương nhỏ nhất: {minDuong}");

        Console.WriteLine($"c. Tổng đường chéo phụ: {TongDuongCheoPhu(a, n)}");
        Console.WriteLine($"d. Đường chéo chính có tăng dần không?: {(KiemTraCheoChinhTangDan(a, n) ? "Có" : "Không")}");
    }

    static int TinhTong(int[,] a, int n)
    {
        int tong = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                tong += a[i, j];
        return tong;
    }

    static int TimDuongNhoNhat(int[,] a, int n)
    {
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (a[i, j] > 0 && a[i, j] < min)
                    min = a[i, j];
        return min;
    }

    static int TongDuongCheoPhu(int[,] a, int n)
    {
        int tong = 0;
        for (int i = 0; i < n; i++)
            tong += a[i, n - 1 - i];
        return tong;
    }

    static bool KiemTraCheoChinhTangDan(int[,] a, int n)
    {
        for (int i = 0; i < n - 1; i++)
            if (a[i, i] >= a[i + 1, i + 1])
                return false;
        return true;
    }
}

// Bài 4

using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class Program
{
    static Node pHead = null;

    static void Main()
    {
        Console.Write("Nhập số lượng phần tử: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int val;
            do
            {
                Console.Write($"Nhập phần tử thứ {i + 1} (nguyên dương): ");
                val = int.Parse(Console.ReadLine());
            } while (val <= 0);
            ThemCuoi(val);
        }

        Console.WriteLine("\nDanh sách hiện tại:");
        HienThi();

        // a. Đếm số lần xuất hiện của x
        Console.Write("\nNhập x cần đếm: ");
        int xDem = int.Parse(Console.ReadLine());
        Console.WriteLine($"a. Số phần tử bằng {xDem}: {DemBangX(xDem)}");

        // b. Tìm phần tử dương nhỏ nhất
        int minDuong = TimDuongNhoNhat();
        if (minDuong == int.MaxValue)
            Console.WriteLine("b. Danh sách rỗng.");
        else
            Console.WriteLine($"b. Phần tử dương nhỏ nhất: {minDuong}");

        // c. Xóa phần tử x xuất hiện đầu tiên
        Console.Write("\nNhập x cần xóa (xuất hiện đầu tiên): ");
        int xXoa = int.Parse(Console.ReadLine());
        XoaDauTien(xXoa);

        Console.WriteLine("c. Danh sách sau khi xóa:");
        HienThi();
    }

    static void ThemCuoi(int data)
    {
        Node moi = new Node(data);
        if (pHead == null)
        {
            pHead = moi;
            return;
        }
        Node p = pHead;
        while (p.Next != null) p = p.Next;
        p.Next = moi;
    }

    static void HienThi()
    {
        Node p = pHead;
        while (p != null)
        {
            Console.Write(p.Data + " ");
            p = p.Next;
        }
        Console.WriteLine();
    }

    static int DemBangX(int x)
    {
        int dem = 0;
        Node p = pHead;
        while (p != null)
        {
            if (p.Data == x) dem++;
            p = p.Next;
        }
        return dem;
    }

    static int TimDuongNhoNhat()
    {
        int min = int.MaxValue;
        Node p = pHead;
        while (p != null)
        {
            if (p.Data > 0 && p.Data < min) min = p.Data;
            p = p.Next;
        }
        return min;
    }

    static void XoaDauTien(int x)
    {
        Node p = pHead;
        Node t = null;

        while (p != null && p.Data != x)
        {
            t = p;
            p = p.Next;
        }

        if (p == null) return; // Không tìm thấy x

        if (t == null) // p là pHead (phần tử đầu)
            pHead = p.Next;
        else // p nằm ở giữa hoặc cuối
            t.Next = p.Next;
    }
}

// Bài 5

using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class Program
{
    static Node l = null;

    static void Main()
    {
        Console.Write("Nhập số lượng phần tử của danh sách l: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập phần tử thứ {i + 1}: ");
            ThemCuoi(int.Parse(Console.ReadLine()));
        }

        if (l == null)
        {
            Console.WriteLine("Danh sách rỗng.");
            return;
        }

        // a. Phần tử lớn nhất
        Console.WriteLine($"\na. Phần tử lớn nhất: {TimMax()}");

        // b. Tổng các phần tử
        Console.WriteLine($"b. Tổng các phần tử: {TinhTong()}");

        // c. Đếm số nguyên tố
        Console.WriteLine($"c. Số lượng số nguyên tố: {DemSoNguyenTo()}");

        // d. Đếm số âm, bằng 0, số dương
        DemAmDuongKhong();

        // e. Đếm số lượng phần tử bằng x
        Console.Write("\nNhập x cần đếm: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine($"e. Số lượng phần tử bằng {x}: {DemBangX(x)}");

        // f. Tìm phần tử dương nhỏ nhất
        int minDuong = TimDuongNhoNhat();
        if (minDuong == int.MaxValue)
            Console.WriteLine("f. Không có phần tử dương trong danh sách.");
        else
            Console.WriteLine($"f. Phần tử dương nhỏ nhất: {minDuong}");
    }

    static void ThemCuoi(int data)
    {
        Node moi = new Node(data);
        if (l == null)
        {
            l = moi;
            return;
        }
        Node p = l;
        while (p.Next != null) p = p.Next;
        p.Next = moi;
    }

    static int TimMax()
    {
        int max = int.MinValue;
        Node p = l;
        while (p != null)
        {
            if (p.Data > max) max = p.Data;
            p = p.Next;
        }
        return max;
    }

    static int TinhTong()
    {
        int tong = 0;
        Node p = l;
        while (p != null)
        {
            tong += p.Data;
            p = p.Next;
        }
        return tong;
    }

    static bool KTNT(int x)
    {
        if (x < 2) return false;
        for (int i = 2; i * i <= x; i++)
            if (x % i == 0) return false;
        return true;
    }

    static int DemSoNguyenTo()
    {
        int dem = 0;
        Node p = l;
        while (p != null)
        {
            if (KTNT(p.Data)) dem++;
            p = p.Next;
        }
        return dem;
    }

    static void DemAmDuongKhong()
    {
        int am = 0, khong = 0, duong = 0;
        Node p = l;
        while (p != null)
        {
            if (p.Data < 0) am++;
            else if (p.Data > 0) duong++;
            else khong++;
            p = p.Next;
        }
        Console.WriteLine($"d. Số âm: {am} | Số bằng 0: {khong} | Số dương: {duong}");
    }

    static int DemBangX(int x)
    {
        int dem = 0;
        Node p = l;
        while (p != null)
        {
            if (p.Data == x) dem++;
            p = p.Next;
        }
        return dem;
    }

    static int TimDuongNhoNhat()
    {
        int min = int.MaxValue;
        Node p = l;
        while (p != null)
        {
            if (p.Data > 0 && p.Data < min) min = p.Data;
            p = p.Next;
        }
        return min;
    }
}