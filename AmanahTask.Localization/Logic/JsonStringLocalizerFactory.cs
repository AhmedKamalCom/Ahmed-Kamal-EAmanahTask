using System;
using System.Globalization;
using System.Reflection;

using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Sello.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private string _resourceRelativePath;
        public JsonStringLocalizerFactory(IOptions<JsonLocalizationOptions> options)
        {
            _resourceRelativePath = options.Value?.ResourcesPath ?? string.Empty;
        }
        public IStringLocalizer Create(Type resourceSource)
        {
                TypeInfo typeInfo = resourceSource.GetTypeInfo();
                AssemblyName assemblyName =
                    new AssemblyName(typeInfo.Assembly.FullName);
                string baseNamespace =
                        assemblyName.Name;
                string typeRelativeNamespace = "";
                if (typeInfo.FullName.Length > baseNamespace.Length)
                {
                    typeRelativeNamespace =
                                   typeInfo.FullName.Substring(baseNamespace.Length);

                }

                return new JsonStringLocalizer(_resourceRelativePath, typeRelativeNamespace, CultureInfo.CurrentUICulture);
            
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            throw new NotImplementedException();
        }
    }
}
