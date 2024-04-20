using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager();
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("----- Quản Lý Sản Phẩm -----");
            Console.WriteLine("1. Nhập thông tin sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Hiển thị theo loại chiết khấu");
            Console.WriteLine("4. Sắp xếp theo giá sau chiết khấu");
            Console.WriteLine("5. Tìm kiếm sản phẩm theo tên");
            Console.WriteLine("6. Thoát");
            Console.WriteLine("Nhập lựa chọn của bạn:");

            int chon;
            while (!int.TryParse(Console.ReadLine(), out chon) || chon < 1 || chon > 6)
            {
                Console.WriteLine("Vui lòng nhập lựa chọn hợp lệ (từ 1 đến 6):");
            }

            switch (chon)
            {
                case 1:
                    productManager.NhapThongTinSanPham();
                    break;
                case 2:
                    productManager.HienThiDanhSachSanPham();
                    break;
                case 3:
                    Console.WriteLine("Nhập loại chiết khấu (TheoSoTien/TheoPhanTram):");
                    string loai = Console.ReadLine();
                    productManager.HienThiTheoLoaiChietKhau(loai);
                    break;
                case 4:
                    productManager.SapXepTheoGiaSauChietKhau();
                    break;
                case 5:
                    Console.WriteLine("Nhập tên sản phẩm cần tìm:");
                    string ten = Console.ReadLine();
                    productManager.TimKiemTheoTen(ten);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }
}
