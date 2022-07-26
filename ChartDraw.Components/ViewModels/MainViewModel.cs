using ChartDraw.Components.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.Components.ViewModels
{
    internal class MainViewModel :  ViewModel
    {
        private ObservableCollection<object> _items = new ObservableCollection<object>();


        public MainViewModel()
        {
            Items.Add(new SqlView());
            Items.Add(new SqlView());
            Items.Add(new SqlView());
        }

        public ObservableCollection<object> Items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged(); }

        }
    }
}
