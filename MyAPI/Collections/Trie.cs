using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /// <summary>
    /// A case insesnsitive Trie
    /// </summary>
    public class Trie
    {
        private Dictionary<char, Trie> children = new Dictionary<char, Trie>();
        bool isEnd = false;


        /// <summary>
        /// Inserts a word into the trie
        /// </summary>
        public void Insert(string s)
        {
            this.Insert(s.ToLower(), 0);
        }

        /// <summary>
        /// Inserts the current character into the children dictionary if it doesn't exist, then calls on the child to recursively insert
        /// </summary>
        private void Insert(string s, int pos)
        {
            if(pos == s.Length)
            {
                isEnd = true;
                return;
            }
            if (!children.ContainsKey(s[pos]))
                children[s[pos]] = new Trie();
            children[s[pos]].Insert(s, ++pos);
        }

        /// <summary>
        /// Returns true if the trie contains the complete word given, regargless of upper/lower case
        /// </summary>
        public bool Contains(string s)
        {
            return this.Contains(s.ToLower(), 0);
        }

        /// <summary>
        /// Checks if the current character exists in children then recursively searches that child for the remaining characters
        /// </summary>
        private bool Contains(string s, int pos)
        {
            if (pos == s.Length)
                return isEnd;
            if (this.children.ContainsKey(s[pos]))
                return this.children[s[pos]].Contains(s, ++pos);
            return false;
        }

        /// <summary>
        /// Returns true if there is a word that starts with the given string, regardless of upper/lower case
        /// </summary>
        public bool StartsWith(string s)
        {
            return this.StartsWith(s.ToLower(), 0);
        }

        /// <summary>
        /// Checks if the children contain the current character from the string, if they do, recursively searches them, returning true if all characters are matched
        /// </summary>
        private bool StartsWith(string s, int pos)
        {
            if (pos == s.Length)
                return true;
            if (this.children.ContainsKey(s[pos]))
                return this.children[s[pos]].StartsWith(s, ++pos);
            return false;
        }

        /// <summary>
        /// Gets the first word recommendation for the given string, if suggetion exists, the original string is returned
        /// </summary>
        public string GetSuggestion(string s)
        {
            return GetSuggestion(s.ToLower(), 0);
        }

        /// <summary>
        /// Gets the first suggestion for the substring by searching children for the current character. If all input characters are used, the first child is selected until the end of a word is reached. 
        /// </summary>
        private string GetSuggestion(string s, int pos)
        {
            if (pos < s.Length)
            {
                if (this.children.ContainsKey(s[pos]))
                    return s[pos] + this.children[s[pos]].GetSuggestion(s, ++pos);
                return s.Substring(pos);
            }
            else
            {
                if (isEnd)
                    return "";
                char c = GetFirstChild();
                if (c == '\0')
                    return "";
                else
                    return c + this.children[c].GetSuggestion(s, ++pos);
            }



        }

        /// <summary>
        /// Gets the first child of a trie node, or \0 if none exists
        /// </summary>
        private char GetFirstChild()
        {
            foreach(char k in this.children.Keys)
            {
                return k;
            }
            return '\0';
        }
    }

}