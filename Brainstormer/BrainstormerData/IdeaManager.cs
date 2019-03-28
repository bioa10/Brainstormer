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
        /// <summary>
        /// Default constructor
        /// </summary>
        public IdeaManager()
        {
            Ideas = new List<Idea>();
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="ideaManager">IdeaManager to copy</param>
        public IdeaManager(IdeaManager ideaManager)
        {
            Ideas = new List<Idea>(ideaManager.Ideas);
        }

        // ----- default properties -----
        public List<Idea> Ideas{ get; private set; }
    }
}
