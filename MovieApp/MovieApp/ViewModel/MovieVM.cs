using System;
using System.Collections.Generic;
using System.Collections;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MovieApp.Model;
using System.Collections.ObjectModel;
using System.Net;
using Xamarin.Forms;
using MovieApp.View;
using System.ComponentModel;

namespace MovieApp.ViewModel
{
    public class MovieVM : BaseViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<string> MovieId { get; set; }

        Movie selectedMovie;
        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                if(selectedMovie != value)
                {
                    selectedMovie = value;
                    OpenDetail();
                }     
            }
        }
        bool isBusy;
        public bool IsBusy
        {
            get => IsBusy;
            set
            {
                if (isBusy == value)
                    return;
                isBusy = SetProperty(ref isBusy, value);
            }
        }

        public MovieVM()
        {
            MovieId = new ObservableCollection<string>();
            Movies = new ObservableCollection<Movie>();
            MakeIdList();
            foreach (string id in MovieId)
            {
                GetMovie(id);
            }
        }
        
        public async Task GetMoviesAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var url = "";
                var client = new HttpClient();
                var json = await client.GetStringAsync(url);
                var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(json);
                foreach (var movie in movies)
                {
                    Movies.Add(movie);
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message,"Cancel");
            }
            finally
            {
                IsBusy = false;
            }
        }
        void GetMovie(string id)
        {
                Movie data;
            using( WebClient wc = new WebClient())
            {
                
                var url = $"http://www.omdbapi.com/?i={id}&apikey=e472ba33";
                var json = wc.DownloadString(url);

                data = JsonConvert.DeserializeObject<Movie>(json.ToString());
                Movies.Add(data);
            }

        }
        void MakeIdList()
        {
            MovieId.Add("tt0848228");
            MovieId.Add("tt0084472");
            MovieId.Add("tt0103639");
            MovieId.Add("tt0215369");
            MovieId.Add("tt0438097");
            MovieId.Add("tt0120755");
            MovieId.Add("tt0117060");
            MovieId.Add("tt0363547");
            MovieId.Add("tt0032553");
            MovieId.Add("tt0880502");
            MovieId.Add("tt0817225");
            MovieId.Add("tt0444182");
            MovieId.Add("tt0292610");
            MovieId.Add("tt0209475");
            MovieId.Add("tt0107076");
            MovieId.Add("tt0120596");
        }
        async void OpenDetail()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DetailView() { BindingContext = selectedMovie });
        }
    }
}
