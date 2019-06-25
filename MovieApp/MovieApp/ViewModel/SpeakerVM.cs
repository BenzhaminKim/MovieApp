using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;
using MovieApp.View;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace MovieApp.ViewModel
{
    public class SpeakerVM : BaseViewModel
    {
        public SpeakerVM()
        {
            Speakers = new Speaker().GetSpeakers();
            OpenMoviesPageCommand = new Command(async () => await OpenMoviesPage(), () => !IsBusy);
        }
        bool isBusy;


        public bool IsBusy
        {
            get => isBusy;
            set {  SetProperty(ref isBusy, value); }
        }

        public List<Speaker> Speakers { get; set; }
        public Command OpenMoviesPageCommand { get; }


        public async Task OpenMoviesPage()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() =>
                {
                    Device.BeginInvokeOnMainThread(async() =>
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new MovieVIew() { BindingContext = new MovieVM() });
                    });
                });
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
               IsBusy = false;
            }
        }
    }
}
