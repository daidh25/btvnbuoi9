using System;
using System.Collections.Generic;
using System.Linq;

public class ProductManager : IProductManager
{
    private List<Product> danhSachSanPham = new List<Product>();
    private List<Product> danhSachDonHang = new List<Product>();

    public void BuyProduct(Product sanPham)
    {
        danhSachSanPham.Add(sanPham);
        danhSachDonHang.Add(sanPham);

        if (danhSachDonHang.Sum(p => p.SoLuong) > 5)
        {
            ApDungChietKhau();
        }
    }

    private void ApDungChietKhau()
    {
        double tongGia = danhSachDonHang.Sum(p => p.Gia);
        double giaGiam = tongGia * 0.95; 
        Product sanPhamChietKhau = new Product("ChietKhau", giaGiam, 1, giaGiam);
        danhSachDonHang.Add(sanPhamChietKhau);
    }

    public void DisplayOrders()
    {
        Console.WriteLine("Chi tiết đơn hàng:");
        Console.WriteLine("Tên\tGiá\tSố Lượng\tĐơn Giá");
        foreach (var donHang in danhSachDonHang)
        {
            Console.WriteLine($"{donHang.Ten}\t{donHang.Gia}\t{donHang.SoLuong}\t{donHang.DonGia}");
        }
        Console.WriteLine($"Tổng giá: {danhSachDonHang.Sum(p => p.Gia)}");
    }

    public Product NhapSanPham()
    {
        Console.WriteLine("Nhập tên sản phẩm:");
        string ten = Console.ReadLine();

        Console.WriteLine("Nhập giá sản phẩm:");
        double gia = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Nhập số lượng sản phẩm:");
        int soLuong = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Nhập đơn giá sản phẩm:");
        double donGia = Convert.ToDouble(Console.ReadLine());

        return new Product(ten, gia, soLuong, donGia);
    }
}
