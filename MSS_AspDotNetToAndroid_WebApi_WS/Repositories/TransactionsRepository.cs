﻿using MSS_AspDotNetToAndroid_WebApi_WS.Models;
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
                                                        // General Part
                                                        idTransaction = trnsc.idTransaction,
                                                        IdMerchant = trnsc.IdMerchant,
                                                        IdTerminalMerchant = trnsc.IdTerminalMerchant,
                                                        IdHost = trnsc.IdHost,
                                                        Amount = trnsc.Amount,
                                                        EtatTransaction = trnsc.EtatTransaction,
                                                        BankOfRequest = trnsc.BankOfRequest,

                                                        // Extended Part
                                                        EtatCloture = trnsc.EtatCloture,
                                                        CurrentDate = trnsc.CurrentDate, // Date
                                                        TimeSystemTransaction = trnsc.TimeSystemTransaction, // Heure Transaction
                                                        Transactiontype = trnsc.Transactiontype, // Transactiontype
                                                        ResponseCode = trnsc.ResponseCode, // ResponseCode
                                                        FID_F_ApprovalCode = trnsc.FID_F_ApprovalCode, // ApprovalCode ( Code d'autorisation)
                                                        CardMask = trnsc.CardMask, // Pan

                                                        // Another Fields for Ticket Part
                                                        ApplicationIdentifierCard = trnsc.ApplicationIdentifierCard, // APPID
                                                        ApplicationCryptogram = trnsc.ApplicationCryptogram, // Sign
                                                        TerminalVerificationResults = trnsc.TerminalVerificationResults, // TVR
                                                        TransactionStatusInformation = trnsc.TransactionStatusInformation, // TSI
                                                        CardBin = trnsc.CardBin
                                                    }
                                                    )
                                                    .Distinct()
                                                    .ToList();          
            }
            return filtered_generalListTransactions;
        }

        public List<gw_bin> getAllBinCardsForPayements()
        {
            var list_BinCards = utwk.getRepository<gw_bin>().GetAll().ToList();
            return list_BinCards;
        }

        public string getCardUsedForPayement(List<gw_bin> list_BinCards,List<gw_trnsct> list_Transactions,string cardBin)
        {
            var cardUsedForPayement_ToReturn = (from c1 in list_BinCards
                                                join c2 in list_Transactions
                                                on c1.gw_bin_id equals cardBin
                                                select c1.gw_bin_label
                                                ).FirstOrDefault();

            return cardUsedForPayement_ToReturn;
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

        public string getBankNameGateWay(List<gw_bank> list_bank,List<gw_bin> list_BinCards,string bankId)
        {
            var BankId_ToReturn = (from c1 in list_bank
                                   join c2 in list_BinCards
                                   on c1.gw_bank_id equals bankId
                                   select c1.gw_bank_name
                                   ).FirstOrDefault();

            return BankId_ToReturn;
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