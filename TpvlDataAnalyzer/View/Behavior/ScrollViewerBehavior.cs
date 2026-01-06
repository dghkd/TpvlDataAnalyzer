using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TpvlDataAnalyzer.View.Behavior
{
    public static class ScrollViewerBehavior
    {
        public static double GetVerticalOffset(DependencyObject obj)
            => (double)obj.GetValue(VerticalOffsetProperty);

        public static void SetVerticalOffset(DependencyObject obj, double value)
            => obj.SetValue(VerticalOffsetProperty, value);

        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.RegisterAttached(
                "VerticalOffset",
                typeof(double),
                typeof(ScrollViewerBehavior),
                new PropertyMetadata(0.0, OnVerticalOffsetChanged));

        private static void OnVerticalOffsetChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ScrollViewer sv)
            {
                sv.ScrollToVerticalOffset((double)e.NewValue);
            }
        }
    }
}