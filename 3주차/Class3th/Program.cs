using Class3th;
using System.Security.Cryptography.X509Certificates;
using static Class3th.Item;

namespace Class3th
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Items
            Potion redPotion = new Potion("빨간 물약", 20.00m, ItemTypes.POTION);
            Potion bluePotion = new Potion("파란 물약", 20.00m, ItemTypes.POTION);

            Weapon sword = new Weapon("검", 152.00m, ItemTypes.WEAPON);
            Weapon axe = new Weapon("도끼", 140.00m, ItemTypes.WEAPON);

            Material ironOre = new Material("철 원석", 10.20m, ItemTypes.MATERIAL);
            Material goldPiece = new Material("금 조각", 10.20m, ItemTypes.MATERIAL);

            Equipment ironRing = new Equipment("철 반지", 26.00m, ItemTypes.EQUIPMENT);
            Equipment diamondHelmet = new Equipment("다이아몬드 투구", 14.00m, ItemTypes.EQUIPMENT);

            Food healthySoup = new Food("건강한 수프", 2.00m, ItemTypes.FOOD);
            Food chicken = new Food("치킨", 8.00m, ItemTypes.FOOD);

            Others stick = new Others("나무 막대기", 0.12m, ItemTypes.OTHERS);
            Others rock = new Others("돌멩이", 0.15m, ItemTypes.OTHERS);
            #endregion

            List<Item> inventory = new List<Item>();
            inventory.Add(redPotion);
            inventory.Add(sword);
            inventory.Add(healthySoup);
            inventory.Add(chicken);
            inventory.Add(rock);


            Player player = new Player();

            foreach(var item in inventory)
            {
                player.UseItem(item);
            }


            #region JustTest
            player.SellItem(redPotion);
            player.SellItem(healthySoup);
            player.BuyItem(stick);
            player.BuyItem(sword);
            player.SellItem(chicken);
            #endregion

        }

    }
}
