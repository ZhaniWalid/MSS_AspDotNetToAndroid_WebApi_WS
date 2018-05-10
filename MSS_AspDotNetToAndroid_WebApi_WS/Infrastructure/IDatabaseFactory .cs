using MSS_AspDotNetToAndroid_WebApi_WS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        GatewayPCIPINContext DataContext { get; }
    }

}
