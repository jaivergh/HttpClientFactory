
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TestWeb21
{
    public class GitHubClient
    {
        public readonly HttpClient Client;

        public GitHubClient(HttpClient client)
        {
            Client = client;
            Client.BaseAddress = new Uri("https://api.github.com");
        }

        public IEnumerable<int> GetIssues()
        {
            return new int[]{1,2,3,4};
        }
    }
}