using System;
using System.Collections.Generic;
using System.Linq;

// 게임의 주요 로직을 관리하는 GameManager 클래스
public class GameManager
{
    private Player player;
    private List<Consumer> consumers;
    private int currentTurn;
    private const int DEBT_PAYMENT_PERIOD = 5; // 5턴마다 빚 변제

    public GameManager()
    {
        // 게임 초기 설정
        player = new Player(10000, 50000); // 10000원으로 시작, 50000원의 빚
        consumers = new List<Consumer>
        {
            new Consumer("전자제품 마니아", ItemType.Electronic),
            new Consumer("미식가", ItemType.Food),
            new Consumer("패셔니스타", ItemType.Apparel)
        };
        currentTurn = 1;
    }

    public void StartGame()
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine("        콘솔 장사 시뮬레이션 게임        ");
        Console.WriteLine("=====================================");
        Console.WriteLine("플레이어는 5턴마다 빚을 변제해야 합니다.\n");

        while (true)
        {
            // 게임 턴 진행
            Console.WriteLine($"\n--- 제 {currentTurn} 턴 ---");
            player.DisplayStatus();

            HandlePlayerActions();

            // 5턴마다 빚 변제
            if (currentTurn % DEBT_PAYMENT_PERIOD == 0)
            {
                Console.WriteLine("\n*** 빚 변제 시기가 돌아왔습니다! ***");
                player.PayDebt(10000); // 예시로 10000원 변제
            }

            // 게임 종료 조건
            if (player.Money < 0 || player.Debt <= 0)
            {
                break;
            }

            currentTurn++;
            Console.WriteLine("\n아무 키나 눌러 다음 턴으로 진행하세요...");
            Console.ReadKey();
            Console.Clear();
        }

        EndGame();
    }

    private void HandlePlayerActions()
    {
        Console.WriteLine("어떤 행동을 하시겠습니까?");
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("2. 아이템 판매");
        Console.WriteLine("3. 빚 변제");
        Console.Write("선택: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                BuyItem();
                break;
            case "2":
                SellItem();
                break;
            case "3":
                Console.Write("얼마를 갚으시겠습니까? ");
                if (int.TryParse(Console.ReadLine(), out int amount))
                {
                    player.PayDebt(amount);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                break;
            default:
                Console.WriteLine("유효하지 않은 선택입니다.");
                break;
        }
    }

    private void BuyItem()
    {
        Console.WriteLine("\n--- 구매 가능한 아이템 ---");
        // 예시 아이템 목록
        var availableItems = new List<Item>
        {
            new Item("사과", ItemType.Food, 1000),
            new Item("낡은 TV", ItemType.Electronic, 50000),
            new Item("티셔츠", ItemType.Apparel, 20000),
            new Item("반지", ItemType.Luxury, 100000)
        };

        for (int i = 0; i < availableItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableItems[i].Name} - {availableItems[i].BasePrice}원");
        }

        Console.Write("구매할 아이템 번호를 선택하세요: ");
        if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex > 0 && itemIndex <= availableItems.Count)
        {
            Item selectedItem = availableItems[itemIndex - 1];
            if (player.UseMoney(selectedItem.BasePrice))
            {
                player.AddItem(selectedItem);
            }
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }
    }

    private void SellItem()
    {
        if (player.Inventory.Count == 0)
        {
            Console.WriteLine("판매할 아이템이 없습니다.");
            return;
        }

        Console.WriteLine("\n--- 판매할 아이템 ---");
        for (int i = 0; i < player.Inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {player.Inventory[i].Name} ({player.Inventory[i].Type})");
        }

        Console.Write("판매할 아이템 번호를 선택하세요: ");
        if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex > 0 && itemIndex <= player.Inventory.Count)
        {
            Item itemToSell = player.Inventory[itemIndex - 1];

            // 판매할 소비자를 무작위로 선택
            Random rand = new Random();
            Consumer consumer = consumers[rand.Next(consumers.Count)];

            Console.WriteLine($"\n'{itemToSell.Name}' 아이템을 {consumer.Name}에게 판매합니다.");
            int price = consumer.BuyItem(itemToSell);

            player.AddMoney(price);
            player.RemoveItem(itemToSell);
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }
    }

    private void EndGame()
    {
        Console.WriteLine("\n=====================================");
        if (player.Debt <= 0)
        {
            Console.WriteLine("      축하합니다! 모든 빚을 갚았습니다!");
        }
        else
        {
            Console.WriteLine("         게임 오버! 소지금이 바닥났습니다.      ");
        }
        Console.WriteLine("=====================================");
    }
}

// 메인 프로그램 진입점
class Program
{
    static void Main(string[] args)
    {
        GameManager game = new GameManager();
        game.StartGame();
    }
}