using xama.Views;
using Xamarin.Forms;

namespace xama
{
  public partial class App
  {
    public App()
    {
      InitializeComponent();

      MainPage = new NavigationPage(new LoginPage());
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
