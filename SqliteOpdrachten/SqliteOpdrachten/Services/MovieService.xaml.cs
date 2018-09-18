using Newtonsoft.Json;
using SqliteOpdrachten.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteOpdrachten.Services
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	 partial class MovieService : ContentPage
	{
        public static readonly int MinSearchLength = 5;
        private const string Url = "https://api.themoviedb.org/3/movie/550?api_key=1e525fa1f6a49e6e31a540809b99a24e";
        private HttpClient _client = new HttpClient();


        public async Task<IEnumerable<Movies>>FindMoviesByTitle(string actor)
        {
            if (Title.Length < MinSearchLength)
                return Enumerable.Empty<Movies>();

            var response = await _client.GetAsync($"{Url}?title={actor}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return Enumerable.Empty<Movies>();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Movies>>(content);
        }

        public MovieService ()
		{
			InitializeComponent ();
		}


        public async Task<Movies> GetMovie(string title)
        {
            var response = await _client.GetAsync($"{Url}?={title}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movies>(content);
        }

        //  private new IEnumerable<Movies> movieList;
        // IEnumerable<Movies>FindMoviesByActor()
    }
}



/*
protected override async void OnAppearing()
{

    private ObservableCollection<Movies> _movies;
    var content = await _client.GetStringAsync(Url);
    var movies = JsonConvert.DeserializeObject<Movies>(content);

    _movies = new ObservableCollection<Movies>();
    listView.ItemsSource = _movies;



    base.OnAppearing();


}
*/
