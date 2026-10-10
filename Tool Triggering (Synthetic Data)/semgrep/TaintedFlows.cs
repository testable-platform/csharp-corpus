// Tool Triggering (Synthetic Data) -- Semgrep
//
// PLANTED: one method per rule in this folder's rules.yml
// EXPECTED: all 3 rules fire (orderkit-tainted-query, -command, -path); 5 findings in total, because -command matches once per Append
//
// Family net46, C# 6. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 6 (it does not compile under C# 5).

using System;
using System.Text;

namespace OrderKit.ToolData.Semgrep
{

    /// <summary>One method per rule in this folder's rules.yml, written to the exact
    /// shape each pattern matches:
    ///
    ///   orderkit-tainted-query    string.Format("SELECT ...", ...)
    ///   orderkit-tainted-command  an Append inside a public static BuildCommand
    ///   orderkit-tainted-path     root.TrimEnd('/') + "/" + name
    ///
    /// The rules are matched against THIS file, so a zero result here means the
    /// scan did not run or the C# grammar did not load -- not that the code is
    /// clean. That distinction is the whole point of the fixture.</summary>
    public static class TaintedFlows
    {
        public static string BuildQuery(string sku, string tenant)
        {
            return string.Format("SELECT * FROM orders WHERE sku = '{0}' AND tenant = '{1}'",
                                 sku, tenant);
        }

        public static string BuildCommand(string verb, string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(verb);
            for (int i = 0; i < args.Length; i++)
            {
                sb.Append(" ");
                sb.Append(args[i]);
            }
            return sb.ToString();
        }

        public static string BuildReportPath(string root, string name)
        {
            return root.TrimEnd('/') + "/" + name;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 6. String interpolation, `nameof`, an
    /// expression-bodied member and an auto-property initializer. None of the four
    /// exists in C# 5.</summary>
    internal static class SemgrepLanguageMarker
    {
        internal static string Tag { get; } = "marker";

        internal static string Describe(long cents) => $"{nameof(SemgrepLanguageMarker)}:{cents}:{Tag}";
    }
}
