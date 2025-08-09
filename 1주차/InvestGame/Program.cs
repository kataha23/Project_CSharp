using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq; // LINQ를 사용하기 위해 추가

// 기업 정보
public class Company
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int InitialPrice { get; set; }
    public int PriceChange { get; set; }
}

// 플레이어 정보
public class Player
{
    public long Cash { get; set; }
    public Dictionary<string, int> Stocks { get; set; }
    public Dictionary<string, int> BuyPriceHistory { get; set; }
}

public class StockMarketGame
{
    private static List<Company> companies;
    private static Player player;
    private static Random random;

    public static void Main(string[] args)
    {
        InitializeGame();

        while (true)
        {
            DisplayMarketInfo();
            Console.WriteLine("\n명령어를 입력하세요 (예: buy A 10, sell B 5, next_turn, exit): ");
            var command = Console.ReadLine().ToLower().Split(' ');
            ProcessCommand(command);
        }
    }

    private static void InitializeGame()
    {
        companies = new List<Company>
        {
            new Company { Name = "A 전자", Price = 40000, InitialPrice = 40000 },
            new Company { Name = "B 제약", Price = 25000, InitialPrice = 25000 },
            new Company { Name = "C 화학", Price = 25000, InitialPrice = 25000 },
            new Company { Name = "D 엔터", Price = 25000, InitialPrice = 25000 },
            new Company { Name = "E 바이오", Price = 20000, InitialPrice = 20000 }
        };

        player = new Player
        {
            Cash = 1000000,
            Stocks = new Dictionary<string, int>(),
            BuyPriceHistory = new Dictionary<string, int>()
        };

        random = new Random();
        Console.Clear();
        Console.WriteLine("주식 투자 게임에 오신 것을 환영합니다! 💰");
        Console.WriteLine($"시작 자금: {player.Cash:N0}원\n");
    }

    private static void UpdatePrices()
    {
        foreach (var company in companies)
        {
            var changePercentage = random.NextDouble() * 0.6 - 0.3; // -0.3 ~ 0.3 (30%)
            var priceChange = (int)(company.Price * changePercentage);
            company.PriceChange = priceChange;
            company.Price += priceChange;

            if (company.Price < 0)
            {
                company.Price = 0;
            }
        }
    }

    private static void DisplayMarketInfo()
    {
        Console.Clear();
        Console.WriteLine("--- 현재 시장 상황 ---");
        Console.WriteLine($"플레이어 자금: {player.Cash:N0}원\n");
        // E 바이오와 정렬을 위해 탭 대신 고정된 너비를 사용
        Console.WriteLine("기업명\t\t현재가\t\t전 대비 변동\t\t보유 수량\t매수 시점 대비");

        foreach (var company in companies)
        {
            Console.ForegroundColor = company.PriceChange > 0 ? ConsoleColor.Red : (company.PriceChange < 0 ? ConsoleColor.Blue : ConsoleColor.Gray);
            string priceChangeSign = company.PriceChange > 0 ? "▲" : (company.PriceChange < 0 ? "▼" : "-");
            string priceChangeDisplay = $"{priceChangeSign} {Math.Abs(company.PriceChange):N0}원";

            int ownedStocks = player.Stocks.GetValueOrDefault(company.Name, 0);
            string buyPriceChangeDisplay = "-";

            if (ownedStocks > 0 && player.BuyPriceHistory.ContainsKey(company.Name))
            {
                int buyPrice = player.BuyPriceHistory[company.Name];
                int currentPrice = company.Price;
                long totalProfit = (long)(currentPrice - buyPrice) * ownedStocks;

                Console.ForegroundColor = totalProfit > 0 ? ConsoleColor.Red : (totalProfit < 0 ? ConsoleColor.Blue : ConsoleColor.Gray);
                buyPriceChangeDisplay = $"{totalProfit:N0}원";
            }

            // E 바이오 이름 길이에 맞춰 탭을 조정
            string namePadding = (company.Name == "E 바이오") ? "\t" : "\t\t";
            Console.WriteLine($"{company.Name}{namePadding}{company.Price:N0}원\t{priceChangeDisplay}\t\t{ownedStocks}주\t\t{buyPriceChangeDisplay}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    private static void ProcessCommand(string[] command)
    {
        if (command.Length == 0) return;

        string action = command[0];

        switch (action)
        {
            case "buy":
            case "sell":
                ProcessTradeCommand(command);
                break;
            case "next_turn":
                UpdatePrices();
                Console.WriteLine("턴이 넘어갔습니다. 주가가 변동되었습니다.");
                break;
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("잘못된 명령어입니다. 다시 시도해주세요.");
                break;
        }
        Console.ReadKey();
    }

    private static void ProcessTradeCommand(string[] command)
    {
        if (command.Length < 3)
        {
            Console.WriteLine("잘못된 명령어입니다. 예: buy A 10");
            return;
        }

        string action = command[0];
        string companyName = string.Join(" ", command.Skip(1).Take(command.Length - 2)).ToUpper();

        if (!int.TryParse(command.Last(), out int quantity))
        {
            Console.WriteLine("수량이 올바르지 않습니다.");
            return;
        }

        var company = companies.Find(c => c.Name.Equals(companyName, StringComparison.OrdinalIgnoreCase));
        if (company == null)
        {
            Console.WriteLine("존재하지 않는 기업입니다.");
            return;
        }

        if (action == "buy")
        {
            BuyStock(company, quantity);
        }
        else if (action == "sell")
        {
            SellStock(company, quantity);
        }
    }

    private static void BuyStock(Company company, int quantity)
    {
        long cost = (long)company.Price * quantity;
        if (player.Cash >= cost)
        {
            player.Cash -= cost;
            player.Stocks[company.Name] = player.Stocks.GetValueOrDefault(company.Name, 0) + quantity;

            // 매수 시점 평균 가격 업데이트
            int currentTotalValue = player.Stocks.GetValueOrDefault(company.Name, 0) * player.BuyPriceHistory.GetValueOrDefault(company.Name, 0);
            int newTotalValue = currentTotalValue + company.Price * quantity;
            int newTotalQuantity = player.Stocks.GetValueOrDefault(company.Name, 0);
            player.BuyPriceHistory[company.Name] = newTotalValue / newTotalQuantity;

            Console.WriteLine($"{company.Name} 주식 {quantity}주를 {cost:N0}원에 매수했습니다.");
        }
        else
        {
            Console.WriteLine("자금이 부족합니다.");
        }
    }

    private static void SellStock(Company company, int quantity)
    {
        if (player.Stocks.ContainsKey(company.Name) && player.Stocks[company.Name] >= quantity)
        {
            long profit = (long)company.Price * quantity;
            player.Cash += profit;
            player.Stocks[company.Name] -= quantity;
            Console.WriteLine($"{company.Name} 주식 {quantity}주를 {profit:N0}원에 매도했습니다.");

            if (player.Stocks[company.Name] == 0)
            {
                player.Stocks.Remove(company.Name);
                player.BuyPriceHistory.Remove(company.Name);
            }
        }
        else
        {
            Console.WriteLine("보유 주식이 부족합니다.");
        }
    }
}