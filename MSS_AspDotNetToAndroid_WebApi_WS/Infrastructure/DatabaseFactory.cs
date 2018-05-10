using MSS_AspDotNetToAndroid_WebApi_WS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private GatewayPCIPINContext dataContext;
        public GatewayPCIPINContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new GatewayPCIPINContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
