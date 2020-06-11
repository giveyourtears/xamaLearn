using xama.Views;

namespace xama
{
  public partial class App
  {
    public App()
    {
      InitializeComponent();

      MainPage = new RegistrationPage();
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
