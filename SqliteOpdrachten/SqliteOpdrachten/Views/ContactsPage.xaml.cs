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

        public ContactsPage()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            InitializeComponent();

            _contacts = new ObservableCollection<Contact>
            {
                new Contact { Id = 1, FirstName = "John", LastName = "Smith", Email = "john@smith.com", Phone = "0228731221" },
                new Contact { Id = 2, FirstName = "Mary", LastName = "Johnson", Email = "mary@johnson.com", Phone = "0228785236" },
                new Contact { Id = 2, FirstName = "Patrick", LastName = "Marion", Email = "marionP@live.com", Phone = "1234567891" },
                new Contact { Id = 2, FirstName = "peyolo", LastName = "pop", Email = "pejollo@pop.com", Phone = "123654789/" },
                new Contact { Id = 2, FirstName = "Pepsi", LastName = "CO", Email = "Pepsi@co.com", Phone = "061412056" }      
            };
            contacts.ItemsSource = _contacts;  
            

        }

        protected override async void OnAppearing()
        {
            

            await _connection.CreateTableAsync<Contact>();

            var con = await _connection.Table<Contact>().ToListAsync();
            _contacts = new ObservableCollection<Contact>(con);

            contacts.ItemsSource = _contacts;

            base.OnAppearing();
        }


        async void OnAddContact(object sender, System.EventArgs e)
        {
            var page = new ContactDetails(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);
            };

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