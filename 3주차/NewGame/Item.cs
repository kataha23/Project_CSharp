using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGame
{
    class Item
    {
        public enum ItemGrades
        {
            COMMON,
            RARE,
            EPIC,
            LEGENDARY
        }

        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public ItemGrades ItemGrade { get; set; }

        public Item(string itemName, int itemPrice, ItemGrades itemGrade)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemGrade = itemGrade;
        }

        public virtual void Enforce()
        {
            Console.WriteLine($"{ItemName}을(를) 강화합니다.");
        }



    }
}
