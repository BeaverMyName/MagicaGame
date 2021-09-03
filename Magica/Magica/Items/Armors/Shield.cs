using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;

namespace Magica.Items.Armors
{
    class Shield : Armor
    {
        public Shield(string name, int defence, params ISkill[] skills) : base (name, defence, skills) { }
    }
}
