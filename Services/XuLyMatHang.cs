﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.DAL;
using doAn_KTLT.Entities;

namespace doAn_KTLT.Services
{
    public class XuLyMatHang
    {
        public static List<MatHang> timKiem(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }
            List<MatHang> dsLoaiHang = LuuTruMatHang.Doc();
            List<MatHang> ketQua = new List<MatHang>();
            foreach (MatHang mh in dsLoaiHang)
            {
                if (mh.maHang.Contains(tuKhoa) || mh.tenHang.Contains(tuKhoa) || mh.loaiHang.Contains(tuKhoa) || mh.congTySanXuat.Contains(tuKhoa))
                {
                    ketQua.Add(mh);
                }
            }
            return ketQua;
        }
        public static bool themMatHang(MatHang matHang)
        {
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            foreach(HoaDonNhap hdn in dsHoaDonNhap)
            {
                if(hdn.maHang == matHang.maHang)
                {
                    if(XuLyDate.chuyenDoi(matHang.ngaySanXuat) >= XuLyDate.chuyenDoi(hdn.ngayHoaDon))
                    {
                        return false;
                    }
                    else if(XuLyDate.chuyenDoi(matHang.hanDung) <= XuLyDate.chuyenDoi(hdn.ngayHoaDon))
                    {
                        return false;
                    }
                    else if(XuLyDate.chuyenDoi(matHang.hanDung) <= XuLyDate.chuyenDoi(matHang.ngaySanXuat))
                    {
                        return false;
                    }
                }
            }
            LuuTruMatHang.luuLoaiHang(matHang);
            return true;
        }
        public static MatHang? timMatHang(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            List<MatHang> dsMatHang = LuuTruMatHang.Doc();
            foreach (MatHang mh in dsMatHang)
            {
                if (mh.maHang == id)
                {
                    return mh;
                }
            }
            return null;
        }
        public static bool Xoa(string id)
        {
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            List<MatHang> dsMatHang = LuuTruMatHang.Doc();
            foreach (HoaDonBan hdb in dsHoaDonBan)
            {
                if (hdb.maHang == id)
                {
                    return false;
                }
            }
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].maHang == id)
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
            LuuTruMatHang.Luu(dsMatHang);
            return true;
        }
    }
}
