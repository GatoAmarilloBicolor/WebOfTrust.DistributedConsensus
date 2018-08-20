using System.Collections.Generic;

namespace WebOfTrustConsensus
{
    public class Proposal
    {
        public Proposal()
        {
            ProposalEntries = new List<ProposalEntry>();
        }

        public byte[] ServerID { get; set; }
        public List<ProposalEntry> ProposalEntries { get; set; }
    }
}
