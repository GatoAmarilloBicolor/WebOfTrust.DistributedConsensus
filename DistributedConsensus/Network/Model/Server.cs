using System;

namespace WebOfTrustConsensus
{
    public class Server
    {
        public byte[] ServerID { get; set; }
        public DateTime LastSeen { get; set; }
        public DateTime ErrorResetTime { get; set; }
        public int Errors { get; set; }
    }
}
