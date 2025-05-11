namespace Emptoris.Views.TEST;
using Emptoris.Services;
using Emptoris.Model;
using System.Diagnostics;
using System.Collections.ObjectModel;

public partial class MAINTEST : ContentView
{
	private ObservableCollection<Item> itens;
	public MAINTEST()
	{
		InitializeComponent();

	}





    public async void SearchOnDB(Object sender, EventArgs e)
    {
        Debug.WriteLine("SEARCH ON DB");
        itens = new ObservableCollection<Item>(await ItemService.ShowItems());
        var ordered = new ObservableCollection<Item>(
                (await ItemService.ShowItems()).OrderBy(i => i.ItemName));
        ShoppingList.ItemsSource = ordered;
    }
}