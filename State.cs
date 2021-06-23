using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainWorldStateEdit
{
    public class State
    {
    }
    public class StateTag : IEnumerable<StateTag>
    {
        public string Tag;
        public int Level;
        public string Value;
        public List<StateTag> Sub;
        public TreeNode Node;

        public StateTag(string tag, int level, string value) { Tag = tag; Level = level; Value = value; }

        public static StateTag ReadNext(string str, ref int pos) 
        {
            if (pos >= str.Length) return null;
            int end = str.IndexOf('<', pos + 1);
            if (end == -1) 
            {
                string s = str.Substring(pos);
                pos += s.Length;
                if (s.Length == 0) return null;
                return Parse(s);
            }
            int start = pos;
            pos = end;
            return Parse(str.Substring(start, end - start));

        }
        public static StateTag Parse(string str) 
        {
            if (str.Length == 0) return null;
            char firstChar = str[0];
            if (firstChar == '<')
            {
                int fullTagEnd = str.IndexOf('>');
                if (fullTagEnd == -1) throw new FormatException("tag format must be [<tagNameA>]TagString");
                string fullTag = str.Substring(1, fullTagEnd - 1);
                string name = str.Substring(fullTagEnd + 1);
                string tag = fullTag.Substring(0, fullTag.Length - 1);
                int level = fullTag[tag.Length] - 'A';
                return new StateTag(tag, level, name);
            }
            else return new StateTag(null, 0, str);
        }
        public override string ToString()
        {
            if (Level == -1) return (Sub is null ? "" : string.Join("", Sub));
            return ((Tag is null) ? "" : $"<{Tag}{(char)('A' + Level)}>") + Value + (Sub is null?"":string.Join("",Sub));
        }
        public bool IsTheSameTag(StateTag t) 
        {
            if (Tag is null || t.Tag is null) return true;
            return Tag == t.Tag;
        }

        public IEnumerator<StateTag> GetEnumerator()
        {
            if (Sub is null) return ((IEnumerable<StateTag>)new StateTag[0]).GetEnumerator();
            return ((IEnumerable<StateTag>)Sub).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (Sub is null) return ((IEnumerable)new StateTag[0]).GetEnumerator();
            return ((IEnumerable)Sub).GetEnumerator();
        }

        public StateTag this[int i] 
        {
            get 
            {
                if (Sub is null) return null;
                return Sub[i];
            }
            set 
            {
                if (Sub is null) return;
                Sub[i] = value;
            }
        }
        public StateTag this[string v]
        {
            get
            {
                if (Sub is null) return null;
                StateTag[] tags = Sub.Where((t) => t.Value == v).ToArray();
                if (tags.Length == 0) return null;
                if (tags.Length == 1) return tags[0];
                return new StateTag("tagList", -2, null)
                {
                    Sub = new List<StateTag>(tags)
                };
            }
        }

        public TreeNode CreateTreeNode() 
        {
            string nodeValue = TagPreview.TagString(this);
            if (IsArrayTag()) 
            {
                bool hideFirst = TagPreview.PreviewFirstTag.Contains(Value);
                List<TreeNode> Subs = new List<TreeNode>();
                foreach (StateTag t in Sub)
                {
                    TreeNode node = t.CreateTreeNode();
                    if (node is null || t == Sub[0] && hideFirst) continue;
                    Subs.Add(node);
                }
                Node = new TreeNode(nodeValue, Subs.ToArray());
                Node.Tag = this;
                return Node;
            }
            if (IsValueTag()) 
            {
                Node = new TreeNode(nodeValue);
                Node.Tag = this;
                return Node;
            }
            if (string.IsNullOrEmpty(Value)) return null;
            
            Node = new TreeNode(nodeValue);
            Node.Tag = this;
            return Node;

        }


        public bool IsArrayTag()
        {
            if (Sub != null && Sub.Count > 0 && !IsValueTag()) return true;
            return false;
        }
        public bool IsValueTag() 
        {
            if (Sub != null && Sub.Count == 1 && Sub[0].Sub == null) return true;
            return false;
        }
        public bool IsFlagTag()
        {
            if (Sub is null) return true;
            return false;
        }
    }
}
