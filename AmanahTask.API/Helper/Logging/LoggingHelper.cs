
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace AmanahTask.API.Helpers
{
    public class LoggingHelper
    {
        private readonly HttpContext _context;
        public LoggingHelper(HttpContext context)
        {
            _context = context;
        }
        public string GetClientIP()
        {
            return _context.Connection.RemoteIpAddress.ToString();
        }
        public string GetUrl()
        {
            return _context.Request.Path.ToString();
        }
        public string GetData()
        {
            string queryString = string.Empty;
            if (_context.Request.QueryString.HasValue)
                queryString =_context.Request.QueryString.Value;
            string formData = string.Empty;
            if (_context.Request.Method=="POST" || _context.Request.Method == "PUT")
                formData = JsonConvert.SerializeObject(_context.Request.Form);
            return $"QUERYSTRING:{queryString}*** FORMDATA:{formData}";
        }
        public string GetMachineName()
        {
            try
            {
                var hostEntry = Dns.GetHostEntry(_context.Connection.RemoteIpAddress);
                return hostEntry.HostName;
            }
            catch
            {
                return "";
            }
        }
        public string GeUserAgent()
        {
            try
            {
                return _context.Request.Headers["User-Agent"].ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
