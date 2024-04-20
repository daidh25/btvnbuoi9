using System;
using System.Collections.Generic;
using System.Linq;

public class StudentRegister : IStudentRegister
{
    private List<(Student, Course, DateTime)> registeredStudents = new List<(Student, Course, DateTime)>();

    public void DangKyKhoaHoc()
    {
        Student student = new Student();
        Course course = new Course();

        DateTime ngayDangKy;
        do
        {
            ngayDangKy = Validator.KiemTraNhapNgay("Ngày đăng ký");
        } while (ngayDangKy > course.NgayKhaiGiang);

        double giamGia = Course.Discount(ngayDangKy);
        double hocPhiSauGiam = course.HocPhi * (1 - giamGia);

        registeredStudents.Add((student, course, ngayDangKy));

        Console.WriteLine($"Đã đăng ký {student.HoTen} vào khóa học {course.Ten} với mức giảm giá {giamGia * 100}%.\nHọc phí sau khi giảm: {hocPhiSauGiam} VND.");
    }

    public void HienThiDanhSachHocVien()
    {
        Console.WriteLine("----- Danh sách học viên đã đăng ký -----");

        for (int i = 0; i < registeredStudents.Count; i++)
        {
            var item = registeredStudents[i];
            double hocPhiSauGiam = item.Item2.HocPhi * (1 - Course.Discount(item.Item3));

            Console.WriteLine($"Họ tên: {item.Item1.HoTen},\nNgày sinh: {item.Item1.NgaySinh.ToShortDateString()}, \nNgày đăng ký: {item.Item3.ToShortDateString()}, \nHọc phí: {item.Item2.HocPhi}, \nHọc phí sau giảm: {hocPhiSauGiam}");
        }
    }

}
