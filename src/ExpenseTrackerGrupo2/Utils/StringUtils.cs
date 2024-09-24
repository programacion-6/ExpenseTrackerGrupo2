using System.Text.RegularExpressions;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Utils;
public static class StringUtils
{
    public static string ToSnakeCase(string input)
    {
        return Regex.Replace(input, "(?<!^)[A-Z]", "_$0").ToLower();
    }

}
