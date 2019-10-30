using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace BaiTapSQLite
{
    public class Database 
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

       

        public Database()
        {
            creatDatabase();
        }

        public bool creatDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.CreateTable<LoaiHoa>();
                    connection.CreateTable<Hoa>();
                    return true;
                }
            
            }
            catch(SQLiteException ex)
            {
                return false;
            }
        }

        public bool InsertLoaiHoa(LoaiHoa loaiHoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(loaiHoa);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool InsertHoa(Hoa Hoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(Hoa);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool UpdateLoaiHoa(LoaiHoa loaiHoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Update(loaiHoa);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }


        public bool DeleteLoaiHoa(LoaiHoa loaiHoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Delete(loaiHoa);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool DeleteAllLoaiHoa()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    //connection.DeleteAll<LoaiHoa>();
                    connection.DropTable<LoaiHoa>();
                    connection.CreateTable<LoaiHoa>();
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool DeleteAllHoa()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    //connection.DeleteAll<Hoa>();
                    connection.DropTable<Hoa>();
                    connection.CreateTable<Hoa>();
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public List<LoaiHoa> SelectAllLoaiHoa()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<LoaiHoa>().ToList();
                }

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public LoaiHoa SelectOneLoaiHoa(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var lh = from l in connection.Table<LoaiHoa>().ToList()
                             where l.MaLoai == id
                             select l;
                    return lh.ToList().FirstOrDefault();
                }

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public LoaiHoa SelectLoaiHoaTheoTen(string ten)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var lh = from l in connection.Table<LoaiHoa>().ToList()
                             where l.TenLoai == ten
                             select l;
                    return lh.ToList().FirstOrDefault();
                }

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public List<Hoa> SelectHoaTheoLoaiHoa(int maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var dsh = from l in connection.Table<Hoa>().ToList()
                             where l.MaLoai == maloai
                             select l;
                    return dsh.ToList<Hoa>();
                }

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public List<object> SelectAllHoa()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var bangHoa = connection.Table<Hoa>();
                    var bangLoaiHoa = connection.Table<LoaiHoa>();
                    var kq = from h in bangHoa
                            join l in bangLoaiHoa
                            on h.MaLoai equals l.MaLoai
                             select new { h.MaHoa, h.TenHoa, h.Hinh, h.DonGia, h.MaLoai, h.Mota, l.TenLoai};
                    return kq.ToList<object>();
                }

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public List<object> SelectLoaiHoa1()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var bangHoa = connection.Table<Hoa>();
                    var bangLoaiHoa = connection.Table<LoaiHoa>();
                    var lh1 = from h in bangHoa
                              group h by h.MaLoai into kq
                             select new {Maloai = kq.Key, TongSoHoa = kq.Count()};
                    var lh2 = from h in bangLoaiHoa
                              join l1 in lh1 on h.MaLoai equals l1.Maloai
                              select new { h.MaLoai,  h.TenLoai, l1.TongSoHoa};

                    return lh2.ToList<object>();
                }

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
    }
}
