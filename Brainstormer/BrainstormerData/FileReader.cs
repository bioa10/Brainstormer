using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormerData
{
    public class FileReader
    {
        public FileReader(string newFileName)
        {
            FileName = newFileName;

            if(FileName == "Ideas.txt")
            {
                // System.IO.File.Exists
                // FileData = System.IO.File.ReadAllLines(@"Ideas.txt");
                FileData = System.IO.File.ReadAllLines(FileName);
                foreach (string line in FileData)
                {
                    // testing in console
                    Console.WriteLine(line);
                }
            }
            else
            {
                // an unknown file name was received
                throw new ArgumentException("An invalid file name was passed to the file reader");
            }
        }

        // warning: this does not append, it deletes previous content
        public void GetData(ref IdeaManager anIdeaManager)
        {
            anIdeaManager.Ideas.Clear();

            for(int i = 0; i < FileData.Length; i++)
            {
                string ideaName;
                string ideaDescription;
                User aUser = new User();

                // skips the first lines to bypass by the file header info
                // more lines may be added to the file header by raising this number
                if(i > 4)
                {
                    ideaName = FileData[i];
                    i++;
                    ideaDescription = FileData[i];

                    // TODO: populate information to the user object here
                    // go find the user that created this idea, maybe use a username stored in the ideas file
                    Idea anIdea = new Idea(ideaName, ideaDescription, aUser);

                    anIdeaManager.Ideas.Add(anIdea);
                }
            }
        }

        // just a test
        //public IdeaTournament GetData(ref IdeaTournament anIdeaTournament)
       // {

       // }
      

        // ----- default properties -----
        private string[] FileData { get; set; }
        private string FileName { get; set; }
    }
}
