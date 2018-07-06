using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.Repositories;
using MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels;
using MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.TransactionsUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Utils.StatusCodeUtils
{
    public class StatusCodeManager
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);

        private TransactionsManager transactionsManager;
        //private TransactionsRepository _transactionsRepository;
        private StatusCodeRepository _statusCodeRepository;

        private string serverKey = "AAA######";
        // Use firebaseTokenId to push notifications to only the device installing the app who have this specific tokenId
        private string firebaseTokenId = "######";
        private string WebApiServerKey = "AIza####";
        private string LegacyServerKey = "AIza##";
        private string applicationId = "####";
        private string senderId = "####";
        private string deviceId = "####"; // My Device Id , Got it From Android Studio from line code in the class LoginActivity.java
        private string mssTopics = "/topics/mss_topics"; // Use topics to push notifications to all the device installing the app

        public StatusCodeManager()
        {
            // _transactionsRepository = new TransactionsRepository();
            transactionsManager = new TransactionsManager();
            _statusCodeRepository = new StatusCodeRepository();

        }

        public List<gw_StatusCodeBindingModel> getOnlyStatusCodeWithDesc()
        {
            var returnedGeneralTransactionsData = transactionsManager.getGeneralTransactionsData();

            var listStatusCodesCodeWithDesc = new List<gw_StatusCodeBindingModel>();

            var sorted_listStatusCodesCodeWithDesc = new List<gw_StatusCodeBindingModel>();

            if (returnedGeneralTransactionsData.Count != 0 && returnedGeneralTransactionsData != null)
            {
                foreach (gw_trnsct_GeneralBindingModel trnsc in returnedGeneralTransactionsData)
                {
                                  
                    listStatusCodesCodeWithDesc.Add(new gw_StatusCodeBindingModel
                    {
                        CodeStatus = trnsc.CodeStatus,
                        CodeStatusDescription = trnsc.CodeStatusDescription,
                        TransactionDate = DateTime.Parse(trnsc.CurrentDate)
                    }
                    );

                    /*
                    listStatusCodesCodeWithDesc.OrderBy(x => x.TransactionDate.TimeOfDay)
                                               .ThenBy(x => x.TransactionDate.Day)
                                               .ThenBy(x => x.TransactionDate.Month)
                                               .ThenBy(x => x.TransactionDate.Year);
                    */

                    sorted_listStatusCodesCodeWithDesc = (from sc in listStatusCodesCodeWithDesc
                                                          orderby sc.TransactionDate descending
                                                          select sc).ToList();

                }
            }


            return sorted_listStatusCodesCodeWithDesc;
        }

        private static int cSharper = 0;
        public List<gw_StatusCodeBindingModel> getOnlyRejectedStatusCodeWithDesc()
        {

            var x = "20";
            var y = "Transaction refusée offline";

            var returnedListStatusCodeWithDesc = getOnlyStatusCodeWithDesc();
            var returnedGeneralTransactionsData = transactionsManager.getGeneralTransactionsData();

            var listRejectedStatusCodesCodeWithDesc = new List<gw_StatusCodeBindingModel>();
            var sorted_listRejectedStatusCodesCodeWithDesc = new List<gw_StatusCodeBindingModel>();

            var listRejectedTransactions = new List<gw_trnsct_GeneralBindingModel>();

            listRejectedTransactions = returnedGeneralTransactionsData.Where(rc => rc.CodeStatus == x && rc.CodeStatusDescription == y).ToList();

            // added test t5albiz
           /* var rejectedCountOldTransFromNowToPast   = returnedGeneralTransactionsData.Where(rc => rc.CodeStatus == x).Count();
            var rejectedCountNewTransFromNowToFuture = (from rct in returnedGeneralTransactionsData
                                                        where rct.CodeStatus == x
                                                        select rct.CodeStatus
                                                        ).Last().ToList().Count();
            var listAllStatusCode = returnedGeneralTransactionsData.Select(r => r.CodeStatus).ToList(); 
            cSharper = 0;
            foreach (string cs in listAllStatusCode)
            {
                while (cs != x)
                {
                    if (cs == x)
                    {
                        cSharper++;
                    }
                }
            }*/
            // fin

            if (listRejectedTransactions.Count != 0 && listRejectedTransactions != null)
            {
                foreach (gw_trnsct_GeneralBindingModel r in listRejectedTransactions)
                {
       
                        listRejectedStatusCodesCodeWithDesc.Add(new gw_StatusCodeBindingModel
                        {
                            CodeStatus = r.CodeStatus,
                            CodeStatusDescription = r.CodeStatusDescription,
                            TransactionDate = DateTimeOffset.Parse(r.CurrentDate),
                            TransactionId = r.idTransaction,
                            TransactionType = r.Transactiontype,
                            CardOfPayement = r.CardUsedForPayement,
                            BankOfRequest = r.BankOfRequest,
                            BankNameGateWay = r.BankName_GateWay,
                            Amount = r.Amount
                        }
                        );


                    // listRejectedStatusCodesCodeWithDesc.OrderBy(t => t.TransactionDate).Distinct();

                    sorted_listRejectedStatusCodesCodeWithDesc = (from sc in listRejectedStatusCodesCodeWithDesc
                                                                  orderby sc.TransactionDate descending
                                                                  select sc).ToList();

                }
            }
            
            return sorted_listRejectedStatusCodesCodeWithDesc;
        }

        public int getCountOfOnlyRejectedStatusCodeWithDesc()
        {
            var listRejectedStatusCodeWithDesc = getOnlyRejectedStatusCodeWithDesc();

            var sizeOfListRejectedStatus = listRejectedStatusCodeWithDesc.Count;

            return sizeOfListRejectedStatus;
        }

        /*
        public bool Successful { get; set; }
        public string Response { get; set; }
        public Exception Error { get; set; }
        */

        public string sendNotificationOfRejectedTransactions()
        {
            //var result = new StatusCodeManager();

            var sizeOfListRejectedStatusCode = getCountOfOnlyRejectedStatusCodeWithDesc();
            bool Successful;
            string Response = "";
            Exception Error;

            try
           {
            Successful = true;
            Error = null;

            //string deviceId = "1:510346677298:android:6ad22fdc69c347fc";

            var txtTitle = "You have new MSS notification";
            var txtBody = "There is " + sizeOfListRejectedStatusCode + " new Rejected Transactions";

            //Create the web request with fire base API  
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "Post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            tRequest.ContentType = "application/json";

            var data = new 
            {
                //to = deviceId, // this if you want to test for single device 
                priority = "high",
                content_available = true,
                notification = new
                {
                    title = txtTitle.Replace(":", ""),
                    body = txtBody,
                    //sound = "sound.caf",
                    //badge = badgeCounter,
                    show_in_foreground = "True",
                    //icon = "myicon"
                },
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(data);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                string sResponseFromServer = tReader.ReadToEnd();
                                Response = sResponseFromServer;
                            }
                    }
                }
            }
        }catch (Exception ex)
            {
                Successful = false;
                Response = null;
                Error = ex;
            }

            return Response;
        }

        private static MessageBindingModel serializableData;
        public string SendNotificationFromFirebaseCloud()
        {
            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";

            var sizeOfListRejectedStatusCode = getCountOfOnlyRejectedStatusCodeWithDesc();

            var txtTitle = "You have new MSS notification";
            var txtBody = "There is " + sizeOfListRejectedStatusCode + " new Rejected Transactions";
       
            var httpWebRequest = WebRequest.CreateHttp(webAddr);
            httpWebRequest.ContentType = "application/json";

            //serverKey - Key from Firebase cloud messaging server  
            httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            //httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key="+serverKey);
            //Sender Id - From firebase project setting  
            httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            //httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=your FCM senderkey");

            httpWebRequest.Method = "POST";

            /*
            httpWebRequest.UseDefaultCredentials = true;
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            */

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                /*
                string strNJson = @"{
                    ""to"": ""/topics/ServiceNow"",
                    ""data"": {
                        ""ShortDesc"": ""Some short desc"",
                        ""IncidentNo"": ""any number"",
                        ""Description"": ""detail desc""
                         }, 
                   ""notification"": {
                              ""title"": ""ServiceNow: Incident No. number"",
                              ""text"": ""This is Notification"",
                              ""sound"":""default""
                      }
                 }";
                 */
                /*
               var data = new
               {
                   to = deviceId, // this if you want to test for single device 
                   //to = "/topics/ServiceNow",
                   priority = "high",
                   content_available = true,
                   notification = new
                   {
                       title = txtTitle.Replace(":", ""),
                       body = txtBody,
                       //sound = "sound.caf",
                       //badge = badgeCounter,
                       show_in_foreground = "True",
                       //icon = "myicon"
                   },
               };
               */
                serializableData = new MessageBindingModel()
                {
                    //to = "/topics/anytopic",
                    to = firebaseTokenId, // this if you want to test for single device                   
                    Data = new NotificationBindingModel()
                    {
                        Title = txtTitle,
                        Message = txtBody
                    },
                    content_available = true,
                    priority = "high"
                    //registration_id = applicationId
                };

                /*
                var data = new
                {
                    //to = "/topics/anytopic",
                    to = firebaseTokenId, // this if you want to test for single device                   
                    notification = new
                    {
                        title = txtTitle,
                        message = txtBody
                    },
                    content_available = true,
                    priority = "high"
                    //registration_id = applicationId
                };
                */
                //string json = "{\"to\": \"" + firebaseTokenId + "\",\"data\": {\"title\": \"" + txtTitle + "\",\"message\": \""+ txtBody + "\"},\"priority\":high,\"content_available\":true}";


                /*
                string msg = @"{
                               to : my_device_token
                               notification : {
                                          title :test from server,
                                          body :test lorem ipsum
                               }
                              }";
             */
                /*
                string postData =
              "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
               + txtBody + "&data.time=" + DateTime.Now.ToString() + "&registration_id=" +
                  WebApiServerKey + "";
               */

                var serializer = new JavaScriptSerializer();
                var strNJson = serializer.Serialize(serializableData);
               // byte[] byteArray = Encoding.UTF8.GetBytes(strNJson);
               // httpWebRequest.ContentLength = byteArray.Length;

                streamWriter.Write(strNJson);
                Console.WriteLine(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public MessageBindingModel getValuesSentNotificationFromFirebaseCloud()
        {
            var result = SendNotificationFromFirebaseCloud();
       
            if (result.Equals("-1"))
            {
                return null;
            }else
            {
                return serializableData;
            }
        }

       /* public async Task<string> sendPushNotifcationToFirebase()
        {
            bool sent;
            //string senderId = "510346677298";


            var sizeOfListRejectedStatusCode = getCountOfOnlyRejectedStatusCodeWithDesc();

            var txtTitle = "You have new MSS notification";
            var txtBody = "There is " + sizeOfListRejectedStatusCode + " new Rejected Transactions";
            object data = null;

                      
            var tokens = new string[2];
            
            for (int i=0; i < tokens.Length; i++)
            {
                tokens[0] = deviceId;
                tokens[1] = senderId;
            }
            

            //sent = await StatusCodeTransactionsPushNotification.SendPushNotification(deviceId, txtTitle, txtBody, data);

            var result = await StatusCodeTransactionsPushNotification.SendPushNotification(deviceId, txtTitle, txtBody, data);

            return result;
        }  */


        /// <summary>
        /// Send a Google Cloud Message. Uses the GCM service and your provided api key.
        /// </summary>
        /// <param name="apiKey">Your Server Key In Your Firebase Parameters</param>
        /// <param name="postData">Data to post via Firebase</param>
        /// <param name="postDataContentType">Content of data in Json</param>
        /// <returns>The response string from the google servers</returns>
        private string SendGCMNotification(string apiKey, string postData, string postDataContentType = "application/json")
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

            //
            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST   //https://android.googleapis.com/gcm/send
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            //
            //  SEND MESSAGE
            string responseLine = "";

            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    var text = "Unauthorized - need new token";
                    Console.WriteLine(text);
                    responseLine = text;
                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    var text = "Response from web service isn't OK";
                    Console.WriteLine(text);
                    responseLine = text;
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {
            }
            return "error";
        }


        public static bool ValidateServerCertificate(object sender,X509Certificate certificate,X509Chain chain,SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public MessageBindingModel sendNotifcation(int differenceCountedRejcTrns)
        {
            //string deviceId = "DEVICE_REGISTRATION_ID";
           
            string message = "some test message";
            string tickerText = "example test GCM";
            string contentTitle = "content title GCM";
            string postData =
            "{ \"registration_ids\": [ \"" + firebaseTokenId + "\" ], " +
              "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
                         "\"contentTitle\":\"" + contentTitle + "\", " +
                         "\"message\": \"" + message + "\"}}";

           // var sizeOfListRejectedStatusCode = getCountOfOnlyRejectedStatusCodeWithDesc();
           
            /*string response = "";
            MessageBindingModel serializableDatas = null;
            if (DifferenceOfCountedRejectedValue > 0)
            {
                var txtTitle = "You have new MSS notification";
                var txtBody = "There is " + DifferenceOfCountedRejectedValue + " New Rejected Transactions";

                serializableDatas = new MessageBindingModel()
                {
                    //to = "/topics/anytopic",
                    to = firebaseTokenId, // this if you want to test for single device                   
                    Data = new NotificationBindingModel()
                    {
                        Title = txtTitle,
                        Message = txtBody
                    },
                    content_available = true,
                    priority = "high"
                    //registration_id = applicationId
                };
                var serializer = new JavaScriptSerializer();
                var strNJson = serializer.Serialize(serializableDatas);

                response = SendGCMNotification(serverKey, strNJson);

            }

            if (response != "" && response != "Unauthorized - need new token" && response != "Response from web service isn't OK")
            {
                return serializableDatas;
            }
            else
            {
                return response;
            }*/

            var txtTitle = "You have new MSS notification";
            var txtBody = "There is " + differenceCountedRejcTrns + " New Rejected Transactions";

            var serializableDatas = new MessageBindingModel()
            {
                //to = "/topics/anytopic",
                to = firebaseTokenId, // this if you want to test for single device                   
                Data = new NotificationBindingModel()
                {
                    Title = txtTitle,
                    Message = txtBody
                },
                content_available = true,
                priority = "high"
                //registration_id = applicationId
            };
            var serializer = new JavaScriptSerializer();
            var strNJson = serializer.Serialize(serializableDatas);

            string response = SendGCMNotification(serverKey, strNJson);

            if (response != "" && response != "Unauthorized - need new token" && response != "Response from web service isn't OK")
            {
                return serializableDatas;
            }else
            {
                return null;
            } 
        }

        private static int sizeOfListRejectedStatusCode = 0;
        public int CalculateDifferenceOfCountedRejectedValue()
        {
            sizeOfListRejectedStatusCode = getCountOfOnlyRejectedStatusCodeWithDesc();
            var DifferenceOfCountedRejectedValue = _statusCodeRepository.ReturnDifferenceCountedRejcTrans(sizeOfListRejectedStatusCode);
            return DifferenceOfCountedRejectedValue;
        }

        public int GetLastDifferenceFromDb()
        {
            var diff = _statusCodeRepository.GetLastDifferenceRejcTrans();
            return diff;
        }

        public void PostCounterTrns()
        {
            var diff = CalculateDifferenceOfCountedRejectedValue();

            RejectedTransactionsCounter rtc = new RejectedTransactionsCounter
            {
                lastCountedValue = sizeOfListRejectedStatusCode,
                lastDifference = diff,
                lastDateTimeOfCount = DateTime.Now
            };

            _statusCodeRepository.AddNewCounterTrans(rtc);
        }

        public string sendManualNotifcation(int differenceCountedRejcTrns)
        {
            //string deviceId = "DEVICE_REGISTRATION_ID";

            string message = "some test message";
            string tickerText = "example test GCM";
            string contentTitle = "content title GCM";
            string postData =
            "{ \"registration_ids\": [ \"" + firebaseTokenId + "\" ], " +
              "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
                         "\"contentTitle\":\"" + contentTitle + "\", " +
                         "\"message\": \"" + message + "\"}}";

            // var sizeOfListRejectedStatusCode = getCountOfOnlyRejectedStatusCodeWithDesc();

            /*string response = "";
            MessageBindingModel serializableDatas = null;
            if (DifferenceOfCountedRejectedValue > 0)
            {
                var txtTitle = "You have new MSS notification";
                var txtBody = "There is " + DifferenceOfCountedRejectedValue + " New Rejected Transactions";

                serializableDatas = new MessageBindingModel()
                {
                    //to = "/topics/anytopic",
                    to = firebaseTokenId, // this if you want to test for single device                   
                    Data = new NotificationBindingModel()
                    {
                        Title = txtTitle,
                        Message = txtBody
                    },
                    content_available = true,
                    priority = "high"
                    //registration_id = applicationId
                };
                var serializer = new JavaScriptSerializer();
                var strNJson = serializer.Serialize(serializableDatas);

                response = SendGCMNotification(serverKey, strNJson);

            }

            if (response != "" && response != "Unauthorized - need new token" && response != "Response from web service isn't OK")
            {
                return serializableDatas;
            }
            else
            {
                return response;
            }*/

            var txtTitle = "You have new MSS notification";
            var txtBody = "There is " + differenceCountedRejcTrns + " New Rejected Transactions";

            var serializableDatas = new MessageBindingModel()
            {
                //to = "/topics/anytopic",
                to = firebaseTokenId, // this if you want to test for single device                   
                Data = new NotificationBindingModel()
                {
                    Title = txtTitle,
                    Message = txtBody
                },
                content_available = true,
                priority = "high"
                //registration_id = applicationId
            };
            var serializer = new JavaScriptSerializer();
            var strNJson = serializer.Serialize(serializableDatas);

            string response = SendGCMNotification(serverKey, strNJson);

            return response;
        }
    }
}
