using System.Threading.Tasks;

namespace TestWeb21
{
    public class Value2Controller
    {
        private readonly GitHubClient _Client;

        public Value2Controller(GitHubClient client)
        {
            _Client = client;
        }

        public async Task<string[]> GetValues()
        {
            var issues = _Client.GetIssues();
            return new string[]{"value1","value2"};
        }
    }
}