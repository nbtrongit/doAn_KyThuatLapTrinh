using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.Entities;
using doAn_KTLT.DAL;

namespace doAn_KTLT.Services
{
    public class XuLyHoaDonNhap
    {
        public static List<HoaDonNhap> timKiem(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            List<HoaDonNhap> ketQua = new List<HoaDonNhap>();
            foreach (HoaDonNhap hdn in dsHoaDonNhap)
            {
                if (hdn.maHoaDon.Contains(tuKhoa) || hdn.maHang.Contains(tuKhoa))
                {
                    ketQua.Add(hdn);
                }
            }
            return ketQua;
        }
        public static bool themHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            DateTime ngayHienTai = DateTime.Now.Date;
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            foreach (HoaDonNhap hdn in dsHoaDonNhap)
            {
                if (hdn.maHang == hoaDonNhap.maHang)
                {
                    return false;
                }
                if(hdn.maHoaDon == hoaDonNhap.maHoaDon)
                {
                    if((hoaDonNhap.ngayHoaDon.Ngay != hdn.ngayHoaDon.Ngay) || (hoaDonNhap.ngayHoaDon.Thang != hdn.ngayHoaDon.Thang) || (hoaDonNhap.ngayHoaDon.Nam != hdn.ngayHoaDon.Nam))
                    {
                        return false;
                    }
                }
            }
            if((ngayHienTai.Year * 10000 + ngayHienTai.Month * 100 + ngayHienTai.Day) < XuLyDate.chuyenDoi(hoaDonNhap.ngayHoaDon))
            {
                return false;
            }
            LuuTruHoaDonNhap.luuHoaDonNhap(hoaDonNhap);
            return true;
        }
        public static int tongNhapTheoMatHang(string maMH)
        {
            int tong = 0;
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            foreach (HoaDonNhap hdn in dsHoaDonNhap)
            {
                if (hdn.maHang == maMH)
                {
                    tong += hdn.soLuong;
                }
            }
            return tong;
        }
    }
}
