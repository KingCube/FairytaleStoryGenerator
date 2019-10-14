using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace FairytaleStoryGenerator
{
    public class Repository
    {
        string fileDir = @"..\..\..\Data\";
        static string fileNodes = @"Nodes.csv";

        Dictionary<string,NodeStory> Nodes = new Dictionary<string, NodeStory>();
 
        public NodeStory GetStartingNode()
        {
            return Nodes["A0"];
        }

        public NodeStory GetNodeByID(string ID)
        {
            return Nodes[ID];
        }

        public void ImportNodes()
        {
            StreamReader sr = new StreamReader(fileDir + fileNodes);

            string dataLine = sr.ReadLine(); //initial gets headers and throw them
            string[] readData;
            string[] storyGlobals;
            string[] storyGlobal;
            string[] continuationPairs;
            string[] continuationPair;

            while ((dataLine = sr.ReadLine()) != null)
            {
                if (dataLine == "")
                    continue;

                readData = dataLine.Split(";");
                NodeStory Node = new NodeStory() { 
                                        ID = readData[0], 
                                        text = readData[1], 
                                        storyGlobals = new Dictionary<string, string>(), 
                                        continuations = new Dictionary<string, float>()};

                //keep going with more complex ones;
                if(readData[2] != "")
                {
                    storyGlobals = readData[2].Split(",");
                    foreach(string s in storyGlobals)
                    {
                        storyGlobal = s.Split(":");
                        Node.storyGlobals[storyGlobal[0]] = storyGlobal[1];
                    }
                }
                if(readData[3] != "")
                {
                    continuationPairs = readData[3].Split(",");

                    foreach (string s in continuationPairs)
                    {
                        continuationPair = s.Split(":");
                        Node.continuations[continuationPair[0]] = float.Parse(continuationPair[1], CultureInfo.InvariantCulture);
                    }
                }

                Nodes[Node.ID] = Node;
            }

        }

    }
}
