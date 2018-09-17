using SQLite;
using SqliteOpdrachten.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteOpdrachten
{
   // [Table("Recipes")]
    public class Recipe : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _name;

        [MaxLength(255)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;

                _name = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public MainPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }


        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);

            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }


        async private void Add_Button(object sender, EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            await _connection.InsertAsync(recipe);

            _recipes.Add(recipe);
        }

        async private  void Update_Button(object sender, EventArgs e)
        {
            var recipe = _recipes[0];
            recipe.Name += " Updated";

            await _connection.UpdateAsync(recipe);
        }

       async private void Delete_Button(object sender, EventArgs e)
        {
            var recipe = _recipes[0];

            await _connection.DeleteAsync(recipe);
            _recipes.Remove(recipe);
        }
    }
}
