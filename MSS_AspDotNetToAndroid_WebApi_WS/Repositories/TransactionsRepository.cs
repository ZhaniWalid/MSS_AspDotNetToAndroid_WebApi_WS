using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Repositories
{
    public class TransactionsRepository : Service<gw_trnsct>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public TransactionsRepository() : base(utwk)
        {
        }

        public List<gw_trnsct> getAllTransactionsData()
        {
            var listTransactions = utwk.getRepository<gw_trnsct>().GetAll().ToList();
            return listTransactions;
        }

        public List<gw_trnsct> filteredGeneralTransactionsData()
        {
            var list_AllTransctionsData = getAllTransactionsData();

            var filtered_generalListTransactions = new List<gw_trnsct>();

            if (list_AllTransctionsData.Count != 0 && list_AllTransctionsData != null)
            {
                filtered_generalListTransactions = (from trnsc in list_AllTransctionsData
                                                    orderby trnsc.AmountAuthorisedNumeric
                                                    select new gw_trnsct
                                                    {
                                                        idTransaction = trnsc.idTransaction,
                                                        IdMerchant = trnsc.IdMerchant,
                                                        IdTerminalMerchant = trnsc.IdTerminalMerchant,
                                                        IdHost = trnsc.IdHost,
                                                        AmountAuthorisedNumeric = trnsc.AmountAuthorisedNumeric,
                                                        EtatTransaction = trnsc.EtatTransaction,
                                                        BankOfRequest = trnsc.BankOfRequest,
                                                        // Extended Part
                                                        EtatCloture = trnsc.EtatCloture,
                                                        CurrentDate = trnsc.CurrentDate, // Date
                                                        TimeSystemTransaction = trnsc.TimeSystemTransaction, // Heure Transaction
                                                        Transactiontype = trnsc.Transactiontype, // Transactiontype
                                                        ResponseCode = trnsc.ResponseCode, // ResponseCode
                                                        FID_F_ApprovalCode = trnsc.FID_F_ApprovalCode, // ApprovalCode ( Code d'autorisation)
                                                        CardMask = trnsc.CardMask // Pan
                                                    }
                                                    )
                                                    .Distinct()
                                                    .ToList();          
            }
            return filtered_generalListTransactions;
        }

        /*

        public List<gw_trnsct> filteredExtendedTransactionsData()
        {
            var list_AllTransctionsData = getAllTransactionsData();

            var filtered_extendedListTransactions = new List<gw_trnsct>();


            if (list_AllTransctionsData.Count != 0 && list_AllTransctionsData != null)
            {
                filtered_extendedListTransactions = (from trnsc in list_AllTransctionsData
                                                    orderby trnsc.ResponseCode
                                                    select new gw_trnsct
                                                    {
                                                        idTransaction = trnsc.idTransaction,
                                                        EtatCloture   = trnsc.EtatCloture,
                                                        CurrentDate = trnsc.CurrentDate, // Date
                                                        TimeSystemTransaction = trnsc.TimeSystemTransaction, // Heure Transaction
                                                        Transactiontype = trnsc.Transactiontype, // Transactiontype
                                                        ResponseCode = trnsc.ResponseCode, // ResponseCode
                                                        FID_F_ApprovalCode = trnsc.FID_F_ApprovalCode, // ApprovalCode ( Code d'autorisation)
                                                        CardMask = trnsc.CardMask // Pan
                                                    }
                                                    )
                                                    .Distinct()
                                                    .ToList();
            }
            return filtered_extendedListTransactions;
        }

        */
        
    }
}