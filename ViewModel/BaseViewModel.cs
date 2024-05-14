using CommunityToolkit.Mvvm.ComponentModel;

namespace Contador.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current?.MainPage?.DisplayAlert(title, message, cancel)!;
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current?.MainPage?.DisplayAlert(title, message, accept, cancel)!;
        }

        [ObservableProperty] string _title;
        [ObservableProperty] bool _isBusy;
    }
}