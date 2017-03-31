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
    [Activity(Label = "SuggestedTimeActivity")]
    public class SuggestedTimeActivity : Activity
    {
        GridView gvSuggestedTimeAlarm;
        SuggestedTimeAdapter suggestedTimeAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // for changing the color of the status bar
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            // Create your application here
            SetContentView(Resource.Layout.suggestedTime);

            CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()
           .SetDefaultFontPath("Fonts/clairehandregular.ttf")
           .SetFontAttrId(Resource.Attribute.fontPath)
           .Build());


            gvSuggestedTimeAlarm = FindViewById<GridView>(Resource.Id.suggestedTime_gvSuggestedTimeAlarm);

            SleepTime sleeptime = new SleepTime(DateTime.Now);
            sleeptime.SuggestedAlarms();
            suggestedTimeAdapter = new SuggestedTimeAdapter(this, sleeptime.SuggestedAlarms());
            gvSuggestedTimeAlarm.Adapter = suggestedTimeAdapter;

            gvSuggestedTimeAlarm.ItemClick += GvSuggestedTimeAlarm_ItemClick;
        }
        protected override void AttachBaseContext(Android.Content.Context @base)
        {
            base.AttachBaseContext(CalligraphyContextWrapper.Wrap(@base));
        }
        private void GvSuggestedTimeAlarm_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // AlarmManager manager = (AlarmManager)GetSystemService(Context.AlarmService);
            //// Intent myIntent = new Intent(this, typeof(AlarmToastReceiver);
            // PendingIntent pendingIntent;

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