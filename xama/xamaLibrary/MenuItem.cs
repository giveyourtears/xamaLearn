using System;
using System.Collections.Generic;
using System.Text;

namespace xamaLibrary
{
  public enum MenuItemType
  {
    MyFilms,
    LogOut
  }
  public class MenuItem
  {
    public MenuItemType Id { get; set; }

    public string Title { get; set; }

    public string ImagePath { get; set; }
  }
}
