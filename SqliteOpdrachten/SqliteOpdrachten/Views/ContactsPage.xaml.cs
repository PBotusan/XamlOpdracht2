using SQLite;
using SqliteOpdrachten.Models;
using SqliteOpdrachten.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteOpdrachten.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {

        private ObservableCollection<Contact> _contacts;
        private SQLiteAsyncConnection _connection;
        private bool _isDataLoaded;

        public ContactsPage()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            await LoadData();

            base.OnAppearing();
        }

        public async Task LoadData()
        {
          //  await _connection.DropTableAsync<Contact>();

            await _connection.CreateTableAsync<Contact>();


            var con = await _connection.Table<Contact>().ToListAsync();
            _contacts = new ObservableCollection<Contact>(con);
            

            contacts.ItemsSource = _contacts;
        }

        async void OnAddContact(object sender, System.EventArgs e)
        {
            var page = new ContactDetails(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);

            };

           await LoadData();
            await Navigation.PushModalAsync(page);
        }

        async void OnContactSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (contacts.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            contacts.SelectedItem = null;

            var page = new ContactDetails(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;

            };

            
            await Navigation.PushModalAsync(page);
        }

        async void OnDeleteContact(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
                _contacts.Remove(contact);
        }
    }
}