using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class FileReader
    {
        // default constructor
        public FileReader()
        {
            
        }

        // warning: this does not append, it deletes previous content
        // overloaded function that reads Idea data from text into objects
        public void GetData(ref IdeaManager anIdeaManager)
        {
            // deletes the old contents of the referenced IdeaManager
            anIdeaManager.Ideas.Clear();

            // reads the associated file from the working directory to an array of strings
            string[] fileData = ReadFile("Ideas.txt");

            // creates and reads in a local UserManager for adding owner data to the ideas
            UserManager aUserManager = new UserManager();
            GetData(ref aUserManager);

            // for the length of the string array
            for (int i = 0; i < fileData.Length; i++)
            {
                // these variables store data to later be compiled into an Idea object
                string ideaName;
                string ideaDescription;
                string ownerUsername;
               
                // skips the first lines to bypass the file header info
                // more lines may be added to the file header by raising this number
                if(i > 5)
                {
                    // reads lines from the file into the storage variables
                    ideaName = fileData[i];
                    i++;
                    ideaDescription = fileData[i];
                    i++;
                    ownerUsername = fileData[i];

                    // searches the UserManager for a user with the matching name of the idea owner
                    // might be better to eventually use a unique ID or something instead
                    bool foundUser = false;
                    int userIterator;
                    for (userIterator = 0;  userIterator < aUserManager.UserList.Count; userIterator++)
                    {
                        if (aUserManager.UserList[userIterator].UserName == ownerUsername)
                        {
                            foundUser = true;
                            break;
                        }
                    }

                    // if an idea has an owner that doesn't exist, this is a problem
                    if (foundUser == false)
                    {
                        throw new Exception("The owner of an idea could not be found in users");
                    }

                    // compiles all of the read data into a single Idea object
                    Idea anIdea = new Idea(ideaName, ideaDescription, aUserManager.UserList[userIterator]);

                    // adds the Idea object to the IdeaManager
                    anIdeaManager.Ideas.Add(anIdea);
                }
            }
        }
     
        // warning: this does not append, it deletes previous content
        // overloaded function that reads User data from text into objects
        public void GetData(ref UserManager aUserManager)
        {
            // deletes the old contents of the referenced UserManager
            aUserManager.UserList.Clear();

            // reads the associated file from the working directory to an array of strings
            string[] fileData = ReadFile("Users.txt");
           
            for (int i = 0; i < fileData.Length; i++)
            {
                // skips the first lines to bypass the file header info
                // more lines may be added to the file header by raising this number
                if (i > 8)
                {
                    // these variables store data to later be compiled into an Idea object
                    string userName;
                    string password;

                    int contributionScore;
                    int votesLeft;

                    bool isAdmin;
                    bool isHost;

                    // reads lines from the file into the storage variables
                    userName = fileData[i];
                    i++;
                    password = fileData[i];
                    i++;

                    if (!Int32.TryParse(fileData[i], out contributionScore))
                    {
                        throw new FormatException("Failed to read contribution score at line: " + i);
                    }
                    i++;

                    if (!Int32.TryParse(fileData[i], out votesLeft))
                    {
                        throw new FormatException("Failed to read votes at line: " + i);
                    }
                    i++;

                    if (!Boolean.TryParse(fileData[i], out isAdmin))
                    {
                        throw new FormatException("Failed to read admin boolean at line: " + i);
                    }
                    i++;

                    if (!Boolean.TryParse(fileData[i], out isHost))
                    {
                        throw new FormatException("Failed to read host boolean at line: " + i);
                    }

                    // compiles all of the read data into a single User object
                    User aUser = new User(userName, password, contributionScore, votesLeft, isAdmin, isHost);

                    // adds the User object to the UserManager
                    aUserManager.UserList.Add(aUser);
                }
            }
        }

        public string[] ReadFile(string fileName)
        {
            if (fileName != "Ideas.txt" && fileName != "Users.txt")
            {
                // an unknown file name was received
                throw new ArgumentException("An invalid file name was passed to the file reader");
            }

            // System.IO.File.Exists
            // FileData = System.IO.File.ReadAllLines(@"Ideas.txt");
            string[] fileData = System.IO.File.ReadAllLines(fileName);

            // view data that was read in console for testing purposes
            foreach (string line in fileData)
            {
                Console.WriteLine(line);
            }

            return fileData;
        }

        // ----- default properties -----
       
    }
}
