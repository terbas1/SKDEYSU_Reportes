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
	public partial class InspecSeguridadPage : ContentPage
	{
       
        public string fecha1;
        public string fecha2;
        public string fecha3;
        public string fecha4;

        

        public InspecSeguridadPage ()
		{
			InitializeComponent ();
		}

        private void PickerFecha1_DateSelected(object sender, DateChangedEventArgs e)
        {
            var fecha1 = pickerFecha1.Date;
            var fecha2 = pickerFechaCump.Date;
            var fecha3 = pickerFechaPro.Date;
            var fecha4 = pickerFechaRespo.Date;
           


        }
        private void Button_Clicked(object sender, EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "InspSegurid.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<InsSeguridad>();

            var inspecSeguridad = new InsSeguridad()
            {
                RazoSoci = EntryRaz.Text,
                RUCI = EntryRucc.Text,
                DomicilioI = EntryDomi.Text,
                ActEcono = EntryActividadd.Text,
                NTraba = EntryNumeroo.Text,
                FechaInspec = fecha1,
                Hora = EntryHora.Text,
                AreaInsp= EntryAreaIns.Text,
                ResponsableArea = EntryRespInsp.Text,
                TipoDeInspeccion = pickerTipoInsp.SelectedItem.ToString(), 
                ResponsableInspeccion = EntryResInspParti.Text,
                PeligroDetectado = EntryPeligoDetec.Text,
                Nr = EntryNu.Text,
                AccionTomar = EntryAcTom.Text,
                Responsable = EntryRes.Text,
                FechaProgram = fecha2,
                FechaCumpl = fecha3,
                Comentarios = EntryComentarios.Text,
                NivelRiesgo = pickerNivelRies.SelectedItem.ToString(),
                Descripcion = EntryDesc.Text,
                Observacion = EntryObservacion.Text,
                FechaRegistro = fecha4,
                NombreApellido = EntryNomyApe.Text,
                Cargo = EntryCargo.Text,
             };
            db.Insert(inspecSeguridad);
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