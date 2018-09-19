using MVVM.Persistence;
using MVVM.ViewModels;

using SqliteOpdrachten.Persistence;

using Xamarin.Forms;

namespace MVVM.Views
{
    public partial class ContactsPage 
	{
        public ContactsPage()
        {
            var contactStore = new SQLiteContactStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ContactBookViewModel(contactStore, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);

            base.OnAppearing();
        }

        void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectContactCommand.Execute(e.SelectedItem);
        }

        public ContactBookViewModel ViewModel
        {
            get { return BindingContext as ContactBookViewModel; }
            set { BindingContext = value; }
        }
    }
}