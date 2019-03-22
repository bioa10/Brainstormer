using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class FileReader
    {
        public FileReader()
        {
            
        }

        // warning: this does not append, it deletes previous content
        public void GetData(ref IdeaManager anIdeaManager)
        {
            anIdeaManager.Ideas.Clear();

            string[] fileData = ReadFile("Ideas.txt");

            List<User> aListOfUsers = new List<User>();
            GetData(ref aListOfUsers);

            for (int i = 0; i < fileData.Length; i++)
            {
                string ideaName;
                string ideaDescription;
                string ownerUsername;
               
                // skips the first lines to bypass the file header info
                // more lines may be added to the file header by raising this number
                if(i > 5)
                {
                    ideaName = fileData[i];
                    i++;
                    ideaDescription = fileData[i];
                    i++;
                    ownerUsername = fileData[i];

                    bool foundUser = false;
                    int userIterator;
                    for (userIterator = 0;  userIterator < aListOfUsers.Count; userIterator++)
                    {
                        if (aListOfUsers[userIterator].UserName == ownerUsername)
                        {
                            foundUser = true;
                            break;
                        }
                    }

                    if (foundUser == false)
                    {
                        throw new Exception("The owner of an idea could not be found in users");
                    }

                    User aUser = aListOfUsers[userIterator];

                    Idea anIdea = new Idea(ideaName, ideaDescription, aUser);

                    anIdeaManager.Ideas.Add(anIdea);
                }
            }
        }
     
        // warning: this does not append, it deletes previous content
        public void GetData(ref List<User> aListOfUsers)
        {
            aListOfUsers.Clear();

            string[] fileData = ReadFile("Users.txt");
           
            for (int i = 0; i < fileData.Length; i++)
            {
                // skips the first lines to bypass the file header info
                // more lines may be added to the file header by raising this number
                if (i > 8)
                {
                    string userName = fileData[i];
                    i++;
                    string userPassword = fileData[i];
                    i++;

                    int contributionScore;
                    if (!Int32.TryParse(fileData[i], out contributionScore))
                    {
                        throw new FormatException("Failed to read contribution score at line: " + i);
                    }
                    i++;

                    int votesLeft;
                    if (!Int32.TryParse(fileData[i], out votesLeft))
                    {
                        throw new FormatException("Failed to read votes at line: " + i);
                    }
                    i++;

                    bool isAdmin;
                    if (!Boolean.TryParse(fileData[i], out isAdmin))
                    {
                        throw new FormatException("Failed to read admin boolean at line: " + i);
                    }
                    i++;

                    bool isHost;
                    if (!Boolean.TryParse(fileData[i], out isHost))
                    {
                        throw new FormatException("Failed to read host boolean at line: " + i);
                    }

                    User aUser = new User(userName, userPassword, contributionScore, votesLeft, isAdmin, isHost);
                    aListOfUsers.Add(aUser);
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
