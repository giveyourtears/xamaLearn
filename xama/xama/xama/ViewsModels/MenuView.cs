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
        public MenuView()
        {
            ProfileName = (string) Application.Current.Properties["name"];
        }
    }
}
