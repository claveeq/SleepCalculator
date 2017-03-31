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
using Android.Provider;
using UK.CO.Chrisjenx.Calligraphy;

namespace SleepCalculator
{
    [Activity(Label = "SpecificTimeActivity")]
    public class SpecificTimeActivity : Activity
    {
        GridView gvSpecificTimeAlarm;
        SuggestedTimeAdapter suggestedTimeAdapter;
        TimePicker timePicker;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // for changing the color of the status bar
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            // Create your application here
            SetContentView(Resource.Layout.specificTime);


            CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()
            .SetDefaultFontPath("Fonts/clairehandregular.ttf")
            .SetFontAttrId(Resource.Attribute.fontPath)
            .Build());

            var tvTime = FindViewById<TextView>(Resource.Id.tvTime);
            var btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            var btnSetSpecificAlarm = FindViewById<Button>(Resource.Id.btnSetSpecificAlarm);
            btnSetSpecificAlarm.Click += delegate
            {
                Intent intent = new Intent(AlarmClock.ActionSetAlarm)
             .PutExtra(AlarmClock.ExtraMessage, "Good Night!")
             .PutExtra(AlarmClock.ExtraHour, timePicker.CurrentHour)
             .PutExtra(AlarmClock.ExtraMinutes, timePicker.CurrentMinute);
                StartActivity(intent);
            };

            btnCalculate.Click += delegate
            {
                gvSpecificTimeAlarm = FindViewById<GridView>(Resource.Id.specificTime_gvSpecificTimeAlarm);
               
                SleepTime sleeptime = new SleepTime(getTime());
                sleeptime.SuggestedAlarms();

                suggestedTimeAdapter = new SuggestedTimeAdapter(this, sleeptime.SpecificAlarms(getTime()));

                gvSpecificTimeAlarm.Adapter = suggestedTimeAdapter;
                suggestedTimeAdapter.NotifyDataSetChanged();
                tvTime.Text = getTime().ToString();
                gvSpecificTimeAlarm.ItemClick += GvSpecificTimeAlarm_ItemClick;
            };
          
            timePicker = FindViewById<TimePicker>(Resource.Id.timePicker1);
            timePicker.SetIs24HourView(Java.Lang.Boolean.True);

        }

        private DateTime getTime()
        {
            StringBuilder strTime = new StringBuilder();
            strTime.Append(timePicker.CurrentHour + ":" + timePicker.CurrentMinute);
            return DateTime.Parse(strTime.ToString());
        }

        protected override void AttachBaseContext(Android.Content.Context @base)
        {
            base.AttachBaseContext(CalligraphyContextWrapper.Wrap(@base));
        }
        private void GvSpecificTimeAlarm_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            DateTime alarmTime = suggestedTimeAdapter.GetAlarmTime(e.Position);
            string message = string.Empty;
            Random random = new Random();
            switch(random.Next(1, 6))
            {
                case 1:
                    message = "Good night, Andrea!";
                    break;
                case 2:
                    message = "Sleep well, Andrea!";
                    break;
                case 3:
                    message = "Sleep tight, Andrea!";
                    break;
                case 4:
                    message = "Wake up bright, Andrea!";
                    break;
                case 5:
                    message = "Night Owl, Tulog na!";
                    break;
                case 6:
                    message = "မင်းတစ်ယောက်တည်းသာ";
                    break;
            }
            Intent intent = new Intent(AlarmClock.ActionSetAlarm)
              .PutExtra(AlarmClock.ExtraMessage, message)
              .PutExtra(AlarmClock.ExtraHour, alarmTime.Hour)
              .PutExtra(AlarmClock.ExtraMinutes, alarmTime.Minute);
            StartActivity(intent);
        }
    }
}