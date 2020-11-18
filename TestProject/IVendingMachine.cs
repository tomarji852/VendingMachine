using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DomainModels;

namespace TestProject
{
    public interface IVendingMachine
    {
        bool IsOperationPossible();

        void AddItem(ItemType item, int price);

        void DeleteItem(ItemType item);

        void UpdateItem(ItemType item, int price);

        void BuyItem(ItemType item, int numberOfItem);       

    }
}
