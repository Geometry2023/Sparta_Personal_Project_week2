using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Sparta_Personal_Project_week2
{
    internal class Program
    {
        static UserData user = new UserData
        {
            Level = "01",
            Chad = "전사",
            Power = 10,
            Defense = 5,
            HP = 100,
            Gold = 15000
        };
        static Item item = new Item();

        static void Main(string[] args)
        {
            Console.WriteLine("==============================Game Start==============================\n");
            
            mainView();


            Console.WriteLine("\n===============================Game End===============================");
        }

        public static void mainView()
        {
            Console.Clear();
            Console.WriteLine("+==============================Main View==============================\n");

            Console.Write(
                "스파르타 마을에 오신 여러분 환영합니다.\n" +
                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n" +

                "1. 상태 보기\n" +
                "2. 인벤토리\n" +
                "3. 상점\n\n" +

                "원하시는 행동을 입력해주세요.\n" +
                ">>"
                );
            MainSelectFunc(Int32.Parse(Console.ReadLine()));
        }


        public static void statusView()
        {
            Console.Clear();
            Console.WriteLine("+==============================Status View==============================\n");

            Console.Write(
                "상태 보기\n" +
                "캐릭터의 정보가 표시됩니다.\n\n" +

                "Lv. " + user.Level + "\n" +
                "Chad ( " + user.Chad + " )" + "\n" +
                "공격력 : " + user.Power + " (+" +item.plusStatus[1] + ") " + "\n" +
                "방어력 : " + user.Defense + " (+" +item.plusStatus[0] + ") " + "\n" +
                "체력 : " + user.HP + "\n" +
                "Gold : " + user.Gold +" G" + "\n\n" +

                "0. 나가기" + "\n\n" +

                "원하시는 행동을 입력해주세요.\n" +
                ">>"
                );
            StatusSelectFunc(Int32.Parse(Console.ReadLine()));

        }

        public static void inventoryMainView()
        {
            Console.Clear();
            Console.WriteLine("+==============================Inventory Main View==============================\n");

            Console.Write(
                "인벤토리\n" +
                "보유 중인 아이템을 관리할 수 있습니다.\n\n" +

                "[아이템 목록]\n");
            string str;
            for (int i = 0; i < 6; i++)
            {
                if (item.inventory.ContainsKey(i + 1)) // 해당 아이템을 가지고 있을시
                {
                    if (item.itemSelect[i] == true) // 해당 아이템을 장착 했을시
                    {
                        item.inventory.TryGetValue(i + 1, out str);
                        Console.WriteLine("- " + "[E]" + str);

                    }
                    else if (item.itemSelect[i] == false) // 해당 아이템을 장착하지 않았을시
                    {
                        item.inventory.TryGetValue(i + 1, out str);
                        Console.WriteLine("- " + str);
                    }
                }
            }

            Console.Write("\n" +
                "1. 장착 관리" + "\n" +
                "0. 나가기" + "\n\n" +
                
                "원하시는 행동을 입력해주세요.\n" +
                ">>"
                );
            InventoryMainSelectFunc(Int32.Parse(Console.ReadLine()));
        }

        public static void inventoryEquipView()
        {
            Console.Clear();
            Console.WriteLine("+==============================Inventory View==============================\n");

            Console.Write(
                "인벤토리 - 장착관리\n" +
                "보유 중인 아이템을 관리할 수 있습니다.\n\n" +

                "[아이템 목록]\n");
            string str;
            for (int i = 0; i < 6; i++)
            {
                if (item.inventory.ContainsKey(i + 1)) // 해당 아이템을 가지고 있을시
                {
                    if (item.itemSelect[i] == true) // 해당 아이템을 장착 했을시
                    {
                        item.inventory.TryGetValue(i + 1, out str);
                        Console.WriteLine(i + 1 + " [E]" + str);

                    }
                    else if (item.itemSelect[i] == false) // 해당 아이템을 장착하지 않았을시
                    {
                        item.inventory.TryGetValue(i + 1, out str);
                        Console.WriteLine(i + 1 + " " + str);
                    }
                }
            }
            Console.Write("\n" +
                "0. 나가기" + "\n\n" +

                "원하시는 행동을 입력해주세요.\n" +
                ">>"
                );
            InventoryEquipSelectFunc(Int32.Parse(Console.ReadLine()));
        }

        public static void shopMainView()
        {
            Console.Clear();
            Console.WriteLine("+==============================ShopMain View==============================\n");

            Console.Write(
                "상점\n" +
                "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +

                "[보유 골드]" + "\n" +
                user.Gold + " G" + "\n\n" +

                "[아이템 목록]" + "\n"
                );
            
            for(int i = 0; i < 6; i++)
            {
                if (item.inventory.ContainsKey(i + 1) == true) // 해당 아이템을 이미 구매 했다면, 구매완료 표시.
                    Console.WriteLine("- " + item.arr[i] + "             |  " + "구매완료");
                else if(item.inventory.ContainsKey(i + 1) == false)
                    Console.WriteLine("- " + item.arr[i] + "             |  " + item.arr2[i]);
            }
            
            Console.Write(
                "\n" +
                "1. 아이템 구매" + "\n" +
                "0. 나가기" + "\n\n" +

                "원하시는 행동을 입력해주세요.\n" +
                ">>"
                );
            
            ShopMainSelectFunc(Int32.Parse(Console.ReadLine()));
        }

        public static void shopView()
        {
            Console.Clear();
            Console.WriteLine("+==============================Shop View==============================\n");

            Console.Write(
                "상점\n" +
                "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +

                "[보유 골드]" + "\n" +
                user.Gold + " G" + "\n\n" +

                "[아이템 목록]" + "\n"
                );
            
            for (int i = 0; i < 6; i++)
            {
                if (item.inventory.ContainsKey(i + 1) == true) // 해당 아이템을 이미 구매 했다면, 구매완료 표시.
                    Console.WriteLine(i + 1 + " " + item.arr[i] + "             |  " + "구매완료");
                else if (item.inventory.ContainsKey(i + 1) == false)
                    Console.WriteLine(i + 1 + " " + item.arr[i] + "             |  " + item.arr2[i]);
            }
            
            Console.Write(
                "\n" +
                "0. 나가기" + "\n\n" +

                "원하시는 행동을 입력해주세요.\n" +
                ">>"
                );
            
            ShopSelectFunc(Int32.Parse(Console.ReadLine()));
        }


        static void MainSelectFunc(int n)
        {
            if (n == 1)
                statusView();
            else if (n == 2)
                inventoryMainView();
            else if (n == 3)
                shopMainView();
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.Write("잘못된 입력입니다.");
                Thread.Sleep(1000);
                mainView();
            }
        }

        static void ShopMainSelectFunc(int n)
        {
            if (n == 0)
                mainView();
            else if (n == 1)
                shopView();
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.Write("잘못된 입력입니다.");
                Thread.Sleep(1000);
                shopMainView();
            }

        }

        static void ShopSelectFunc(int n)
        {
            if (n == 0)
                shopMainView();
            else if(n >= 1 && n <= 6)
            {
                if (user.Gold >= item.arr2[n-1]) //구매할 돈이 있으면
                {
                    if (item.inventory.ContainsKey(n)) //아이템을 구매했으면 이미 구입한 아이템 출력
                    {
                        Console.Clear();
                        Console.SetCursorPosition(5, 5);
                        Console.Write("이미 구매한 아이템입니다.");
                        Thread.Sleep(1000);
                        shopView();
                    }
                    else //아이템을 구매 안했으면 구매O
                    {
                        item.inventory.Add(n, item.arr[n-1]);
                        user.Gold -= item.arr2[n - 1];
                        if (n >= 1 && n <= 3)
                        {
                            user.Defense += item.arr3[n - 1];
                            item.plusStatus[0] += item.arr3[n - 1];
                            item.itemSelect[n - 1] = true;
                        }
                        else if (n >= 4 && n <= 6)
                        {
                            user.Power += item.arr3[n - 1];
                            item.plusStatus[1] += item.arr3[n - 1];
                            item.itemSelect[n - 1] = true;
                        }
                        Console.Clear();
                        Console.SetCursorPosition(5, 5);
                        Console.Write("구매를 완료했습니다.");
                        Thread.Sleep(1000);
                        shopView();
                    }
                }      
                else //구매할 돈이 없으면
                {
                    Console.Clear();
                    Console.SetCursorPosition(5, 5);
                    Console.Write("Gold가 부족합니다.");
                    Thread.Sleep(1000);
                    shopView();
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.Write("잘못된 입력입니다.");
                Thread.Sleep(1000);
                shopView();
            }

        }

        static void StatusSelectFunc(int n)
        {
            if (n == 0)
                mainView();
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.Write("잘못된 입력입니다.");
                Thread.Sleep(1000);
                statusView();
            }
                
        }

        static void InventoryMainSelectFunc(int n)
        {
            if (n == 0)
                mainView();
            else if(n == 1)
                inventoryEquipView();
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.Write("잘못된 입력입니다.");
                Thread.Sleep(1000);
                inventoryMainView();
            }

        }

        static void InventoryEquipSelectFunc(int n)
        {
            if (n == 0)
                inventoryMainView();
            else if (n == 1 && item.inventory.ContainsKey(1))
            {
                if (item.itemSelect[0] == false)
                {
                    item.itemSelect[0] = true;
                    user.Defense += item.arr3[0];
                    item.plusStatus[0] += item.arr3[0];
                    inventoryEquipView();
                }
                else if (item.itemSelect[0] == true)
                {
                    item.itemSelect[0] = false;
                    user.Defense -= item.arr3[0];
                    item.plusStatus[0] -= item.arr3[0];
                    inventoryEquipView();
                }
            }
            else if (n == 2 && item.inventory.ContainsKey(2))
            {
                if (item.itemSelect[1] == false)
                {
                    item.itemSelect[1] = true;
                    user.Defense += item.arr3[1];
                    item.plusStatus[0] += item.arr3[1];
                    inventoryEquipView();
                }
                else if (item.itemSelect[1] == true)
                {
                    item.itemSelect[1] = false;
                    user.Defense -= item.arr3[1];
                    item.plusStatus[0] -= item.arr3[1];
                    inventoryEquipView();
                }
            }
            else if (n == 3 && item.inventory.ContainsKey(3))
            {
                if (item.itemSelect[2] == false)
                {
                    item.itemSelect[2] = true;
                    user.Defense += item.arr3[2];
                    item.plusStatus[0] += item.arr3[2];
                    inventoryEquipView();
                }
                else if (item.itemSelect[2] == true)
                {
                    item.itemSelect[2] = false;
                    user.Defense -= item.arr3[2];
                    item.plusStatus[0] -= item.arr3[2];
                    inventoryEquipView();
                }
            }
            else if (n == 4 && item.inventory.ContainsKey(4))
            {
                if (item.itemSelect[3] == false)
                {
                    item.itemSelect[3] = true;
                    user.Power += item.arr3[3];
                    item.plusStatus[1] += item.arr3[3];
                    inventoryEquipView();
                }
                else if (item.itemSelect[3] == true)
                {
                    item.itemSelect[3] = false;
                    user.Power -= item.arr3[3];
                    item.plusStatus[1] -= item.arr3[3];
                    inventoryEquipView();
                }
            }
            else if (n == 5 && item.inventory.ContainsKey(5))
            {
                if (item.itemSelect[4] == false)
                {
                    item.itemSelect[4] = true;
                    user.Power += item.arr3[4];
                    item.plusStatus[1] += item.arr3[4];
                    inventoryEquipView();
                }
                else if (item.itemSelect[4] == true)
                {
                    item.itemSelect[4] = false;
                    user.Power -= item.arr3[4];
                    item.plusStatus[1] -= item.arr3[4];
                    inventoryEquipView();
                }
            }
            else if (n == 6 && item.inventory.ContainsKey(6))
            {
                if (item.itemSelect[5] == false)
                {
                    item.itemSelect[5] = true;
                    user.Power += item.arr3[5];
                    item.plusStatus[1] += item.arr3[5];
                    inventoryEquipView();
                }
                else if (item.itemSelect[5] == true)
                {
                    item.itemSelect[5] = false;
                    user.Power -= item.arr3[5];
                    item.plusStatus[1] -= item.arr3[5];
                    inventoryEquipView();
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.Write("잘못된 입력입니다.");
                Thread.Sleep(1000);
                inventoryEquipView();
            }
            
        }
    }
}
