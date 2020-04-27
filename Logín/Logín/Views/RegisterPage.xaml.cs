using Logín.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Logín.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<Users>();
            var usuario = new Users()
            {
                UserNombres = EntryNombres.Text,
                UserApellidos = EntryApellidos.Text,
                UserDNI = EntryDNI.Text,
                UserCelular = EntryCelular.Text,
                UserCorreo = EntryCorreo.Text,
                UserPassword = EntryPassword.Text,
            };
            db.Insert(usuario);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Felicitaciones", " Usuario Registrado Exitosamente", "Yes", "Cancel");
                if (result)
                    await Navigation.PushAsync(new LoginPage());
            });
            
            

        }
    }
}