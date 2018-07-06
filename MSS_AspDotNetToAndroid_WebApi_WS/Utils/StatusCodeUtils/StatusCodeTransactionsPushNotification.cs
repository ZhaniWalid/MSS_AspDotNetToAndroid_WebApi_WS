using MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Utils.StatusCodeUtils
{
    public static class StatusCodeTransactionsPushNotification
    {
        private static Uri FireBasePushNotificationsURL = new Uri("https://fcm.googleapis.com/fcm/send");
        private static string ServerKey = "AAAAdtMITDI:APA91bEliRXCtk918DC8SZj8ei9_hYWnTMPDTy97Bph8AM9vS5NZWC-KJAMNhXdk5WgcN-yw--RJy1p4LGPOaRSDtOokgXL5hOb2VDer1wXuitk-vDRWIsi8FSZnyhPTvrg5qUqyS-gy4IdRljeb4K-Xx7Hm8ufYUw";
        private static string senderId = "510346677298";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceTokens">List of all devices assigned to a user</param>
        /// <param name="title">Title of notification</param>
        /// <param name="body">Description of notification</param>
        /// <param name="data">Object with all extra information you want to send hidden in the notification</param>
        /// <returns></returns>
        public static async Task<string> SendPushNotification(string deviceToken, string title, string body, object data)
        {
            bool sent = true;
            HttpResponseMessage result = null;

            if (deviceToken != null)
            {
                //Object creation

                /*
                var messageInformation = new Message()
                {
                    notification = new Notification()
                    {
                        Title = title,
                        Text = body
                    },
                    data = data,
                    registration_ids = deviceTokens
                };
                */

                var messageInformation = new MessageBindingModel()
                {
                    to = deviceToken, // this if you want to test for single device 
                    //to = "/topics/ServiceNow",
                    Data = new NotificationBindingModel()
                    {
                        Title = title,
                        Message = body
                    },
                };

                //Object to JSON STRUCTURE => using Newtonsoft.Json;
                string jsonMessage = JsonConvert.SerializeObject(messageInformation);

                /*
                 ------ JSON STRUCTURE ------
                 {
                    notification: {
                                    title: "",
                                    text: ""
                                    },
                    data: {
                            action: "Play",
                            playerId: 5
                            },
                    registration_ids = ["id1", "id2"]
                 }
                 ------ JSON STRUCTURE ------
                 */

                //Create request to Firebase API
                var request = new HttpRequestMessage(HttpMethod.Post, FireBasePushNotificationsURL);

                request.Headers.TryAddWithoutValidation("Authorization", "key=" + ServerKey);
                request.Headers.TryAddWithoutValidation("Authorization", "id="  + senderId);
                request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

               
                using (var client = new HttpClient())
                {
                    result = await client.SendAsync(request);
                    sent = sent && result.IsSuccessStatusCode;
                }
            }
            var s = result.Content.ToString();

            return s;
        }

    }
}