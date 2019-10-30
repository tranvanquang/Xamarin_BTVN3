using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaiTapSQLite
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ThemLoaiHoa : ContentPage
	{
        LoaiHoa lh;
        public ThemLoaiHoa ()
		{
			InitializeComponent ();

            listViewLoaiHoa.ItemsSource = App.db.SelectAllLoaiHoa();
            lh = new LoaiHoa();
            lh.TenLoai = "DF";
            this.BindingContext = lh;
        }

        private void btn_themloai(object sender, EventArgs e)
        {           
            lh.TenLoai = tenloaihoa.Text.ToString();
            App.db.InsertLoaiHoa(lh);
            listViewLoaiHoa.ItemsSource = App.db.SelectAllLoaiHoa();
            tenloaihoa.Text = "";
        }

        private void btn_xoaloai(object sender, EventArgs e)
        {
            App.db.DeleteAllLoaiHoa();
            DisplayAlert("Notification", "Đã xoá tất cả các loại hoa", "OK");
            listViewLoaiHoa.ItemsSource = App.db.SelectAllLoaiHoa();
        }

        private void btn_xoahoa(object sender, EventArgs e)
        {
            App.db.DeleteAllHoa();
            DisplayAlert("Notification", "Đã xoá tất cả các hoa", "OK");
        }

        private void listViewLoaiHoa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //LoaiHoa lh = (LoaiHoa)sender;
            LoaiHoa lh = (LoaiHoa)listViewLoaiHoa.SelectedItem;
            int Id = lh.MaLoai;
            Navigation.PushAsync(new HienThiHoa(Id));
            
        }

    }
}