using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace BaiTapSQLite
{
    public class LoaiHoa : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int MaLoai { get; set; }
        private string _TenLoai;
        public string TenLoai
        {
            get
            {
                return _TenLoai;
            }
            set
            {
                if (_TenLoai != value)
                {
                    _TenLoai = value;

                    OnPropertyChanged("TenLoai");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
