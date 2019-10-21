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

        public PathManager()
        {
            repository = new Repository();
            repository.ImportNodes();
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
                string next = "";
                double rndNext = rnd.NextDouble();
                double sum = 0;
                foreach(KeyValuePair<string,float> kvp in node.continuations)
                {
                    sum += kvp.Value;
                    if (rndNext < sum)
                    {
                        next = kvp.Key;
                        break;
                    }
                }
                NodeStory nextNode = repository.GetNodeByID(next);
                Traverse(nextNode);
            }
        }
    }
}
