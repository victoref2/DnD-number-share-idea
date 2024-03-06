using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_number_share_idea
{
    
    public class Spell : INotifyPropertyChanged
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string casting_time { get; set; }
        public string duration { get; set; }
        public string Range { get; set; }
        public string Damage { get; set; }
        public string Components { get; set; }
        public string Description { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
    }

}
