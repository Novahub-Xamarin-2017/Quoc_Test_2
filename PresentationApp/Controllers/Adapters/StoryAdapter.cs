using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace PresentationApp.Controllers.Adapters
{
    class StoryAdapter : RecyclerView.Adapter
    {
        private List<string> stories;

        public List<string> Stories
        {
            get => stories;
            set
            {
                stories = value; 
                NotifyDataSetChanged();
            }
        }

        public override int ItemCount => Stories.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((StoryViewHolder) holder).ImageName = stories[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.StoryView, parent, false);
            return new StoryViewHolder(itemView);
        }
    }
}