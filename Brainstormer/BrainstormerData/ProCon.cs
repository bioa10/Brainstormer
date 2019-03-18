using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class ProCon : Comment
    {
        public ProCon(string description, User creator, bool isPro) : base(description, creator)
        {
            IsPro = isPro;
        }
        public bool IsPro { get; private set; }
    }
}
