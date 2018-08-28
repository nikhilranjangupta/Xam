using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageXamarin.Forms
{
    public static class BasicDataStorage
    {
        const string BasicUrlKey = "basicurl";

        public static string BasicUrl
        {
            get => CrossSettings.Current.GetValueOrDefault(BasicUrlKey, "");
            set => CrossSettings.Current.AddOrUpdateValue(BasicUrlKey,value);
        }
}
