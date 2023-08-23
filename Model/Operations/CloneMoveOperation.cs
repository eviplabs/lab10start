using System;

namespace LAB10_MAUI_AttaxxPlus.Model.Operations
{
    public class CloneMoveOperation : OperationBase
    {
        public CloneMoveOperation(GameBase game) : base(game)
        {
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            if (selectedField == null)
                return false;


            if (Math.Abs(selectedField.Row - currentField.Row)
                + Math.Abs(selectedField.Column - currentField.Column) == 1
                && !selectedField.IsEmpty()
                && currentField.IsEmpty())
            {
                currentField.Owner = selectedField.Owner;
                
                ChangeOwnerOfOccupiedFieldsAroundField(currentField);
                return true;
            }
            return false;
        }
    }
}