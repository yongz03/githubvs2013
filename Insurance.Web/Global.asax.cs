using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Insurance.Web
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            var config = GlobalConfiguration.Configuration;

            JsonMediaTypeFormatter json = config.Formatters.JsonFormatter;
            JsonSerializerSettings serializerSettings = json.SerializerSettings;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }

        public static JsonSerializerSettings JsonSerializerSettings
        {
            get
            {
                return GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            }
        }
    }
}
