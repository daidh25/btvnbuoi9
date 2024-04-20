using System;

public class Course
{
    public string Ten { get;  set; }
    public string MoTa { get;  set; }
    public double HocPhi { get;  set; }
    public DateTime NgayKhaiGiang { get;  set; }

    public Course()
    {
        Ten = Validator.KiemTraNhap("Tên khóa học");
        MoTa = Validator.KiemTraNhap("Mô tả khóa học");
        HocPhi = Validator.KiemTraNhapSo("Học phí");
        NgayKhaiGiang = Validator.KiemTraNhapNgay("Ngày khai giảng");
    }

    public static double Discount(DateTime ngayDangKy)
    {
        if ((ngayDangKy - DateTime.Now).TotalDays > 30)
        {
            return 0.15;
        }
        else if ((ngayDangKy - DateTime.Now).TotalDays > 10)
        {
            return 0.10;
        }
        return 0;
    }
}
