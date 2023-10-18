using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_MAUI_AttaxxPlus.Model.Operations
{
    public abstract class OperationBase : IOperation
    {
        protected GameBase game;
        public OperationBase(GameBase game)
        {
            this.game = game;
        }

       
        public abstract bool TryExecute(Field selectedField, Field currentField);

        protected void ChangeOwnerOfOccupiedFieldsAroundField(Field field)
        {
            for (int row = field.Row - 1; row <= field.Row + 1; row++)
                if (row >= 0 && row < game.Fields.GetLength(0))
                    for (int column = field.Column - 1; column <= field.Column + 1; column++)
                        if (column >= 0 && column < game.Fields.GetLength(1))
                            if (!game.Fields[row, column].IsEmpty())
                                game.Fields[row, column].Owner = field.Owner;
        }
    }
}
