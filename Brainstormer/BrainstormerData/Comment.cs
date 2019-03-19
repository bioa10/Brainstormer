using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class Comment
    {
        /// <summary>
        /// Comment constructor
        /// </summary>
        /// <param name="description">Accepts a string as the message. Can not be empty or null.</param>
        /// <param name="creator">Accepts a User as the creator. Must not be null.</param>
        public Comment(string description, User creator)
        {
            if (description == null || description == "") throw new ArgumentNullException("Description can not be empty or null.");
            if (creator == null) throw new ArgumentNullException("creator can not be null.");
            Description = description;
            Creator = creator;
        }

        /// <summary>
        /// Sets the description of the comment if the user has permission.
        /// </summary>
        /// <param name="description">Accepts a string to set the description to.</param>
        /// <param name="user">The user that is requesting to set the name.</param>
        /// <returns>Returns whether the user has permission to set the image. Returns true when successful and false when unsuccessful.</returns>
        public bool SetDescription(string description, User user)
        {
            if (user == null) throw new ArgumentNullException("user can not be null.");
            if (user.Equals(Creator)) Description = description;
            else return false;
            return true;
        }

        // ----- default properties -----
        public string Description { get; private set; }
        public User Creator { get; private set; }
    }
}
