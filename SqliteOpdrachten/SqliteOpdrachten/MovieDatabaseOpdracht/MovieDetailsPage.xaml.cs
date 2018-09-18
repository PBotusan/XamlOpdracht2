using SqliteOpdrachten.MovieModels;
using SqliteOpdrachten.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteOpdrachten.MovieDatabaseOpdracht
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetailsPage : ContentPage
	{
        private MovieService _movieService = new MovieService();
        private Movies _movie;

        public MovieDetailsPage ()
		{
			InitializeComponent ();
		}
	}
}