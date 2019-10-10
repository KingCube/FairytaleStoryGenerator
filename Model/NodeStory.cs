using System;
using System.Collections.Generic;
using System.Text;

namespace FairytaleStoryGenerator
{
    public class NodeStory
    {
        public string ID;
        public string text;
        public Dictionary<string, string> storyGlobals;

        public List<string> continuations;
    }
}
