using Logín.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Logín.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CamaraPage : ContentPage
	{
        ObservableCollection<MediaModel> Photos = new ObservableCollection<MediaModel>();

        public CamaraPage ()
		{
			InitializeComponent ();
		}

        private async void photoButton_Pressed(object sender, EventArgs e)
        {
            var isInitialize = await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.IsSupported || !isInitialize)
            {

                await DisplayAlert("Error", "La Camara no se Encuentra Disponible", "OK");
                return;
            }
            var newPhotoID = Guid.NewGuid();

            using (var photo = await CrossMedia.Current.TakePhotoAsync(
                new StoreVideoOptions()
                {
                    Name = newPhotoID.ToString(),
                    SaveToAlbum = true,
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Demo Camara",
                    CustomPhotoSize = 50

                }))
            {
                if (string.IsNullOrWhiteSpace(photo?.Path))
                {
                    return;

                }
                var newPhotoMedia = new MediaModel()
                {
                    MediaID = newPhotoID,
                    Path = photo.Path,
                    LocalDateTime = DateTime.Now
                };

                Photos.Add(newPhotoMedia);

                photo.Dispose();

            }

            listPhotos.ItemsSource = Photos;
        }
    }
}