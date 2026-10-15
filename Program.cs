using System;
using System.Collections.Generic;

namespace Lab02_OOPBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập font tiếng Việt cho Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("          CHƯƠNG TRÌNH CHẠY BÀI LAB 2 - IT3212     ");
                Console.WriteLine("==================================================");
                Console.WriteLine(" 1. Bài 1: Khai báo lớp SinhVien và in thông tin");
                Console.WriteLine(" 2. Bài 2: Constructor và nạp chồng constructor");
                Console.WriteLine(" 3. Bài 3: Đóng gói và kiểm tra dữ liệu (Validation)");
                Console.WriteLine(" 4. Bài 4: Phương thức nghiệp vụ (Tính tuổi, Xếp loại)");
                Console.WriteLine(" 5. Bài 5: Quản lý danh sách SinhVien (List<T>, Find)");
                Console.WriteLine(" 6. Bài 6: Lớp SanPham (Thành tiền & kiểm tra dữ liệu)");
                Console.WriteLine(" 7. Bài 7: Lớp TaiKhoanNganHang (Nạp, rút, chuyển tiền)");
                Console.WriteLine(" 8. Bài 8: Lớp NhanVien (Tính lương & in bảng lương)");
                Console.WriteLine(" 9. Bài 9: Lớp HinhChuNhat (Constructor, chu vi, diện tích)");
                Console.WriteLine(" 10. Bài 10: Ứng dụng quản lý sinh viên Console (Menu CRUD)");
                Console.WriteLine(" 0. Thoát chương trình");
                Console.WriteLine("--------------------------------------------------");
                Console.Write("=> Nhựa chọn bài muốn chạy (0-10): ");

                string choice = Console.ReadLine() ?? "";
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        RunBai1();
                        break;
                    case "2":
                        RunBai2();
                        break;
                    case "3":
                        RunBai3();
                        break;
                    case "4":
                        RunBai4();
                        break;
                    case "5":
                        RunBai5();
                        break;
                    case "6":
                        RunBai6();
                        break;
                    case "7":
                        RunBai7();
                        break;
                    case "8":
                        RunBai8();
                        break;
                    case "9":
                        RunBai9();
                        break;
                    case "10":
                        QuanLySinhVienApp.Chay();
                        break;
                    case "0":
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng bấm phím bất kỳ để chọn lại!");
                        break;
                }

                if (choice != "0" && choice != "10")
                {
                    Console.WriteLine("\n--------------------------------------------------");
                    Console.Write("Bấm phím bất kỳ để quay lại menu chính...");
                    Console.ReadKey();
                }
            }
        }

        static void RunBai1()
        {
            Console.WriteLine("--- CHẠY BÀI 1: Khai báo lớp SinhVien ---");
            SinhVien sv1 = new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2);
            sv1.HienThi();
        }

        static void RunBai2()
        {
            Console.WriteLine("--- CHẠY BÀI 2: Constructor và nạp chồng ---");
            SinhVien svMacDinh = new SinhVien();
            Console.Write("Constructor mặc định: ");
            svMacDinh.HienThi();

            SinhVien svCoThamSo = new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8);
            Console.Write("Constructor có tham số: ");
            svCoThamSo.HienThi();
        }

        static void RunBai3()
        {
            Console.WriteLine("--- CHẠY BÀI 3: Đóng gói và kiểm tra dữ liệu ---");
            try
            {
                SinhVien sv = new SinhVien();
                Console.WriteLine("Đang thử gán họ tên rỗng...");
                sv.HoTen = ""; // Sẽ văng ngoại lệ
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bắt được ngoại lệ thành công: {ex.Message}");
            }

            try
            {
                SinhVien sv = new SinhVien();
                Console.WriteLine("Đang thử gán điểm TB = 12 (ngoài khoảng [0,10])...");
                sv.DiemTB = 12;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bắt được ngoại lệ thành công: {ex.Message}");
            }
        }

        static void RunBai4()
        {
            Console.WriteLine("--- CHẠY BÀI 4: Phương thức nghiệp vụ ---");
            SinhVien sv = new SinhVien("SV03", "Lê Cường", new DateTime(2004, 1, 15), 9.2);
            sv.HienThi();
            Console.WriteLine($"=> Tuổi tính toán: {sv.TinhTuoi()}");
            Console.WriteLine($"=> Xếp loại học lực: {sv.XepLoai()}");
        }

        static void RunBai5()
        {
            Console.WriteLine("--- CHẠY BÀI 5: Quản lý danh sách SinhVien (List<T>) ---");
            List<SinhVien> ds = new List<SinhVien>();
            ds.Add(new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2));
            ds.Add(new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8));

            Console.WriteLine("Danh sách ban đầu:");
            foreach (var sv in ds) sv.HienThi();

            Console.Write("\nNhập mã SV cần tìm (ví dụ: SV01): ");
            string ma = Console.ReadLine() ?? "";

            SinhVien? ketQua = ds.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (ketQua == null)
                Console.WriteLine("Không tìm thấy!");
            else
            {
                Console.WriteLine("Đã tìm thấy sinh viên:");
                ketQua.HienThi();
            }
        }

        static void RunBai6()
        {
            Console.WriteLine("--- CHẠY BÀI 6: Lớp SanPham ---");
            SanPham sp = new SanPham("SP01", "Laptop Dell", 15000000, 2);
            sp.HienThi();
        }

        static void RunBai7()
        {
            Console.WriteLine("--- CHẠY BÀI 7: Lớp TaiKhoanNganHang ---");
            TaiKhoanNganHang tk1 = new TaiKhoanNganHang("101", "Nguyễn Xuân Anh", 2000000);
            TaiKhoanNganHang tk2 = new TaiKhoanNganHang("102", "Quỹ Lớp", 500000);

            Console.WriteLine($"Tài khoản 1: {tk1.TenChuTaiKhoan} - Số dư: {tk1.SoDu:N0} đ");
            tk1.NapTien(500000);
            tk1.RutTien(1000000);

            Console.WriteLine("\nChuyển 500.000 đ từ TK1 sang TK2:");
            tk1.ChuyenTien(tk2, 500000);
            Console.WriteLine($"Số dư TK2 hiện tại: {tk2.SoDu:N0} đ");
        }

        static void RunBai8()
        {
            Console.WriteLine("--- CHẠY BÀI 8: Lớp NhanVien ---");
            NhanVien nv = new NhanVien("NV01", "Hoàng Văn Nam", 4000000, 2.34, 1500000);
            nv.InBangLuong();
        }

        static void RunBai9()
        {
            Console.WriteLine("--- CHẠY BÀI 9: Lớp HinhChuNhat ---");
            HinhChuNhat hcn = new HinhChuNhat(7.5, 4.0);
            hcn.HienThi();
        }
    }
}