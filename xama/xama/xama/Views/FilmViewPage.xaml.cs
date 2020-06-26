using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xama.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xama.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmViewPage : ContentView
    {
        //private readonly NewFilmView _viewModel;
        //public FilmViewPage()
        //{
        //    InitializeComponent();
        //    BindingContext = _viewModel = new NewFilmView(this);
        //}

        //public FilmViewPage(NewFilmView dishDetail)
        //{
        //    InitializeComponent();
        //    BindingContext = _viewModel = new NewFilmView(this, dishDetail);
        //}

        //private void DeleteIngredient(object sender, EventArgs eventArgs)
        //{
        //    _viewModel.DeleteIngredientCommand.Execute(sender);
        //}
    }
}