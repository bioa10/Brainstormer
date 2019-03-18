using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

// this class defines an idea

namespace BrainstormerData
{


    public class Idea
    {
        private int _votes;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Idea()
        {
            // if the position values are negative it
            // means that the idea is not displayed
            // in the mindmap
            MindMapX = -1;
            MindMapY = -1;
            _votes = 0;
        }
        public void SetMindMapPosition(int X, int Y)
        {

        }
        public void SetMindMapParent(int ParentID)
        {

        }
        public void LikeIdea(User user)
        {

        }

        // -----  properties -----
        public string Name { get; set; }
        public string Description { get; set; }
        public int MindMapX { get; private set; }
        public int MindMapY { get; private set; }
        public int MindMapParent { get; private set; }
        public List<Comment> Comments { get; private set; }
        public List<ProCon> ProCons { get; private set; }
        public List<User> Likes { get; private set; }
        public int Votes
        {
            get { return _votes; }
            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException(); }
                _votes = value;
            }
        }
        public User Creator { get; private set; }
        public Image image { get; private set; }


    }
}
