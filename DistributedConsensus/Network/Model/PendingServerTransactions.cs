using System.Collections.Generic;

namespace WebOfTrustConsensus
{
    public class PendingServerTransactions
    {
        public PendingServerTransactions()
        {
            ProposalEntries = new List<ApprovedProposalEntry>();
        }
        public byte[] ServerID { get; set; }
        public List<ApprovedProposalEntry> ProposalEntries { get; set; }
    }
}
