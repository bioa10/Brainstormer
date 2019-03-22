using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class User
    {
        public User(string newUserName, string newUserPassword, int newContributionScore, int newVotesLeft, bool newIsAdmin, bool newIsHost)
        {
            UserName = newUserName;
            UserPassword = newUserPassword;
            ContributionScore = newContributionScore;
            VotesLeft = newVotesLeft;
            isAdmin = newIsAdmin;
            isHost = newIsHost;
        }

        // ----- default properties -----
        public string UserName { get; private set; }

        public string UserPassword { get; private set; }

        public int ContributionScore { get; private set; }

        public int VotesLeft { get; private set; }

        public bool isAdmin { get; private set; }

        public bool isHost { get; private set; }
    }
}
