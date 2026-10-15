using System;

namespace Lab02_OOPBasics
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public double LuongCoBan { get; set; }
        public double HeSoLuong { get; set; }
        public double PhuCap { get; set; }

        public NhanVien(string maNV, string hoTen, double luongCoBan, double heSoLuong, double phuCap)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
            HeSoLuong = heSoLuong;
            PhuCap = phuCap;
        }

        public double TinhLuong() => (LuongCoBan * HeSoLuong) + PhuCap;

        public void InBangLuong()
        {
            Console.WriteLine($"[NV] Mã: {MaNV} | Tên: {HoTen} | LCB: {LuongCoBan:N0} | HSL: {HeSoLuong} | Phụ cấp: {PhuCap:N0} => Tổng lương: {TinhLuong():N0}");
        }
    }
}