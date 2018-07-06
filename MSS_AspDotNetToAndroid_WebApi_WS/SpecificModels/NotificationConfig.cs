using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels
{
    public class NotificationConfig
    {
        public string Priority { get; set; }
        public bool ContentAvailability { get; set; }
        public NotificationBindingModel notification { get; set; }

        public NotificationConfig()
        {

        }

    }
}