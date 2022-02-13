using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrientLogic.models
{
    internal class Typ
    {

        public double Health { get; set; }
        public double AttDMG { get; set; }
        public double AttSpeed { get; set; }
        public double AttRange { get; set; }
        public bool CanDamage { get; set; }
        public bool CanTakeDamage { get; set; }

        public Typ(double health, double attDMG, double attSpeed, double attRange, bool canDamage, bool canTakeDamage)
        {
            Health = health;
            AttDMG = attDMG;
            AttSpeed = attSpeed;
            AttRange = attRange;
            CanDamage = canDamage;
            CanTakeDamage = canTakeDamage;
        }
    }
}
