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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ChartDraw.Components.Views
{
    public sealed partial class SqlView : UserControl
    {
        private bool _isHovering = false;
        public SqlView()
        {
            this.InitializeComponent();
        }

        private void Border_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            _isHovering = true;
        }

        private void Border_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            _isHovering = false;
        }
    }
}
