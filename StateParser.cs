using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainWorldStateEdit
{
    public class StateParser
    {
        public readonly StateTag TagTree = new StateTag("top", -1, null);
        readonly Stack<StateTag> TagPath = new Stack<StateTag>();

        static readonly Dictionary<string, string> TagValueMatch = new Dictionary<string, string>()
        {
            { "ws", "WINSTATE" },
        };

        static readonly string[] IgnoreTagLevel = new string[] { "rg", "mpd" };

        public StateParser(string state, string topTagValue = null)
        {
            TagTree.Value = topTagValue;
            TagPath.Push(TagTree);
            int pos = 0;
            while (true)
            {
                StateTag t = StateTag.ReadNext(state, ref pos);
                if (t == null) break;
                InsertTag(t);
            }
        }
        public override string ToString() => TagTree.ToString();

        void InsertTag(StateTag tag)
        {
        Start:
            StateTag topTag = TagPath.Peek();
            if (tag.IsTheSameTag(topTag))
            {
                if (tag.Level > topTag.Level && !(IgnoreTagLevel.Contains(topTag.Tag) && topTag.Level == 1))
                {
                    AddSubTag(tag);
                    return;
                }
                TagPath.Pop();
                goto Start;
            }
            if (AnyTagInPath(tag.Tag)) { PopToTag(tag.Tag); goto Start; }
            AddSubTag(tag);
        }
        void AddSubTag(StateTag sub)
        {
        Start:
            //if (sub.Value == "Rock") Debugger.Break();
            StateTag tag = TagPath.Peek();
            if (tag.Sub is null) tag.Sub = new List<StateTag>();
            if ((tag.Level > sub.Level && sub.Tag.Length != 1) 
                || (tag.Sub.Count > 0 && tag.Sub[0].Level > sub.Level && tag.Sub[0].IsTheSameTag(sub)) 
                || tag.Value == "" && tag.Level == 0)
            {
                TagPath.Pop();
                goto Start;
            }
            tag.Sub.Add(sub);
            TagPath.Push(sub);
        }
        bool AnyTagInPath(string tag)
        {
            if (TagValueMatch.ContainsKey(tag)) 
            {
                StateTag topTag = TagPath.Peek();
                string v = TagValueMatch[tag];
                foreach (StateTag t in TagPath)
                    if (topTag.Value != t.Value && v == t.Value) return true;
            }
            else foreach (StateTag t in TagPath) if (t.Tag == tag) return true;
            return false;
        }
        void PopToTag(string tag)
        {
            bool predefinedTag = TagValueMatch.ContainsKey(tag);
            string tagValue = predefinedTag ? TagValueMatch[tag] : null;

            while (true)
            {
                StateTag t = TagPath.Peek();
                if (predefinedTag) { if (tagValue == t.Value) return; }
                else if (t.Tag == tag) return;
                TagPath.Pop();
            }
        }
    }
}
