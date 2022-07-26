using System;

namespace ChartDraw.TComponents.ViewModels
{
    internal class SqlViewModel : ViewModel
    {
        private double _height;
        public double Height
        {
            get { return _height; }
            set { _height = value; NotifyPropertyChanged(); SetDependents(value); }

        }
        private double _fontSize;

        public double FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; NotifyPropertyChanged(); }
        }

        private string _padding;

        public string Padding
        {
            get { return _padding; }
            set { _padding = value; NotifyPropertyChanged(); }
        }

        private double _containerHeight;

        public double ContainerHeight
        {
            get { return _containerHeight; }
            set { _containerHeight = value; NotifyPropertyChanged(); }
        }

        private string _textBoxText;

        public string TextBoxText
        {
            get { return _textBoxText; }
            set { _textBoxText = value; NotifyPropertyChanged(); }
        }
        public SqlViewModel()
        {
            FontSize = 10;
            Height = 30;
            ContainerHeight = Height;
            TextBoxText = "Zartzurt";

        }



        private void SetDependents(double value)
        {
            Padding = $"0 {Math.Abs((3 * (value - FontSize)) / 8)} 0 0";
        }
        #region Global Properties
        private bool _isHovering = false;
        public bool IsHovering
        {
            get { return _isHovering; }
            set { _isHovering = value; NotifyPropertyChanged(); }
        }

        private bool _isFocused = false;

        public bool IsFocused
        {
            get { return _isFocused; }
            set { _isFocused = value; NotifyPropertyChanged(); FocusedChanged?.Invoke(this,value); }
        }

        public bool _isPressing = false;
        public bool IsPressing
        {
            get { return _isPressing; }
            set { 
                _isPressing = value; NotifyPropertyChanged();
                Pressed?.Invoke(this,value);
            }
            
        }

        #endregion

        #region Events
        public static event Action<object, bool> Pressed;

        public event Action<object, bool> FocusedChanged;
        #endregion

    }
}
