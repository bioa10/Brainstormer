using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class contains all of the ideas

namespace BrainstormerData
{

    public class IdeaManager
    {
        // default constructor
        public IdeaManager()
        {
            Ideas = new List<Idea>();
        }

        // ----- default properties -----
        public List<Idea> Ideas{ get; private set; }
    }
}
