using System;
using System.Collections.Generic;
using System.Text;

namespace FairytaleStoryGenerator
{
    public class PathManager
    {
        public Repository repository;
        Random rnd = new Random();

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
            Console.Write(node.text);

            if (node.continuations.Count == 0)
                return;
            else
            {
                int rndID = rnd.Next(node.continuations.Count);
                NodeStory nextNode = repository.GetNodeByID(node.continuations[rndID]);
                Traverse(nextNode);
            }
        }
    }
}
