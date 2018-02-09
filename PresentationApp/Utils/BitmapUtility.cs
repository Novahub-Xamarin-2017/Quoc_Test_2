using Android.App;
using Android.Graphics;

namespace PresentationApp.Utils
{
    class BitmapUtility
    {
        public static Bitmap GetBitmapFromAsset(string fileName)
        {
            using (var stream = Application.Context.Assets.Open(fileName))
            {
                var bitmap = BitmapFactory.DecodeStream(stream);
                return bitmap;
            }
        }
    }
}