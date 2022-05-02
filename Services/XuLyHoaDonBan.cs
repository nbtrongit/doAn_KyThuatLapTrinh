using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.Entities;
using doAn_KTLT.DAL;
using doAn_KTLT.Services;

namespace doAn_KTLT.Services
{
    public class XuLyHoaDonBan
    {
        public static List<HoaDonBan> timKiem(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            List<HoaDonBan> ketQua = new List<HoaDonBan>();
            foreach (HoaDonBan hdb in dsHoaDonBan)
            {
                if (hdb.maHoaDon.Contains(tuKhoa) || hdb.maHang.Contains(tuKhoa))
                {
                    ketQua.Add(hdb);
                }
            }
            return ketQua;
        }
        public static int tongBanTheoMatHang(string maMH)
        {
            int tong = 0;
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            foreach(HoaDonBan hdb in dsHoaDonBan)
            {
                if(hdb.maHang == maMH)
                {
                    tong += hdb.soLuong;
                }
            }
            return tong;
        }
        public static bool themHoaDonBan(HoaDonBan hoaDonBan)
        {
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            List<MatHang> dsMatHang = LuuTruMatHang.Doc();
            DateTime ngayHienTai = DateTime.Now.Date;
            foreach (HoaDonBan hdb in dsHoaDonBan)
            {
                if (hdb.maHoaDon == hoaDonBan.maHoaDon)
                {
                    if ((hoaDonBan.ngayHoaDon.Ngay != hdb.ngayHoaDon.Ngay) || (hoaDonBan.ngayHoaDon.Thang != hdb.ngayHoaDon.Thang) || (hoaDonBan.ngayHoaDon.Nam != hdb.ngayHoaDon.Nam))
                    {
                        return false;
                    }
                    else if(hdb.maHang == hoaDonBan.maHang)
                    {
                        return false;
                    }
                }
            }
            if (hoaDonBan.soLuong + XuLyHoaDonBan.tongBanTheoMatHang(hoaDonBan.maHang) > XuLyHoaDonNhap.tongNhapTheoMatHang(hoaDonBan.maHang))
            {
                return false;
            }
            else if ((ngayHienTai.Year * 10000 + ngayHienTai.Month * 100 + ngayHienTai.Day) < XuLyDate.chuyenDoi(hoaDonBan.ngayHoaDon))
            {
                return false;
            }
            foreach(HoaDonNhap hdn in dsHoaDonNhap)
            {
                if(hdn.maHang == hoaDonBan.maHang && XuLyDate.chuyenDoi(hoaDonBan.ngayHoaDon) < XuLyDate.chuyenDoi(hdn.ngayHoaDon))
                {
                    return false;
                }
                else if(hdn.maHang == hoaDonBan.maHang && hoaDonBan.donGia <= hdn.donGia)
                {
                    return false;
                }
            }
            foreach(MatHang mh in dsMatHang)
            {
                if(mh.maHang == hoaDonBan.maHang && XuLyDate.chuyenDoi(hoaDonBan.ngayHoaDon) >= XuLyDate.chuyenDoi(mh.hanDung))
                {
                    return false;
                }
            }
            LuuTruHoaDonBan.luuHoaDonBan(hoaDonBan);
            return true;
        }
        public static HoaDonBan? timHoaDonBan(string id1, string id2)
        {
            if (string.IsNullOrEmpty(id1) || string.IsNullOrEmpty(id2))
            {
                return null;
            }
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            foreach (HoaDonBan hdb in dsHoaDonBan)
            {
                if (hdb.maHoaDon == id1 && hdb.maHang == id2)
                {
                    return hdb;
                }
            }
            return null;
        }
        public static bool Xoa(string id1, string id2)
        {
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if (dsHoaDonBan[i].maHoaDon == id1 && dsHoaDonBan[i].maHang == id2)
                {
                    dsHoaDonBan.Remove(dsHoaDonBan[i]);
                }
            }
            LuuTruHoaDonBan.Luu(dsHoaDonBan);
            return true;
        }
    }
}
