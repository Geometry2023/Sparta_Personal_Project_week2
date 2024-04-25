using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Personal_Project_week2
{
    internal class UserData
    {
        private string level;
        private string chad;
        private int power;
        private int defense;
        private int hp;
        private int gold;

        
        

        public string Level {  get { return level; } set {  level = value; } }
        public string Chad { get {  return chad; } set {  chad = value; } }
        public int Power { get { return power; } set { power = value; } }
        public int Defense { get {  return defense; } set {  defense = value; } }
        public int HP { get { return hp; } set { hp = value; } }
        public int Gold {  get { return gold; } set {  gold = value; } }
    }

    public struct Item
    {
        public string[] arr = {
                             "수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.",
                             "무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.",
                             "스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                             "낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.",
                             "청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.",
                             "스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다.",
            }; //아이템 설명
        public int[] arr2 = { 1000, 1200, 3500, 600, 1500, 4000 }; //아이템 가격
        public int[] arr3 = { 5, 9, 15, 2, 5, 7 }; //아이템 능력치
        public int[] plusStatus = new int[2]; // 아이템을 구매하고 +된 능력치 값을 저장한 배열. 0 : defense, 1 : power
        public Dictionary<int, string> inventory = new Dictionary<int, string>(); // 구매한 아이템 
        public bool[] itemSelect = { false, false, false, false, false, false }; // 아이템 장착 확인. 처음 기본 장착 하지않음.

        public Item()
        {
        }
    }
}
