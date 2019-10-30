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
	public partial class ManHinhThemLoai : ContentPage
	{
        LoaiHoa lh;
        public ManHinhThemLoai ()
		{
			InitializeComponent ();

            //listViewLoaiHoa.ItemsSource = App.db.selectLoaiHoa();
            lh = new LoaiHoa();
            lh.TenLoai = "DF";
            this.BindingContext = lh;
        }

        private void btn_addLoai(object sender, EventArgs e)
        {
            lh.TenLoai = txtTenLoai.Text.ToString();
            //App.db.insertLoaiHoa(lh);
            //listViewLoaiHoa.ItemsSource = App.db.selectLoaiHoa();
            txtTenLoai.Text = "";
        }

        private void listViewLoaiHoa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            LoaiHoa lh = (LoaiHoa)listViewLoaiHoa.SelectedItem;
            int Id = lh.MaLoai;
            Navigation.PushAsync(new HienThiHoa(Id));

        }
    }
}