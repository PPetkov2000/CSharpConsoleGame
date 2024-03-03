using Game.Models.Warriors;

namespace Game
{
    class Battle
    {
        public static void StartFight(Warrior warrior1, Warrior warrior2)
        {
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                if (GetAttackResult(warrior2, warrior1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }
        }

        public static string GetAttackResult(Warrior warriorOne, Warrior warriorTwo)
        {
            double warriorOneAttackAmount = warriorOne.Attack();
            double warriorTwoArmorAmount = warriorTwo.Block();
            double warriorTwoBlockedAttack = warriorTwo.Guard();
            double damageToWarriorTwo = warriorOneAttackAmount - warriorTwoArmorAmount;

            if (damageToWarriorTwo > 0 && warriorTwoBlockedAttack != 10000)
            {
                warriorTwo.Health = warriorTwo.Health - damageToWarriorTwo;
                Console.WriteLine($"{warriorOne.Name} Attacks {warriorTwo.Name} and Deals {damageToWarriorTwo} Damage");
                Console.WriteLine($"{warriorTwo.Name} has {warriorTwo.Health} health left\n");
            }

            if (warriorTwo.Health <= 0)
            {
                Console.WriteLine($"{warriorTwo.Name} has Died and {warriorOne.Name} is Victorious\n");
                return "Game Over";
            }

            return "Fight";
        }
    }
}
