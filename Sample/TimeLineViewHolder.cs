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
    public class TimeLineViewHolder : RecyclerView.ViewHolder
    {
        public TextView name;
        public TimelineView mTimelineView;
        public TimeLineViewHolder(View itemView, int viewType)
            : base(itemView)
        {
            name = itemView.FindViewById<TextView>(Resource.Id.tx_name);
            mTimelineView = itemView.FindViewById<TimelineView>(Resource.Id.time_marker);
            mTimelineView.InitLine(viewType);
        }
    }
}