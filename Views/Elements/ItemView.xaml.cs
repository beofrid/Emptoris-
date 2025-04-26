using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Emptoris.Views.Elements;

public partial class ItemView : ContentView
{
    private ObservableCollection<Test> _test;
    public ItemView()
    {
        InitializeComponent();
        _test = new ObservableCollection<Test>
        {
            new Test {Num = 8},
            new Test {Num = 6},
            new Test {Num = 8},
            new Test {Num = 60},
            new Test {Num = 80},
            new Test {Num = 6}



        };
        ShoppingList.ItemsSource = _test;

    }


    public class Test
    {
        public int Num { get; set; }
        public int CheckState { get; set; } = 0;


    }




    // for windows
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ItemStyleControl(sender);

    }

    #region Item Style
    private void ItemStyleControl(object sender)
    {

        if (sender is Grid grid && grid.BindingContext is Test item)
        {
           
            switch (item.CheckState)
            {
                case 0:
                    ItemStyleHandler(sender, TextDecorations.Strikethrough, Color.FromArgb("#242424"), Color.FromArgb("#242424"), "#060606");
                    Debug.WriteLine("\n\t\t CheckState is" + item.CheckState + "\n");
                    item.CheckState = 1;
                    Debug.WriteLine("\n\t\t CheckState is" + item.CheckState + "\n");
                    break;
                case 1:
                    ItemStyleHandler(sender, TextDecorations.None, Color.FromArgb("#f7dcc4"), Color.FromArgb("#f7dcc4"), "#fe8618");
                    Debug.WriteLine("\n\t\t CheckState is" + item.CheckState + "\n");
                    item.CheckState = 2;
                    Debug.WriteLine("\n\t\t CheckState is" + item.CheckState + "\n");

                    break;
                case 2:
                    ItemStyleHandler(sender, TextDecorations.None, Color.FromArgb("#f7dcc4"), Color.FromArgb("#d7985d"), "Original");
                    Debug.WriteLine("\n\t\t CheckState is" + item.CheckState + "\n");
                    item.CheckState = 0;
                    Debug.WriteLine("\n\t\t CheckState is" + item.CheckState + "\n");

                    break;
                default:
                    break;
            }


        }

    }

    private void ItemStyleHandler(object sender, TextDecorations decorations, Color textColor, Color unTextColor, string backgroundColor)
    {
        Grid? grid = sender as Grid;
        if (grid != null)
        {
        Debug.WriteLine("\n\t\t ItemStyleHandlerGRID ISN'T NULL\n");
            var labels = grid.Children.OfType<Label>().ToList();

            Label? unLabel = labels.FirstOrDefault();
            Label? itemLabel = labels.LastOrDefault();
            Label? numLabel = labels.Count > 1 ? labels[1] : null;
            Border? parentBorder = grid.Parent as Border;

            if (itemLabel != null && numLabel != null && unLabel != null && parentBorder != null)
            {
                itemLabel.TextDecorations = decorations;
                itemLabel.TextColor = textColor;
                unLabel.TextDecorations = decorations;
                unLabel.TextColor = unTextColor;
                numLabel.TextColor = unTextColor;


                if (backgroundColor == "Original" &&
                    Application.Current.Resources.TryGetValue("Secondary", out var originalColor) &&
                    originalColor is Color original)
                {
                    parentBorder.BackgroundColor = original;

                }
                else
                {
                    parentBorder.BackgroundColor = Color.FromArgb(backgroundColor);
                }
            }
        }
    }

#endregion

    private void ShoppingList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        ItemStyleControl(sender);



    }


    private void OnEditSwipe(object sender, EventArgs e)
    {
        var item = ((SwipeItem)sender).CommandParameter;
        // Handle edit
    }

    private void OnDeleteSwipe(object sender, EventArgs e)
    {
        var item = ((SwipeItem)sender).CommandParameter;
        // Handle delete
    }
}


