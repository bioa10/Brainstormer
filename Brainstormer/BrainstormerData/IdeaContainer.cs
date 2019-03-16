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
        private List<Idea> myContainer;

        // default constructor
        public IdeaContainer()
        {
            
        }

        public List<Idea> MyContainer
        {
            get { return myContainer; }
            set { myContainer = value; }
        }
    }
}
