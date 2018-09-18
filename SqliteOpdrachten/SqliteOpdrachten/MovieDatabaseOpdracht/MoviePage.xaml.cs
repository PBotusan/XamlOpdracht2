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
using SqliteOpdrachten.Services;

namespace SqliteOpdrachten.MovieDatabaseOpdracht
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
        private MovieService _service = new MovieService();
        private BindableProperty isSearchingProperty = BindableProperty.Create("IsSearching", typeof(bool), typeof(MoviePage), false);

        public bool IsSearching
        {
            get { return (bool)GetValue(isSearchingProperty); }
            set { SetValue(isSearchingProperty, value); }
        }

        public MoviePage ()
		{
            BindingContext = this;
			InitializeComponent ();
		}


        private void SearchList_TextChanged(object sender, TextChangedEventArgs e)
		{
            if (e.NewTextValue == null)
                return;

            //if (SearchBar.(searchList))
            //   return _movies;
            // || e.NewTextValue.Length < MovieService.MinSearchLength
            //return _movies.Where(c => c.Adult.StartWith(searchList));
           // await FindMovieTitles(title: e.NewTextValue);
        }

		async private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
            if (e.SelectedItem == null)
                return;

            var movie = e.SelectedItem as Movies; // moet nog naar gekeken worden
            listView.SelectedItem = null;

            await Navigation.PushModalAsync(new MovieDetailsPage());
        }
	}
}