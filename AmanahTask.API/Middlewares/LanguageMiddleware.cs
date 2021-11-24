using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AmanahTask.API
{
    public class LanguageMiddleware
    {
        public RequestDelegate nextDelegate;
        public LanguageMiddleware(RequestDelegate next) => nextDelegate = next;

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.Select(x=>x.Key).Any(x=>x=="Language"))
            {
                var test = httpContext.Request.Headers.Where(x => x.Key == "Language").Select(x => x.Value).FirstOrDefault();
                if (httpContext.Request.Headers.Where(x=>x.Key=="Language").Select(x=>x.Value).FirstOrDefault() == "ar")
                {
                    CultureInfo culture = new CultureInfo("ar-EG");
                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;

                }
                else
                {
                    CultureInfo culture = new CultureInfo("en-US");
                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                }
            }
            else
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
            }
            await nextDelegate.Invoke(httpContext);
        }
    }
}
