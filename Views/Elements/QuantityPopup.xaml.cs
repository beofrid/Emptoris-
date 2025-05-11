using CommunityToolkit.Maui.Views;

namespace Emptoris.Views.Elements;

public partial class QuantityPopup : Popup
{
    private readonly Action<int> _onQuantitySelected;

    public QuantityPopup(Action<int> onQuantitySelected)
    {
        InitializeComponent();
        _onQuantitySelected = onQuantitySelected;
        




    }
    #region region that I tried to open the keyboard, but it don't worked
    //private async void OnPopupOpened(object sender, EventArgs e)
    //{
    //    await Task.Delay(100); 

    //    QuantityEntry.Focus();
    //}

    //private void FocusEntry()
    //{
    //    if (!QuantityEntry.IsFocused)
    //    {
    //        QuantityEntry.Focus();
    //    }
    //}
    #endregion

    private void OnAddClicked(object sender, EventArgs e)
    {
        if (int.TryParse(QuantityEntry.Text, out int quantity) && quantity > 0)
        {
            _onQuantitySelected?.Invoke(quantity);
            Close(); // dismiss the popup
        }
        else
        {
            // Optionally show a validation message
        }
    }


}