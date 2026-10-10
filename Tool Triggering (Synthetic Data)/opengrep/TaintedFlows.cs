// Tool Triggering (Synthetic Data) -- Opengrep
//
// PLANTED: the same three planted flows, with this folder's own copy of the rules
// EXPECTED: all 3 rules fire, matching the semgrep folder
//
// Family net472, C# 7.3. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 7.3 (it does not compile under C# 7.2).

using System;
using System.Text;

namespace OrderKit.ToolData.Opengrep
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

    /// <summary>LANGUAGE MARKER -- C# 7.3. Tuple equality. The `==` operator was
    /// not defined over tuples before this version.</summary>
    internal static class OpengrepLanguageMarker
    {
        internal static bool SameShape(string skuA, int qtyA, string skuB, int qtyB)
        {
            return (skuA, qtyA) == (skuB, qtyB);
        }
    }
}
