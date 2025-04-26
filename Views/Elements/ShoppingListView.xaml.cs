using System.Collections.ObjectModel;
using System.Diagnostics;
using Emptoris.Model;

namespace Emptoris.Views.Elements;

public partial class ShoppingListView : ContentView
{
    public ObservableCollection<Item>? _itemList;
    public List<Item>? _allItems;
    public Timer timer;


    public ObservableCollection<TEST_CARD> ShoppingCard { get; set; }
	public ShoppingListView()
	{
		InitializeComponent();


       


        ShoppingCard = new ObservableCollection<TEST_CARD>
        {
            new TEST_CARD { ListName = "Mercado", PreviewItems = "Arroz, \nFeijão, \nMacarrão" },
            new TEST_CARD { ListName = "Farmácia", PreviewItems = "Vitamina C, Band-aid" },
            new TEST_CARD { ListName = "Padaria", PreviewItems = "Pão, Croissant" },
            new TEST_CARD { ListName = "Hortifruti", PreviewItems = "Maçã, Alface, Cenoura" }
        };

        ListCard.ItemsSource = ShoppingCard;
    



    }

    public class TEST_CARD
    {
        public string? ListName { get; set; }
        public string? PreviewItems { get; set; }
    }

//    protected override void OnParentSet()
//    {
//        base.OnParentSet();
//        createlist(); // Chama o método somente após o carregamento da view
//    }


//    private void createlist()
//    {
//        _allItems = new List<Item>
//        {
//            new Item { ItemName = "Apple" },
//            new Item { ItemName = "Banana" },
//            new Item { ItemName = "Carrot" },
//            new Item { ItemName = "Dairy Milk" },
//            new Item { ItemName = "Eggs" },
//            new Item { ItemName = "Flour" },
//            new Item { ItemName = "Garlic" },
//            new Item { ItemName = "Honey" },
//            new Item { ItemName = "Ice Cream" },
//            new Item { ItemName = "Juice" },
//                    new Item { ItemName = "Apple" },
//            new Item { ItemName = "Banana" },
//            new Item { ItemName = "Carrot" },
//            new Item { ItemName = "Dairy Milk" },
//            new Item { ItemName = "Eggs" },
//            new Item { ItemName = "Flour" },
//            new Item { ItemName = "Garlic" },
//            new Item { ItemName = "Honey" },
//            new Item { ItemName = "Ice Cream" },
//            new Item { ItemName = "Juice" },
//                    new Item { ItemName = "Apple" },
//            new Item { ItemName = "Banana" },
//            new Item { ItemName = "Carrot" },
//            new Item { ItemName = "Dairy Milk" },
//            new Item { ItemName = "Eggs" },
//            new Item { ItemName = "Flour" },
//            new Item { ItemName = "Garlic" },
//            new Item { ItemName = "Honey" },
//            new Item { ItemName = "Ice Cream" },
//            new Item { ItemName = "Juice" }
//        };

//        _itemList = new ObservableCollection<Item>(_allItems);
//        if (ItemList == null)
//        {
//            Debug.WriteLine("ShoppingListView: ITEM IS NOT NULL");
//            return;
//        }
//        else
//        {
//            Debug.WriteLine("ShoppingListView: ITEM IS NOT NULL");

//        }

//    }


 




//    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
//    {
//        //string searchText = e.NewTextValue?.ToLower() ?? string.Empty;


//        //if (string.IsNullOrWhiteSpace(searchText))
//        //{
//        //    _itemList.Clear();
//        //    foreach (var item in _allItems)
//        //        _itemList.Add(item);
//        //}
//        //else
//        //{
//        //    var filteredList = _allItems
//        //        .Where(item => item.ItemName.ToLower().Contains(searchText))
//        //        .ToList();

//        //    _itemList.Clear();
//        //    foreach (var ingredient in filteredList)
//        //        _itemList.Add(ingredient);
//        //}

//    }

//    private void SearchBar_Focused(object sender, FocusEventArgs e)
//    {
//        DropDown.IsVisible = true;
//        ItemList.ItemsSource = _itemList;


//    }

//    private async void SearchBar_Unfocused(object sender, FocusEventArgs e)
//    {
//        await Task.Delay(100);

//        DropDown.IsVisible = false;
//    }
//    private void Button_Clicked(object sender, EventArgs e)
//    {
//        Debug.WriteLine("ShoppingListView: DROP-DOWN BUTTON CLICKED");

//    }
}



/*
 
  public async Task AccessDBAndShowIngredients()
    {
        _allIngredients = await ClientListHelper.GetIngredientsList();
//pega tudo do bd
        _itemList = new ObservableCollection<Ingredient>(_allIngredients);
//coloca na itemlist
        ItemList.ItemsSource = _itemList;
    }


    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue?.ToLower() ?? string.Empty;


        if (string.IsNullOrWhiteSpace(searchText))
        {
            _itemList.Clear();
            foreach (var ingredient in _allIngredients)
                _itemList.Add(ingredient);
        }
        else
        {
            var filteredList = _allIngredients
                .Where(ingredient => ingredient.name.ToLower().Contains(searchText))
                .ToList();

            _itemList.Clear();
            foreach (var ingredient in filteredList)
                _itemList.Add(ingredient);
        }
 */