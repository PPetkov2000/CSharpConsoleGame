using Game.Interfaces.Warriors;
using Game.Models.Weapons;

namespace Game.Models.Warriors
{
    class Warrior : IWarrior
    {
        public string Name { get; set; }
        public double Health { get; set; }
        public double AttackDamage { get; set; }
        public double AttackSpeed { get; set; }
        public double Armor { get; set; }
        public double BlockChance { get; set; }
        public double Stamina { get; set; }
        public double Energy { get; set; }
        public double Mana { get; set; }
        public double Weight { get; set; }
        public double Speed { get; set; }
        public double Agility { get; set; }
        public double Endurance { get; set; }
        public double Perception { get; set; }
        public double Intelligence { get; set; }
        public int Level { get; set; }
        //public string Rank { get; set; }
        //public string? Description { get; set; }
        public List<Weapon>? Weapons { get; set; }

        Random random = new Random();

        public Warrior(
            string name = "Warrior",
            double health = 0,
            double attackDamage = 0,
            double attackSpeed = 0,
            double armor = 0,
            double blockChance = 0,
            double stamina = 0,
            double energy = 0,
            double mana = 0,
            double weight = 0,
            double speed = 0,
            double agility = 0,
            double endurance = 0,
            double perception = 0,
            double intelligence = 0,
            int level = 0,
            List<Weapon>? weapons = null
        )
        {
            Name = name;
            Health = health;
            AttackSpeed = attackSpeed;
            AttackDamage = attackDamage;
            Armor = armor;
            BlockChance = blockChance;
            Stamina = stamina;
            Energy = energy;
            Mana = mana;
            Weight = weight;
            Speed = speed;
            Agility = agility;
            Endurance = endurance;
            Perception = perception;
            Intelligence = intelligence;
            Level = level;
            Weapons = weapons ?? new List<Weapon>();
        }

        public double Attack()
        {
            if (AttackDamage <= 0) return 0;
            return random.Next(1, (int)AttackDamage);
        }
        public virtual double Block()
        {
            if (Armor <= 0) return 0;
            return random.Next(1, (int)Armor);
        }
        public virtual double Guard()
        {
            if (BlockChance <= 0) return 0;
            return random.Next(1, (int)BlockChance + 1);
        }
    }
}
