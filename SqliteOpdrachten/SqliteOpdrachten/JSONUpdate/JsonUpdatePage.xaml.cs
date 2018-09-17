using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteOpdrachten.JSONUpdate
{
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JsonUpdatePage : ContentPage
	{
        private const string url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient client = new HttpClient();
        private ObservableCollection<Posts> _posts;


        public JsonUpdatePage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            var content = await client.GetStringAsync(url);
            var posts = JsonConvert.DeserializeObject<List<Posts>>(content);

            _posts = new ObservableCollection<Posts>(posts);
            postsListView.ItemsSource = _posts;

            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var post = new Posts { Title = "Title " + DateTime.Now.Ticks };
            _posts.Insert(0, post);

            var content = JsonConvert.SerializeObject(post); 
            await client.PostAsync(url, new StringContent(content));        
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var post = _posts[0];
            post.Title += " Updated";

            var content = JsonConvert.SerializeObject(post);
            await client.PutAsync(url + "/" + post.Id, new StringContent(content));
        }

       async void OnDelete(object sender, System.EventArgs e)
        {
            var post = _posts[0];
            _posts.Remove(post);

            await client.DeleteAsync(url + "/" + post.Id);         
        }
    }
}