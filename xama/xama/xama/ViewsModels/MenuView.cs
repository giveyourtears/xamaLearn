using System.Collections.ObjectModel;
using xamaLibrary;
using Xamarin.ViewModels.Base;

namespace xama.ViewsModels
{
  class MenuView : BaseViewModel
  {
    private ObservableCollection<MenuItem> _menuItems;
    public ObservableCollection<MenuItem> MenuItems
    {
      get => _menuItems;
      set
      {
        _menuItems = value;
        OnPropertyChanged();
      }
    }
    public MenuView()
    {
      _menuItems = new ObservableCollection<MenuItem>
      {
        new MenuItem {Id = MenuItemType.MyFilms, Title = "My Films", ImagePath = "MyFilms.png"},
        new MenuItem {Id = MenuItemType.LogOut, Title = "Logout", ImagePath = "Logout.png"}
      };
    }
  }
}
