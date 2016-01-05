using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Graphics;
namespace Sample
{
    [Activity(Label = "MainActivity", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView mRecyclerView;

        private TimeLineAdapter mTimeLineAdapter;
        private List<TimeLineModel> mDataList = new List<TimeLineModel>();
        public XamarinTimeLine.TimelineView xt;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            mRecyclerView = (RecyclerView)FindViewById<RecyclerView>(Resource.Id.recyclerView);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(linearLayoutManager);
          
            InitView();
        }
        private void InitView()
        {
            for (int i = 0; i < 10; i++)
            {
                TimeLineModel model = new TimeLineModel();
                model.name = "Random" + i;
                model.age = i;
                mDataList.Add(model);
            }
            mTimeLineAdapter = new TimeLineAdapter(mDataList);
            mRecyclerView.SetAdapter(mTimeLineAdapter);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }
    }
}

