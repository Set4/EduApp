using Android.App;
using Android.OS;
using Android.Views;
using CheeseBind;

namespace EduApp.Fragments
{
    public class StatFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.stat_layout, null);
            Cheeseknife.Bind(this, view);
            return view;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            Cheeseknife.Reset(this);
        }
    }
}