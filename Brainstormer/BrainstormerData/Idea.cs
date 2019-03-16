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
        private string _description;

        // where inside the mindmap is this idea located
        private mindMapPositionStruct _position;

        // default constructor
        public Idea()
        {
            // if the position values are negative it
            // means that the idea is not displayed
            // in the mindmap
            _position.x = -1;
            _position.y = -1;
        }

        // -----  properties -----

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public mindMapPositionStruct Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
