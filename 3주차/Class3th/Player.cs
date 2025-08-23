using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3th
{
    class Player
    {
        

        public void UseItem(Item item)
        {
           item.Use();
        }

        public void SellItem(Item item) 
        {
            item.ShopSell();
        }

        public void BuyItem(Item item)
        {
            item.ShopBuy();
        }
    }
}
