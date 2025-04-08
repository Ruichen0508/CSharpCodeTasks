using PT4;
using System.Text.RegularExpressions;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("XString39");
            string getstr = GetString();
            Match match = Regex.Match(getstr, @" (\w+) ");
            Put(match.Groups[1].ToString());
        }
    }
}