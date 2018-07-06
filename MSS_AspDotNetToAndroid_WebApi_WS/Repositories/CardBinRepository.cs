using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Repositories
{
    public class CardBinRepository : Service<gw_bin>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        private TransactionsRepository _transactionRepository;

        public CardBinRepository() : base(utwk)
        {
            _transactionRepository = new TransactionsRepository();
        }

        public List<gw_bin> getAllBinCardsForPayements()
        {
            var list_BinCards = utwk.getRepository<gw_bin>().GetAll().ToList();
            return list_BinCards;
        }

        public string getCardUsedForPayement(List<gw_bin> list_BinCards, List<gw_trnsct> list_Transactions, string cardBin)
        {
            var cardUsedForPayement_ToReturn = (from c1 in list_BinCards
                                                join c2 in list_Transactions
                                                on c1.gw_bin_id equals cardBin
                                                select c1.gw_bin_label
                                                ).FirstOrDefault();

            return cardUsedForPayement_ToReturn;
        }

        // I didn't use it , but it works fine
        public List<gw_trnsct> getAllCardsBinCodes()
        {
            var list_AllTransctionsData = _transactionRepository.getAllTransactionsData();

            var filtered_ListCardsBinCodes = new List<gw_trnsct>();

            if (list_AllTransctionsData.Count != 0 && list_AllTransctionsData != null)
            {
                filtered_ListCardsBinCodes = (from trnsc in list_AllTransctionsData
                                              select new gw_trnsct
                                              {
                                                  CardBin = trnsc.CardBin
                                              }
                                              ).Distinct()
                                              .ToList();
            }

            return filtered_ListCardsBinCodes;
        }

        // I didn't use it , but it works fine
        public List<gw_bin> getAllBinCardsLabels()
        {
            var list_AllBinCards = getAllBinCardsForPayements();

            var filtered_ListBinCardLabels = new List<gw_bin>();

            if (list_AllBinCards.Count != 0 && list_AllBinCards != null)
            {
                filtered_ListBinCardLabels = (from bin_card in list_AllBinCards
                                              select new gw_bin
                                              {
                                                  gw_bin_label = bin_card.gw_bin_label
                                              }
                                              ).Distinct()
                                               .ToList();
            }

            return filtered_ListBinCardLabels;
        }

    }
}