using LAB10_MAUI_AttaxxPlus.Model.Operations;
using LAB10_MAUI_AttaxxPlus.ViewModel;
using System.Windows.Input;
using System.ComponentModel;
using Microsoft.Maui.Graphics;

namespace LAB10_MAUI_AttaxxPlus.Boosters
{
    public interface IBooster : IOperation, ICommand, INotifyPropertyChanged
    {
        GameViewModel GameViewModel { get; set; }

        ImageSource Image { get; }

        string Title { get; }

        void InitializeGame();
    }
}