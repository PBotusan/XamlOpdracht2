using SqliteOpdrachten.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

       /* public async Task<IEnumerable<Movies>>FindMoviesByTitle(string actor)
        {
            if (movie.Length < MinSearchLength)
                return;
        }*/

        public MovieService ()
		{
			InitializeComponent ();
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
