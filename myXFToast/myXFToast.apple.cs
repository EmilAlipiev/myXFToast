using Foundation;
using UIKit;

namespace Plugin.myXFToast
{
    /// <summary>
    /// Interface for myXFToast
    /// </summary>
    public class myXFToastImplementation : ImyXFToast
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2;

        void ShowAlert(string message, double seconds)
        {
            var alert = UIAlertController.Create(null, message, UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad ? UIAlertControllerStyle.Alert : UIAlertControllerStyle.ActionSheet);

            var alertDelay = NSTimer.CreateScheduledTimer(seconds, obj =>
            {
                DismissMessage(alert, obj);
            });

            var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (viewController.PresentedViewController != null)
            {
                viewController = viewController.PresentedViewController;
            }
            viewController.PresentViewController(alert, true, () =>
            {
                UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(_ => DismissMessage(alert, null));
                alert.View.Superview?.Subviews[0].AddGestureRecognizer(tapGesture);
            });
        }

        void DismissMessage(UIAlertController alert, NSTimer alertDelay)
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

        public void Show(string message, bool IsLong = false, string bgColorHex = "#000000")
        {
            ShowAlert(message, IsLong ? LONG_DELAY : SHORT_DELAY);
        }
    }
}
