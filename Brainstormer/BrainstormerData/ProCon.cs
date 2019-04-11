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
        /// <param name="description">Accepts a string as the message.
        /// Can not be empty or null.</param>
        /// 
        /// <param name="creator">Accepts a User as the creator. Must not be null.</param>
        /// 
        /// <param name="isPro">Accepts a boolean whether the object is a pro or con.
        /// True for pro, false for con.</param>
        public ProCon(string description, User creator, bool isPro) : base(description, creator)
        {
            IsPro = isPro;
        }

        // ----- default properties -----
        public bool IsPro { get; private set; }
    }
}