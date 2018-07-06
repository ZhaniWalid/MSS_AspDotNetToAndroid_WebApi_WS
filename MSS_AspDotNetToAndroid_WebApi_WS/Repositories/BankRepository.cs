using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Repositories
{
    public class BankRepository : Service<gw_bank>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public BankRepository() : base(utwk)
        {
        }

        public List<gw_bank> getAllBank()
        {
            var list_Bank = utwk.getRepository<gw_bank>().GetAll().ToList();
            return list_Bank;
        }

        public string getBankIdGateWay(List<gw_bin> list_BinCards, List<gw_trnsct> list_Transactions, string cardBin)
        {
            var BankId_ToReturn = (from c1 in list_BinCards
                                   join c2 in list_Transactions
                                   on c1.gw_bin_id equals cardBin
                                   select c1.gw_bin_bank_id
                                   ).FirstOrDefault();

            return BankId_ToReturn;
        }

        public string getBankNameGateWay(List<gw_bank> list_bank, List<gw_bin> list_BinCards, string bankId)
        {
            var BankId_ToReturn = (from c1 in list_bank
                                   join c2 in list_BinCards
                                   on c1.gw_bank_id equals bankId
                                   select c1.gw_bank_name
                                   ).FirstOrDefault();

            return BankId_ToReturn;
        }

    }
}