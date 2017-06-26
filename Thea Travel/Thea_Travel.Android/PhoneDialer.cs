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
using Thea_Travel.Services;
using Android.Telephony;
using Xamarin.Forms;
using Thea_Travel.Droid;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Thea_Travel.Droid
{
    class PhoneDialer : IDialer
    {
        public PhoneDialer() { }
        public bool Dial(string number)
        {
            var context = Forms.Context; 
            if(context == null)
            {
                return false;
            }
            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Android.Net.Uri.Parse("tel:" + number));

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
                return true;
            }
            return false;
        }

        public static bool IsIntentAvailable(Context context,Intent intent)
        {
            var packageManager = context.PackageManager;
            var list = packageManager.QueryIntentServices(intent, 0).Union(packageManager.QueryIntentActivities(intent, 0));
            if (list.Any())
                return true;
            TelephonyManager man = TelephonyManager.FromContext(context);
            return man.PhoneType != PhoneType.None;

        }
    }
}