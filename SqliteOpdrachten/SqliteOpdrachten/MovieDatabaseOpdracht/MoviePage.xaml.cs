using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SqliteOpdrachten.MovieModels;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace SqliteOpdrachten.MovieDatabaseOpdracht
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
        private const string Url = "https://api.themoviedb.org/3/movie/550?api_key=1e525fa1f6a49e6e31a540809b99a24e";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Movies> _movies;


        public MoviePage ()
		{
			InitializeComponent ();
		}


        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var movies = JsonConvert.DeserializeObject<Movies>(content);

            _movies = new ObservableCollection<Movies>();
            listView.ItemsSource = _movies;

            base.OnAppearing();

        }

        private void SearchList_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}