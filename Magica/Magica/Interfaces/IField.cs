using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Interfaces
{
    /// <summary>
    /// All levels in the game must implement the interface IField.
    /// </summary>
    interface IField
    {
        public IObject[,] Field { get; set; }

        public void FieldInitialization(IObject[] objects);

        public void DisplayField();
    }
}
