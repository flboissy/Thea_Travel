using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using Thea_Travel.iOS.Services;
using Thea_Travel.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Thea_Travel.iOS.Services
{
    class PhoneDialer : IDialer
    {
        public PhoneDialer() { }
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + number));
        }
    }
}
