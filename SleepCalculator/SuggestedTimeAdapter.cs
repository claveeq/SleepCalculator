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

namespace SleepCalculator
{
    class SuggestedTimeAdapter : BaseAdapter
    {
        List<DateTime> suggestedTimeList;
        Context context;

        public SuggestedTimeAdapter(Context context, List<DateTime> suggestedTimeList)
        {
            this.context = context;
            this.suggestedTimeList = suggestedTimeList;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public DateTime GetAlarmTime(int position)
        {
            return suggestedTimeList[position];
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            SuggestedTimeAdapterViewHolder holder = null;

            if(view != null)
                holder = view.Tag as SuggestedTimeAdapterViewHolder;

            if(holder == null)
            {
                holder = new SuggestedTimeAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.alarm_item, parent, false);
                holder.tvAlarmTime = view.FindViewById<TextView>(Resource.Id.tvAlarmTime);
                holder.ivAlarmIcon = view.FindViewById<ImageView>(Resource.Id.ivAlarmIcon);
                view.Tag = holder;
            }
      
            //fill in your items
            holder.tvAlarmTime.Text = suggestedTimeList[position].ToShortTimeString();
            if(position == 4)
                holder.ivAlarmIcon.SetImageResource(Resource.Drawable.ic_alarm_red_A200_48dp);
 
            
            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return suggestedTimeList.Count;
            }
        }
    }

    class SuggestedTimeAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView tvAlarmTime { get; set; }
        public ImageView ivAlarmIcon { get; set; }
    }
}