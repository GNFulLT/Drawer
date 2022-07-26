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
using Microsoft.Toolkit.Uwp;
using Windows.UI.Xaml.Media.Animation;
using ChartDraw.TComponents.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ChartDraw.TComponents.Views
{
    public sealed partial class SqlView : UserControl
    {
        private readonly Storyboard _hoverAnim;
        private readonly Storyboard _exitAnim;
        private readonly SqlViewModel _dataContext;
        public SqlView()
        {
           
            this.InitializeComponent();
           /* _hoverAnim = CBorder.Resources["HoverAnim"] as Storyboard;
            _exitAnim = CBorder.Resources["ExitAnim"] as Storyboard;
           _dataContext = this.DataContext as SqlViewModel;*/
            (this.DataContext as SqlViewModel).FocusedChanged += FocusedChanged;
            
        }

        private void FocusedChanged(object sender,bool b)
        {
            if (!b)
                _exitAnim.Begin();

     
        }

        private void Border_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            _dataContext.IsHovering = true;
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);

            _hoverAnim.Begin();
           
        }
        private void Border_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            _dataContext.IsHovering = false;
            _dataContext.IsPressing = false;
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
            if (_dataContext.IsFocused is false)
                _exitAnim.Begin();
        }

        private void CBorder_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _dataContext.IsPressing = true;
            lastPosition = e.GetCurrentPoint((UIElement)sender).Position;
        }

        private void CBorder_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _dataContext.IsPressing = false;

        }
        Point lastPosition;
        private void CBorder_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (!_dataContext.IsPressing)
                return;
            Point newPos = e.GetCurrentPoint((UIElement)sender).Position;
           /* tt.X = tt.X + (newPos.X - lastPosition.X);
            tt.Y = tt.Y + (newPos.Y - lastPosition.Y);*/
        }
    }
}
