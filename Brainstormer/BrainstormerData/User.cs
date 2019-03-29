using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class User
    {
        private int _ContributionScore;

        /// <summary>
        /// User constructor
        /// </summary>
        /// <param name="userName">A string representing the name of the user</param>
        /// <param name="userPassword">A string string representing the password of the user (UNSAFE)</param>
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            ContributionScore = 0;
            VotesLeft = 0;
            IsAdmin = false;
            IsHost = false;
        }

        /// <summary>
        /// Load constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public User(string userName, string password, int contributionScore, int votesLeft, bool isAdmin, bool isHost)
        {
            UserName = userName;
            Password = password;
            ContributionScore = contributionScore;
            VotesLeft = votesLeft;
            IsAdmin = isAdmin;
            IsHost = isHost;
        }

        /// <summary>
        /// Allows the user to change their username
        /// </summary>
        /// <param name="userName">A string representing the new username of the user</param>
        /// <param name="user">The user making the request, must be the user that is changing their username</param>
        /// <returns>Returns false if the user is not trying to edit their own username, true if they are</returns>
        public bool SetUsername(string userName, User user)
        {
            if (user == null) throw new ArgumentNullException("user can not be null.");
            if (user.Equals(this)) UserName = userName;
            else return false;
            return true;
        }

        /// <summary>
        /// Allows the user to change their password
        /// </summary>
        /// <param name="password">A string representing the new password of the user (UNSAFE)</param>
        /// <param name="user">The user making the request, must be the user that is changing their username</param>
        /// <returns>Returns false if the user is not trying to edit their own password, true if they are</returns>
        public bool SetPassword(string password, User user)
        {
            if (user == null) throw new ArgumentNullException("user can not be null.");
            if (user.Equals(this)) Password = password;
            else return false;
            return true;
        }

        /// <summary>
        /// Makes this user an admin
        /// </summary>
        /// <param name="user">The user making the request, must be the host</param>
        /// <returns>Returns false if the user is not the host, true if they are</returns>
        public bool MakeAdmin(User user)
        {
            if (user == null) throw new ArgumentNullException("user can not be null.");
            if (user.IsHost) IsAdmin = true;
            else return false;
            return true;
        }

        /// <summary>
        /// Makes this user the host
        /// </summary>
        /// <param name="user">The user making the request, must be the host</param>
        /// <returns>Returns false if the user is not the host, true if they are</returns>
        public bool MakeHost(User user)
        {
            if (user == null) throw new ArgumentNullException("user can not be null.");
            if (user.IsHost) IsHost = true;
            else return false;
            return true;
        }

        // ----- default properties -----
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int VotesLeft { get; set; }
        public bool IsAdmin { get; private set; }
        public bool IsHost { get; private set; }

        // ----- custom properties -----

        public int ContributionScore
        {
            get
            {
                return _ContributionScore;
            }
            set
            {
                if (value >= 0) _ContributionScore = value;
                else throw new ArgumentOutOfRangeException("Contribution score can not be negative.");
            }
        }
    }
}
