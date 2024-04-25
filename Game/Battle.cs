using Game.Models.Warriors;

using Serilog;

namespace Game
{
    class Battle
    {
        public static void StartFight(Warrior warriorOne, Warrior warriorTwo)
        {
            if (warriorOne.WeaponsInUse.Count == 0)
            {
                Log.Information("Warrior {warriorOne} is unequipped. You could use some weapon", warriorOne.Name);
            }
            while (true)
            {
                if (GetBattleResult(warriorOne, warriorTwo) == "Game Over")
                {
                    Log.Information("Game Over");
                    break;
                }
                if (GetBattleResult(warriorTwo, warriorOne) == "Game Over")
                {
                    Log.Information("Game Over");
                    break;
                }
            }
        }

        public static string GetBattleResult(Warrior warriorOne, Warrior warriorTwo)
        {
            var damageToWarriorTwo = warriorOne.Attack(warriorTwo);
            var blockedAttack = warriorTwo.Block();

            if (damageToWarriorTwo > 0 && blockedAttack == false)
            {
                warriorTwo.Health = warriorTwo.Health - damageToWarriorTwo;
                Log.Information("{warriorOne} Attacks {warriorTwo} and Deals {damageToWarriorTwo} Damage", warriorOne.Name, warriorTwo.Name, damageToWarriorTwo);
                Log.Information("{warriorTwo} has {warriorTwoHealth} health left", warriorTwo.Name, warriorTwo.Health);
            }

            if (warriorTwo.Health <= 0)
            {
                Log.Information("{warriorTwo} has Died and {warriorOne} is Victorious", warriorTwo.Name, warriorOne.Name);
                return "Game Over";
            }

            return "Fight";
        }
    }
}
