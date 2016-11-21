using System.Text.RegularExpressions;

namespace BileFountain.Utils {
    class StringUtil {

        public static string PostProcess(string value) {
            Regex regex1 = new Regex(" a ([aeio])");
            Regex regex2 = new Regex(" a u([^s])");
            Regex regex3 = new Regex("  +");
            value = regex1.Replace(value, " an $1");
            value = regex2.Replace(value, " an u$1");
            value = regex3.Replace(value, " ");
            if (value.Contains("*")) {
                value = value.Replace("*", "");
                if (!value.Contains("~"))
                    value = pluralize(value);
            }
            value = value.Replace("~", "");
            return UcFirstAll(value).Trim();
        }

       public static string UcFirst(string value) {
            return value[0].ToString().ToUpper() + value.Substring(1);
        }

        public static string UcFirstAll(string value) {
            value = UcFirst(value);
            bool isWaiting = false;
            string result = "";
            for (int index = 0; index < value.Length; index ++) {
                string curr = value[index] + "";
                if (isWaiting) {
                    if (Regex.IsMatch(curr, "[a-zA-Z]")) {
                        curr = curr.ToUpper();
                        isWaiting = false;
                    } else if (Regex.IsMatch(curr, "[0-9]")) {
                        isWaiting = false;
                    }
                } else if (curr == ".") {
                    isWaiting = true;
                }
                result += curr;
            }
            return result;
        }

        /*public static string MatchCase(string source, string text) {
            Regex allUpper = new Regex("^[A-Z]+$");
            if (allUpper.IsMatch(source))
                return text.ToUpper();
            Regex first = new Regex("^[A-Z]");
            if (first.IsMatch(source))
                return StringUtil.UcFirst(text);
            return text;
        }*/

        private static string pluralize(string value) {
            if (string.IsNullOrEmpty(value))
                return value;
            if (value.EndsWith("s")) //will need refining eventually but no counter-examples yet
                return value;
            if (value.EndsWith("y") && !value.EndsWith("ey"))
                return value.Substring(0, value.Length - 1) + "ies";
            return value + "s";
        }
    }
}
