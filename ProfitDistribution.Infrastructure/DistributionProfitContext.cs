﻿using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;

namespace ProfitDistribution.Infrastructure
{
    public class DistributionProfitContext
    {
        private IFirebaseConfig config;
        public DistributionProfitContext()
        {
            config = new FirebaseConfig
            {
                AuthSecret = "WqwG9kisGWYpECo14cMnDzf0tH4raW5WWay6jOa4",
                BasePath = "https://profitdistribution-b317a-default-rtdb.firebaseio.com/"
            };

            var client = new FirebaseClient(config);
        }

        public FirebaseClient GetClient() => new FirebaseClient(config);

    }
}
