
using Logín.Models;
using Logín.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Logín
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        async  void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<Users>().Where(u=>u.UserCorreo.Equals(Correo.Text) && u.UserPassword.Equals(Password.Text)).FirstOrDefault();

            if (myquery !=null)
            {
                App.Current.MainPage = new NavigationPage( new MylistPage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Correo o Contraseña  Incorrecto", "Yes", "Cancel");
                    if (result)
                        await Navigation.PushAsync(new LoginPage());
                    else
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }
                });

            }


        }
    }
}