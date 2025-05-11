using System.Diagnostics;
using System.Text.RegularExpressions;
using Emptoris.Services;

namespace Emptoris.Views.Elements;

public partial class InsertItem : ContentView
{

    List<string> categories;
    public InsertItem()
    {

        InitializeComponent();
        categories = new List<string>
            {
                "Alimenta��o",
                "Hortifruti",
                "Higiene e Limpeza"
            };


        CategoryPicker.ItemsSource = categories;
        CategoryPicker.SelectedIndex = 0;
    }

    private async void InsertItem_Clicked(object sender, EventArgs e)
    {
        Entry name = NameEntry;
        Entry quantity = QuantityEntry;
        Picker category = CategoryPicker;
        string stringQuantity = quantity.Text;
        string stringCategory = categories[category.SelectedIndex];
        Debug.WriteLine(stringCategory);
        string stringName = name.Text.ToLower();
        int validation = await ItemService.ItemValidationService(stringName);
        Debug.WriteLine(stringName + " J� existe " + validation);



        if (
                !string.IsNullOrWhiteSpace(name.Text) &&
                name.Text.Length > 2 &&
                Regex.IsMatch(name.Text, @"^[a-zA-Z�-��-��-��-��-��-���\s]+$")
            )


        {
            _ = ItemService.AddItem(stringName, stringCategory);
            Debug.WriteLine(stringName);

        }
        else if (validation == 0)
        {
            Debug.WriteLine(stringName + " J� existe " + validation);

            _ = DisplayInfo("Este item j� existe no banco de dados. Preste mais aten��o", "Desculpa, n�o vi");

        }
        else
        {
            _ = DisplayInfo("Insira um texto v�lido", "Desculpa, vou inserir");
        }


    }

    public async Task DisplayInfo(string info, string btn)
    {

        var page = GetParentPage();
        if (page != null)
        {
            await page.DisplayAlert("ATEN��O", info, btn);

        }
    }
    Page GetParentPage()
    {
        Element parent = this;
        while (parent != null)
        {
            if (parent is Page page)
                return page;
            parent = parent.Parent;
        }
        return null;
    }



    public void InsertOnDB()
    {
        Debug.WriteLine("Inerting on db", "InsertITEM");
        _ = ItemService.AddItem("A��car", "Alimenta��o");
        _ = ItemService.AddItem("Arroz", "Alimenta��o");
        _ = ItemService.AddItem("Achocolatado", "Alimenta��o");
        _ = ItemService.AddItem("Aveia", "Alimenta��o");
        _ = ItemService.AddItem("Batata Palha", "Alimenta��o");
        _ = ItemService.AddItem("Mistura para Bolo", "Alimenta��o");
        _ = ItemService.AddItem("Caf�", "Alimenta��o");
        _ = ItemService.AddItem("Chocolate", "Alimenta��o");
        _ = ItemService.AddItem("Coco ralado", "Alimenta��o");
        _ = ItemService.AddItem("Creme de leite", "Alimenta��o");
        _ = ItemService.AddItem("Erva", "Alimenta��o");
        _ = ItemService.AddItem("Ervilha partida", "Alimenta��o");
        _ = ItemService.AddItem("Extrato de tomate", "Alimenta��o");
        _ = ItemService.AddItem("Farinha", "Alimenta��o");
        _ = ItemService.AddItem("Farinha integral", "Alimenta��o");
        _ = ItemService.AddItem("Farofa", "Alimenta��o");
        _ = ItemService.AddItem("Feij�o colorido", "Alimenta��o");
        _ = ItemService.AddItem("Feij�o Preto", "Alimenta��o");
        _ = ItemService.AddItem("Fermento biol�gico", "Alimenta��o");
        _ = ItemService.AddItem("Fermento qu�mico", "Alimenta��o");
        _ = ItemService.AddItem("Gr�o de bico", "Alimenta��o");
        _ = ItemService.AddItem("Leite", "Alimenta��o");
        _ = ItemService.AddItem("Leite condensado", "Alimenta��o");
        _ = ItemService.AddItem("Lentilha", "Alimenta��o");
        _ = ItemService.AddItem("Manteiga", "Alimenta��o");
        _ = ItemService.AddItem("Massa", "Alimenta��o");
        _ = ItemService.AddItem("Massa de pastel", "Alimenta��o");
        _ = ItemService.AddItem("Miervi", "Alimenta��o");
        _ = ItemService.AddItem("Moca/filtro de caf�", "Alimenta��o");
        _ = ItemService.AddItem("Molho de tomate", "Alimenta��o");
        _ = ItemService.AddItem("Nata", "Alimenta��o");
        _ = ItemService.AddItem("�leo", "Alimenta��o");
        _ = ItemService.AddItem("Or�gano", "Alimenta��o");
        _ = ItemService.AddItem("Pipoca", "Alimenta��o");
        _ = ItemService.AddItem("Pimenta preta", "Alimenta��o");
        _ = ItemService.AddItem("Polenta", "Alimenta��o");
        _ = ItemService.AddItem("Polvilho", "Alimenta��o");
        _ = ItemService.AddItem("Prote�na de soja", "Alimenta��o");
        _ = ItemService.AddItem("Queijo", "Alimenta��o");
        _ = ItemService.AddItem("Requeij�o", "Alimenta��o");
        _ = ItemService.AddItem("Ra��o", "Alimenta��o");
        _ = ItemService.AddItem("Sal", "Alimenta��o");
        _ = ItemService.AddItem("Shoyo", "Alimenta��o");

        // Itens sugeridos
        _ = ItemService.AddItem("Azeite de oliva", "Alimenta��o");
        _ = ItemService.AddItem("Vinagre", "Alimenta��o");
        _ = ItemService.AddItem("Ketchup", "Alimenta��o");
        _ = ItemService.AddItem("Mostarda", "Alimenta��o");
        _ = ItemService.AddItem("Mel", "Alimenta��o");
        _ = ItemService.AddItem("Maionese", "Alimenta��o");

        // Categoria Hortifruti
        _ = ItemService.AddItem("Cebola", "Hortifruti");
        _ = ItemService.AddItem("Tomate", "Hortifruti");
        _ = ItemService.AddItem("Alho", "Hortifruti");
        _ = ItemService.AddItem("Alho-por�", "Hortifruti");
        _ = ItemService.AddItem("Batata", "Hortifruti");
        _ = ItemService.AddItem("Cenoura", "Hortifruti");
        _ = ItemService.AddItem("Vagem", "Hortifruti");
        _ = ItemService.AddItem("Piment�o", "Hortifruti");
        _ = ItemService.AddItem("Alface", "Hortifruti");
        _ = ItemService.AddItem("Pera", "Hortifruti");
        _ = ItemService.AddItem("Banana", "Hortifruti");
        _ = ItemService.AddItem("Lim�o", "Hortifruti");
        _ = ItemService.AddItem("Couve", "Hortifruti");
        _ = ItemService.AddItem("Espinafre", "Hortifruti");
        _ = ItemService.AddItem("Br�colis", "Hortifruti");
        _ = ItemService.AddItem("Ab�bora", "Hortifruti");
        _ = ItemService.AddItem("Abobrinha", "Hortifruti");
        _ = ItemService.AddItem("Pepino", "Hortifruti");

        // Categoria Higiene e Limpeza
        _ = ItemService.AddItem("Amaciante", "Higiene e Limpeza");
        _ = ItemService.AddItem("�lcool", "Higiene e Limpeza");
        _ = ItemService.AddItem("Creme dental", "Higiene e Limpeza");
        _ = ItemService.AddItem("Desinfetante", "Higiene e Limpeza");
        _ = ItemService.AddItem("Escova de dente", "Higiene e Limpeza");
        _ = ItemService.AddItem("Esponja", "Higiene e Limpeza");
        _ = ItemService.AddItem("Inseticida", "Higiene e Limpeza");
        _ = ItemService.AddItem("Limpa vidro", "Higiene e Limpeza");
        _ = ItemService.AddItem("Multiuso", "Higiene e Limpeza");
        _ = ItemService.AddItem("Papel higi�nico", "Higiene e Limpeza");
        _ = ItemService.AddItem("Papel toalha", "Higiene e Limpeza");
        _ = ItemService.AddItem("Sab�o em barra", "Higiene e Limpeza");
        _ = ItemService.AddItem("Sab�o l�quido", "Higiene e Limpeza");
        _ = ItemService.AddItem("Sabonete", "Higiene e Limpeza");
        _ = ItemService.AddItem("Sabonete L�quido", "Higiene e Limpeza");
        _ = ItemService.AddItem("Shampoo", "Higiene e Limpeza");
        _ = ItemService.AddItem("Condicionador", "Higiene e Limpeza");
        _ = ItemService.AddItem("�gua sanit�ria", "Higiene e Limpeza");
        _ = ItemService.AddItem("Luvas de borracha", "Higiene e Limpeza");


    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        InsertOnDB();
    }
}






