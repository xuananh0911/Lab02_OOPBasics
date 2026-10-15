using System;
using System.Collections.Generic;

namespace Lab02_OOPBasics
{
    public class SinhVien
    {
        private string _hoTen = string.Empty;
        private double _diemTB;

        public string MaSV { get; set; } = string.Empty;

        public string HoTen
        {
            get => _hoTen;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được rỗng.");
                _hoTen = value.Trim();
            }
        }

        public DateTime NgaySinh { get; set; }

        public double DiemTB
        {
            get => _diemTB;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(DiemTB), "Điểm TB phải từ 0 đến 10.");
                _diemTB = value;
            }
        }

        public SinhVien()
        {
            MaSV = "Chưa có";
            HoTen = "Chưa có";
            NgaySinh = DateTime.Today;
            DiemTB = 0;
        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }

        public int TinhTuoi()
        {
            int tuoi = DateTime.Today.Year - NgaySinh.Year;
            if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }

        public string XepLoai()
        {
            if (DiemTB >= 9) return "Xuất sắc";
            if (DiemTB >= 8) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5) return "Trung bình";
            return "Yếu";
        }

        public void HienThi()
        {
            Console.WriteLine($"{MaSV} - {HoTen} - {NgaySinh:dd/MM/yyyy} - {DiemTB:N2} | Tuổi: {TinhTuoi()} | Xếp loại: {XepLoai()}");
        }
    }

    public class QuanLySinhVienApp
    {
        private static List<SinhVien> dsSV = new List<SinhVien>()
        {
            new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2),
            new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8),
            new SinhVien("SV03", "Lê Cường", new DateTime(2004, 1, 15), 9.5)
        };

        public static void Chay()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== QUẢN LÝ SINH VIÊN ==========");
                Console.WriteLine("1. Xem danh sách sinh viên");
                Console.WriteLine("2. Thêm sinh viên mới");
                Console.WriteLine("3. Sửa thông tin sinh viên");
                Console.WriteLine("4. Xóa sinh viên");
                Console.WriteLine("5. Tìm kiếm sinh viên theo mã");
                Console.WriteLine("6. Sắp xếp theo Điểm TB (Giảm dần)");
                Console.WriteLine("7. Thống kê theo xếp loại");
                Console.WriteLine("0. Quay lại menu chính");
                Console.Write("Chọn chức năng (0-7): ");

                string chon = Console.ReadLine() ?? "";

                switch (chon)
                {
                    case "1": XemDanhSach(); break;
                    case "2": ThemSinhVien(); break;
                    case "3": SuaSinhVien(); break;
                    case "4": XoaSinhVien(); break;
                    case "5": TimKiemSinhVien(); break;
                    case "6": SapXep(); break;
                    case "7": ThongKe(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

                Console.WriteLine("\nBấm phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }

        private static void XemDanhSach()
        {
            Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
            if (dsSV.Count == 0) { Console.WriteLine("Danh sách trống!"); return; }
            foreach (var sv in dsSV) sv.HienThi();
        }

        private static void ThemSinhVien()
        {
            try
            {
                Console.WriteLine("\n--- THÊM SINH VIÊN MỚI ---");
                Console.Write("Nhập mã SV: "); string ma = Console.ReadLine()!;
                if (dsSV.Any(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Mã SV đã tồn tại!");
                    return;
                }
                Console.Write("Nhập họ tên: "); string ten = Console.ReadLine()!;
                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                DateTime ns = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);
                Console.Write("Nhập điểm TB: "); double dtb = double.Parse(Console.ReadLine()!);

                dsSV.Add(new SinhVien(ma, ten, ns, dtb));
                Console.WriteLine("Thêm sinh viên thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        private static void SuaSinhVien()
        {
            Console.Write("\nNhập mã SV cần sửa: ");
            string ma = Console.ReadLine()!;
            var sv = dsSV.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv == null) { Console.WriteLine("Không tìm thấy!"); return; }

            try
            {
                Console.Write($"Sửa tên mới (Bỏ trống nếu giữ nguyên '{sv.HoTen}'): ");
                string ten = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(ten)) sv.HoTen = ten;

                Console.Write($"Sửa điểm TB mới (Bỏ trống nếu giữ nguyên '{sv.DiemTB}'): ");
                string dtbStr = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(dtbStr)) sv.DiemTB = double.Parse(dtbStr);

                Console.WriteLine("Cập nhật thông tin thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật: {ex.Message}");
            }
        }

        private static void XoaSinhVien()
        {
            Console.Write("\nNhập mã SV cần xóa: ");
            string ma = Console.ReadLine()!;
            var sv = dsSV.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv == null) { Console.WriteLine("Không tìm thấy!"); return; }

            dsSV.Remove(sv);
            Console.WriteLine("Đã xóa sinh viên thành công!");
        }

        private static void TimKiemSinhVien()
        {
            Console.Write("\nNhập mã SV cần tìm: ");
            string ma = Console.ReadLine()!;
            var sv = dsSV.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv == null) Console.WriteLine("Không tìm thấy sinh viên!");
            else
            {
                Console.WriteLine("Kết quả tìm kiếm:");
                sv.HienThi();
            }
        }

        private static void SapXep()
        {
            dsSV = dsSV.OrderByDescending(x => x.DiemTB).ToList();
            Console.WriteLine("\nĐã sắp xếp danh sách theo Điểm TB giảm dần!");
            XemDanhSach();
        }

        private static void ThongKe()
        {
            Console.WriteLine("\n--- THỐNG KÊ XẾP LOẠI ---");
            var thongKe = dsSV.GroupBy(x => x.XepLoai())
                               .Select(g => new { Loai = g.Key, SoLuong = g.Count() });

            foreach (var item in thongKe)
            {
                Console.WriteLine($"- Xếp loại {item.Loai}: {item.SoLuong} sinh viên");
            }
        }
    }
}