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
	public partial class ObsPreventivaPage : ContentPage
	{
        public string fecha;
        public string fecha1;
        public string fecha2;

        public ObsPreventivaPage ()
		{
			InitializeComponent ();
           
            
        }
        private void PickerFechaObservador_DateSelected(object sender, DateChangedEventArgs e)
        {
            var fecha = pickerFechaObservador.Date;
            var fecha1 = pickerFechaObservada.Date;
            var fecha2 = pickerFechaLevantamiento.Date;

        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<ObservacionPreventiva>();

            var observacion = new ObservacionPreventiva()
            {
                ObPreTipo = pickerTipo.SelectedItem.ToString(),
                ObPreActoSubEsta = pickerActoSubEstandar.SelectedItem.ToString(),
                ObPreCondicionSubEsta = pickerCondiSubEstandar.SelectedItem.ToString(),
                ObPreDaño = pickerDano.SelectedItem.ToString(),
                ObPreArea = pickerArea.SelectedItem.ToString(),
                ObPreLugar = EntryLugar.Text,
                ObPreNombreObservador = Entryobservador.Text,
                ObPreNombreObservadorFecha = fecha,
                ObPreNombreObservada = EntryObservada.Text,
                ObPreNombreObservadaFecha = fecha1,
                ObPreJefe = EntryJefe.Text,
                ObPreDescripcion = EntryDescripcion.Text,
                ObPreMediCorrectiva = EntryMedida.Text,
                ObPreCompromiso = EntryCompromiso.Text,
                ObPreFechaLevantamiento = fecha2,
            };
            db.Insert(observacion);
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