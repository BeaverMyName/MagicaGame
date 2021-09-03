using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;
using Magica.Battles;

namespace Magica.Objects.Units.Skills
{
    /*
     * Class that represents all skills in the game.
     */
    abstract class Skill : ISkill
    {
        private string[] asset;
        private string name;
        private int manaCost;

        public string[] Asset
        {
            get
            {
                return asset;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int ManaCost
        {
            get
            {
                return manaCost;
            }
        }

        public Skill(string[] asset, string name, int manaCost)
        {
            this.asset = asset;
            this.name = name;
            this.manaCost = manaCost;
        }

        public virtual bool Action(Unit caster, Unit target)
        {
            if (caster.CurrentMp < manaCost)
            {
                Battle.ChangeLog($"{caster.Name}: Not enough mana");
                return false;
            }
            caster.CurrentMp -= manaCost;
            return true;
        }
    }
}
