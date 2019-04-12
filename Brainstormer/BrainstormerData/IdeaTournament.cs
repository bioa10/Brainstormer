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
        private Random randomNumberGenerator = new Random();

        /// <summary>
        /// IdeaTournament constructor
        /// </summary>
        /// <param name="ideaManager">Accepts an IdeaManager that it will make a copy of</param>
        /// 
        /// <param name="userManager">Accepts a UserManager to track which users have voted</param>
        /// 
        /// <param name="breakTies">Accepts a boolean of whether to
        /// break ties with a coin flip</param>
        public IdeaTournament(IdeaManager ideaManager, UserManager userManager, bool breakTies)
        {
            IdeaManager = new IdeaManager(ideaManager);
            UserManager = userManager;
            BreakTies = breakTies;
            MaxVotesPerUser = IdeaManager.Ideas.Count / 2;
            RoundNumber = 1;
            //MinVotes = 1;
        }

        /// <summary>
        /// Starts the next round of the tournament
        /// </summary>
        public void StartRound()
        {
            ClearVotes();
            //Shuffle();
            MaxVotesPerUser = IdeaManager.Ideas.Count / 2;
            foreach (User user in UserManager.UserList)
            {
                user.VotesLeft = MaxVotesPerUser;
            }
        }
        
        /// <summary>
        /// Adds a vote to an idea and removes a vote from the user
        /// </summary>
        /// <param name="idea">Accepts the Idea that was voted for</param>
        /// 
        /// <param name="user"></param>
        public bool Vote(Idea idea, User user)
        {
            // if this user has not voted for this idea
            if(idea.Voters.Contains(user) == false)
            {
                user.VotesLeft--;
                idea.Votes++;
                idea.Voters.Add(user);

                //CheckRoundEnd();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the percentage of votes used versus unused from all users
        /// 1 = all votes used, 0.50 = half of the votes used, etc
        /// </summary>
        public double calculatePercentageVotesUsed()
        {
            // the total amount of votes given across all users
            double votesSupplied = UserManager.UserList.Count * MaxVotesPerUser;

            // the total number of votes used by all users
            double votesUsed = 0;

            for(int i = 0; i < UserManager.UserList.Count; i++)
            {
                votesUsed += MaxVotesPerUser - UserManager.UserList[i].VotesLeft;
            }

            return votesUsed / votesSupplied;
        }

        /// <summary>
        /// Shuffles the idea list to help remove bias
        /// </summary>
        private void Shuffle()
        {
            List<Idea> ideas = new List<Idea>(IdeaManager.Ideas);
            IdeaManager.Ideas.Clear();
            while (ideas.Count > 0)
            {
                IdeaManager.Ideas.Add(ideas[randomNumberGenerator.Next(0, ideas.Count - 1)]);
            }
        }

        /// <summary>
        /// Removes all ideas that don't have enough votes
        /// </summary>
        private void TrimIdeas()
        {
            List<Idea> trimmedList = IdeaManager.Ideas.Where(x => x.Votes > MinVotes).ToList();
            IdeaManager.Ideas.Clear();
            foreach (Idea idea in trimmedList)
            {
                IdeaManager.Ideas.Add(idea);
            }
        }

        /// <summary>
        /// Clears the votes from all ideas
        /// </summary>
        private void ClearVotes()
        {
            foreach (Idea idea in IdeaManager.Ideas)
            {
                idea.Votes = 0;
                idea.Voters.Clear();
            }
        }

        /// <summary>
        /// Checks if everyone has voted, and starts the next round if they have
        /// </summary>
        /// <returns></returns>
        private bool CheckRoundEnd()
        {
            foreach (User user in UserManager.UserList)
            {
                if (user.VotesLeft > 0)
                {
                    return false;
                }
            }
            RoundNumber++;
            MinVotes = RoundNumber / 2;
            TrimIdeas();
            StartRound();
            return true;
        }





        // ----- default properties -----
        public IdeaManager IdeaManager { get; private set; }
        public UserManager UserManager { get; private set; }

        // the current round that the tournament is on
        public int RoundNumber { get; private set; }
        // the minimum number of votes for an idea to survive
        public int MinVotes { get; private set; }
        // the amount of votes given to each user per round
        public int MaxVotesPerUser { get; private set; }
        public bool BreakTies { get; private set; }

    }
}