using Android.Widget;
using xama.Droid.ToastNotifications;

[assembly: Xamarin.Forms.Dependency(typeof(ToastNotification))]
namespace xama.Droid.ToastNotifications
{
  public class ToastNotification : IToast
  {
    public void Show(string message)
    {
      Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
    }
  }
}