using System;
using System.Collections.Generic;

public class Player
{
    // 플레이어의 소지금을 나타내는 속성. 외부에선 값을 읽기만 가능하게 private set을 사용.
    public int Money { get; private set; }

    // 플레이어가 가진 빚을 나타내는 속성.
    public int Debt { get; private set; }

    // 플레이어가 소유한 아이템 목록.
    public List<Item> Inventory { get; private set; }

    // Player 클래스의 생성자. 게임 시작 시 플레이어의 초기 상태를 설정합니다.
    public Player(int startMoney, int startDebt)
    {
        Money = startMoney;
        Debt = startDebt;
        Inventory = new List<Item>();
    }

    // 소지금을 추가하는 메서드.
    public void AddMoney(int amount)
    {
        if (amount > 0)
        {
            Money += amount;
            Console.WriteLine($"소지금 {amount}원을 얻었습니다. 현재 소지금: {Money}원");
        }
    }

    // 소지금을 사용하는 메서드. 돈이 부족하면 false를 반환합니다.
    public bool UseMoney(int amount)
    {
        if (amount > 0 && Money >= amount)
        {
            Money -= amount;
            Console.WriteLine($"소지금 {amount}원을 사용했습니다. 현재 소지금: {Money}원");
            return true;
        }

        Console.WriteLine("소지금이 부족합니다.");
        return false;
    }

    // 아이템을 인벤토리에 추가하는 메서드.
    public void AddItem(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine($"'{item.Name}' 아이템을 획득했습니다.");
    }

    // 아이템을 인벤토리에서 제거하는 메서드.
    public bool RemoveItem(Item item)
    {
        if (Inventory.Remove(item))
        {
            Console.WriteLine($"'{item.Name}' 아이템을 판매했습니다.");
            return true;
        }

        Console.WriteLine("해당 아이템을 가지고 있지 않습니다.");
        return false;
    }

    // 빚을 갚는 메서드.
    public void PayDebt(int amount)
    {
        if (amount > 0)
        {
            // 갚을 빚이 남은 금액보다 크다면, 남은 빚만 갚습니다.
            int payAmount = Math.Min(amount, Debt);
            if (UseMoney(payAmount))
            {
                Debt -= payAmount;
                Console.WriteLine($"빚 {payAmount}원을 변제했습니다. 남은 빚: {Debt}원");
            }
        }
    }

    // 플레이어의 현재 상태를 출력하는 메서드.
    public void DisplayStatus()
    {
        Console.WriteLine("--- 플레이어 상태 ---");
        Console.WriteLine($"소지금: {Money}원");
        Console.WriteLine($"남은 빚: {Debt}원");
        Console.WriteLine($"인벤토리 아이템 수: {Inventory.Count}개");
        Console.WriteLine("---------------------");
    }
}