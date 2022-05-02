using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.DAL;
using doAn_KTLT.Entities;

namespace doAn_KTLT.Services
{
    public class XuLyLoaiHang
    {
        public static bool themLoaiHang(string loaiHang)
        {
            if (loaiHang == null)
            {
                return false;
            }
            List<string> dsLoaiHang = LuuTruLoaiHang.Doc();
            foreach (string lh in dsLoaiHang)
            {
                if (lh == loaiHang)
                {
                    return false;
                }
            }
            LuuTruLoaiHang.luuLoaiHang(loaiHang);
            return true;
        }
        public static List<string> timKiem(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }
            List<string> dsLoaiHang = LuuTruLoaiHang.Doc();
            List<string> ketQua = new List<string>();
            foreach (string lh in dsLoaiHang)
            {
                if (lh.Contains(tuKhoa))
                {
                    ketQua.Add(lh);
                }
            }
            return ketQua;
        }
        public static bool suaLoaiHang(string tuKhoaCu, string tuKhoaMoi)
        {
            List<string> dsLoaiHang = LuuTruLoaiHang.Doc();
            foreach (string lh in dsLoaiHang)
            {
                if (lh == tuKhoaMoi && lh != tuKhoaCu)
                {
                    return false;
                }
            }
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i] == tuKhoaCu)
                {
                    dsLoaiHang[i] = tuKhoaMoi;
                }
            }
            LuuTruLoaiHang.Luu(dsLoaiHang);
            List<MatHang> dsMatHang = LuuTruMatHang.Doc();
            MatHang mh = dsMatHang[0];
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].loaiHang == tuKhoaCu)
                {
                    mh = dsMatHang[i];
                    mh.loaiHang = tuKhoaMoi;
                    dsMatHang[i] = mh;
                }
            }
            LuuTruMatHang.Luu(dsMatHang);
            return true;
        }
        public static bool xoaLoaiHang(string tuKhoa)
        {
            if (tuKhoa == null)
            {
                return false;
            }
            List<MatHang> dsMatHang = LuuTruMatHang.Doc();
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.Doc();
            for(int i = 0; i < dsHoaDonBan.Count; i++)
            {
                for (int j = 0; j < dsMatHang.Count; j++)
                {
                    if((dsHoaDonBan[i].maHang == dsMatHang[j].maHang) && (dsMatHang[j].loaiHang == tuKhoa))
                    {
                        return false;
                    }
                }
            }
            for(int i = 0; i < dsMatHang.Count; i++)
            {
                if(dsMatHang[i].loaiHang == tuKhoa)
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
            LuuTruMatHang.Luu(dsMatHang);
            List<string> dsLoaiHang = LuuTruLoaiHang.Doc();
            foreach (string lh in dsLoaiHang)
            {
                if (lh == tuKhoa)
                {
                    dsLoaiHang.Remove(tuKhoa);
                    LuuTruLoaiHang.Luu(dsLoaiHang);
                    return true;
                }
            }
            return false;
        }
    }
}
