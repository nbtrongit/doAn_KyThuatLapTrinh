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
            if(hoaDonNhap.soLuong == 0 || hoaDonNhap.donGia == 0)
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
        public static HoaDonNhap? timHoaDonNhap(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            foreach(HoaDonNhap hdn in dsHoaDonNhap)
            {
                if(hdn.maHang == id)
                {
                    return hdn;
                }
            }
            return null;
        }
        public static bool Xoa(string id)
        {
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            List<MatHang> dsMatHang = LuuTruMatHang.Doc();
            foreach (HoaDonBan hdb in dsHoaDonBan)
            {
                if (hdb.maHang == id)
                {
                    return false;
                }
            }
            for(int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if(dsHoaDonNhap[i].maHang == id)
                {
                    dsHoaDonNhap.Remove(dsHoaDonNhap[i]);
                }
            }
            LuuTruHoaDonNhap.Luu(dsHoaDonNhap);
            for(int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].maHang == id)
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
            LuuTruMatHang.Luu(dsMatHang);
            return true;
        }
        public static bool Sua(string id, HoaDonNhap hoaDonNhapMoi)
        {
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            List<MatHang> dsMatHang = LuuTruMatHang.Doc();
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            DateTime ngayHienTai = DateTime.Now.Date;
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if(dsHoaDonNhap[i].maHang != id)
                {
                    if (dsHoaDonNhap[i].maHang == hoaDonNhapMoi.maHang)
                    {
                        return false;
                    }
                    else if (dsHoaDonNhap[i].maHoaDon == hoaDonNhapMoi.maHoaDon)
                    {
                        if (hoaDonNhapMoi.ngayHoaDon.Ngay != dsHoaDonNhap[i].ngayHoaDon.Ngay || hoaDonNhapMoi.ngayHoaDon.Thang != dsHoaDonNhap[i].ngayHoaDon.Thang || hoaDonNhapMoi.ngayHoaDon.Nam != dsHoaDonNhap[i].ngayHoaDon.Nam)
                        {
                            return false;
                        }
                    }
                }
            }
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if(dsMatHang[i].maHang == id)
                {
                    if(XuLyDate.chuyenDoi(hoaDonNhapMoi.ngayHoaDon) >= XuLyDate.chuyenDoi(dsMatHang[i].hanDung) || XuLyDate.chuyenDoi(hoaDonNhapMoi.ngayHoaDon) <= XuLyDate.chuyenDoi(dsMatHang[i].ngaySanXuat))
                    {
                        return false;
                    }
                }
            }
            if(XuLyDate.chuyenDoi(hoaDonNhapMoi.ngayHoaDon) > (ngayHienTai.Year * 10000 + ngayHienTai.Month * 100 + ngayHienTai.Day))
            {
                return false;
            }
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if(dsHoaDonBan[i].maHang == id)
                {
                    if(XuLyDate.chuyenDoi(hoaDonNhapMoi.ngayHoaDon) > XuLyDate.chuyenDoi(dsHoaDonBan[i].ngayHoaDon))
                    {
                        return false;
                    }
                    else if(hoaDonNhapMoi.donGia >= dsHoaDonBan[i].donGia)
                    {
                        return false;
                    }
                }
            }
            if (hoaDonNhapMoi.donGia == 0 || hoaDonNhapMoi.soLuong < XuLyHoaDonBan.tongBanTheoMatHang(id))
            {
                return false;
            }

            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if (dsHoaDonNhap[i].maHang == id)
                {
                    dsHoaDonNhap[i] = hoaDonNhapMoi;
                    break;
                }
            }
            LuuTruHoaDonNhap.Luu(dsHoaDonNhap);
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].maHang == id)
                {
                    MatHang mh = dsMatHang[i];
                    mh.maHang = hoaDonNhapMoi.maHang;
                    mh.donGia = hoaDonNhapMoi.donGia;
                    dsMatHang[i] = mh;
                    break;
                }
            }
            LuuTruMatHang.Luu(dsMatHang);
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if (dsHoaDonBan[i].maHang == id)
                {
                    HoaDonBan hdb = dsHoaDonBan[i];
                    hdb.maHang = hoaDonNhapMoi.maHang;
                    dsHoaDonBan[i] = hdb;
                    break;
                }
            }
            LuuTruHoaDonBan.Luu(dsHoaDonBan);
            return true;
        }
    }
}
