using System;
using System.Collections.Generic;
using System.Globalization;
using FubuLocalization;
using FubuLocalization.Basic;

namespace FubuDate.Localization
{
    public class LocalizationDataProvider : ILocalizationStorage
    {
        public void WriteMissing(string key, string text, CultureInfo culture)
        {
            
        }

        public void LoadAll(Action<string> tracer, Action<CultureInfo, IEnumerable<LocalString>> callback)
        {
            foreach (var token in StringTokens.ResourceManager.GetResourceSet(new CultureInfo("no"),false,false))
            {
                
            }
        }

        public IEnumerable<LocalString> Load(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}