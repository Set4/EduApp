using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Android.Support.V13.App;
using Android.Content.PM;
using CheeseBind;
using Me.Relex;

namespace EduApp
{
    [Activity(Theme = "@style/MainTheme.NoActionBar", LaunchMode = LaunchMode.SingleTask, ScreenOrientation = ScreenOrientation.Portrait)]
    public class InfoActivity : Activity, ViewPager.IOnPageChangeListener
    {
        [BindView(Resource.Id.infoActivity_infoVP)]
        ViewPager viewPager;

        [BindView(Resource.Id.infoActivity_nextBtn)]
        Button nextBtn;

        [BindView(Resource.Id.infoActivity_pageIndicator)]
        CircleIndicator pageIndicator;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.info_layout);
            Cheeseknife.Bind(this);

            viewPager.Adapter = new InfoViewPagerAdapter(FragmentManager);
            viewPager.SetPageTransformer(true, new FadeTransformer());

            pageIndicator.SetViewPager(viewPager);
        }

        public void OnPageScrollStateChanged(int state)
        {
        }
        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }
        public void OnPageSelected(int position)
        {
        }

        [OnClick(Resource.Id.infoActivity_nextBtn)]
        void OnClickSelectRegistartionButton(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }

    public class InfoViewPagerAdapter : FragmentPagerAdapter  //FragmentStatePagerAdapter
    {
        private List<Fragment> cardFragments { get; set; }

        public InfoViewPagerAdapter(FragmentManager fragmentManager) : base(fragmentManager)
        {
            cardFragments = new List<Fragment>{
                    new InfoFragment(),
                    new InfoFragment(),
                    new InfoFragment(),
                    new InfoFragment()
                };
        }

        public override int Count => cardFragments.Count;

        public override Fragment GetItem(int position) => cardFragments[position];
    }

    public class FadeTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        private const float MaxAngle = 30F;
        public void TransformPage(View view, float position)
        {
            if (position < -1 || position > 1)
            {
                view.Alpha = 0; // The view is offscreen.
            }
            else
            {
                view.Alpha = 1;

                view.PivotY = view.Height / 2; // The Y Pivot is halfway down the view.

                // The X pivots need to be on adjacent sides.
                if (position < 0)
                {
                    view.PivotX = view.Width;
                }
                else
                {
                    view.PivotX = 0;
                }

                view.RotationY = MaxAngle * position; // Rotate the view.
            }
        }
    }

    public class InfoFragment : Fragment
    {
        int imageResId;

        public InfoFragment()
        {
        }

        public InfoFragment(int imageResId)
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.info_item, container, false);
            return view;
        }
    }
}