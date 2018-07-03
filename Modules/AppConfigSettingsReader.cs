using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace El.Test.UiTests.Modules
{
    /// <summary>
    /// Читает настройки из AppSettings и преобразует их к нужному типу
    /// </summary>
    public static class AppConfigSettingsReader
    {
        public static T Read<T>(string key, T defaultValue = default(T))
        {
            var s = ReadAppConfigValue(key);
            if (string.IsNullOrEmpty(s))
                return defaultValue;

            var type = typeof(T);

            //if (type.IsNullable())
            //    type = type.GetGenericArguments()[0];

            if (type.IsEnum)
                return (T)ReadEnum(type, s);

            if (type == typeof(bool))
                return (T)ReadBoolean(s);

            if (type == typeof(int))
                return (T)ReadInt(s);

            if (type == typeof(decimal))
                return (T)ReadDecimal(s);

            if (type == typeof(string))
                return (T)( (object)s );

            throw new Exception(string.Format("Unsupported config type: {0}", typeof(T)));
        }

        private static object ReadDecimal(string s)
        {
            return decimal.Parse(s, CultureInfo.InvariantCulture);
        }

        private static object ReadInt(string s)
        {
            return int.Parse(s);
        }

        private static object ReadBoolean(string s)
        {
            return Convert.ToBoolean(s);
        }

        private static object ReadEnum(Type type, string s)
        {
            return Enum.Parse(type, s);
        }

        private static string ReadAppConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static Dictionary<string, string> ReadStartsWithAppConfigValue(string key)
        {
            var items = new Dictionary<string, string>();
            foreach (string setting in ConfigurationManager.AppSettings)
            {
                if (setting.StartsWith(key))
                {
                    var value = ConfigurationManager.AppSettings[setting];
                    items.Add(setting, value);
                }
            }
            return items;
        }
    }
}
