using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class ProCon : Comment
    {
        /// <summary>
        /// ProCon constructor
        /// </summary>
        /// <param name="name">Accepts a string as a name.</param>
        /// <param name="description">Accepts a string as the message.
        /// Can not be empty or null.</param>
        /// 
        /// <param name="creator">Accepts a User as the creator. Must not be null.</param>
        /// 
        /// <param name="isPro">Accepts a boolean whether the object is a pro or con.
        /// True for pro, false for con.</param>
        public ProCon(string name, string description, User creator, bool isPro) : base(description, creator)
        {
            if (name.Trim() == "" || name == null)
            {
                throw new ArgumentNullException("Name can not be empty.");
            }
            IsPro = isPro;
            Name = name;
        }

        public override string ToString()
        {
            return (IsPro ? "Pro: " : "Con: ") + Description;
        }

        // ----- default properties -----
        public bool IsPro { get; private set; }
        public string Name { get; set; }
    }
}