using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_MAUI_AttaxxPlus.Model.Operations
{
    public interface IOperation
    {
        /// <summary>
        /// Tries to execute this operation
        /// </summary>
        /// <param name="selectedField">A field previously selected by the player (may be null if there is none)</param>
        /// <param name="currentField">The field currently clicked</param>
        /// <returns>True if executed. False if cannot execute (no side effects)</returns>
        bool TryExecute(Field selectedField, Field currentField);
    }
}
