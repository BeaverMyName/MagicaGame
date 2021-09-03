using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units;

namespace Magica.Interfaces
{
    /// <summary>
    /// All skills in the game must implement the interface ISkill.
    /// </summary>
    interface ISkill
    {
        public string[] Asset { get; }
        public string Name { get; }
        public int ManaCost { get; }

        public bool Action(Unit caster, Unit target);
    }
}
