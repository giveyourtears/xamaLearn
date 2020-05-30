using Android.App;
using Android.Support.V7.App;

namespace xama.Droid
{
  [Activity(Label = "Mobile App Name", Theme = "@style/splash_screen", MainLauncher = true, NoHistory = true)]
  public class Splash : AppCompatActivity
  {
    protected override void OnResume()
    {
      base.OnResume();
      StartActivity(typeof(MainActivity));
    }
  }
}