using BileFountain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BileFountain {
    public class Profanerizer {
        private Dictionary<string, string> fragments;
        private Dictionary<string, string> templates;
        private Dictionary<string, List<string>> words;
        private static Random random = new Random();

        public Profanerizer() {
            templates = FileUtil.LoadTemplates();
            fragments = FileUtil.LoadFragments();
            words = FileUtil.LoadWords();
        }

        public string Profane() {
            List<string> keys = templates.Keys.ToList();
            int index = random.Next(keys.Count);
            return Profane(keys[index]);
        }

        public string Profane(string name) {
            string result = null;
            string key = name.ToLower();
            if (templates.ContainsKey(key)) {
                result = templates[key];
            }
            else if (fragments.ContainsKey(key)) {
                result = fragments[key];
            } else {
                return "";
            }
            while (true) {
                string token = getNextToken(result);
                if (string.IsNullOrEmpty(token))
                    return StringUtil.PostProcess(result);
                Regex regex = new Regex(Regex.Escape(token));
                result = regex.Replace(result, getWord(token), 1);
            }
        }

        private string getWord(string token) {
            bool isFragment = token.StartsWith("<");
            bool isText = token.StartsWith("(");
            string listName = new Regex("[%<>()]").Replace(token, "");
            if (listName.Contains("|")) {
                if (isText)
                    return getTextChoice(listName.Split('|'));
                if (isFragment)
                    return getFragmentChoice(listName.Split('|'));
                else
                    return getWordChoice(listName.Split('|'));
            }
            bool optional = listName.Contains("?");
            if (optional) {
                if (random.Next(2) == 1)
                    return "";
                listName = listName.Replace("?", "");
            }
            if (isFragment)
                return StringUtil.MatchCase(listName, Profane(listName));
            listName = listName.Replace("*", "");
            string key = listName.ToLower();
            if (!words.ContainsKey(key)) {
                return null;
            }
            int index = random.Next(words[key].Count);
            string result = words[key][index];
            return StringUtil.MatchCase(listName, result);
        }

        private string getTextChoice(string[] values) {
            int index = random.Next(values.Length);
            return values[index];
        }

        private string getWordChoice(string[] values) {
            int index = random.Next(values.Length);
            return getWord("%" + values[index] + "%");
        }

        private string getFragmentChoice(string[] values) {
            int index = random.Next(values.Length);
            return getWord("<" + values[index] + ">");
        }

        private string getNextToken(string pattern) {
            Regex regex = new Regex("([%<(][^>%)]+[%>)])");
            Match result = regex.Match(pattern);
            if (result.Groups.Count > 0)
                return result.Groups[0].Value;
            else
                return "";
        }

        
    }
}
