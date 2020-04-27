using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Plugin.myXFToast
{
    [Preserve(AllMembers = true)]
    /// <summary>
    /// Interface for myXFToast
    /// </summary>
    public class myXFToastImplementation : ImyXFToast
    {
        private static Android.Widget.Toast toastInstance;

        public void Show(string message, bool IsLong = false, string ColorRgb = null)
        {
            //Toast.MakeText(Android.App.Application.Context, message, IsLong? ToastLength.Long: ToastLength.Short).Show();

            if (toastInstance != null)
                toastInstance.Cancel();

            toastInstance = Android.Widget.Toast.MakeText(Android.App.Application.Context, message,
                IsLong ? ToastLength.Long : ToastLength.Short);
            if (ColorRgb != null && ColorRgb != Color.White.ToString())
            {
                View tView = toastInstance.View;
                tView.SetBackgroundColor(Color.ParseColor(ColorRgb));

                TextView text = (TextView)tView.FindViewById(Android.Resource.Id.Message);
                text.SetShadowLayer(0, 0, 0, Color.Transparent);
                text.SetTextColor(Color.White);
            }


            toastInstance.Show();
        }
    }
}
