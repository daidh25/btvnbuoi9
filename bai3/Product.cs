using System;
using System.Text.RegularExpressions;

public class Product
{
    public string Ten { get; set; }
    public double Gia { get; set; }
    public int SoLuong { get; set; }
    public double DonGia { get; set; }

    public Product()
    {
        NhapThongTin();
    }

    public Product(string ten, double gia, int soLuong, double donGia)
    {
        Ten = ten;
        Gia = gia;
        SoLuong = soLuong;
        DonGia = donGia;
    }

    private string KiemTraNhap(string input, string fieldName)
    {
        while (string.IsNullOrWhiteSpace(input) || !KiemTraDuLieu(input))
        {
            Console.WriteLine($"Vui lòng nhập lại {fieldName}, không chứa ký tự đặc biệt, khoảng trắng, hoặc thẻ HTML:");
            input = Console.ReadLine();
        }
        return input;
    }

    public static bool KiemTraDuLieu(string input)
    {
        if (Regex.IsMatch(input, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
        {
            return false;
        }
        if (Regex.IsMatch(input, @"<[^>]*>") || Regex.IsMatch(input, @"<style[^>]*>.*</style>") || Regex.IsMatch(input, @"<script[^>]*>.*</script>"))
        {
            return false;
        }
        return true;
    }

    private double KiemTraNhapSo(string input, string fieldName)
    {
        double result;
        while (!double.TryParse(input, out result) || result < 0)
        {
            Console.WriteLine($"Vui lòng nhập lại {fieldName}, chỉ chứa số dương:");
            input = Console.ReadLine();
        }
        return result;
    }

    private int KiemTraNhapSoNguyen(string input, string fieldName)
    {
        int result;
        while (!int.TryParse(input, out result) || result < 0)
        {
            Console.WriteLine($"Vui lòng nhập lại {fieldName}, chỉ chứa số nguyên dương:");
            input = Console.ReadLine();
        }
        return result;
    }
    public void NhapThongTin()
    {
        Console.WriteLine("Nhập tên sản phẩm:");
        Ten = KiemTraNhap(Console.ReadLine(), "Tên sản phẩm");

        Console.WriteLine("Nhập giá sản phẩm:");
        Gia = KiemTraNhapSo(Console.ReadLine(), "Giá sản phẩm");

        Console.WriteLine("Nhập số lượng sản phẩm:");
        SoLuong = KiemTraNhapSoNguyen(Console.ReadLine(), "Số lượng sản phẩm");

        Console.WriteLine("Nhập đơn giá sản phẩm:");
        DonGia = KiemTraNhapSo(Console.ReadLine(), "Đơn giá sản phẩm");
    }
}
