using System.Collections.ObjectModel;
using System.Linq;
using System;
using LAB10_MAUI_AttaxxPlus.Model;

namespace LAB10_MAUI_AttaxxPlus.ViewModel
{
    public class GameViewModel : ObservableObject
    {
        public readonly GameBase Model;

        public GameViewModel(GameBase model) : base()
        {
            this.Model = model;
            Model.PropertyChanged += Model_PropertyChanged;          
            InitFieldsBasedOnModel();
            BoosterListViewModel = new BoosterListViewModel(this);
        }

        #region Field management
        public ObservableCollection<FieldViewModelList> Fields { get; set; }

        private void InitFieldsBasedOnModel()
        {
            var fieldCommand = new FieldCommand(this);
            Fields = new ObservableCollection<FieldViewModelList>();
            for (int row = 0; row < Model.Fields.GetLength(0); row++)
            {
                var rowList = new FieldViewModelList();
                for (int col = 0; col < Model.Fields.GetLength(1); col++)
                {
                    rowList.Add(
                        new FieldViewModel(Model.Fields[row, col])
                        { FieldCommand = fieldCommand }
                        );
                }
                Fields.Add(rowList);
            }
        }

        private FieldViewModel selectedField;
        public FieldViewModel SelectedField
        {
            get => selectedField;
            set
            {
                if (selectedField != value)
                {
                    if (selectedField != null)
                        selectedField.IsSelected = false;
                    selectedField = value;
                    if (selectedField != null)
                        selectedField.IsSelected = true;
                    Notify();
                }
            }
        }
        #endregion

        public int CurrentPlayer { get => Model.CurrentPlayer; }

        public int? Winner { get => Model.Winner; }
        public bool IsGameRunning { get => Model.IsGameRunning; }

        #region INPC forwarding
        private readonly string[] dependentPropertyNames =
            { nameof(GameBase.Winner), nameof(GameBase.IsGameRunning),
              nameof(GameBase.CurrentPlayer) };

        private void Model_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (dependentPropertyNames.Contains(e.PropertyName))
                Notify(e.PropertyName);
        }
        #endregion

        public FieldCommand FieldCommand { get; private set; }

        internal async void EndOfTurn()
        {
            SelectedField = null;
            Model.EndOfTurn();

            if (!Model.IsGameRunning)
            {

                await App.Current.MainPage.DisplayAlert("",$"Game over. Winner is player {Model.Winner}","OK");
                Model.InitializeGame();
                foreach (var b in BoosterListViewModel.Boosters)
                    b.InitializeGame();
            }
        }

        public BoosterListViewModel BoosterListViewModel { get; set; }
    }
}