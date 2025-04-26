using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Emptoris.Views.Elements;

public partial class MenuView : ContentView
{
    public MenuView()
	{
		InitializeComponent();
	}
  
    private void NewBDItem_Clicked(object sender, EventArgs e)
	{
        MainPage.Current.VisibilityHandler("Other"); 
        MainPage.MainFrameInstance.Content = new InsertItem();
    }

	private void ShoppingLists_Clicked(object sender, EventArgs e)
	{
        MainPage.Current.VisibilityHandler("ShoppingList");
        MainPage.MainFrameInstance.Content = new ShoppingListView();
	}



   


}