using System.Collections.Generic;

namespace WebOfTrustConsensus
{
    public class ListenerFirewall
    {
        public ListenerFirewall()
        {
            BannedServers = new List<Server>();
            RecentServers = new List<Server>();
            ActiveServers = new List<Server>();
        }

        public List<Server> BannedServers { get; set; }
        public List<Server> RecentServers { get; set; }
        public List<Server> ActiveServers { get; set; }
    }
}
