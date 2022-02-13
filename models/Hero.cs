using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrientLogic.models
{
    class Hero : Typ
    {
        public double MaxHealth { get; set; }
        public string Name { get; set; }
        public bool CanBeHealedUntilMax { get; set; }
        public bool CanMoveIfNoEnemy { get; set; }

        public Hero(double maxhealth, string name, bool canbehealeduntilmax, bool canmoveifnoenemy, double health, double attDMG, double attSpeed,
            double attRange, bool canDamage, bool canTakeDamage) : base(health, attDMG, attSpeed, attRange, canDamage, canTakeDamage)
        {
            MaxHealth = maxhealth;
            Name = name;
            CanBeHealedUntilMax = canbehealeduntilmax;
            CanMoveIfNoEnemy = canmoveifnoenemy;
        }

    }
}