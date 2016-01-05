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

namespace Sample
{
    public class TimeLineModel : Java.Lang.Object, Java.IO.ISerializable
    {
        public String name { get; set; }
        public int age { get; set; }
    }
}