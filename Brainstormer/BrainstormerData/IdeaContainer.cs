using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class contains all of the ideas

namespace BrainstormerData
{

    class IdeaContainer
    {
        private List<Idea> _container;

        // default constructor
        public IdeaContainer()
        {
            
        }

        public List<Idea> Container
        {
            get { return _container; }
            set { _container = value;}
        }
    }
}
