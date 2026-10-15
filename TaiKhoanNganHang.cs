using System;

namespace Lab02_OOPBasics
{
    public class TaiKhoanNganHang
    {
        public string SoTaiKhoan { get; private set; }
        public string TenChuTaiKhoan { get; private set; }
        public double SoDu { get; private set; }

        public TaiKhoanNganHang(string soTaiKhoan, string tenChuTaiKhoan, double soDuBanDau = 0)
        {
            if (soDuBanDau < 0) throw new ArgumentException("Số dư ban đầu không được âm.");
            SoTaiKhoan = soTaiKhoan;
            TenChuTaiKhoan = tenChuTaiKhoan;
            SoDu = soDuBanDau;
        }

        public void NapTien(double soTien)
        {
            if (soTien <= 0)
            {
                Console.WriteLine("Số tiền nạp phải lớn hơn 0.");
                return;
            }
            SoDu += soTien;
            Console.WriteLine($"Nạp thành công {soTien:N0}. Số dư mới: {SoDu:N0}");
        }

        public bool RutTien(double soTien)
        {
            if (soTien <= 0)
            {
                Console.WriteLine("Số tiền rút phải lớn hơn 0.");
                return false;
            }
            if (soTien > SoDu)
            {
                Console.WriteLine("Số dư không đủ để thực hiện giao dịch.");
                return false;
            }
            SoDu -= soTien;
            Console.WriteLine($"Rút thành công {soTien:N0}. Số dư còn lại: {SoDu:N0}");
            return true;
        }

        public void ChuyenTien(TaiKhoanNganHang tkNhan, double soTien)
        {
            if (RutTien(soTien))
            {
                tkNhan.NapTien(soTien);
                Console.WriteLine($"Chuyển thành công {soTien:N0} tới tài khoản {tkNhan.SoTaiKhoan}.");
            }
        }
    }
}