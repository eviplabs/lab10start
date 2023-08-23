using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LAB10_MAUI_AttaxxPlus.Model
{

    /// <summary>
    /// Represents one field of the game.
    /// </summary>
    public class Field : ObservableObject
    {
        public int Row { get; set; }
        public int Column { get; set; }

        private int owner = 0;
        public int Owner { 
            get { return owner; } 
            set {
                if(owner != value)
                {
                    owner = value;
                    Notify();
                }
            }
        }
        public bool IsEmpty() => (owner == 0);

    }
}
