using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaiTapSQLite
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ThemHoa : ContentPage
	{
		public ThemHoa ()
		{
			InitializeComponent ();
            pickerLoaiHoa.BindingContext = App.db;
            pickerLoaiHoa.ItemsSource = App.db.SelectAllLoaiHoa();
            
            //Cai cho nay tuy thuoc vao Nen tang muon chay.
            //Android:
            //string[] dshinh = new string[] { "@drawable/hoa1.jpg", "@drawable/hoa2.png", "@drawable/hoa3.jpg", "@drawable/hoa4.png", "@drawable/hoa5.jpg", "@drawable/hoa6.png", "@drawable/hoa7.jpg", "@drawable/hoa8.png", "@drawable/hoa9.jpg", "@drawable/hoa10.png"};
            //IOS:
            string[] dshinh = new string[] { "hoa1.jpg", "hoa2.png", "hoa3.jpg", "hoa4.png", "hoa5.jpg", "hoa6.png", "hoa7.jpg", "hoa8.png", "hoa9.jpg", "hoa10.png" };
            pickerHinh.ItemsSource = dshinh;
        }
        private void btn_themhoa(object sender, EventArgs e)
        {
            Hoa hoa = new Hoa();
            LoaiHoa loaihoa = (LoaiHoa)pickerLoaiHoa.SelectedItem;
            hoa.MaLoai = loaihoa.MaLoai;
            hoa.TenHoa = txtTenHoa.Text.ToString();
            hoa.Hinh = pickerHinh.SelectedItem.ToString();
            hoa.DonGia = int.Parse(txtGiaBan.Text);
            hoa.Mota = txtMoTa.Text.ToString();
            if (App.db.InsertHoa(hoa)) DisplayAlert("Notification", "Thêm hoa thành công", "OK");
            else DisplayAlert("Notification", "Thất bại ...", "OK");
            Clear();
        }

        private void btn_xoahoa(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            pickerLoaiHoa.SelectedItem = null;
            pickerHinh.SelectedItem = null;
            txtGiaBan.Text = "";
            txtMoTa.Text = "";
            txtTenHoa.Text = "";
        }
    }
}