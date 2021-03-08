using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace ProfitDistribution.Infrastructure
{
    public class DistributionProfitContext
    {
        private IFirebaseConfig config;
        public DistributionProfitContext(string authSecret, string basePath)
        {
            config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath
            };
        }

        public FirebaseClient GetClient() => 
            new FirebaseClient(config);

    }
}
