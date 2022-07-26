using ChartDraw.TComponents.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ChartDraw.TComponents.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        private ObservableCollection<object> _items = new ObservableCollection<object>();

        public List<SqlViewModel> Views = new List<SqlViewModel>();

        public SqlViewModel focusedViewModel = null;
        public MainViewModel()
        {

            var model = CreateSqlViewModel();
            Items.Add(model);
            Items.Add(CreateSqlViewModel());
            Items.Add(CreateSqlViewModel());
        }
        public ObservableCollection<object> Items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged(); }

        }
        #region Private Methods
        public SqlViewModel CreateSqlViewModel()
        {
            var sqlViewModel = new SqlViewModel();
            return sqlViewModel;
        }

        #endregion

        #region Public Methods
        public void SetFocusedViewModel(object dataContext)
        {
            if (dataContext == focusedViewModel)
                return;
            if(focusedViewModel != null)
            {
                focusedViewModel.IsFocused = false;
            }
            focusedViewModel = (dataContext as SqlViewModel);
            focusedViewModel.IsFocused = true;
        }

        internal void FocusedViewModelLost()
        {
            if (focusedViewModel == null)
                return;
            focusedViewModel.IsFocused = false;
            focusedViewModel = null;
        }
        #endregion
    }
}
