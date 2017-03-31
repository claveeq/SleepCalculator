using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using UK.CO.Chrisjenx.Calligraphy;
using AlertDialog = Android.Support.V7.App.AlertDialog;
namespace SleepCalculator
{
    [Activity(Label = "Night Owl", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ImageView btnSuggestedTime;
        ImageView btnSpecificTime;
        ImageView milk;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // for changing the color of the status bar
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            //Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()
            .SetDefaultFontPath("Fonts/clairehandregular.ttf")
            .SetFontAttrId(Resource.Attribute.fontPath)
            .Build());

            btnSuggestedTime = FindViewById<ImageView>(Resource.Id.ivSleepNow);
            btnSpecificTime = FindViewById<ImageView>(Resource.Id.ivYouPick);
            milk = FindViewById<ImageView>(Resource.Id.glass);

            btnSuggestedTime.Click += BtnSuggestedTime_Click;
            btnSpecificTime.Click += BtnSpecificTime_Click;
            milk.Click += Milk_Click;
         
        }

        private void Milk_Click(object sender, System.EventArgs e)
        {
            var builder = new AlertDialog.Builder(this);

            builder.SetTitle("About the App!")
             .SetMessage("On average, it takes around 14 mintues to fall asleep, and each stage while sleeping last around 90 minutes. Waking up in the middle of a sleep cylce leaves you feeling tired, but waking up in between cylces lets you wake up feeling refreshed and alert. This app will help you set an alarm to wake up between sleep cycle, so you feel refreshed each time you wake up, tap SLEEP NOW to see times to wake up if you go to bed right now, or the one that says YOUR PICK to pick a time to wake up and this app will tell you the times you should be falling asleep at.")
             .SetNegativeButton("Zzz", delegate { });

            builder.Create().Show();
        }

        private void BtnSuggestedTime_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(SuggestedTimeActivity));
        }

        private void BtnSpecificTime_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(SpecificTimeActivity));
        }

        protected override void AttachBaseContext(Android.Content.Context @base)
        {
            base.AttachBaseContext(CalligraphyContextWrapper.Wrap(@base));
        }
    }
}

