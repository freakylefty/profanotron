using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace BileFountain.Utils {

    class FileUtil {
        private static List<string> readFile(string filename) {
            List<string> result = new List<string>();
            Assembly bile = Assembly.LoadFrom("BileFountain.dll");
            using (Stream stream = bile.GetManifestResourceStream("BileFountain.Data." + filename + ".txt")) {
                if (stream == null)
                    return result;
                string data = "";
                using (var sr = new StreamReader(stream)) {
                    data = sr.ReadToEnd();
                }
                string[] lines = data.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
                Regex comment = new Regex("#.*$");
                for (int index = 0; index < lines.Length; index++) {
                    string line = lines[index];
                    line = comment.Replace(line, "").Trim();
                    if (line.Equals(string.Empty))
                        continue;
                    result.Add(line);
                }
            }
            return result;
        }

        public static Dictionary<string, string> LoadTemplates() {
            Dictionary<string, string> templates = new Dictionary<string, string>();
            List<string> lines = readFile(@"Templates");

            Regex regex = new Regex("^[^!]([^:]+):(.+)$");
            foreach (string line in lines) {
                Match match = regex.Match(line);
                if (match.Groups.Count == 3) {
                    templates[match.Groups[1].Value] = match.Groups[2].Value;
                }
            }
            return templates;
        }

        public static Dictionary<string, string> LoadFragments() {
            Dictionary<string, string> templates = new Dictionary<string, string>();
            List<string> lines = readFile(@"Templates");

            Regex regex = new Regex("^!([^:]+):(.+)$");
            foreach (string line in lines) {
                Match match = regex.Match(line);
                if (match.Groups.Count == 3) {
                    templates[match.Groups[1].Value] = match.Groups[2].Value;
                }
            }
            return templates;
        }

        public static Dictionary<string, List<string>> LoadWords() {
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
            List<string> lines = readFile(@"Words");
            string group = null;

            for (int index = 0; index < lines.Count; index++) {
                string line = lines[index].Trim();
                if (string.IsNullOrEmpty(line) || line.Equals(":"))
                    continue;
                if (line.EndsWith(":")) {
                    group = line.Substring(0, line.Length - 1);
                    words[group] = new List<string>();
                    continue;
                }
                if (string.IsNullOrEmpty(group))
                    continue;
                words[group].Add(line);
            }
            return words;
        }
    }
}
