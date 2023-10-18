using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB10_MAUI_AttaxxPlus.Boosters;
using LAB10_MAUI_AttaxxPlus.Model;
using System.Globalization;
using System.Collections.ObjectModel;

namespace LAB10_MAUI_AttaxxPlus.ViewModel
{
    public class BoosterListViewModel : ObservableObject
    {
        public ObservableCollection<IBooster> Boosters { get; set; } = new ObservableCollection<IBooster>();

        public BoosterListViewModel(GameViewModel gameViewModel)
        {
            // EVIP: using reflection to find all non-abstract implementations of an interface
            var currentAssembly = this.GetType().Assembly;
            // EVIP: using Linq for searching
            var allIBoosterTypes = currentAssembly.DefinedTypes
                .Where(t => t.ImplementedInterfaces.Any(i => i == typeof(IBooster)))
                .Where(t => !t.IsAbstract).ToList();
            foreach (var boosterType in allIBoosterTypes)
            {
                // EVIP: using reflection to instantiate objects
                IBooster booster = Activator.CreateInstance(boosterType.AsType()) as IBooster;
                booster.GameViewModel = gameViewModel;
                Notify(nameof(Boosters));
            }
        }
    }
}
