using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class UserManager
    {
        public UserManager()
        {
            UserList = new List<User>();
        }

        // ----- default properties -----
        public List<User> UserList { get; set; }
    }
}
