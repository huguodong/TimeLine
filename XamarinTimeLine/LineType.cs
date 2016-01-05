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

namespace XamarinTimeLine
{
    public class LineType
    {
        public static int NORMAL = 0;
        public static int BEGIN = 1;
        public static int END = 2;
        public static int ONLYONE = 3;
    }
}