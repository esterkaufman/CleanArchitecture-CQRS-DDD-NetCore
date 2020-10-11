using Moj.Core.Rest.Common.Proxies;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using Moj.Core.Rest.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Moj.Keshet.Repositiories.Proxy.Interface;

namespace Moj.Keshet.Repositiories.Proxy.Implementation
{
    public class ServiceExampleProxy : BaseProxy, IServiceExampleProxy
    {
        #region Constractor
        public ServiceExampleProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
           : base(httpClient, httpContextAccessor)
        {
        }

        public ServiceExampleProxy()
            : base() { } // for reflection

        #region IRoutingProxy

        public IServiceCollection Configure(IServiceCollection services, string baseUri)
        {
            return base.Configure<IServiceExampleProxy, ServiceExampleProxy>(services, baseUri);
        }

        #endregion IRoutingProxy
        #endregion

        public IList<ReturnData> GetWeatherForecast()
        {
            return DoGetGeneric<IList<ReturnData>>("");
            //var res =  DoGetGeneric<string>("");

            //return new List<ReturnData>();
        }
    }


    public interface IServiceExampleProxy : IRoutingProxy
    {
        IList<ReturnData> GetWeatherForecast();
    }
}
