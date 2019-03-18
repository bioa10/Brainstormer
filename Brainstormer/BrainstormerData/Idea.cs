using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class defines an idea

namespace BrainstormerData
{


    public class Idea
    {
        // what is the idea
        private string _description;

        

        // default constructor
        public Idea()
        {
            // if the position values are negative it
            // means that the idea is not displayed
            // in the mindmap
            MindMapX = -1;
            MindMapY = -1;
        }

        // -----  properties -----

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public override string ToString()
        {
            return Description;
        }

        public int MindMapX { get; private set; }
        public int MindMapY { get; private set; }
    }
}
