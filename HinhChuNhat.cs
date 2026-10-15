using System;

namespace Lab02_OOPBasics
{
    public class HinhChuNhat
    {
        private double _chieuDai;
        private double _chieuRong;

        public double ChieuDai
        {
            get => _chieuDai;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Chiều dài phải lớn hơn 0.");
                _chieuDai = value;
            }
        }

        public double ChieuRong
        {
            get => _chieuRong;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Chiều rộng phải lớn hơn 0.");
                _chieuRong = value;
            }
        }

        public HinhChuNhat(double chieuDai, double chieuRong)
        {
            ChieuDai = chieuDai;
            ChieuRong = chieuRong;
        }

        public double TinhChuVi() => (ChieuDai + ChieuRong) * 2;
        public double TinhDienTich() => ChieuDai * ChieuRong;

        public void HienThi()
        {
            Console.WriteLine($"HCN [{ChieuDai} x {ChieuRong}] -> Chu vi: {TinhChuVi()} | Diện tích: {TinhDienTich()}");
        }
    }
}