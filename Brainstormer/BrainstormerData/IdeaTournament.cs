using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class stores and manages data for idea tournaments
namespace BrainstormerData
{
    public class IdeaTournament
    {
        public IdeaTournament(IdeaManager newIdeaManager)
        {
            anIdeaManager = newIdeaManager;
            round = 0;
        }

        

        

        // ----- default properties -----
        public IdeaManager anIdeaManager { get; set; }

        // the current round that the tournament is on
        public int round { get; set; }

    }
}
