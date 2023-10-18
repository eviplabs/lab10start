using LAB10_MAUI_AttaxxPlus.Model;
using LAB10_MAUI_AttaxxPlus.ViewModel;

namespace LAB10_MAUI_AttaxxPlus.View
{

    public partial class GameView : ContentView
    {
        public GameViewModel ViewModel { get; set; }

        public GameView()
        {
            ViewModel = new GameViewModel(new SimpleGame(5));
            this.BindingContext = ViewModel;
            InitializeComponent();
        }

   
    }
}
