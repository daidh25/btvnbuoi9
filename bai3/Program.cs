using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        ProductManager quanLySanPham = new ProductManager();
        Product sanPham = quanLySanPham.NhapSanPham();
        quanLySanPham.BuyProduct(sanPham);

        Console.WriteLine("Bạn có muốn mua sản phẩm khác không? (có/không)");
        string traLoi = Console.ReadLine();

        while (traLoi.ToLower() == "có")
        {
            sanPham = quanLySanPham.NhapSanPham();
            quanLySanPham.BuyProduct(sanPham);

            Console.WriteLine("Bạn có muốn mua sản phẩm khác không? (có/không)");
            traLoi = Console.ReadLine();
        }

        quanLySanPham.DisplayOrders();
    }
}
