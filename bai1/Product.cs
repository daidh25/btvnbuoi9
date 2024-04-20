using System;
using System.Collections.Generic;

public class Product
{
    public string Ten { get; set; }
    public double Gia { get; set; }
    public string LoaiChietKhau { get; set; }
    public double GiaSauChietKhau { get; set; }
    public Product()
    {
        Ten = "";
        Gia = 0;
        LoaiChietKhau = "";
        GiaSauChietKhau = 0;
    }
    public Product(string ten, double gia, string loaiChietKhau)
    {
        this.Ten = ten;
        this.Gia = gia;
        this.LoaiChietKhau = loaiChietKhau;
        this.GiaSauChietKhau = CalculatorDiscount();
    }
    

    public double CalculatorDiscount()
    {
        switch (LoaiChietKhau)
        {
            case "TheoSoTien":
                if (Gia > 100000)
                    return Gia - 5000;
                else if (Gia > 10000)
                    return Gia - 1000;
                else
                    return Gia;
            case "TheoPhanTram":
                if (Gia > 100000)
                    return Gia * 0.95;
                else if (Gia > 10000)
                    return Gia * 0.99;
                else
                    return Gia;
            default:
                return Gia;
        }
    }
}
