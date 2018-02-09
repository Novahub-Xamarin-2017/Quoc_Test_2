using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using PresentationApp.Utils;

namespace PresentationApp.Controllers.Adapters
{
    class StoryViewHolder : RecyclerView.ViewHolder
    {
        private string imageName;

        public string ImageName
        {
            set
            {
                imageName = value; 
                ibStory.SetImageBitmap(BitmapUtility.GetBitmapFromAsset(imageName + ".png"));
            }
        }

        private readonly ImageButton ibStory;

        public StoryViewHolder(View itemView) : base(itemView)
        {
            ibStory = itemView.FindViewById<ImageButton>(Resource.Id.ibStory);
        }
    }
}