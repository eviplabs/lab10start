using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB10_MAUI_AttaxxPlus.Model;

namespace LAB10_MAUI_AttaxxPlus.ViewModel{
    public class FieldViewModel : ObservableObject
    {
        public Field Model { get; internal set; }

        public FieldViewModel(Field model)
        {
            Model = model;
            model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName == nameof(Field.Owner))
                Notify(nameof(Owner));
        }

       
        public int Owner { get => Model.Owner; }

        public FieldCommand FieldCommand { get; set; }

        private bool isSelected = false;
  
        public bool IsSelected
        {
            get => isSelected;
            set
            {
               
                if (isSelected != value)
                {
                    isSelected = value;
                    Notify();
                }
            }
        }
    }
}