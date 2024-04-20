using System;
using System.Text.RegularExpressions;

public static class Validator
{
    public static string KiemTraNhap(string fieldName)
    {
        string input;
        while (true)
        {
            Console.WriteLine($"Nhập {fieldName}:");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && KiemTraDuLieu(input))
            {
                break;
            }
            Console.WriteLine($"Vui lòng nhập {fieldName} hợp lệ.");
        }
        return input;
    }

    public static double KiemTraNhapSo(string fieldName)
    {
        double result;
        while (true)
        {
            Console.WriteLine($"Nhập {fieldName}:");
            if (double.TryParse(Console.ReadLine(), out result) && result >= 0)
            {
                break;
            }
            Console.WriteLine($"Vui lòng nhập {fieldName} hợp lệ.");
        }
        return result;
    }

    public static DateTime KiemTraNhapNgay(string fieldName)
    {
        DateTime result;
        while (true)
        {
            Console.WriteLine($"Nhập {fieldName} (dd/MM/yyyy):");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out result))
            {
                break;
            }
            Console.WriteLine($"Vui lòng nhập {fieldName} hợp lệ.");
        }
        return result;
    }

    private static bool KiemTraDuLieu(string input)
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
}
