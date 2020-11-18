using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.DomainModels
{
    public class Item
    {
        public readonly int MaxCount = 10;
        public readonly int MinCount = 0;
        public ItemType itemId { get; set; }   
        public int Price { get; set; }
        public int ItemCount { get; set; }
       
    }

    public enum ItemType
    {
        Chips,
        Coldrink,
        Chocolates
    }

}
