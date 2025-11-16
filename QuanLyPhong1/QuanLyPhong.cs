using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhong1
{
    internal class QuanLyPhong
    {
        private string _maPhong;
        private string _tenPhong;
        private int _soLuong;
        private int _soLuongMax;
        private bool _HD;

        public QuanLyPhong(string maPhong, string tenPhong, int soLuong, int soLuongMax, bool hD)
        {
            _maPhong = maPhong;
            _tenPhong = tenPhong;
            _soLuong = soLuong;
            _soLuongMax = soLuongMax;
            _HD = hD;
        }

        public string MaPhong { get => _maPhong; set => _maPhong = value; }
        public string TenPhong { get => _tenPhong; set => _tenPhong = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public int SoLuongMax { get => _soLuongMax; set => _soLuongMax = value; }
        public bool HD { get => _HD; set => _HD = value; }
    }
}
