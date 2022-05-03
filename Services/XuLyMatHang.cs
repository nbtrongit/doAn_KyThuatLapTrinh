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
        public static bool Sua (string id, MatHang matHangMoi)
        {
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.Doc();
            List<MatHang> dsMatHang = LuuTruMatHang.Doc();
            List<string> dsLoaiHang = LuuTruLoaiHang.Doc();
            MatHang matHang = dsMatHang[0];
            foreach(MatHang mh in dsMatHang)
            {
                if(mh.maHang == id)
                {
                    matHang = mh;
                    break;
                }
            }
            for(int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if(dsHoaDonNhap[i].maHang != id && matHangMoi.maHang == dsHoaDonNhap[i].maHang)
                {
                    return false;
                }
                else if(dsHoaDonNhap[i].maHang == id)
                {
                    if (XuLyDate.chuyenDoi(matHangMoi.hanDung) <= XuLyDate.chuyenDoi(dsHoaDonNhap[i].ngayHoaDon) || XuLyDate.chuyenDoi(matHangMoi.ngaySanXuat) >= XuLyDate.chuyenDoi(dsHoaDonNhap[i].ngayHoaDon))
                    {
                        return false;
                    }
                }
            }
            if (XuLyDate.chuyenDoi(matHangMoi.hanDung) <= XuLyDate.chuyenDoi(matHangMoi.ngaySanXuat))
            {
                return false;
            }
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if(dsHoaDonBan[i].maHang == id && XuLyDate.chuyenDoi(matHangMoi.hanDung) <= XuLyDate.chuyenDoi(dsHoaDonBan[i].ngayHoaDon))
                {
                    return false;
                }
                else if (dsHoaDonBan[i].maHang == id && matHangMoi.donGia >= dsHoaDonBan[i].donGia)
                {
                    return false;
                }
            } 
            if(matHangMoi.donGia == 0)
            {
                return false;
            }
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if(dsLoaiHang[i] != id && dsLoaiHang[i] == matHangMoi.loaiHang)
                {
                    return false;
                }
            }
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if(dsMatHang[i].maHang == id)
                {
                    dsMatHang[i] = matHangMoi;
                }
                if(dsMatHang[i].loaiHang == matHang.loaiHang)
                {
                    MatHang mh = dsMatHang[i];
                    mh.loaiHang = matHangMoi.loaiHang;
                    dsMatHang[i] = mh;
                }
            }
            LuuTruMatHang.Luu(dsMatHang);
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i] == matHang.loaiHang)
                {
                    dsLoaiHang[i] = matHangMoi.loaiHang;
                    break;
                }
            }
            LuuTruLoaiHang.Luu(dsLoaiHang);
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if(dsHoaDonNhap[i].maHang == id)
                {
                    HoaDonNhap hdn = dsHoaDonNhap[i];
                    hdn.maHang = matHangMoi.maHang;
                    hdn.donGia = matHangMoi.donGia;
                    dsHoaDonNhap[i] = hdn;
                    break;
                }
            }
            LuuTruHoaDonNhap.Luu(dsHoaDonNhap);
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if(dsHoaDonBan[i].maHang == id)
                {
                    HoaDonBan hdb = dsHoaDonBan[i];
                    hdb.maHang = matHangMoi.maHang;
                    dsHoaDonBan[i] = hdb;
                }
            }
            LuuTruHoaDonBan.Luu(dsHoaDonBan);
            return true;
        }
    }
}
