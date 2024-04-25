using Game.Interfaces.Warriors;
using Game.Models.Weapons;

using Serilog;

namespace Game.Models.Warriors
{
    public class Warrior : IWarrior
    {
        public string Name { get; set; } = "Warrior";
        public double? Health { get; set; } = 100;
        public double? AttackDamage { get; set; } = 10;
        public double? AttackSpeed { get; set; } = 1;
        public double? AttackRange { get; set; } = 1;
        public double? Armor { get; set; } = 0;
        public double? BlockChance { get; set; } = 0;
        public double? Stamina { get; set; } = 100;
        public double? Energy { get; set; } = 0;
        public double? Mana { get; set; } = 0;
        public double? Weight { get; set; } = 0;
        public double? Speed { get; set; } = 0;
        public double? Agility { get; set; } = 0;
        public double? Endurance { get; set; } = 0;
        public double? Perception { get; set; } = 0;
        public double? Intelligence { get; set; } = 0;
        public int? Level { get; set; } = 1;
        public string? Rank { get; set; } = "";
        public string? Description { get; set; } = "";
        public double? BaseAttackDamage { get { return Level * 10; } }
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Weapon> WeaponsInUse { get; set; } = new List<Weapon>();
        public int? MaxWeaponsInUseAtOnce { get; set; } = 2;

        Random random = new Random();

        public Warrior(
            string name = "Warrior"
        //double health = 100,
        //double attackDamage = 10,
        //double? attackSpeed = 0,
        //double armor = 0,
        //double? blockChance = 0,
        //double? stamina = 100,
        //double? energy = 0,
        //double? mana = 0,
        //double? weight = 0,
        //double? speed = 0,
        //double? agility = 0,
        //double? endurance = 0,
        //double? perception = 0,
        //double? intelligence = 0,
        //int? level = 1,
        //string? rank = "",
        //string? description = "",
        //List<Weapon>? weapons = null
        //List<Weapon>? weaponsInUse = null
        )
        {
            Name = name;
            //Health = health;
            //AttackSpeed = attackSpeed;
            //AttackDamage = attackDamage;
            //Armor = armor;
            //BlockChance = blockChance;
            //Stamina = stamina;
            //Energy = energy;
            //Mana = mana;
            //Weight = weight;
            //Speed = speed;
            //Agility = agility;
            //Endurance = endurance;
            //Perception = perception;
            //Intelligence = intelligence;
            //Level = level;
            //Rank = rank;
            //Description = description;
            //Weapons = weapons ?? new List<Weapon>();
            //WeaponsInUse = weaponsInUse ?? new List<Weapon>();
        }

        public virtual double Attack(Warrior enemyWarrior)
        {
            WeaponsInUse.ForEach(w =>
            {
                //w.Attack(enemyWarrior);
                Log.Information("Weapon in use: {Type} with {Damage} damage", w.Type, w.Damage);
            });

            var damageFromWeapons = WeaponsInUse.Sum(w => w.Damage);
            var totalAttackDamage = BaseAttackDamage + damageFromWeapons;
            if (totalAttackDamage == null || totalAttackDamage <= 0)
            {
                return 0;
            }
            var damageAfterArmorReduce = totalAttackDamage - (totalAttackDamage * (enemyWarrior.Armor / 100));
            if (damageAfterArmorReduce == null || damageAfterArmorReduce <= 0)
            {
                return 0;
            }
            return (double)damageAfterArmorReduce;
        }

        public virtual bool Block()
        {
            if (BlockChance == null || BlockChance <= 0)
            {
                return false;
            }
            int randomBlockNumber = random.Next(1, 100);
            if (randomBlockNumber < BlockChance)
            {
                Log.Information("{Name} Blocked Enemy Attack", Name);
                return true;
            }
            return false;
        }

        public virtual void ChangeWeapon(Weapon weapon, Weapon? weaponToReplace)
        {
            if (Weapons == null || Weapons.Count == 0)
            {
                Log.Information("{Name} does not have any weapons", Name);
                return;
            }
            bool isValidWeapon = Weapons.Any(w => w.Type == weapon.Type);
            if (isValidWeapon == false)
            {
                Log.Information("The weapon {weapon} can't be used by this warrior {Name}", weapon.Type, Name);
                return;
            }
            if (weapon.Durability <= 0)
            {
                Log.Information("Can't select the chosen weapon {weapon} because it is broken", weapon.Type);
                return;
            }
            if (WeaponsInUse.Count == 0)
            {
                WeaponsInUse.Add(weapon);
            }
            else
            {
                var weaponInUse = WeaponsInUse.FirstOrDefault(w => w.Type == weapon.Type);
                if (weaponInUse == null)
                {
                    if (WeaponsInUse.Count < MaxWeaponsInUseAtOnce)
                    {
                        WeaponsInUse.Add(weapon);
                    }
                    else
                    {
                        if (weaponToReplace == null)
                        {
                            WeaponsInUse.RemoveAt(0);
                            WeaponsInUse.Add(weapon);
                            Log.Information("Maximum capacity of weapons in use at once reached and no specified weapon to replace so the first weapon in use is removed");
                        }
                        else
                        {
                            var weaponToRemove = WeaponsInUse.FirstOrDefault(w => w.Type == weaponToReplace.Type);
                            if (weaponToRemove == null)
                            {
                                Log.Information("The weapon to replace {weaponToReplace} is not present in the list of weapons in use", weaponToReplace.Type);
                            }
                            else
                            {
                                WeaponsInUse.Remove(weaponToRemove);
                                WeaponsInUse.Add(weapon);
                            }
                        }
                    }
                }
                else
                {
                    Log.Information("The weapon you chose to pick is already in use: {weapon}", weapon.Type);
                }
            }
        }
    }
}
