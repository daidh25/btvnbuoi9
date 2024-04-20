using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class ProductManager : Product
{
    private List<Product> productList = new List<Product>();
    private string KiemTraNhap(string input, string fieldName)
    {
        while (string.IsNullOrWhiteSpace(input) || !KiemTraDuLieu(input))
        {
            Console.WriteLine($"Vui lòng nhập lại {fieldName}, không chứa ký tự đặc biệt, khoảng trắng, hoặc thẻ HTML:");
            input = Console.ReadLine();
        }
        return input;
    }

    private bool KiemTraDuLieu(string input)
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
        while (!int.TryParse(input, out result) || result <= 0)
        {
            Console.WriteLine($"Vui lòng nhập lại {fieldName}, chỉ chứa số nguyên dương:");
            input = Console.ReadLine();
        }
        return result;
    }

    private string KiemTraNhapLoaiChietKhau(string input)
    {
        while (input != "TheoSoTien" && input != "TheoPhanTram")
        {
            Console.WriteLine("Vui lòng chọn loại chiết khấu hợp lệ (TheoSoTien/TheoPhanTram):");
            input = Console.ReadLine();
        }
        return input;
    }
    public void NhapThongTinSanPham()
    {
        Console.WriteLine("Nhập số lượng sản phẩm cần thêm:");
        int n = KiemTraNhapSoNguyen(Console.ReadLine(), "Số lượng sản phẩm");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập thông tin sản phẩm thứ {i + 1}:");
            Console.WriteLine("Nhập tên sản phẩm:");
            string ten = KiemTraNhap(Console.ReadLine(), "Tên sản phẩm");

            Console.WriteLine("Nhập giá sản phẩm:");
            double gia = KiemTraNhapSo(Console.ReadLine(), "Giá sản phẩm");

            Console.WriteLine("Chọn loại chiết khấu (TheoSoTien/TheoPhanTram):");
            string loaiChietKhau = KiemTraNhapLoaiChietKhau(Console.ReadLine());

            Product product = new Product(ten, gia, loaiChietKhau);
            productList.Add(product);
        }
    }

    public void HienThiDanhSachSanPham()
    {
        if (productList.Count == 0)
        {
            Console.WriteLine("Không có sản phẩm nào trong danh sách!");
            return;
        }

        Console.WriteLine("Danh sách sản phẩm:");
        for (int i = 0; i < productList.Count; i++)
        {
            var product = productList[i];
            Console.WriteLine($"Sản phẩm {i + 1}:");
            Console.WriteLine($"Tên sản phẩm: {product.Ten}, Giá: {product.Gia}, Loại chiết khấu: {product.LoaiChietKhau}, Giá sau chiết khấu: {product.GiaSauChietKhau}");
        }
    }

    public void HienThiTheoLoaiChietKhau(string loai)
    {
        var filteredList = productList.Where(p => p.LoaiChietKhau == loai).ToList();

        if (filteredList.Count == 0)
        {
            Console.WriteLine($"Không có sản phẩm nào có loại chiết khấu {loai}!");
            return;
        }

        Console.WriteLine($"Danh sách sản phẩm có loại chiết khấu {loai}:");
        for (int i = 0; i < filteredList.Count; i++)
        {
            var product = filteredList[i];
            Console.WriteLine($"Sản phẩm {i + 1}:");
            Console.WriteLine($"Tên sản phẩm: {product.Ten}, Giá: {product.Gia}, Giá sau chiết khấu: {product.GiaSauChietKhau}");
        }
    }

    public void SapXepTheoGiaSauChietKhau()
    {
        productList = productList.OrderByDescending(p => p.GiaSauChietKhau).ToList();
        HienThiDanhSachSanPham();
    }

    public void TimKiemTheoTen(string ten)
    {
        var foundProducts = productList.Where(p => p.Ten.Contains(ten)).ToList();

        if (foundProducts.Count == 0)
        {
            Console.WriteLine($"Không tìm thấy sản phẩm có tên chứa '{ten}'!");
            return;
        }

        Console.WriteLine($"Danh sách sản phẩm có tên chứa '{ten}':");
        for (int i = 0; i < foundProducts.Count; i++)
        {
            var product = foundProducts[i];
            Console.WriteLine($"Sản phẩm {i + 1}:");
            Console.WriteLine($"Tên sản phẩm: {product.Ten}, Giá: {product.Gia}, Loại chiết khấu: {product.LoaiChietKhau}, Giá sau chiết khấu: {product.GiaSauChietKhau}");
        }
    }

}
