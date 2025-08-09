using System;
using System.Text;

namespace Project_1_GameFlow
{
    internal class Program
    {

        public static ConsoleColor titleColor = ConsoleColor.Cyan;

        static void Main(string[] args)
        {

            #region 프로그래밍 언어의 기본 문법

            #region 주석
            // 주석 : 컴퓨터 못 읽음 (내용 정리/코드를 읽는 다른 사람 배려)
            // ㄴ ctrl + k + c = 범위 주석 활성화 / ctrl + k + u = 범위 주석 비활성화
            // ㄴ shift + alt + 방향키 위 or 아래 = 위/아래 줄 동시 선택 
            #endregion

            #region 변수
            // 변수 : 특정 타임 데이터를 메모리에 저장 / 다시 사용하는 데이터
            // ㄴ 정수, 실수(부동소수점), 문자(열)
            // ㄴ 타입 뒤에 변수를 구분하는 이름을 지어준다.

            // 변수의 선언 및 초기화
            int num1 = 10;
            float numfloat1 = 1.1f;
            string myString = "안녕!";
            char myChar = 'A';
            #endregion

            #region 메소드(함수)

            // 기본 형태 : 접근지정자 리턴타입 함수이름(타입 변수이름)
            // public void MethodName(int num)

            // C# 에서의 특징
            // 1. 메소드는 클래스 안에서 정의되어야 함
            // 2. 메소드의 선언과 사용 방식이 다름
            //  2-1. 선언은 구현되지 않은 내용을 직접 정의하는 것이다. -> 범위로 표현을 해준다.
            // 3. 함수 선언 이후 중괄호로 내용을 표시한다.

            // " 함수를 만들어줘. 접근 지정자를 public, 반환타입을 void로, 매개 인자를 누락해서 만들어줘 "
            // 콘솔 환경, 언어는 C#, 특정 문자열의 색상을 다른 색상으로 변경해주는 함수를 만들어줘.

            #endregion

            #endregion

            // 플레이어 스탯
            float playerHP = 10f;
            float playerATK = 3f;
            int playerGOLD = 100;

            // 적 스탯
            float enemyHP = 10f;
            float enemyATK = 3f;

            #region Cotents
            void InGame()
            {
                StartBattle();
            }

            #region 1. 타이틀
            // 언어/환경 명시 필요 - " C#으로 작성할거임 + 콘솔 환경에서 타이틀을 만들어줘 "
            // 자세한 내용 필요 - " 타이틀은 게임 화면에 이미지와 게임 시작 버튼이 있어야해 "



            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "카타하 어드벤처"; // 콘솔 창 상단 제목
            Console.CursorVisible = false;

            string[] titleArt =
            {
                @"888    d8P         d8888 88888888888        d8888 888    888        d8888",
                @"888   d8P         d88888     888           d88888 888    888       d88888",
                @"888  d8P         d88P888     888          d88P888 888    888      d88P888",
                @"888d88K         d88P 888     888         d88P 888 8888888888     d88P 888",
                @"8888888b       d88P  888     888        d88P  888 888    888    d88P  888",
                @"888  Y88b     d88P   888     888       d88P   888 888    888   d88P   888",
                @"888   Y88b   d8888888888     888      d8888888888 888    888  d8888888888",
                @"888    Y88b d88P     888     888     d88P     888 888    888 d88P     888",
                "",
                ""
            };

            string[] menuItems = {
                "게임 시작\n",
                "  설 정\n",
                "  종 료\n"
            };
            int selectedIndex = 0;



            // 타이틀 화면 루프
            while (true)
            {
                Console.Clear();
                PrintCentered(titleArt);
                Console.WriteLine();
                PrintMenu(menuItems, selectedIndex);

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;
                else if (key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex + 1) % menuItems.Length;
                else if (key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0) // 게임 시작
                    {
                        StartGame();
                        break;
                    }
                    else if (selectedIndex == 1) // 설정
                    {
                        ShowSettings();
                    }
                    else if (selectedIndex == 2) // 종료
                    {
                        break;
                    }
                }
            }

            // 게임 종료 코드
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("게임을 종료합니다...");
            Thread.Sleep(1000);



            static void PrintCentered(string[] lines)
            {

                int width = Console.WindowWidth;
                int startY = Math.Max(0, (Console.WindowHeight - lines.Length) / 4);

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    int startX = Math.Max(0, (width - line.Length) / 2);
                    Console.SetCursorPosition(startX, startY + i);
                    Console.ForegroundColor = titleColor;
                    Console.Write(line);
                    Console.ResetColor();
                }
            }

            static void PrintMenu(string[] items, int selectedIndex)
            {
                int width = Console.WindowWidth;
                for (int i = 0; i < items.Length; i++)
                {
                    string item = items[i];
                    int startX = Math.Max(0, (width - item.Length) / 2);
                    Console.SetCursorPosition(startX, Console.CursorTop);

                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.WriteLine(item);
                    Console.ResetColor();
                }
            }

            void StartGame()
            {
                Console.Clear();
                Console.WriteLine("게임이 시작됩니다...");
                Thread.Sleep(1500);
                // 실제 게임 로직으로 이동
                InGame();
            }

            void ShowSettings()
            {
                Console.Clear();
                Console.WriteLine("[설정 메뉴]");

                Console.Write("변경할 색상 이름을 입력하세요: ");
                string colorName = Console.ReadLine();
                ColorSettings(colorName);

                Console.WriteLine("아무 키나 누르면 메인 메뉴로 돌아갑니다...");
                Console.ReadKey(true);
            }

            #endregion

            #region 2. 캐릭터
            // ㄴ 캐릭터는 체력, 공격력 존재 / UI 필요
            // ㄴ " 게임 캐릭터의 체력과 공격력을 설치하고 이를 UI에 표시하도록 해줘 "

            void ShowPlayerStats()
            {
                Console.Clear();


                // 화면 오른쪽 위에 표시
                Console.SetCursorPosition(Console.WindowWidth - 20, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"♥ HP: {playerHP}");
                Console.ResetColor();

                Console.SetCursorPosition(Console.WindowWidth - 20, 1);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"⚔ ATK: {playerATK}");
                Console.ResetColor();

                Console.SetCursorPosition(Console.WindowWidth - 20, 2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"$ GOLD: {playerGOLD}");
                Console.ResetColor();

                Console.ReadKey();
            }
            #endregion

            #region 3. 전투  

            void ShowEnemyStats()
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[적] HP: {enemyHP}  ATK: {enemyATK}");
                Console.ResetColor();
            }

            void StartBattle()
            {

                while (playerHP > 0 && enemyHP > 0)
                {
                    Console.Clear();

                    // 양쪽 스탯 표시
                    ShowPlayerStats();
                    ShowEnemyStats();

                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("행동을 선택하세요:");
                    Console.WriteLine("1. 공격");
                    Console.WriteLine("2. 방어");

                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.D1)
                    {
                        // 플레이어 공격
                        Console.WriteLine($"당신은 적에게 {playerATK} 피해를 입혔습니다!");
                        enemyHP -= playerATK;
                    }
                    else if (key == ConsoleKey.D2)
                    {
                        // 방어 (피해 절반)
                        Console.WriteLine("당신은 방어 자세를 취했습니다!");
                    }
                    Thread.Sleep(800);

                    // 적 턴
                    if (enemyHP > 0)
                    {
                        float damage = enemyATK;
                        if (key == ConsoleKey.D2) damage /= 2; // 방어 시 절반 피해
                        Console.WriteLine($"적이 공격하여 {damage} 피해를 입혔습니다!");
                        playerHP -= damage;
                    }
                    Thread.Sleep(1000);
                }

                Console.Clear();
                if (playerHP <= 0 && enemyHP <= 0)
                    Console.WriteLine("무승부! 서로 쓰러졌습니다.");
                else if (playerHP <= 0)
                    Console.WriteLine("당신은 패배했습니다...");
                else
                    Console.WriteLine("승리! 적을 물리쳤습니다!");

                Console.WriteLine("아무 키나 누르면 메인 메뉴로 돌아갑니다...");
                Console.ReadKey(true);
            }
            #endregion

            #region 4. 보상
            #endregion

            #region 5. 성장
            #endregion

            #region 6. 스토리 
            #endregion

            #endregion
        }

        public static void ColorSettings(string colorName)
        {
            if (Enum.TryParse(colorName, true, out ConsoleColor newColor))
            {
                titleColor = newColor;
                Console.WriteLine($"타이틀 색상이 {newColor}로 변경되었습니다!");
            }
            else
            {
                Console.WriteLine("잘못된 색상 이름입니다. 예: Red, Blue, Yellow...");
            }
        }

    }
}
