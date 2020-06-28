using System;
using xama.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new MenuView();
        }

        private void Signup(object sender, EventArgs e)
        {
          Application.Current.MainPage = new ProfilePage();
        }
  }
}