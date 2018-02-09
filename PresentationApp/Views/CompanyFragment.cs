using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace PresentationApp.Views
{
    public class CompanyFragment : Fragment
    {
        private ImageView ibDiscover, ibPeople, ibService, ibNumber, ibVenture;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FrameCompany, container, false);
            GetWidgets(view);
            SetWidgetListeners();
            return view;
        }

        private void GetWidgets(View view)
        {
            ibDiscover = view.FindViewById<ImageView>(Resource.Id.ibDiscover);
            ibPeople = view.FindViewById<ImageView>(Resource.Id.ibPeople);
            ibService = view.FindViewById<ImageView>(Resource.Id.ibService);
            ibNumber = view.FindViewById<ImageView>(Resource.Id.ibNumber);
            ibVenture = view.FindViewById<ImageView>(Resource.Id.ibVenture);
        }

        private void SetWidgetListeners()
        {
            ibDiscover.Click += OwtTileOnclick;
            ibPeople.Click += OwtTileOnclick;
            ibService.Click += OwtTileOnclick;
            ibNumber.Click += OwtTileOnclick;
            ibVenture.Click += OwtTileOnclick;
        }

        private void OwtTileOnclick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(Activity, typeof(ShowDocumentation));
            intent.PutExtra(MainActivity.FileName, ((ImageView)sender).Tag.ToString());
            StartActivity(intent);
        }
    }
}