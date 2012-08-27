using System.Globalization;
using FubuLocalization;

namespace FubuDate.Localization
{
    public class LocalizationMissingHandler : ILocalizationMissingHandler
    {
        public string FindMissingText(StringToken key, CultureInfo culture)
        {
            return FindMissingText(key.Key, key.DefaultValue, culture);
        }

        public string FindMissingProperty(PropertyToken key, CultureInfo culture)
        {
            var combinedKey = string.Format("{0}_{1}", key.ParentType.Name, key.PropertyName);
            return FindMissingText(combinedKey, key.FindDefaultHeader(culture), culture);
        }

        public string FindMissingText(string key, string defaultValue, CultureInfo culture)
        {
            var value = StringTokens.ResourceManager.GetString(key, culture);
            return value ?? defaultValue ?? culture + "_" + key;
        }
    }
}