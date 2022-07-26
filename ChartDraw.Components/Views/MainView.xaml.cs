using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChartDraw.Components.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page
    {
        private readonly double _initialWidth;
        private readonly double _initialHeight;
        private const double MAX_ZOOM_OUT_RATIO = 3;
        private const double MAX_ZOOM_IN_RATIO = 0.57;
        private  double _maxTranslateX;
        private  double _maxTranslateY;
        private bool _isLeftPressing = false;
        public MainView()
        {
            this.InitializeComponent();
            Canvas.Width = (CurrWindow.Width * (1/MAX_ZOOM_IN_RATIO))*2;
            Canvas.Height = (CurrWindow.Height * (1/MAX_ZOOM_IN_RATIO))*2;
            _initialWidth = Canvas.Width;
            _initialHeight = Canvas.Height;
            _maxTranslateX = CurrWindow.Width - _initialWidth;
            _maxTranslateY = CurrWindow.Height - _initialHeight;
        }
        const double ScaleRate = 1.1;
        private void Canvas_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            var delta = e.GetCurrentPoint((UIElement)sender).Properties.MouseWheelDelta;

            if (delta > 0)
            {
                if (st.ScaleX * ScaleRate > MAX_ZOOM_OUT_RATIO)
                    return;
                st.ScaleX *= ScaleRate;
                st.ScaleY *= ScaleRate;
                _maxTranslateX = CurrWindow.Width - (st.ScaleX * _initialWidth);
                _maxTranslateY = CurrWindow.Height - (st.ScaleY * _initialHeight);
               
            }
            else
            {
                if(st.ScaleX * ScaleRate <= MAX_ZOOM_IN_RATIO)
                    return;
                  st.ScaleX /= ScaleRate;
                  st.ScaleY /= ScaleRate;
                _maxTranslateX = CurrWindow.Width - (st.ScaleX * _initialWidth);
                _maxTranslateY = CurrWindow.Height - (st.ScaleY * _initialHeight);

                //Büyültme işlemi yaparken taşmayı önler
                if(tt.X < _maxTranslateX)
                    tt.X = _maxTranslateX;
                if(tt.Y < _maxTranslateY)
                    tt.Y = _maxTranslateY;
            }
        }

        
        const double MoveRate = 1.1;
        Point lastPosition;
        private void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint((UIElement)sender);    
            
            if (!_isLeftPressing)
                return;
            Point delta = new Point(ptrPt.Position.X - lastPosition.X,ptrPt.Position.Y - lastPosition.Y);
            double newX = tt.X + delta.X;
            double newY = tt.Y + delta.Y;

            if (newX <= 0 && newX >= _maxTranslateX)
            {
                tt.X = newX;

            }
            if(newY <= 0 && newY >= _maxTranslateY)
            {
                tt.Y = newY;

            }


        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _isLeftPressing = true;
            lastPosition = e.GetCurrentPoint((UIElement)sender).Position;
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _isLeftPressing = false;
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);

        }

        private void Canvas_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Canvas_PointerReleased(sender, e);
        }
    }
}
