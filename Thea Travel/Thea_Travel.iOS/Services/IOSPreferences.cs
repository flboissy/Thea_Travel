
using System;
using Xamarin.Forms;
using Thea_Travel.Services;
using Foundation;
using Thea_Travel.iOS.Services;


[assembly: Dependency(typeof(IOSPreferences))]
namespace Thea_Travel.iOS.Services
{
    class IOSPreferences : IPreferences
    {
        private NSUserDefaults Prefs;
        public IOSPreferences()
        {
            Prefs = NSUserDefaults.StandardUserDefaults;
        }


        public void BoolPreferences(bool value, string key)
        {
            Prefs.SetBool(value, key);
            Prefs.Synchronize();
        }


        public void FloatPreferences(float value, string key)
        {
            Prefs.SetFloat(value, key);
            Prefs.Synchronize();
        }
        public void IntPreferences(int value, string key)
        {
            Prefs.SetInt(value, key);
            Prefs.Synchronize();
        }

        public void StringPreferences(string value, string key)
        {
            Prefs.SetString(value, key);
            Prefs.Synchronize();
        }
        public float GetFloatPrefrencesForKey(string key)
        {
            return Prefs.FloatForKey(key);
        }

        public int GetIntPrefrencesForKey(string key)
        {
            return Convert.ToInt32(Prefs.IntForKey(key));
        }

        public string GetStringPrefrencesForKey(string key)
        {
            return Prefs.StringForKey(key);
        }

        public bool getBoolPreferencesForKey(string key)
        {
            return Prefs.BoolForKey(key);
        }
    }
}
