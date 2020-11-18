using System;
using System.Collections.Generic;
using TestProject.DomainModels;

namespace TestProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<ItemType, Item> itemMap;
            
            try
            {

                Console.WriteLine("Please provide UserType 0 for Employee and 1 for Admin");
                string inputUser = Console.ReadLine();
                Users users = (Users)Enum.Parse(typeof(Users), inputUser);

                Console.WriteLine("Please provide Action 0 for add, 1 for delete, 2 for update, 3 for buy");
                string inpuAction = Console.ReadLine();
                Actions actions = (Actions)Enum.Parse(typeof(Actions), inpuAction);

                Console.WriteLine("Please provide ItemType 0 for Chips, 1 for Coldrink, 2 for Chocolates");
                string inputItemType = Console.ReadLine();
                ItemType itemType = (ItemType)Enum.Parse(typeof(ItemType), inputItemType);




                string inputPrice = "";
                if (actions == Actions.Add || actions == Actions.Update)
                {
                    Console.WriteLine("Please provide price , a integer number");
                    inputUser = Console.ReadLine();
                }                
                
                int price;
                if (inputPrice.Length > 0)
                    price = Int32.Parse(inputPrice);
                else
                    price = 0;

                string inputNumberOfItems = "";
                if (actions == Actions.Buy)
                {
                    Console.WriteLine("Please provide number of item you want to buy");
                    inputNumberOfItems = Console.ReadLine();
                }
                int numberOfitems;
                if (inputNumberOfItems.Length > 0)
                    numberOfitems = Int32.Parse(inputNumberOfItems);
                else
                    numberOfitems = 0;



                IVendingMachine vendingMachine = new VendingMachine(users, actions);

                switch (actions)
                {
                    case Actions.Add:
                        if (vendingMachine.IsOperationPossible())
                        {
                            vendingMachine.AddItem(itemType, price);
                            Console.WriteLine("item got added successfully " + itemType.ToString());
                        }
                            
                        break;
                    case Actions.Update:
                        if (vendingMachine.IsOperationPossible())
                        {
                            vendingMachine.UpdateItem(itemType, price);
                            Console.WriteLine("item got updated successfully " + itemType.ToString());
                        }
                        break;
                    case Actions.Delete:
                        if (vendingMachine.IsOperationPossible())
                        {
                            vendingMachine.DeleteItem(itemType);
                            Console.WriteLine("item got deleted successfully " + itemType.ToString());
                        }
                        break; ;

                    case Actions.Buy:
                        if (vendingMachine.IsOperationPossible())
                        {
                            vendingMachine.BuyItem(itemType, numberOfitems);
                            Console.WriteLine("you have bought the item successfully " + itemType.ToString());
                        }
                        break;
                    default:
                        // code block
                        break;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Given inputs are not valid Please check");
            }
            


            


        }
    }
}
