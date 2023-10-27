using LAB10_MAUI_AttaxxPlus.Model;

namespace LAB10_MAUI_AttaxxPlus.Boosters
{

    public class DummyBooster : BoosterBase
    {
        private int usableCounter = 2;

        public override string Title { get => $"Dummy ({usableCounter})"; }

        public DummyBooster()
            : base()
        {
            LoadImage(@"Resources/Images/dummybooster.png");
        }

        protected override void CurrentPlayerChanged()
        {
            base.CurrentPlayerChanged();
            Notify(nameof(this.Title));
        }

        public override void InitializeGame()
        {
            usableCounter = 2;
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            if (usableCounter > 0)
            {
                usableCounter--;
                Notify(nameof(Title));
            }
            return true;
        }
    }
}