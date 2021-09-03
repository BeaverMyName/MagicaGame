using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;

namespace Magica.Items.Weapons
{
    class Staff : Weapon
    {
        public Staff(string name, int dmg, params ISkill[] skills) : base(name, dmg, skills) { }
    }
}
