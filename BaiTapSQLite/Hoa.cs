using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BaiTapSQLite
{
    public class Hoa
    {
        [PrimaryKey,AutoIncrement]
        public int MaHoa { get; set; }
        public int MaLoai { get; set; }
        public string TenHoa { get; set; }
        public string Hinh { get; set; }
        public string Mota { get; set; }
        public int DonGia { get; set; }

    }
}
