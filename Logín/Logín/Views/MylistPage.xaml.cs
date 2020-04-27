using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Logín.ViewModels;
using Logín.Models;
using Plugin.Media;
using System.Collections.ObjectModel;

namespace Logín.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MylistPage : ContentPage
	{
        

		public MylistPage ()
		{
			InitializeComponent ();
            
            BindingContext = new MylistPageViewModel();

		}
        private async void OneItemSelected(object sender, ItemTappedEventArgs e)
        {
            var item1 = "Observación Preventiva";
            var item2 = "Documento de Inspección";
            var item3 = "Observación Planeada de Tareas (OPT)";
            var mydetail = e.Item as MylistDocuments;

            if (mydetail.Detail.Equals(item1))
            {
                await Navigation.PushAsync(new ObsPreventivaPage());
            }else if (mydetail.Detail.Equals(item2))
            {
                await Navigation.PushAsync(new InspecSeguridadPage());
            }
            else if (mydetail.Detail.Equals(item3))
            {
                await Navigation.PushAsync(new OPTPage());
            }
            else
            {
                await Navigation.PushAsync(new MylistPage());
            }
        }
  
    }
}