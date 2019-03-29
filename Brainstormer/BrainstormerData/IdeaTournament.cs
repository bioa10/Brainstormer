﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class stores and manages data for idea tournaments
namespace BrainstormerData
{

    public class IdeaTournament
    {
        private Random rand = new Random();

        /// <summary>
        /// IdeaTournament constructor
        /// </summary>
        /// <param name="ideaManager">Accepts an IdeaManager that it will make a copy of</param>
        /// <param name="userManager">Accepts a UserManager to track which users have voted</param>
        /// <param name="breakTies">Accepts a boolean of whether to break ties with a coin flip</param>
        public IdeaTournament(IdeaManager ideaManager, UserManager userManager, bool breakTies)
        {
            IdeaManager = new IdeaManager(ideaManager);
            UserManager = userManager;
            BreakTies = breakTies;
            UserVotes = IdeaManager.Ideas.Count / 2;
            RoundNumber = 1;
            MinVotes = 1;
        }

        /// <summary>
        /// Starts the next round of the tournament
        /// </summary>
        public void StartRound()
        {
            ClearVotes();
            Shuffle();
            UserVotes = IdeaManager.Ideas.Count / 2;
            foreach (User user in UserManager.UserList)
            {
                user.VotesLeft = UserVotes;
            }
        }
        
        /// <summary>
        /// Adds a vote to an idea and removes a vote from the user
        /// </summary>
        /// <param name="idea">Accepts the Idea that was voted for</param>
        /// <param name="user"></param>
        public void Vote(Idea idea, User user)
        {
            user.VotesLeft--;
            idea.Votes++;
            CheckRoundEnd();
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
                IdeaManager.Ideas.Add(ideas[rand.Next(0, ideas.Count - 1)]);
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
        public int MinVotes { get; private set; }
        public int UserVotes { get; private set; }
        public bool BreakTies { get; private set; }

    }
}
