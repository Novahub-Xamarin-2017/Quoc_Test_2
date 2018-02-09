using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using PresentationApp.Controllers.Adapters;

namespace PresentationApp.Views
{
    public class StoriesFragment : Fragment
    {
        private StoryAdapter adapter;

        private RecyclerView rvStories;

        private readonly List<string> stories = new List<string>()
        {
            "01_genolier",
            "02_ubs",
            "03_atupri",
            "04_firmenich",
            "05_wingo",
            "06_nestle",
            "07_pictet",
            "08_hermes",
            "09_sicpa",
            "10_adama"
        };
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FrameStory, container, false);

            adapter = new StoryAdapter {Stories = stories};
            rvStories = view.FindViewById<RecyclerView>(Resource.Id.rvStories);
            rvStories.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false));
            rvStories.SetAdapter(adapter);

            return view;
        }
    }
}