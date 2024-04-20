using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StudentRegister studentRegister = new StudentRegister();
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("----- Hệ Thống Đăng Ký Khóa Học -----");
            Console.WriteLine("1. Đăng ký học");
            Console.WriteLine("2. Hiển thị danh sách học viên đăng ký");
            Console.WriteLine("3. Thoát");
            Console.WriteLine("Nhập lựa chọn của bạn:");

            int chon;
            while (!int.TryParse(Console.ReadLine(), out chon) || chon < 1 || chon > 3)
            {
                Console.WriteLine("Vui lòng nhập lựa chọn hợp lệ (từ 1 đến 3):");
            }

            switch (chon)
            {
                case 1:
                    studentRegister.DangKyKhoaHoc();
                    break;
                case 2:
                    studentRegister.HienThiDanhSachHocVien();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }
}
