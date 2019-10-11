using System;
using System.Collections.Generic;
using System.Text;

namespace FairytaleStoryGenerator
{
    public class PathManager
    {
        public Repository repository;
        Random rnd = new Random();
        Dictionary<string, string> Globals = new Dictionary<string, string>();
        List<string> Globalslabels = new List<string>() { "KDFAMOUS","KDTHREAT","MCNOUN", "MCADJ","MCADJVERB" };

        public PathManager()
        {
            repository = new Repository();
            repository.ImportNodes();
            foreach (string s in Globalslabels)
                Globals[s] = "NOT SET";
        }

        public void Start()
        {
            Traverse(repository.GetStartingNode());
        }

        void Traverse(NodeStory node)
        {
            //Set new globals
            foreach (KeyValuePair<string, string> kvp in node.storyGlobals)
                Globals[kvp.Key] = kvp.Value;
                
            //Time to handle text;
            string toWrite = node.text.Replace(@"\N","\n"); //for some reason imported escape characters are not recognised, so we upCase and work around.

            foreach (KeyValuePair<string, string> kvp in Globals)
                toWrite = toWrite.Replace(kvp.Key, kvp.Value); //not very memoryfriendly I know, not in-place

            Console.Write(toWrite);

            //check continuations
            if (node.continuations.Count == 0)
            {
                Console.WriteLine("\n\n\n");
                return;
            }
            else
            {
                int rndID = rnd.Next(node.continuations.Count);
                NodeStory nextNode = repository.GetNodeByID(node.continuations[rndID]);
                Traverse(nextNode);
            }
        }
    }
}
