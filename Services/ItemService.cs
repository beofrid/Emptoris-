using Emptoris.Data.Repositories;
using Emptoris.Model;
using System.Diagnostics;


namespace Emptoris.Services
{

    class ItemService
    {

        public static async Task AddItem(string item, string category)
        {
            var itemRepository = new ItemRepository();
            var validation = await ItemValidationService(item);

            if (validation == 0)
            {
                Debug.WriteLine("ITEM SERVICES This item already exists");
            }
            else
            {
                var addItem = new Item
                {
                    ItemName = item,
                    Category = category
                };
                await itemRepository.AddAsync(addItem);
                Debug.WriteLine("ITEM SERVICES: Add " + item + " categoria " + category +  ": successful");

            }


        }
        public static async Task<List<Item>> ShowItems()
        {           
                Debug.WriteLine("Show Items", "ITEM SERVICE");
            var itemRepository = new ItemRepository();

           List<Item> items = await itemRepository.GetAllFromTableAsync();
            foreach (var item in items)
            {
                Debug.WriteLine(item.ItemName, "ITEM SERVICE");
            }

            return items;
        }



        public static async Task<int> ItemValidationService(string item)
        {
            var itemRepository = new ItemRepository();
            if (await itemRepository.GetByNameAsync(item)!= null)
            {
                return 0;
            }
            else
            {
                return 1;
            }


            
        }

    }
    

}
