using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Aptacode.Forms.Wpf.Mvvm.Behaviours
{
    public class DoubleClickTextBoxBehaviour : Behavior<TextBox>
    {
        private long _timestamp;

        protected override void OnAttached()
        {
            AssociatedObject.Focusable = false;
            AssociatedObject.Cursor = Cursors.Arrow;

            AssociatedObject.MouseDoubleClick += AssociatedObjectOnMouseDoubleClick;
            AssociatedObject.LostFocus += AssociatedObjectOnLostFocus;
        }

        private void AssociatedObjectOnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
            {
                return;
            }

            if (AssociatedObject.Focusable)
            {
                return; //fix an issue of selecting all text on double click
            }

            AssociatedObject.Cursor = Cursors.IBeam;
            AssociatedObject.Focusable = true;
            AssociatedObject.Focus();
            AssociatedObject.CaretIndex = AssociatedObject.Text.Length;

            _timestamp = Stopwatch.GetTimestamp();
        }

        private void AssociatedObjectOnLostFocus(object sender, RoutedEventArgs e)
        {
            var delta = Stopwatch.GetTimestamp() - _timestamp;
            var timesp = new TimeSpan(delta);

            if (timesp.TotalSeconds < 1)
            {
                return;
            }

            AssociatedObject.Cursor = Cursors.Arrow;
            AssociatedObject.Focusable = false;
        }
    }
}