using System.Collections.Generic;

namespace WebOfTrustConsensus
{
    public class LastClosedLedger
    {
        public LastClosedLedger()
        {
            CryptoGL = new List<ApprovedProposalEntry>();
            ChangeHistory = new List<FinalizationTransactionMessage>();
        }
        public List<FinalizationTransactionMessage> ChangeHistory { get; set; }
        public List<ApprovedProposalEntry> CryptoGL { get; set; }
    }
}
