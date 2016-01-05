using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using XamarinTimeLine;

namespace Sample
{
    public class TimeLineAdapter : RecyclerView.Adapter
    {
        private List<TimeLineModel> mFeedList;
        public TimeLineAdapter(List<TimeLineModel> feedList)
        {
            mFeedList = feedList;
        }
        public override int GetItemViewType(int position)
        {
            return TimelineView.GetTimeLineViewType(position, ItemCount);
        }
        public override int ItemCount
        {
            get { return (mFeedList != null ? mFeedList.Count : 0); }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TimeLineModel timeLineModel = mFeedList[position];
            var hod = holder as TimeLineViewHolder;
            hod.name.Text = "name£º" + timeLineModel.name + "age£º" + timeLineModel.age;   
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = View.Inflate(parent.Context, Resource.Layout.item_timeline, null);
            return new TimeLineViewHolder(view, viewType);
        }
    }
}