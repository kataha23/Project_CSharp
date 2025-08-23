using System;

public class Consumer
{
    // 소비자의 이름
    public string Name { get; private set; }

    // 소비자가 선호하는 아이템 종류
    public ItemType PreferredType { get; private set; }

    // 생성자: 소비자의 이름과 선호 아이템 종류를 설정
    public Consumer(string name, ItemType preferredType)
    {
        Name = name;
        PreferredType = preferredType;
    }

    // 아이템을 구매하고 지불할 금액을 반환하는 메서드
    public int BuyItem(Item item)
    {
        int price = 0;

        // 아이템 종류가 소비자의 선호 타입과 일치하는지 확인
        if (item.Type == PreferredType)
        {
            // 선호 아이템인 경우, 기본 가격의 1.5배 지불
            price = (int)(item.BasePrice * 1.5);
            Console.WriteLine($"{Name}은(는) '{item.Name}'을(를) 선호합니다. 특별 가격으로 {price}원을 지불합니다.");
        }
        else
        {
            // 선호하지 않는 아이템인 경우, 기본 가격과 동일한 금액 지불
            price = item.BasePrice;
            Console.WriteLine($"{Name}은(는) '{item.Name}'에 대해 {price}원을 지불합니다.");
        }

        return price;
    }
}