// 아이템 종류를 정의하는 열거형(enum).
// enum은 관련 있는 상수 집합을 정의할 때 유용합니다.
public enum ItemType
{
    Food,
    Electronic,
    Luxury,
    Apparel,
    Others
}

// 아이템의 속성을 담는 클래스.
public class Item
{
    // 아이템의 이름.
    public string Name { get; private set; }

    // 아이템의 종류를 나타내는 속성.
    public ItemType Type { get; private set; }

    // 아이템의 기본 가격.
    public int BasePrice { get; private set; }

    // Item 클래스의 생성자.
    public Item(string name, ItemType type, int basePrice)
    {
        Name = name;
        Type = type;
        BasePrice = basePrice;
    }

    // 아이템의 정보를 출력하는 메서드.
    public void DisplayItemInfo()
    {
        Console.WriteLine($"--- 아이템 정보 ---");
        Console.WriteLine($"이름: {Name}");
        Console.WriteLine($"종류: {Type}");
        Console.WriteLine($"기본 가격: {BasePrice}원");
        Console.WriteLine("--------------------");
    }
}