using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
    public interface IPageService
    {
        Task PopModalAsync(Page page);
        Task<Page> PopModalAsync();

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
    }
}
