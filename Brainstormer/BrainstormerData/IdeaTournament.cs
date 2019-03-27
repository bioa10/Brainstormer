using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class stores and manages data for idea tournaments
namespace BrainstormerData
{

    public class IdeaTournament
    {
        Random rand = new Random();

        public IdeaTournament(IdeaManager ideaManager, UserManager userManager, bool breakTies)
        {
            IdeaManager = new IdeaManager(ideaManager);
            UserManager = userManager;
            BreakTies = breakTies;
            UserVotes = IdeaManager.Ideas.Count / 2;
            RoundNumber = 1;
            MinVotes = 1;
        }

        public void StartRound()
        {

        }
        
        public void Vote()
        {
        }

        private void Shuffle()
        {
            List<Idea> ideas = new List<Idea>(IdeaManager.Ideas);
            IdeaManager.Ideas.Clear();
            while (ideas.Count > 0)
            {
                IdeaManager.Ideas.Add(ideas[rand.Next(0, ideas.Count - 1)]);
            }
        }

        private void TrimIdeas()
        {
            foreach (Idea idea in IdeaManager.Ideas)
            {
                if (idea.Votes < MinVotes)
                {
                    IdeaManager.Ideas.Remove(idea);
                }
            }
        }

        private void ClearVotes()
        {
            foreach (Idea idea in IdeaManager.Ideas)
            {
                idea.Votes = 0;
            }
        }



        // ----- default properties -----
        public IdeaManager IdeaManager { get; private set; }
        public UserManager UserManager { get; private set; }

        // the current round that the tournament is on
        public int RoundNumber { get; private set; }
        public int MinVotes { get; private set; }
        public int UserVotes { get; private set; }
        public bool BreakTies { get; private set; }

    }
}
