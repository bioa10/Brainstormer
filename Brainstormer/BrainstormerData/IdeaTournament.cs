using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class IdeaTournament
    {
        public IdeaTournament(IdeaManager newIdeaManager)
        {
            anIdeaManager = newIdeaManager;
        }

        

        

        // ----- default properties -----
        public IdeaManager anIdeaManager { get; set; }

    }
}
