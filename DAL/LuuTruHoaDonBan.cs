using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.Entities;
using Newtonsoft.Json;
using System.IO;

namespace doAn_KTLT.DAL
{
    public class LuuTruHoaDonBan
    {
        public static bool Luu(List<HoaDonBan> dsHoaDonBan)
        {
            StreamWriter file = new StreamWriter("./hoadonban.json");
            string json = JsonConvert.SerializeObject(dsHoaDonBan);
            file.Write(json);
            file.Close();
            return true;
        }
        public static List<HoaDonBan> Doc()
        {
            List<HoaDonBan> dsHoaDonBan;
            StreamReader file = new StreamReader("./hoadonban.json");
            string json = file.ReadToEnd();
            file.Close();
            dsHoaDonBan = JsonConvert.DeserializeObject<List<HoaDonBan>>(json);
            return dsHoaDonBan;
        }
        public static void luuHoaDonBan(HoaDonBan hoaDonBan)
        {
            List<HoaDonBan> dsHoaDonBan = Doc();
            dsHoaDonBan.Add(hoaDonBan);
            Luu(dsHoaDonBan);
        }
    }
}
