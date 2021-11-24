using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Sello.Localization
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private string _resourcesRelativePath;
        private string _typeRelativeNamespace;
        private CultureInfo _uiCulture;
        private JObject _resourceCache;
        //factory class will create instance of that localizer 

        public JsonStringLocalizer(string resourcesRelativePath , string typeRelativeNamespace , CultureInfo uiCulture)
        {
            _resourcesRelativePath = resourcesRelativePath;
            _typeRelativeNamespace = typeRelativeNamespace;
            _uiCulture = uiCulture;
        }
        JObject GetResource()
        {
            // if(_resourceCache == null)
            //  {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
           // Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
           
            string tag = CultureInfo.CurrentUICulture.Name;
            //string tag = _uiCulture.Name;
                string typeRelativePath = _typeRelativeNamespace.Replace(".", "/");
                if (typeRelativePath.Contains("ViewModel"))
                {
                  typeRelativePath = $"/ViewModels{typeRelativePath}";
                }
                string filePath = $"{path}/{ _resourcesRelativePath}/{typeRelativePath}/{tag}.json";
              //  var x = Directory.GetFiles($"{ _resourcesRelativePath}{typeRelativePath}/{tag}.json");

                string json = File.Exists(filePath) ?
                                File.ReadAllText(filePath, Encoding.UTF8) : "{}";
                var test=  JsonConvert.DeserializeObject(json);
                _resourceCache = JObject.Parse(json);

         //  }
            return _resourceCache;
        }
        public LocalizedString this[string name] => this[name,null];

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                JObject resources = GetResource();
                string value = resources.Value<string>(name);
                bool resourceNotFound = string.IsNullOrWhiteSpace(value);
                if (resourceNotFound)
                {
                    value = name;

                }
                else
                {
                    if (arguments != null)
                    {
                        value = string.Format(value, arguments);
                    }
                }
                return new LocalizedString(name, value, resourceNotFound);
                
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            JObject resources = GetResource();
            foreach (var pair in resources)
            {
                yield return new LocalizedString(pair.Key, pair.Value.Value<string>());
            }
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new JsonStringLocalizer(_resourcesRelativePath, _typeRelativeNamespace, culture);
        }
    }
}
