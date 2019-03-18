using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class contains all of the ideas

namespace BrainstormerData
{

    class IdeaManager
    {
        // default constructor
        public IdeaManager()
        {
            Container = new List<Idea>();
        }

        public List<Idea> Container{ get; set; }
    }
}
