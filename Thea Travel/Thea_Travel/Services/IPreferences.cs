using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thea_Travel.Services
{
    public interface IPreferences
    {
        void StringPreferences(string value, string key);
        void IntPreferences(int value, string key);
        void FloatPreferences(float value, string key);
        void BoolPreferences(bool value, string key);
        bool getBoolPreferencesForKey(string key);
        string GetStringPrefrencesForKey(string key);
        int GetIntPrefrencesForKey(string key);
        float GetFloatPrefrencesForKey(string key);
    }
}
