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
    public partial class ProfilePage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileView();
        }
    }
}