using System;

public class Student
{
    public string HoTen { get;  set; }
    public DateTime NgaySinh { get;  set; }

    public Student()
    {
        HoTen = Validator.KiemTraNhap("Họ tên");
        NgaySinh = Validator.KiemTraNhapNgay("Ngày sinh");
    }
}
