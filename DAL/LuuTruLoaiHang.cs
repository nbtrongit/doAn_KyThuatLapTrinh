using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.Entities;
using Newtonsoft.Json;
using System.IO;

namespace doAn_KTLT.DAL
{
    public class LuuTruLoaiHang
    {
        public static bool Luu(List<string> dsLoaiHang)
        {
            StreamWriter file = new StreamWriter("./loaihang.json");
            string json = JsonConvert.SerializeObject(dsLoaiHang);
            file.Write(json);
            file.Close();
            return true;
        }
        public static List<string> Doc()
        {
            List<string> dsLoaiHang;
            StreamReader file = new StreamReader("./loaihang.json");
            string json = file.ReadToEnd();
            file.Close();
            dsLoaiHang = JsonConvert.DeserializeObject<List<string>>(json);
            return dsLoaiHang;
        }
        public static void luuLoaiHang(string loaiHang)
        {
            List<string> dsLoaiHang = Doc();
            dsLoaiHang.Add(loaiHang);
            Luu(dsLoaiHang);
        }
    }
}
