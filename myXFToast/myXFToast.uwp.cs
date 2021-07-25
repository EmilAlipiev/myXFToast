using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Plugin.myXFToast
{
    /// <summary>
    /// Interface for myXFToast
    /// </summary>
    public class myXFToastImplementation : ImyXFToast
    {
        private const double LONG_DELAY = 3.5;
        private const double SHORT_DELAY = 2.0;

        public void Show(string message, bool IsLong = false, string bgColorHex = null)
        {
            ShowMessage(message, IsLong ? LONG_DELAY : SHORT_DELAY, bgColorHex);
        }

        private void ShowMessage(string message, double duration, string bgColorHex = "#000000")
        {
            var label = new TextBlock
            {
                Text = message,
                Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            Windows.UI.Color color = Windows.UI.Colors.Black;
            if (bgColorHex != null)
            {
                color = ConvertColorFromHexString(bgColorHex);
            }

            var style = new Style { TargetType = typeof(FlyoutPresenter) };
            style.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(color)));
            style.Setters.Add(new Setter(FrameworkElement.MaxHeightProperty, 1));
            var flyout = new Flyout
            {
                Content = label,
                Placement = Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode.Full,
                FlyoutPresenterStyle = style,
            };

            flyout.ShowAt(Window.Current.Content as FrameworkElement);

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(duration) };
            timer.Tick += (sender, e) => {
                timer.Stop();
                flyout.Hide();
            };
            timer.Start();
        }

        private Windows.UI.Color ConvertColorFromHexString(string colorStr)
        {
            colorStr = colorStr.Replace("#", string.Empty);
            // from #RRGGBB string
            var r = (byte)System.Convert.ToUInt32(colorStr.Substring(0, 2), 16);
            var g = (byte)System.Convert.ToUInt32(colorStr.Substring(2, 2), 16);
            var b = (byte)System.Convert.ToUInt32(colorStr.Substring(4, 2), 16);
            //get the color
            Windows.UI.Color color = Windows.UI.Color.FromArgb(255, r, g, b);

            return color;
        }
    }
}
