using Game.Models.Warriors;
using Game.Models.Weapons;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MeleeWeapon knife = new MeleeWeapon(type: "Knife", durability: 100, damage: 20);
            MeleeWeapon sword = new MeleeWeapon(type: "Sword", durability: 100, damage: 30);
            RangedWeapon pistol = new RangedWeapon(type: "Pistol", durability: 100, range: 400, ammo: 250, ammoCapacity: 20, damage: 30, accuracy: 90);
            RangedWeapon bow = new RangedWeapon(type: "Bow", durability: 100, damage: 10, weight: 5, range: 50, ammo: int.MaxValue, ammoCapacity: int.MaxValue, accuracy: 98);
            DefenceWeapon shield = new DefenceWeapon(type: "Shield", durability: 100, damage: 10, weight: 10, maxBlockDamage: 200);
            RangedWeapon staff = new RangedWeapon(type: "Staff", durability: 100, damage: 40, weight: 5, range: 300, ammo: int.MaxValue, ammoCapacity: int.MaxValue, accuracy: 80);
            MeleeWeapon hammer = new MeleeWeapon(type: "Hammer", durability: 100, damage: 60, weight: 15);
            MeleeWeapon axe = new MeleeWeapon(type: "Axe", durability: 100, damage: 80, weight: 20);

            List<Weapon> thorWeapons = new List<Weapon> { hammer, axe };
            List<Weapon> lokiWeapons = new List<Weapon> { staff };
            List<Weapon> captainAmericaWeapons = new List<Weapon> { shield };
            List<Weapon> hawkEyeWeapons = new List<Weapon> { bow, knife, sword };
            List<Weapon> blackWidowWeapons = new List<Weapon> { pistol, knife };

            MeleeWarrior thor = new MeleeWarrior(name: "Thor", health: 300, attackDamage: 50, armor: 30, blockChance: 30, weapons: thorWeapons);
            MagicWarrior loki = new MagicWarrior(name: "Loki", health: 200, attackDamage: 30, armor: 10, teleportChance: 50, weapons: lokiWeapons);
            MeleeWarrior hulk = new MeleeWarrior(name: "Hulk", health: 1000, attackDamage: 200, armor: 10, blockChance: 20);
            MeleeWarrior captainAmerica = new MeleeWarrior(name: "Captain America", health: 100, attackDamage: 20, armor: 20, blockChance: 95, weapons: captainAmericaWeapons);
            MeleeWarrior ironMan = new MeleeWarrior(name: "Iron Man", health: 100, attackDamage: 40, armor: 80, blockChance: 50);
            RangedWarrior hawkeye = new RangedWarrior(name: "Hawkeye", health: 100, attackDamage: 10, armor: 2, blockChance: 10, weapons: hawkEyeWeapons);
            RangedWarrior blackWidow = new RangedWarrior(name: "Black Widow", health: 100, attackDamage: 10, armor: 2, blockChance: 10, weapons: blackWidowWeapons);

            Battle.StartFight(thor, loki);
            // Battle.StartFight(thor, hulk);
            // Battle.StartFight(captainAmerica, ironMan);
            // Battle.StartFight(hawkeye, blackWidow);

            Warrior[] warriors = [thor, loki, hulk, captainAmerica, ironMan, hawkeye, blackWidow];
            Random.Shared.Shuffle(warriors);
            Console.WriteLine("Shuffled warriors");
            foreach (var warrior in warriors)
            {
                Console.WriteLine(warrior.Name);
            }
        }
    }
}