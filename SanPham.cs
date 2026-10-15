using System;

namespace Lab02_OOPBasics
{
    public class SanPham
    {
        private string _maSP = string.Empty;
        private string _tenSP = string.Empty;
        private double _donGia;
        private int _soLuong;

        public string MaSP
        {
            get => _maSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Mã SP không được trống.");
                _maSP = value;
            }
        }

        public string TenSP
        {
            get => _tenSP;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Tên SP không được trống.");
                _tenSP = value;
            }
        }

        public double DonGia
        {
            get => _donGia;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Đơn giá phải >= 0.");
                _donGia = value;
            }
        }

        public int SoLuong
        {
            get => _soLuong;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Số lượng phải >= 0.");
                _soLuong = value;
            }
        }

        public SanPham(string maSP, string tenSP, double donGia, int soLuong)
        {
            MaSP = maSP;
            TenSP = tenSP;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public double TinhThanhTien() => DonGia * SoLuong;

        public void HienThi()
        {
            Console.WriteLine($"Mã: {MaSP} | Tên: {TenSP} | Đơn giá: {DonGia:N0} | SL: {SoLuong} | Thành tiền: {TinhThanhTien():N0}");
        }
    }
}