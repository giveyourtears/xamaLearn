using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xama.ViewsModels;
using xamaLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class FilmDetailPage : ContentPage
  {
    public FilmDetailPage(FilmModel model)
    {
      InitializeComponent();
      BindingContext = new FilmDetailView(model);
    }
  }
}