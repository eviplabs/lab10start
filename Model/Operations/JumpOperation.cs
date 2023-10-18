using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_MAUI_AttaxxPlus.Model.Operations
{
    public class JumpOperation : OperationBase
    {
        public JumpOperation(GameBase game) : base(game)
        {
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            if (selectedField == null)
                return false;
            int deltaRow = Math.Abs(selectedField.Row - currentField.Row);
            int deltaCol = Math.Abs(selectedField.Column - currentField.Column);
            if (deltaRow != 0 && deltaCol != 0)
                return false;
            if (deltaRow != 2 && deltaCol != 2)
                return false;
            if (selectedField.Owner == 0)
                return false;
            if (currentField.Owner != 0)
                return false;
            currentField.Owner = selectedField.Owner;
            selectedField.Owner = 0;
            ChangeOwnerOfOccupiedFieldsAroundField(currentField);
            return true;
        }
    }
}
