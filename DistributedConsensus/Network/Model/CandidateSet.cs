using System.Collections.Generic;

namespace WebOfTrustConsensus
{
    public class CandidateSet
    {
        public CandidateSet()
        {
            ConsensusQueue = new List<PendingServerTransactions>();
            VerifiedProposals = new List<ApprovedProposalEntry>();
            UnverifiedProposals = new List<Proposal>();
        }
        public List<PendingServerTransactions> ConsensusQueue { get; set; }
        public int MinimumAgreementThreshold { get; set; }

        public List<ApprovedProposalEntry> VerifiedProposals { get; set; }
        public List<Proposal> UnverifiedProposals { get; set; }
    }
}
