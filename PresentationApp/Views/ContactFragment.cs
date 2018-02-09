using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace PresentationApp.Views
{
    public class ContactFragment : Fragment
    {
        private Spinner spEmployees;

        private ArrayAdapter adapter;

        private readonly List<string> employees = new List<string>
        {
            "Invoker",
            "Faceless Void",
            "Luna",
            "Potm",
            "Butcher"
        };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FrameContact, container, false);

            spEmployees = view.FindViewById<Spinner>(Resource.Id.spEmployees);
            adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleSpinnerItem, employees);
            spEmployees.Adapter = adapter;
            
            return view;
        }
    }
}