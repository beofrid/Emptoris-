using Emptoris.Data.Repositories;
using Emptoris.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emptoris.Services
{
    class ShoppingListService
    {
        public async Task AddShoppingList(string name)
        {
            var shoppingListRepository = new ShoppingListRepository();

            var addShoppingList = new ShoppingList
            {
                ListName = name
            };

            await shoppingListRepository.AddAsync(addShoppingList);
            Debug.WriteLine("Add Shopping List: successful");


        }
    }
}
