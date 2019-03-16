using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class defines an idea

namespace BrainstormerData
{
    public struct mindMapPositionStruct
    {
        public int x;
        public int y;
    }

    public class Idea
    {
        // what is the idea
        private string myDescription;

        // where inside the mindmap is this idea located
        private mindMapPositionStruct myPosition;

        // default constructor
        public Idea()
        {
            // if the position values are negative it
            // means that the idea is not displayed
            // in the mindmap
            myPosition.x = -1;
            myPosition.y = -1;
        }

        // -----  properties -----

        public string Description
        {
            get { return myDescription; }
            set { myDescription = value; }
        }

        public mindMapPositionStruct Position
        {
            get { return myPosition; }
            set { myPosition = value; }
        }
    }
}
