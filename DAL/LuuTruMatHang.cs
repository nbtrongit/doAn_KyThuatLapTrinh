using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.Entities;
using Newtonsoft.Json;
using System.IO;

namespace doAn_KTLT.DAL
{
    public class LuuTruMatHang
    {
        public static bool Luu(List<MatHang> dsMatHang)
        {
            StreamWriter file = new StreamWriter("./mathang.json");
            string json = JsonConvert.SerializeObject(dsMatHang);
            file.Write(json);
            file.Close();
            return true;
        }
        public static List<MatHang> Doc()
        {
            List<MatHang> dsMatHan;
            StreamReader file = new StreamReader("./mathang.json");
            string json = file.ReadToEnd();
            file.Close();
            dsMatHan = JsonConvert.DeserializeObject<List<MatHang>>(json);
            return dsMatHan;
        }
        public static void luuLoaiHang(MatHang matHang)
        {
            List<MatHang> dsMatHang = Doc();
            dsMatHang.Add(matHang);
            Luu(dsMatHang);
        }
    }
}
