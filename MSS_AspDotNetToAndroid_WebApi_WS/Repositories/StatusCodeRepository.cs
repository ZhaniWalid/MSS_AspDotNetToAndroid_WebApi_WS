using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Repositories
{
    public class StatusCodeRepository : Service<gw_status_code>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public StatusCodeRepository() : base(utwk)
        {

        }

        public List<gw_status_code> getAllStatusCodeData()
        {
            var listStatusCode = utwk.getRepository<gw_status_code>().GetAll().ToList();
            return listStatusCode;
        }

        public string getStatusCodeDescription(List<gw_status_code> list_StatusCodes, List<gw_trnsct> list_Transactions, string codeStatus)
        {
            var StatusCodeDescription_ToReturn = (from c1 in list_StatusCodes
                                                  join c2 in list_Transactions
                                                  on c1.gw_status_code_id equals codeStatus
                                                  select c1.gw_status_code_description
                                                 ).FirstOrDefault();

            return StatusCodeDescription_ToReturn;
        }

        public List<gw_status_code> getAllRejectedStatusCodeData(string code,string codeDesc)
        {
            var listStatusCodeRejected = utwk.getRepository<gw_status_code>()
                                             .GetMany(rc => rc.gw_status_code_id == code && rc.gw_status_code_description == codeDesc)
                                             .ToList();
            return listStatusCodeRejected;
        }


        // Rejected Transactions Counter for Notification
        public void InsertCounterTrans(RejectedTransactionsCounter rtc)
        {
            utwk.getRepository<RejectedTransactionsCounter>().Add(rtc);
            utwk.Commit();
        }

        public void UpdateCounterTrans(RejectedTransactionsCounter rtc)
        {
            utwk.getRepository<RejectedTransactionsCounter>().Update(rtc);
            utwk.Commit();
        }

        public RejectedTransactionsCounter findRejecTransByLastCount(int lastId)
        {
            var rejTrnsCount = utwk.getRepository<RejectedTransactionsCounter>().Get(rtc => rtc.idCounterRejTrns == lastId);
            return rejTrnsCount;
        }

        public List<RejectedTransactionsCounter> getAllCountedTypeTrans()
        {
            var listOfAll = utwk.getRepository<RejectedTransactionsCounter>().GetMany().ToList();
            return listOfAll;
        }

       /* public List<int> getAllCountedRejcTrans()
        {
            var listOfAll = getAllCountedTypeTrans();

            var listCountedTrns = (from l in listOfAll
                                      select l.lastCountedValue).ToList();

            return listCountedTrns;
        }

        public int getMaxIdOfCountedRejTrns()
        {
            var listOfAll = getAllCountedTypeTrans();
            var maxId = listOfAll.Select(t => t.idCounterRejTrns).Max();

            return maxId;
        }*/

        public int getLastIdOfCountedRejTrns()
        {
            var listOfAll = getAllCountedTypeTrans();
            var lastId = listOfAll.OrderByDescending(t => t.lastDateTimeOfCount).Select(t => t.idCounterRejTrns).First();

            return lastId;
        }

        public int GetLastCountedRejcTrans()
        {
            //var listCountedTrns = getAllCountedRejcTrans();
            var listOfAll = getAllCountedTypeTrans();
            var maxId = getLastIdOfCountedRejTrns();

            /*var lastOldOne = (from c in listOfAll
                              orderby c.lastDateTimeOfCount
                              where c.idCounterRejTrns == maxId
                              select c.lastCountedValue).LastOrDefault();*/
            var lastOldOne = listOfAll.OrderByDescending(t => t.lastDateTimeOfCount).Where(t => t.idCounterRejTrns == maxId).Select(t => t.lastCountedValue).FirstOrDefault();

            return lastOldOne;
        }

        public int GetLastDifferenceRejcTrans()
        {
            //var listCountedTrns = getAllCountedRejcTrans();
            var listOfAll = getAllCountedTypeTrans();
            var maxId = getLastIdOfCountedRejTrns();

            /*var lastOldOne = (from c in listOfAll
                              orderby c.lastDateTimeOfCount
                              where c.idCounterRejTrns == maxId
                              select c.lastCountedValue).LastOrDefault();*/
            var lastOldDifference = listOfAll.OrderByDescending(t => t.lastDateTimeOfCount).Where(t => t.idCounterRejTrns == maxId).Select(t => t.lastDifference).FirstOrDefault();
            return lastOldDifference;
        }

        // private static RejectedTransactionsCounter rtc;
        public int ReturnDifferenceCountedRejcTrans(int newCountedValue)
        {
            var lastOldOne = GetLastCountedRejcTrans();
            //var lastId = getLastIdOfCountedRejTrns();
            var difference = 0;
            return difference = newCountedValue - lastOldOne;

            /*if (newCountedValue > lastOldOne)
            {
                difference = newCountedValue - lastOldOne;

            }else if (newCountedValue < lastOldOne)
            {
                difference = newCountedValue - lastOldOne;
            }
            else
            {
                difference = 0;
            }*/

        }

        public void AddNewCounterTrans(RejectedTransactionsCounter rtc)
        {
            InsertCounterTrans(rtc);
        }

    }
}