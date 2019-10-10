using System;
using System.Collections.Generic;
using System.Text;

namespace FairytaleStoryGenerator
{
    public class Repository
    {
        Dictionary<string,NodeStory> Nodes = new Dictionary<string, NodeStory>();
        
        public void ImportNodes()
        {
            Nodes.Add("A0",new NodeStory() { ID = "A0", text = "Once upon a time and then the story was dead",continuations = new string[0] });
        }

        public NodeStory GetStartingNode()
        {
            return Nodes["A0"];
        }

        public NodeStory GetNodeByID(string ID)
        {
            return Nodes[ID];
        }
        

    }
}
