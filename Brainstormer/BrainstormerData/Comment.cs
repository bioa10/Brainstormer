using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class Comment
    {
        public Comment(string description, User creator)
        {
            Description = description;
            Creator = creator;
        }
        public string Description { get; private set; }
        public User Creator { get; private set; }
    }
}
