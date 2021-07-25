using Android.Graphics;
using Android.OS;
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
        private static Toast toastInstance;
        public void Show(string message, bool isLong = false, string bgColorHex = "#000000")
        {
            //Toast.MakeText(Android.App.Application.Context, message, IsLong? ToastLength.Long: ToastLength.Short).Show();

            if (toastInstance != null)
                toastInstance.Cancel();

            toastInstance = Toast.MakeText(Android.App.Application.Context, message, isLong ? ToastLength.Long : ToastLength.Short);

            if (Build.VERSION.SdkInt <= BuildVersionCodes.Q)
            {
                if (bgColorHex != null && bgColorHex != Color.White.ToString())
                {
                    View tView = toastInstance.View;
                    tView.SetBackgroundColor(Color.ParseColor(bgColorHex));

                    TextView text = (TextView)tView.FindViewById(Android.Resource.Id.Message);
                    text.SetShadowLayer(0, 0, 0, Color.Transparent);
                    text.SetTextColor(Color.White);
                }
            }
            toastInstance.Show();
        }
    }
}
