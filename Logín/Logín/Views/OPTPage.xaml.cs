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
	public partial class OPTPage : ContentPage
	{
        
        public string fecha1;
        public string fecha2;

        public OPTPage ()
		{
			InitializeComponent ();
		}

        private void PickerFecha1_DateSelected(object sender, DateChangedEventArgs e)
        {
            var fecha1 = pickerFecha1.Date;
            var fecha2 = pickerFecha2.Date;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OptDocument.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<OTP>();

            var Opt = new OTP()
            {
                RazonSocial= EntryRazon.Text,
                Domicilio = EntryDomicilio.Text,
                ActividadEconomica = EntryActividad.Text,
                NumTrabajadores = EntryNumero.Text,
                Sede = EntrySede.Text,
                RUC = EntryRuc.Text,
                CentroCosto = EntryCentroCosto.Text,
                Ubicacion = EntryUbicacion.Text,
                NombreDelPETS = EntryNomPets.Text,
                Fecha = fecha1,
                Ocupacion = EntryOcupa.Text,
                Preg1 = EntryPregu1.Text,
                Com1 = EntryCome1.Text,
                Preg2 = EntryPregu2.Text,
                Com2 = EntryCome2.Text,
                Preg3 = EntryPregu3.Text,
                Com3 = EntryCome3.Text,
                Preg4 = EntryPregu4.Text,
                Com4 = EntryCome4.Text,
                Preg5 = EntryPregu5.Text,
                Com5 = EntryCome5.Text,
                Preg6 = EntryPregu6.Text,
                Com6 = EntryCome6.Text,
                Preg7 = EntryPregu7.Text,
                Com7 = EntryCome7.Text,
                Preg8 = EntryPregu8.Text,
                Com8 = EntryCome8.Text,
                Preg9 = EntryPregu9.Text,
                Com9 = EntryCome9.Text,
                Preg10 = EntryPregu10.Text,
                Com10 = EntryCome10.Text,
                Preg11 = EntryPregu11.Text,
                Com11 = EntryCome11.Text,
                Preg12 = EntryPregu12.Text,
                Com12 = EntryCome12.Text,
                Recomendacion=EntryRecomen.Text,
                Responsable= EntryResponsable.Text,
                Fecha2 =fecha2,
                Cargo = EntryCargo.Text,
                NomyApell= EntryNomApell.Text,

            };
            db.Insert(Opt);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Felicitaciones", "Se guardo Correctamente", "Yes", "Cancel");
                if (result)
                    await Navigation.PushAsync(new MylistPage());
            });

        }

        async void IrFoto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CamaraPage());

        }
    }
}