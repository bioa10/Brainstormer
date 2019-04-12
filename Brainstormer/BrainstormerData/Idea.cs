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
        // Variables backing properties
        private int _votes;
        private int _mindMapParent;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Idea(string name, string description, User creator)
        {
            if (name == null || name == "")
            {
                throw new ArgumentNullException("Name can not be empty or null.");
            }
            if (creator == null)
            {
                throw new ArgumentNullException("creator can not be null.");
            }

            Name = name;
            Description = description;
            
            // a newly created idea has no parent in the mindmap
            IsMindMapChild = false;

            // a newly created idea is not in the mindmap
            IsInMindmap = false;

            // a newly created idea has no votes
            _votes = 0;

            Creator = creator;
            Comments = new List<Comment>();
            ProCons = new List<ProCon>();
            Likes = new List<User>();
            Image = null;
            Voters = new List<User>();
        }

        /// <summary>
        /// Sets the name of the idea if the user has permission.
        /// </summary>
        /// <param name="name">Accepts a string to set the name to. Can not be empty or null.</param>
        /// 
        /// <param name="user">The user that is requesting to set the name.</param>
        /// 
        /// <returns>Returns whether the user has permission to set the image.
        /// Returns true when successful and false when unsuccessful.</returns>
        public bool SetName(string name,User user)
        {
            if (name == null || name == "")
            {
                throw new ArgumentNullException("Name can not be empty or null.");
            }
            if (user == null)
            {
                throw new ArgumentNullException("user can not be null.");
            }
            if (user.Equals(Creator))
            {
                Name = name;
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets the description of the idea if the user has permission.
        /// </summary>
        /// <param name="description">Accepts a string to set the description to.</param>
        /// 
        /// <param name="user">The user that is requesting to set the name.</param>
        /// 
        /// <returns>Returns whether the user has permission to set the image.
        /// Returns true when successful and false when unsuccessful.</returns>
        public bool SetDescription(string description, User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user can not be null.");
            }
            if (user.Equals(Creator))
            {
                Description = description;
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets the X and Y position of the idea in the MindMap.
        /// </summary>
        /// <param name="X">An int that represents the X position. Must be greater than 0.</param>
        /// 
        /// <param name="Y">An int that represents the Y position. Must be greater than 0.</param>
        public void SetMindMapPosition(int x, int y)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException("X must be greater than or equal to 0.");
            }
            if (y < 0)
            {
                throw new ArgumentOutOfRangeException("Y must be greater than or equal to 0.");
            }

            MindMapX = x;
            MindMapY = y;
        }

        /// <summary>
        /// Adds a user to the list of users that like an idea.
        /// </summary>
        /// <param name="user">The user to add to the like list.
        /// If already in the list nothing happens.</param>
        public void LikeIdea(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user can not be null.");
            }
            if (!Likes.Contains(user))
            {
                Likes.Add(user);
            }

        }

        /// <summary>
        /// Removes a user from the list of users that like an idea.
        /// </summary>
        /// <param name="user">The user to remove from the like list.
        /// If not in the list nothing happens.</param>
        public void UnlikeIdea(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user can not be null.");
            }
            if (Likes.Contains(user))
            {
                Likes.Remove(user);
            }
        }

        /// <summary>
        /// Sets the image of the idea if the user has permission.
        /// </summary>
        /// <param name="image">The image to set on the idea. Pass null to remove the image.</param>
        /// 
        /// <param name="user">The user that is requesting to set the image.</param>
        /// 
        /// <returns>Returns whether the user has permission to set the image.
        /// Returns true when successful and false when unsuccessful.</returns>
        public bool SetImage(Image image,User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user can not be null.");
            }
            if (user.Equals(Creator))
            {
                Image = image;
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets the ToString function.
        /// </summary>
        /// <returns>Returns the name of the Idea.</returns>
        public override string ToString()
        {
            return Name;
        }

        // ----- default properties -----

            // the name/title of the idea
        public string Name { get; private set; }

        // describes what the idea is
        public string Description { get; private set; }

        // does this idea have a parent in the mindmap?
        public bool IsMindMapChild { get; private set; }

        // is this idea displayed in the mindmap?
        public bool IsInMindmap { get; private set; }

        // the x and y coordinates of the idea's position
        // within the mind map
        public int MindMapX { get; private set; }
        public int MindMapY { get; private set; }

        // the comments about this idea left by users
        public List<Comment> Comments { get; private set; }

        // the pros and cons about this idea left by users
        public List<ProCon> ProCons { get; private set; }

        // a list of users who added a like to this idea
        public List<User> Likes { get; private set; }

        // a list of users who voted for this idea
        public List<User> Voters { get; private set; }

        // the user who created this idea
        public User Creator { get; private set; }

        // the image that represents this idea
        public Image Image { get; private set; }

        // ----- custom properties -----

        // the ParentID of this idea's parent within the mindmap
        public int MindMapParent
        {
            get { return _mindMapParent; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ParentID must be greater than or equal to 0.");
                }
                _mindMapParent = value;
            }
        }

        public int Votes
        {
            get { return _votes; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Votes must be greater than or equal to 0.");
                }
                _votes = value;
            }
        }
    }
}