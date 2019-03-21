using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class User
    {
        public User()
        {

        }

        // ----- default properties -----
        public string UserName { get; private set; }

        public string UserPassword { get; private set; }

        public int ContributionScore { get; private set; }

        public int VotesLeft { get; private set; }
    }
}
