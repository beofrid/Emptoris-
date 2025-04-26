using System.Collections.ObjectModel;
using System.Diagnostics;
using Emptoris.Model;


namespace Emptoris.Views.Elements;

public partial class InsertDBView : ContentView
{
    private ObservableCollection<Item> _itemList;
    public ObservableCollection<Item>? _dropDownitemList;
    public List<Item>? _allItems;
    public Timer timer;

    public InsertDBView()
	{
        Debug.WriteLine("\n\n \t\t INITIALIZED INSERT DB ","INSERTDBVIEW");
		InitializeComponent();
        //InsertItem.Content = new InsertItem();

        _itemList = new ObservableCollection<Item>
        {
            new Item{ ItemName = "Queijo" },
        };

        ShoppingList.ItemsSource = _itemList;
	}



    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
       

    }





    private void DeleteButton_Clicked(object sender, EventArgs e)
    {

    }
}