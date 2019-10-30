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
	public partial class HienThiHoa : ContentPage
	{
		public HienThiHoa (int Id)
		{
			InitializeComponent ();
            listViewHoa.ItemsSource = App.db.SelectHoaTheoLoaiHoa(Id);
        }
	}
}