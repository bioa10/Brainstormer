using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class UserManager
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserManager()
        {
            UserList = new List<User>();
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="userManager">UserManager to copy</param>
        public UserManager(UserManager userManager)
        {
            UserList = userManager.UserList;
        }

        // ----- default properties -----
        public List<User> UserList { get; private set; }
    }
}
