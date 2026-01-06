using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace TpvlDataAnalyzer.View.Behavior
{
    public class SmoothScrollBehavior : Behavior<ListView>
    {
        private ScrollViewer? _scrollViewer;
        private TranslateTransform _transform;

        public double ScrollStep { get; set; } = 100;

        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnLoaded;
            AssociatedObject.PreviewMouseWheel += OnMouseWheel;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= OnLoaded;
            AssociatedObject.PreviewMouseWheel -= OnMouseWheel;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _scrollViewer = FindVisualChild<ScrollViewer>(AssociatedObject);
            var presenter = FindVisualChild<ItemsPresenter>(AssociatedObject);

            if (presenter != null
                && _scrollViewer != null)
            {
                _transform = new TranslateTransform();
                presenter.RenderTransform = _transform;
            }
        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (_scrollViewer == null || _transform == null)
                return;

            e.Handled = true;
            bool atTop = _scrollViewer.VerticalOffset <= 0;
            bool atBottom = _scrollViewer.VerticalOffset >= _scrollViewer.ScrollableHeight;

            if ((e.Delta > 0 && atTop) || (e.Delta < 0 && atBottom))
            {
                // 滑鼠滾輪已經到頂或到底
                return;
            }

            // 先讓 ScrollViewer 正常捲動（維持虛擬化）

            // 視覺補間動畫
            _transform.BeginAnimation(
                TranslateTransform.YProperty,
                new DoubleAnimation
                {
                    From = e.Delta > 0 ? -ScrollStep : ScrollStep,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(500),
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                });

            if (e.Delta > 0)
                _scrollViewer.LineUp();
            else
                _scrollViewer.LineDown();
        }

        private static T? FindVisualChild<T>(DependencyObject parent)
            where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T found)
                    return found;

                var result = FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}