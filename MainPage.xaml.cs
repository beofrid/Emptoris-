using CommunityToolkit.Maui.Views;
using Emptoris.Model;
using Emptoris.Services;
using Emptoris.Views.Elements;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Emptoris

{


    public partial class MainPage : ContentPage
    {
        public static MainPage Current { get; private set; }
        public static Frame MainFrameInstance { get; private set; }
        private ObservableCollection<Item>? _itemList;
        public Timer timer;



        public MainPage()
        {
            InitializeComponent();
            InitializeMainFrame();
            MainFrameInstance = MainFrame; //to acess the main frame from MenuView
            Current = this;


        }

        public void InitializeMainFrame()
        {
            MainFrame.Content = new ItemView();
           // MainFrame.Content = new MAINTEST();
            String appDataPath = FileSystem.AppDataDirectory;
            Debug.WriteLine($"AppDataDirectory: {appDataPath}", "MAIN PAGE");
            VisibilityHandler("AddItem");

        }

        private void ShoppingList_Clicked(Object sender, EventArgs e)
        {
           

        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            InitializeMainFrame();
            VisibilityHandler("AddItem");

            try
            {
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ErroR: {ex.Message}", "MAIN PAGE");
            }
        }

        private void Menu_Button_Clicked(object sender, EventArgs e)
        {
            MainFrame.Content = new MenuView();
            VisibilityHandler("OpenMenu");
            //createlist();




        }
        
        public void VisibilityHandler(string code)
        {
            switch (code)
            {
                case "OpenMenu":
                    MenuBars.IsVisible = false;
                    MenuBtn.IsVisible = false;
                    PlusBtn.IsVisible = true;
                    AppSearchBar.IsVisible = false;
                    break;
                case "AddItem":
                    MenuBars.IsVisible = true;
                    MenuBtn.IsVisible = true;
                    PlusBtn.IsVisible = false;
                    AppSearchBar.IsVisible = true;
                    break;
                case "ShoppingList":
                    MenuBars.IsVisible = true;
                    MenuBtn.IsVisible = true;
                    PlusBtn.IsVisible = false;
                    AppSearchBar.IsVisible = false;
                    break;
                case "Other":
                    MenuBars.IsVisible = true;
                    MenuBtn.IsVisible = true;
                    PlusBtn.IsVisible = true;
                    AppSearchBar.IsVisible = false;
                    break;
                default: Debug.WriteLine("Error: Visibility Handler code is wrong", "MAIN PAGE");
                    break;
              
            }

        }
    

     #region search bar
        protected override void OnParentSet()
        {
            base.OnParentSet();
            FetchItens(); // method that waits the load of the view
        }


        private async void FetchItens()
        {

            _itemList = new ObservableCollection<Item>(await ItemService.ShowItems());
            var itensOrdered = new ObservableCollection<Item>(
                    (await ItemService.ShowItems()).OrderBy(i => i.ItemName));
            ItemList.ItemsSource = itensOrdered;


        }







        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string searchText = e.NewTextValue?.ToLower() ?? string.Empty;


            //if (string.IsNullOrWhiteSpace(searchText))
            //{
            //    _itemList.Clear();
            //    foreach (var item in _allItems)
            //        _itemList.Add(item);
            //}
            //else
            //{
            //    var filteredList = _allItems
            //        .Where(item => item.ItemName.ToLower().Contains(searchText))
            //        .ToList();

            //    _itemList.Clear();
            //    foreach (var ingredient in filteredList)
            //        _itemList.Add(ingredient);
            //}

        }

        private void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            DropDown.IsVisible = true;
            ItemList.ItemsSource = _itemList;


        }

        private void SearchBar_Unfocused(object sender, FocusEventArgs e)
        {
            //maybe useless (in windows machine works)
            HideDropdown();
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("DROP-DOWN BUTTON CLICKED", "MAIN PAGE");
            HideDropdown();


        }
        private void Label_Tapped(Object sender, EventArgs e)
        {
            if (sender is Label label && label.BindingContext is Item selectedItem)
            {
                Console.WriteLine($"Label clicked: {selectedItem.ItemName}");
                if (selectedItem != null)
                {
                    var popup = new QuantityPopup(quantity =>
                    {
                        // This runs after the user confirms the quantity
                        //AddItemToShoppingList(item, quantity);
                    });

                    this.ShowPopup(popup);
                }
            }
            UnfocusSearchbar();
            HideDropdown();
           

        }


        private void UnfocusSearchbar()
        {
            SearchBar SearchBar = AppSearchBar;

            if (AppSearchBar.IsFocused)
            {
                AppSearchBar.Unfocus(); 
            }
        }

        private async void HideDropdown()
        {
            Debug.WriteLine("\n\n \t\t" +
                "" +
                ",HIDE DROP-DOWN", "MAIN PAGE");

            await Task.Delay(100);
            DropDown.IsVisible = false;
        }


    }


    #endregion


}
