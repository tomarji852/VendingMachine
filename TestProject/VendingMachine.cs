using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DomainModels;

namespace TestProject
{
    public class VendingMachine : IVendingMachine
    {
       // private List<Item> _items;
        private Dictionary<ItemType, Item> _itemMap;
        private Users _users;
        private Actions _actions;


        public VendingMachine( Users users, Actions actions)
        {
            this._itemMap = new Dictionary<ItemType, Item>();
            this._users = users;
            this._actions = actions;
        }

        public bool IsOperationPossible()
        {
            if(_users == Users.Employees)
            {
                if (_actions == Actions.Buy)
                    return true;
            }
            else
            {
                return true;
            }

            return false;
        }

        public void AddItem(ItemType item, int price)
        {
            if (!_itemMap.ContainsKey(item))
            {                
                _itemMap.Add(item, new Item() {itemId = item, ItemCount = 1, Price = price });
            }

            else
            {
                if (_itemMap[item].ItemCount < _itemMap[item].MaxCount)
                    _itemMap[item].ItemCount++;
                else
                {
                    throw new OutOfMemoryException();
                }
            }
           
            
        }

        public void BuyItem(ItemType item, int numberOfItem)
        {
            if (_itemMap.ContainsKey(item) && _itemMap[item].ItemCount >= numberOfItem)
            {
                _itemMap[item].ItemCount -= numberOfItem;
                if (_itemMap[item].ItemCount < 5)
                    Console.WriteLine("Please add more item :" + item.ToString());
            }              

            else
            {
                Console.WriteLine("There is not item availale so you can not buy item :" + item.ToString());
                throw new OutOfMemoryException();
            }
        }

        public void DeleteItem(ItemType item)
        {
            if (_itemMap.ContainsKey(item) && _itemMap[item].ItemCount > _itemMap[item].MinCount)
            {
                _itemMap[item].ItemCount -= 1;
                if (_itemMap[item].ItemCount < 5)
                    Console.WriteLine("Please add more item :" + item.ToString());
            }

            else
            {
                Console.WriteLine("There is not item availale so you can not delete item :" + item.ToString());
                throw new OutOfMemoryException();
            }
        }

        public void UpdateItem(ItemType item, int price)
        {
            if (_itemMap.ContainsKey(item))
             _itemMap[item].Price = price;
        }
    }
}
