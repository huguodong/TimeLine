using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinTimeLine
{
    public class TimelineView : View
    {
        private Drawable mMarker;
        private Drawable mStartLine;
        private Drawable mEndLine;
        private int mMarkerSize;
        private int mLineSize;

        private Rect mBounds;
        private Context mContext;
        public TimelineView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            mContext = context;
            Init(attrs);
        }
        private void Init(IAttributeSet attrs)
        {
            TypedArray typedArray = Context.ObtainStyledAttributes(attrs, Resource.Styleable.timeline_style);
            mMarker = typedArray.GetDrawable(Resource.Styleable.timeline_style_marker);
            mStartLine = typedArray.GetDrawable(Resource.Styleable.timeline_style_line);
            mEndLine = typedArray.GetDrawable(Resource.Styleable.timeline_style_line);
            mMarkerSize = typedArray.GetDimensionPixelSize(Resource.Styleable.timeline_style_marker_size, 25);
            mLineSize = typedArray.GetDimensionPixelSize(Resource.Styleable.timeline_style_line_size, 2);
            typedArray.Recycle();
            if (mMarker == null)
            {
                mMarker = mContext.Resources.GetDrawable(Resource.Drawable.marker);
            }
        }
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            //Width measurements of the width and height and the inside view of child controls
            int w = mMarkerSize + PaddingLeft + PaddingRight;
            int h = mMarkerSize + PaddingTop + PaddingBottom;

            // Width and height to determine the final view through a systematic approach to decision-making
            int widthSize = ResolveSizeAndState(w, widthMeasureSpec, 0);
            int heightSize = ResolveSizeAndState(h, heightMeasureSpec, 0);

            SetMeasuredDimension(widthSize, heightSize);
            InitDrawable();
        }
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            InitDrawable();
        }
        private void InitDrawable()
        {
            int pLeft = PaddingLeft;
            int pRight = PaddingRight;
            int pTop = PaddingTop;
            int pBottom = PaddingBottom;
            int width = Width;// Width of current custom view
            int height = Height;
            int cWidth = width - pLeft - pRight;// Circle width
            int cHeight = height - pTop - pBottom;
            int markSize = Math.Min(mMarkerSize, Math.Min(cWidth, cHeight));
            if (mMarker != null)
            {
                mMarker.SetBounds(pLeft, pTop, pLeft + markSize, pTop + markSize);
                mBounds = mMarker.Bounds;
            }
            int centerX = mBounds.CenterX();
            int lineLeft = centerX - (mLineSize >> 1);
            if (mStartLine != null)
            {
                mStartLine.SetBounds(lineLeft, 0, mLineSize + lineLeft, mBounds.Top);
            }
            if (mEndLine != null)
            {
                mEndLine.SetBounds(lineLeft, mBounds.Bottom, mLineSize + lineLeft, height);
            }

        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            if (mMarker != null)
            {
                mMarker.Draw(canvas);
            }

            if (mStartLine != null)
            {
                mStartLine.Draw(canvas);
            }
            if (mEndLine != null)
            {
                mEndLine.Draw(canvas);
            }
        }
        public void SetMarker(Drawable marker)
        {
            mMarker = marker;
            InitDrawable();
        }
        public void SetStartLine(Drawable startline)
        {
            mStartLine = startline;
            InitDrawable();
        }
        public void SetEndLine(Drawable endLine)
        {
            mEndLine = endLine;
            InitDrawable();
        }
        public void SetMarkerSize(int markerSize)
        {
            mMarkerSize = markerSize;
            InitDrawable();
        }
        public void SetLineSize(int lineSize)
        {
            mLineSize = lineSize;
            InitDrawable();
        }
        public void InitLine(int viewType)
        {

            if (viewType == LineType.BEGIN)
            {
                SetStartLine(null);
            }
            else if (viewType == LineType.END)
            {
                SetEndLine(null);
            }
            else if (viewType == LineType.ONLYONE)
            {
                SetStartLine(null);
                SetEndLine(null);
            }

            InitDrawable();
        }
        public static int GetTimeLineViewType(int position, int total_size)
        {
            if (position == 0)
            {
                return LineType.BEGIN;
            }
            else if (position == total_size - 1)
            {
                return LineType.END;
            }
            else if (total_size == 1)
            {
                return LineType.ONLYONE;
            }
            else
            {
                return LineType.NORMAL;
            }
        }
    }
}
