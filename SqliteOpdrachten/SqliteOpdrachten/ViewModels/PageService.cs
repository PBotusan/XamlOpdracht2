using MVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
   public class PageService : IPageService
    {
   
        public async Task PopModalAsync(Page page)
        {
            await MainPage.Navigation.PushModalAsync(page);
        }

        public async Task<Page> PopModalAsync()
        {
            return await MainPage.Navigation.PopModalAsync();
        }

        public Task PushModalAsync(ContactDetails contactDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);


        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }

    }
}
