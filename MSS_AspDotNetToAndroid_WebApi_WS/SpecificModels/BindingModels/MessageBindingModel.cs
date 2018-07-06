using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels
{
    public class MessageBindingModel
    {
        //public string[] registration_ids { get; set; }
        public string to { get; set; }
        public NotificationBindingModel Data { get; set; }
        //public object data { get; set; }
        public bool content_available { get; set; }
        public string priority { get; set; }

        public MessageBindingModel()
        {

        }
    }
}