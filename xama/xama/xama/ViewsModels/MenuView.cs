using System.Windows.Input;
using xama.Views;
using xama.ViewsModels.Base;
using Xamarin.Forms;

namespace xama.ViewsModels
{
    class MenuView : BaseViewModel
    {
        private string _title;
        public string ProfileName
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ICommand OpenProfilePage => new Command(async () =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
        });


        public MenuView()
        {
            ProfileName = (string) Application.Current.Properties["name"];
        }
    }
}
