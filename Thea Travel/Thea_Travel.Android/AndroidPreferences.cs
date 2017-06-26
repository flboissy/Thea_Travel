using Android.Content;
using Android.Preferences;
using System;
using Thea_Travel.Droid;
using Thea_Travel.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidPreferences))]
namespace Thea_Travel.Droid
{
    class AndroidPreferences : IPreferences
    {
        private ISharedPreferences Prefs;
        private ISharedPreferencesEditor Editor;
        
        public AndroidPreferences()
        {
            Prefs = PreferenceManager.GetDefaultSharedPreferences(Forms.Context);
            Editor = Prefs.Edit();
        }

        public void BoolPreferences(bool value, string key)
        {
            Editor.PutBoolean(key, value);
            Editor.Apply();
        }


        public void IntPreferences(int value, string key)
        {
            Editor.PutInt(key, value);
            Editor.Apply();
        }

        public void StringPreferences(string value, string key)
        {
            Editor.PutString(key, value);
            Editor.Apply();
        }

        public void FloatPreferences(float value, string key)
        {
            Editor.PutFloat(key, value);
            Editor.Apply();
        }

        public float GetFloatPrefrencesForKey(string key)
        {
            return Prefs.GetFloat(key,0);
        }

        public int GetIntPrefrencesForKey(string key)
        {
            return Prefs.GetInt(key, 0);
        }

        public string GetStringPrefrencesForKey(string key)
        {
            return Prefs.GetString(key, String.Empty);
        }

     
        public bool getBoolPreferencesForKey(string key)
        {
            return Prefs.GetBoolean(key, false);
        }
    }
}