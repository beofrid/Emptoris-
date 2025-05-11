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
                "Alimentação",
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
        Debug.WriteLine(stringName + " Já existe " + validation);



        if (
                !string.IsNullOrWhiteSpace(name.Text) &&
                name.Text.Length > 2 &&
                Regex.IsMatch(name.Text, @"^[a-zA-Zà-üÀ-Üá-úÁ-Úã-õÃ-ÕçÇ\s]+$")
            )


        {
            _ = ItemService.AddItem(stringName, stringCategory);
            Debug.WriteLine(stringName);

        }
        else if (validation == 0)
        {
            Debug.WriteLine(stringName + " Já existe " + validation);

            _ = DisplayInfo("Este item já existe no banco de dados. Preste mais atenção", "Desculpa, não vi");

        }
        else
        {
            _ = DisplayInfo("Insira um texto válido", "Desculpa, vou inserir");
        }


    }

    public async Task DisplayInfo(string info, string btn)
    {

        var page = GetParentPage();
        if (page != null)
        {
            await page.DisplayAlert("ATENÇÃO", info, btn);

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
        _ = ItemService.AddItem("Açúcar", "Alimentação");
        _ = ItemService.AddItem("Arroz", "Alimentação");
        _ = ItemService.AddItem("Achocolatado", "Alimentação");
        _ = ItemService.AddItem("Aveia", "Alimentação");
        _ = ItemService.AddItem("Batata Palha", "Alimentação");
        _ = ItemService.AddItem("Mistura para Bolo", "Alimentação");
        _ = ItemService.AddItem("Café", "Alimentação");
        _ = ItemService.AddItem("Chocolate", "Alimentação");
        _ = ItemService.AddItem("Coco ralado", "Alimentação");
        _ = ItemService.AddItem("Creme de leite", "Alimentação");
        _ = ItemService.AddItem("Erva", "Alimentação");
        _ = ItemService.AddItem("Ervilha partida", "Alimentação");
        _ = ItemService.AddItem("Extrato de tomate", "Alimentação");
        _ = ItemService.AddItem("Farinha", "Alimentação");
        _ = ItemService.AddItem("Farinha integral", "Alimentação");
        _ = ItemService.AddItem("Farofa", "Alimentação");
        _ = ItemService.AddItem("Feijão colorido", "Alimentação");
        _ = ItemService.AddItem("Feijão Preto", "Alimentação");
        _ = ItemService.AddItem("Fermento biológico", "Alimentação");
        _ = ItemService.AddItem("Fermento químico", "Alimentação");
        _ = ItemService.AddItem("Grão de bico", "Alimentação");
        _ = ItemService.AddItem("Leite", "Alimentação");
        _ = ItemService.AddItem("Leite condensado", "Alimentação");
        _ = ItemService.AddItem("Lentilha", "Alimentação");
        _ = ItemService.AddItem("Manteiga", "Alimentação");
        _ = ItemService.AddItem("Massa", "Alimentação");
        _ = ItemService.AddItem("Massa de pastel", "Alimentação");
        _ = ItemService.AddItem("Miervi", "Alimentação");
        _ = ItemService.AddItem("Moca/filtro de café", "Alimentação");
        _ = ItemService.AddItem("Molho de tomate", "Alimentação");
        _ = ItemService.AddItem("Nata", "Alimentação");
        _ = ItemService.AddItem("Óleo", "Alimentação");
        _ = ItemService.AddItem("Orégano", "Alimentação");
        _ = ItemService.AddItem("Pipoca", "Alimentação");
        _ = ItemService.AddItem("Pimenta preta", "Alimentação");
        _ = ItemService.AddItem("Polenta", "Alimentação");
        _ = ItemService.AddItem("Polvilho", "Alimentação");
        _ = ItemService.AddItem("Proteína de soja", "Alimentação");
        _ = ItemService.AddItem("Queijo", "Alimentação");
        _ = ItemService.AddItem("Requeijão", "Alimentação");
        _ = ItemService.AddItem("Ração", "Alimentação");
        _ = ItemService.AddItem("Sal", "Alimentação");
        _ = ItemService.AddItem("Shoyo", "Alimentação");

        // Itens sugeridos
        _ = ItemService.AddItem("Azeite de oliva", "Alimentação");
        _ = ItemService.AddItem("Vinagre", "Alimentação");
        _ = ItemService.AddItem("Ketchup", "Alimentação");
        _ = ItemService.AddItem("Mostarda", "Alimentação");
        _ = ItemService.AddItem("Mel", "Alimentação");
        _ = ItemService.AddItem("Maionese", "Alimentação");

        // Categoria Hortifruti
        _ = ItemService.AddItem("Cebola", "Hortifruti");
        _ = ItemService.AddItem("Tomate", "Hortifruti");
        _ = ItemService.AddItem("Alho", "Hortifruti");
        _ = ItemService.AddItem("Alho-poró", "Hortifruti");
        _ = ItemService.AddItem("Batata", "Hortifruti");
        _ = ItemService.AddItem("Cenoura", "Hortifruti");
        _ = ItemService.AddItem("Vagem", "Hortifruti");
        _ = ItemService.AddItem("Pimentão", "Hortifruti");
        _ = ItemService.AddItem("Alface", "Hortifruti");
        _ = ItemService.AddItem("Pera", "Hortifruti");
        _ = ItemService.AddItem("Banana", "Hortifruti");
        _ = ItemService.AddItem("Limão", "Hortifruti");
        _ = ItemService.AddItem("Couve", "Hortifruti");
        _ = ItemService.AddItem("Espinafre", "Hortifruti");
        _ = ItemService.AddItem("Brócolis", "Hortifruti");
        _ = ItemService.AddItem("Abóbora", "Hortifruti");
        _ = ItemService.AddItem("Abobrinha", "Hortifruti");
        _ = ItemService.AddItem("Pepino", "Hortifruti");

        // Categoria Higiene e Limpeza
        _ = ItemService.AddItem("Amaciante", "Higiene e Limpeza");
        _ = ItemService.AddItem("Álcool", "Higiene e Limpeza");
        _ = ItemService.AddItem("Creme dental", "Higiene e Limpeza");
        _ = ItemService.AddItem("Desinfetante", "Higiene e Limpeza");
        _ = ItemService.AddItem("Escova de dente", "Higiene e Limpeza");
        _ = ItemService.AddItem("Esponja", "Higiene e Limpeza");
        _ = ItemService.AddItem("Inseticida", "Higiene e Limpeza");
        _ = ItemService.AddItem("Limpa vidro", "Higiene e Limpeza");
        _ = ItemService.AddItem("Multiuso", "Higiene e Limpeza");
        _ = ItemService.AddItem("Papel higiênico", "Higiene e Limpeza");
        _ = ItemService.AddItem("Papel toalha", "Higiene e Limpeza");
        _ = ItemService.AddItem("Sabão em barra", "Higiene e Limpeza");
        _ = ItemService.AddItem("Sabão líquido", "Higiene e Limpeza");
        _ = ItemService.AddItem("Sabonete", "Higiene e Limpeza");
        _ = ItemService.AddItem("Sabonete Líquido", "Higiene e Limpeza");
        _ = ItemService.AddItem("Shampoo", "Higiene e Limpeza");
        _ = ItemService.AddItem("Condicionador", "Higiene e Limpeza");
        _ = ItemService.AddItem("Água sanitária", "Higiene e Limpeza");
        _ = ItemService.AddItem("Luvas de borracha", "Higiene e Limpeza");


    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        InsertOnDB();
    }
}






