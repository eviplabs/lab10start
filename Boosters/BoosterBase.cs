using System;
using LAB10_MAUI_AttaxxPlus.Model;
using LAB10_MAUI_AttaxxPlus.ViewModel;


namespace LAB10_MAUI_AttaxxPlus.Boosters
{
    public abstract class BoosterBase : ObservableObject, IBooster
    {
        private GameViewModel gameViewModel;
        public GameViewModel GameViewModel
        {
            get => gameViewModel;
            set
            {
                if (gameViewModel != null)
                    gameViewModel.PropertyChanged -= GameViewModel_PropertyChanged;
                gameViewModel = value;
                gameViewModel.PropertyChanged += GameViewModel_PropertyChanged;
            }
        }

        public ImageSource Image { get; protected set; }
        public abstract string Title { get; }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public bool CanExecute(object parameter) => true;

        public BoosterBase()
        {
            InitializeGame();
        }

        public void Execute(object parameter)
        {
            if (TryExecute(GameViewModel.SelectedField?.Model, null))
                GameViewModel.EndOfTurn();
        }

        protected void LoadImage(string imageFilename)
        {
            Image = ImageSource.FromFile(imageFilename);
        }

        private void GameViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentPlayer")
                this.CurrentPlayerChanged();
        }

        public abstract bool TryExecute(Field selectedField, Field currentField);

        public virtual void InitializeGame() { }

        protected virtual void CurrentPlayerChanged() { }
    }
}

