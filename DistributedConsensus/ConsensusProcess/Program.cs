//namespace WebOfTrustConsensus
//{
//    class Program
//    {


//        static void Main1(string[] args)
//        {
//            // Async, send proposals inbound.
//            // - If transaction source on ListenerFirewall, process high priority
//            // - - If not, then put into mempool for lag-processing
//            // - - - If lag processing complete/Pass, move to queue2
//            //
//            // Async, send Transactions inbound
//            // - If transaction source on ListenerFirewall, process
//            // - Find what transactions that are common among the UNL
//            // - - Process/verify proposals missing in others.
//            // - - 50% agreement... dispose unverified, or put into tx buffer
//            // - - 60% agreement... dispose unverified, or put into tx buffer
//            // - - 70% agreement... dispose unverified, or put into tx buffer
//            // - - 80% agreement... dispose unverified, or put into tx buffer
//            // - - 90% agreement... dispose unverified, or put into tx buffer
//            // - - 100% agreement... dispose unverified, or put into tx buffer
//            // Send 
//            CandidateSet currentCandidateSet = new CandidateSet();
//            var listenerFirewall = new ListenerFirewall();
//            {
//                byte[] incomingHost = new byte[0];
//                Proposal incomingProposal = new Proposal();
//                incomingProposal.ProposalEntries.Add(new ProposalEntry() { Key = new byte[0], Value = new byte[0], Proof = new byte[0] });
//                incomingProposal.ProposalEntries.Add(new ProposalEntry() { Key = new byte[0], Value = new byte[0], Proof = new byte[0] });
//                incomingProposal.ProposalEntries.Add(new ProposalEntry() { Key = new byte[0], Value = new byte[0], Proof = new byte[0] });
//                incomingProposal.ProposalEntries.Add(new ProposalEntry() { Key = new byte[0], Value = new byte[0], Proof = new byte[0] });

//                foreach (var proposal in incomingProposal.ProposalEntries)
//                {
//                    bool didPass = ValidatePendingChange(proposal.Key, proposal.Value, proposal.Proof);
//                    if (!didPass)
//                    {
//                        // Mark the server as sending invalid transactions. Could be communication issue, code modification, or malicious intent
//                        // If too many errors are recieved, server may be temp banned, or perm banned
//                    }
//                    currentCandidateSet.VerifiedProposals.Add((ApprovedProposalEntry)proposal);
//                }
//            }
//            // TIMER: Compute a transaction from existing candidateSet
//            {
//                int countOfActiveServers = 10; // todo: calculate RecentlySeen, Not temp/perm banned, located in ListenerFirewall
//                int thresholdOfAgreement = 50; // percent. Increases in the interval to 100

//                // returns:
//                // - a list of verified proposals above the agreement threshold
//                // - a list of proposals not in that threshold (buffer)
//                var proposalAgreementReport = currentCandidateSet.VerifiedProposals;

//                // Send the batch of verified and proposals to UNL list
//                // includes server IDs, to aid in p2p discoverability
//                // todo: track if servers on UNL are actually adding to the set.  If we don't get UNL back with TX we sent them, then they are ignoring us
//                // todo: add 'compression' to servers that already have proof by removing the proof (redundancy)
//            }
//            // TIMER: UNL Discovery
//            {
//                // Hey how many UNL slots available? (return 0-any number).  Can be artifically low to join many different replication "pods"
//                // Share this information with peers if >1 and/or not interested
//                // GetPeers().  Can be artifically low, random subset
//            }
//            // TIMER: Age out old, non validated transactions
//            {

//            }
//        }

//        private static bool ValidatePendingChange(byte[] key, byte[] value, byte[] proof)
//        {
//            return false;
//            // is prooftype UProve or AnonCredentials
//            // are they permitted to make this change to the corresponding key value
//            // Each key has an owner, verify hash match
//            {

//            }
//        }
//    }
//}
