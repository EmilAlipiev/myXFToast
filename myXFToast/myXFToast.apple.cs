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
        const double SHORT_DELAY = 0.75;

        void ShowAlert(string message, double seconds)
        {
            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            var alertDelay = NSTimer.CreateScheduledTimer(seconds, obj =>
            {
                DismissMessage(alert, obj);
            });

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
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

        public void Show(string message, bool IsLong = false, string ColorRgb = null)
        {
            ShowAlert(message, IsLong ? LONG_DELAY : SHORT_DELAY);
        }

        //public void ShowToastWarning(string message)
        //{
        //    ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
        //    System.Xml.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
        //    // Set Text
        //    System.Xml.XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
        //    toastTextElements[0].InnerText = message;
        //    // toast duration
        //    IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
        //    ((XmlElement)toastNode).SetAttribute("duration", "long");

        //    // Create the toast notification based on the XML content you've specified.
        //    ToastNotification toast = new ToastNotification(toastXml);

        //    // Send your toast notification.
        //    ToastNotificationManager.CreateToastNotifier().Show(toast);
        //}
    }
}
