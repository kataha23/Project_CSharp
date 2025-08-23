using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class3th
{
    public class Item
    {
        // 현재 잔액
        protected decimal Gold = 10m;
        // 구매됐는가?
        protected bool isBuyed;


        // 아이템 분류 목록
        public enum ItemTypes
        {
            POTION,
            MATERIAL,
            EQUIPMENT,
            WEAPON,
            FOOD,
            OTHERS
        }

        
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public ItemTypes ItemType { get; set; }
        public Item(string itemName, decimal itemPrice, ItemTypes itemType)
        {
           ItemName = itemName;
           ItemPrice = itemPrice;
           ItemType = itemType;
        }

        // 사용 시스템
        public virtual void Use()
        {
            Console.WriteLine($" {ItemName} / 가격 : {ItemPrice} / 분류 : {ItemType} ");
        }

        // 판매 시스템
        public virtual void ShopSell()
        {
            Console.WriteLine($" {ItemName} / 가격 : {ItemPrice} / 분류 : {ItemType}");
            Gold = Gold + ItemPrice;
            
        }

        // 구매 시스템
        public virtual void ShopBuy()
        {
            Console.WriteLine($" {ItemName} / 가격 : {ItemPrice} / 분류 : {ItemType}");

            if (Gold - ItemPrice < 0)
            {
                Console.WriteLine("잔액이 부족합니다.\n");
                isBuyed = false;
            }
            else { Gold = Gold - ItemPrice; isBuyed = true; }


        }



    }

    // 포션 클래스는  Item의 기능을 상속받음 (상속 / Inheritance)
    class Potion : Item
    {
        public Potion(string itemName, decimal itemPrice, ItemTypes itemType) : base(itemName, itemPrice, itemType)
        {

        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine($"이 포션을 사용했습니다. \n");
        }

        public override void ShopSell()
        {
            base.ShopSell();
            Console.WriteLine($"이 포션을 판매했습니다. 현재 잔액 : {Gold} \n");
        }

        public override void ShopBuy()
        {
            base.ShopBuy();
            if (isBuyed) { Console.WriteLine($"이 포션을 구매했습니다. 현재 잔액 : {Gold} \n"); }
        }
    }

    class Weapon : Item
    {
        public Weapon(string itemName, decimal itemPrice, ItemTypes itemType) : base(itemName, itemPrice, itemType)
        {

        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("이 무기를 장착했습니다. \n");
        }

        public override void ShopSell()
        {
            base.ShopSell();
            Console.WriteLine($"이 무기를 판매했습니다. 현재 잔액 : {Gold} \n");
        }

        public override void ShopBuy()
        {
            base.ShopBuy();
            if (isBuyed) { Console.WriteLine($"이 무기를 구매했습니다. 현재 잔액 : {Gold} \n"); }
        }
    }

    class Equipment : Item
    {
        public Equipment(string itemName, decimal itemPrice, ItemTypes itemType) : base(itemName, itemPrice, itemType)
        {

        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("이 장비를 장착했습니다. \n");
        }

        public override void ShopSell()
        {
            base.ShopSell();
            Console.WriteLine($"이 장비를 판매했습니다. 현재 잔액 : {Gold} \n");
        }

        public override void ShopBuy()
        {
            base.ShopBuy();
            if (isBuyed) { Console.WriteLine($"이 장비를 구매했습니다. 현재 잔액 : {Gold} \n"); }
        }
    }

    class Food : Item
    {
        public Food(string itemName, decimal itemPrice, ItemTypes itemType) : base(itemName, itemPrice, itemType)
        {

        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("이 음식을 먹었습니다. \n");
        }

        public override void ShopSell()
        {
            base.ShopSell();
            Console.WriteLine($"이 음식을 판매했습니다. 현재 잔액 : {Gold} \n");
        }

        public override void ShopBuy()
        {
            base.ShopBuy();
            if (isBuyed) { Console.WriteLine($"이 음식을 구매했습니다. 현재 잔액 : {Gold} \n"); }
        }
    }

    class Material : Item
    {
        public Material(string itemName, decimal itemPrice, ItemTypes itemType) : base(itemName, itemPrice, itemType)
        {

        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("이 재료를 사용했습니다. \n");
        }

        public override void ShopSell()
        {
            base.ShopSell();
            Console.WriteLine($"이 재료를 판매했습니다. 현재 잔액 : {Gold} \n");
        }

        public override void ShopBuy()
        {
            base.ShopBuy();
            if (isBuyed) { Console.WriteLine($"이 재료를 구매했습니다. 현재 잔액 : {Gold} \n"); }
        }
    }

    class Others : Item
    {
        public Others(string itemName, decimal itemPrice, ItemTypes itemType) : base(itemName, itemPrice, itemType)
        {

        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("이 아이템을 사용했습니다. \n");
        }

        public override void ShopSell()
        {
            base.ShopSell();
            Console.WriteLine($"이 아이템을 판매했습니다. 현재 잔액 : {Gold} \n");
        }

        public override void ShopBuy()
        {
            base.ShopBuy();
            if (isBuyed) { Console.WriteLine($"이 아이템을 구매했습니다. 현재 잔액 : {Gold} \n"); }
        }
    }
}