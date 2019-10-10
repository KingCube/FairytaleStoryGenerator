using System;
using System.Collections.Generic;
using System.Text;

namespace FairytaleStoryGenerator
{
    class NodeStory
    {
        public string ID;
        public string text;
        public Dictionary<string, string> storyGlobals;

        public string[] continuations;
    }
}
