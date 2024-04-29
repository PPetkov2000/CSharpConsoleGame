using Game.Models.Warriors;

using Serilog;

namespace Game
{
    class Battle
    {
        public static void StartFight(Warrior warriorOne, Warrior warriorTwo)
        {
            Log.Information("Battle between {warriorOne} (level {warriorOneLevel}) and {warriorTwo} (level {warriorTwoLevel}) started", warriorOne.Name, warriorOne.Level, warriorTwo.Name, warriorTwo.Level);

            if (warriorOne.WeaponsInUse.Count == 0)
            {
                Log.Information("Warrior {warriorOne} is unequipped. You could use some weapon", warriorOne.Name);
            }
            if (warriorTwo.WeaponsInUse.Count == 0)
            {
                Log.Information("Warrior {warriorTwo} is unequipped. You could use some weapon", warriorTwo.Name);
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
            var blockedAttack = warriorTwo.Block(warriorTwo);

            //if (blockedAttack == true)
            //{
            //    foreach (var w2 in warriorTwo.WeaponsInUse)
            //    {
            //        w2.Block(warriorOne);
            //    }
            //}
            //else
            //{
            //    foreach (var w1 in warriorOne.WeaponsInUse)
            //    {
            //        damageToWarriorTwo += w1.Attack(warriorTwo);
            //    }
            //}

            if (damageToWarriorTwo > 0 && blockedAttack == false)
            {
                warriorTwo.Health = warriorTwo.Health - damageToWarriorTwo;
                Log.Information("{warriorOne} Attacked {warriorTwo} and Dealt {damageToWarriorTwo} Damage. {warriorTwo} has {warriorTwoHealth} health left", warriorOne.Name, warriorTwo.Name, damageToWarriorTwo, warriorTwo.Name, warriorTwo.Health);
            }

            if (warriorTwo.Health <= 0)
            {
                Log.Information("{warriorTwo} has Died and {warriorOne} is Victorious", warriorTwo.Name, warriorOne.Name);
                // TODO: Increase the level and rank of the winner
                return "Game Over";
            }

            return "Fight";
        }
    }
}
