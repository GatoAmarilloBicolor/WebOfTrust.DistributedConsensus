using System.Collections.Generic;

namespace WebOfTrustConsensus
{
    public class FinalizationTransactionMessage
    {
        public FinalizationTransactionMessage()
        {
            ChangesToSave = new List<ApprovedProposalEntry>();
        }
        public byte[] FinalizationHash { get; set; }
        public List<ApprovedProposalEntry> ChangesToSave { get; set; }
    }
}
