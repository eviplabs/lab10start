using LAB10_MAUI_AttaxxPlus.Model.Operations;

namespace LAB10_MAUI_AttaxxPlus.ViewModel
{

    public class FieldCommand : CommandBase
    {

        private readonly GameViewModel vm;

        private readonly CloneMoveOperation cloneMove;
        private readonly JumpOperation jump;

        public FieldCommand(GameViewModel vm) : base()
        {
            this.vm = vm;
            cloneMove = new CloneMoveOperation(vm.Model);
            jump = new JumpOperation(vm.Model);
        }

        public override void Execute(object parameter)
        {
            FieldViewModel current = parameter as FieldViewModel;

            if (current.Owner == vm.CurrentPlayer)
            {
                vm.SelectedField = current;
                return;
            }
            if (vm.SelectedField != null && vm.SelectedField != current)
            {

                if (cloneMove.TryExecute(vm.SelectedField.Model, current.Model)
                    || jump.TryExecute(vm.SelectedField.Model, current.Model))
                {
                    vm.EndOfTurn();
                }
            }
        }
    }
}
